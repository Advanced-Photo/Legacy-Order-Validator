using Ganss.Excel;

namespace Legacy_Order_Validator
{
    public partial class Order_Validator : Form
    {
        private List<string> Backgrounds = [];
        private List<string> Units = [];
        private List<Order> Orders = [];
        private List<string> ImageFiles = [];
        private readonly List<KeyValuePair<string, List<string>>> StudentsWithErrors = [];

        public Order_Validator()
        {
            InitializeComponent();
        }

        private void DisableForm()
        {
            excelFileButton.Enabled = false;
            exportErrorsButton.Enabled = false;
            clearScreenButton.Enabled = false;
            mainMenuStrip.Enabled = false;
        }

        private void EnableForm()
        {
            excelFileButton.Enabled = true;
            exportErrorsButton.Enabled = true;
            clearScreenButton.Enabled = true;
            mainMenuStrip.Enabled = true;
        }

        private void ClearForm()
        {
            // clear global variables and status textbox
            Orders.Clear();
            ImageFiles.Clear();
            StudentsWithErrors.Clear();
            statusTextbox.Clear();

            // disable 'Validate Order' button and hide the 'Export Errors' button
            validateOrderButton.Enabled = false;
            exportErrorsButton.Visible = false;
        }

        private void UpdateStatusTextbox(string value)
        {
            try
            {
                // check if invoke is required
                if (statusTextbox.InvokeRequired)
                {
                    statusTextbox.Invoke(new Action(() => UpdateStatusTextbox(value)));
                    return;
                }

                // update the status textbox and scroll to the bottom
                statusTextbox.Text += value;
                statusTextbox.SelectionStart = statusTextbox.Text.Length;
                statusTextbox.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the status textbox:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void Order_Validator_Load(object sender, EventArgs e)
        {
            // check that the background text file exists
            string backgroundFile = Path.Combine(Application.StartupPath, "Backgrounds.txt");
            if (!File.Exists(backgroundFile))
            {
                MessageBox.Show($"Unable to locate Backgrounds.txt.\n\nExpected Path:\n{backgroundFile}", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enabled = false;
                return;
            }

            // check that the units text file exists
            string unitsFile = Path.Combine(Application.StartupPath, "Units.txt");
            if (!File.Exists(unitsFile))
            {
                MessageBox.Show($"Unable to locate Units.txt.\n\nExpected Path:\n{unitsFile}", "Missing File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Enabled = false;
                return;
            }

            // load backgrounds and units into lists
            Backgrounds = [.. await File.ReadAllLinesAsync(backgroundFile)];
            Units = [.. await File.ReadAllLinesAsync(unitsFile)];
        }

        private void ExcelFileButton_Click(object sender, EventArgs e)
        {
            // prompt user to select an Excel file
            ClearForm();
            if (excelFileDialog.ShowDialog() == DialogResult.OK)
            {
                // disable the form while we work
                DisableForm();
                string excelFileDirectory = Path.GetDirectoryName(excelFileDialog.FileName)!;
                string excelFileName = Path.GetFileName(excelFileDialog.FileName);

                try
                {
                    // map records to a list of objects
                    UpdateStatusTextbox($"Loading file '{excelFileName}'...\n");
                    Orders = [.. new ExcelMapper(excelFileDialog.FileName).Fetch<Order>()];
                    Orders.RemoveAll(order => string.IsNullOrEmpty(order.PurchaseDate));
                    UpdateStatusTextbox($"Successfully loaded {Orders.Count} order records from file.\n");
                }
                catch (Exception ex)
                {
                    UpdateStatusTextbox($"An error occurred while loading the file:\n\n{ex.Message}");
                    EnableForm();
                    return;
                }

                try
                {
                    // gather JPEG and PNG images in the same directory as the Excel file
                    UpdateStatusTextbox($"Searching for images...\n");
                    List<string> jpegFiles = [.. Directory.GetFiles(excelFileDirectory, "*.jpg", SearchOption.AllDirectories)];
                    List<string> pngFiles = [.. Directory.GetFiles(excelFileDirectory, "*.png", SearchOption.AllDirectories)];
                    ImageFiles.AddRange(jpegFiles);
                    ImageFiles.AddRange(pngFiles);
                    ImageFiles = [.. ImageFiles.OrderBy(file => file)];
                    UpdateStatusTextbox($"Found {ImageFiles.Count} images.\n");
                    UpdateStatusTextbox("Click the 'Validate Order' button to begin.\n\n");
                }
                catch (Exception ex)
                {
                    UpdateStatusTextbox($"An error occurred while searching for images:\n\n{ex.Message}");
                    EnableForm();
                    return;
                }

                // work finished, re-enable the form
                EnableForm();
                validateOrderButton.Enabled = true;
            }
        }

        private void ValidateOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                // disable the form while we work
                DisableForm();
                validateOrderButton.Enabled = false;

                // begin validating each record
                UpdateStatusTextbox("Validating...\n\n");
                foreach (Order order in Orders)
                {
                    // setup if error occurs
                    List<string> errorMessages = [];

                    // Step 1. Check Image File Exists
                    bool imageExists = ImageFiles.Any(file => Path.GetFileNameWithoutExtension(file) == order.ImageName.Trim());
                    if (!imageExists)
                        errorMessages.Add($"\tImage Not Found: {order.ImageName}");

                    // Step 2. Validate Background
                    string[] backgroundAndSizes = order.BackgroundAndSizes.Split('/', StringSplitOptions.RemoveEmptyEntries);
                    string background = backgroundAndSizes[0].Trim();
                    string units = backgroundAndSizes.Length == 2 ? backgroundAndSizes[1].Trim() : string.Empty;
                    bool backgroundExists = Backgrounds.Any(bkg => bkg.Equals(background, StringComparison.CurrentCultureIgnoreCase));
                    if (!backgroundExists)
                        errorMessages.Add($"\tInvalid Background: {background}");

                    // Step 3. Validate Units Exist
                    // check if Product Title contains either 'BYO' or 'A La Carte'
                    if (order.ProductTitle.Contains("BYO", StringComparison.CurrentCultureIgnoreCase) || order.ProductTitle.Contains("A La Carte", StringComparison.CurrentCultureIgnoreCase))
                    {
                        // if Product Title does not contain 'Classic' and there is no / in Background & Sizes, error
                        if (!order.ProductTitle.Contains("Classic", StringComparison.CurrentCultureIgnoreCase) && string.IsNullOrEmpty(units))
                            errorMessages.Add("\tMissing Units in the Background & Sizes Column");
                    }

                    // Step 4. Validate Units Value
                    if (!string.IsNullOrEmpty(units))
                    {
                        bool unitsValid = Units.Any(u => u.Equals(units, StringComparison.CurrentCultureIgnoreCase));
                        if (!unitsValid)
                            errorMessages.Add($"\tInvalid Units: {units}");
                    }

                    // check if there were any errors
                    if (errorMessages.Count > 0)
                    {
                        // update the status textbox
                        int excelRow = Orders.IndexOf(order) + 2;
                        string key = $"{order.FirstName.Trim()} {order.LastName.Trim()} {order.OrderID?.Trim()}".Trim();
                        string errorMessage = string.Join('\n', errorMessages);
                        UpdateStatusTextbox($"Row {excelRow}: {key}\n{errorMessage}\n");

                        // check if student already has errors
                        KeyValuePair<string, List<string>> studentWithError = StudentsWithErrors.Find(pair => pair.Key == key);
                        if (studentWithError.Key != null)
                        {
                            // update error messages and remove student from list
                            errorMessages.AddRange(studentWithError.Value);
                            errorMessages = [.. errorMessages.Distinct()];
                            StudentsWithErrors.Remove(studentWithError);
                        }

                        // add student with error to the list
                        studentWithError = new(key, errorMessages);
                        StudentsWithErrors.Add(studentWithError);
                    }
                }

                // show that validation is complete and re-enable the form
                UpdateStatusTextbox("\nValidation completed.\n\n");
                EnableForm();

                // show the 'Export Errors' button if there are students with errors
                if (StudentsWithErrors.Count > 0)
                {
                    exportErrorsButton.Visible = true;

                    string message = $"There were {StudentsWithErrors.Count} students that are invalid.";
                    if (StudentsWithErrors.Count == 1)
                        message = "There was 1 student that is invalid.";

                    UpdateStatusTextbox($"{message}\n");
                    UpdateStatusTextbox("Click the 'Export Errors' button to generate a log file with a summary of errors.");
                }
                else
                    UpdateStatusTextbox("No errors were found in the file.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while validating the Excel file:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportErrorsButton_Click(object sender, EventArgs e)
        {
            // disable the form while we work
            DisableForm();

            // log file setup
            int missingImageCount = 0;
            int invalidBackgroundCount = 0;
            int missingUnitsCount = 0;
            int invalidUnitsCount = 0;
            string logFileContent = string.Empty;

            // loop through Students With Errors list
            foreach (KeyValuePair<string, List<string>> pair in StudentsWithErrors)
            {
                // add error counts
                missingImageCount += pair.Value.Count(err => err.StartsWith("\tImage Not Found"));
                invalidBackgroundCount += pair.Value.Count(err => err.StartsWith("\tInvalid Background"));
                missingUnitsCount += pair.Value.Count(err => err.StartsWith("\tMissing Units"));
                invalidUnitsCount += pair.Value.Count(err => err.StartsWith("\tInvalid Units"));

                // add to log text
                string errorMessage = string.Join('\n', pair.Value);
                logFileContent += $"\n{pair.Key}\n{errorMessage}";
            }

            // generate log file text
            string logText = $"Summary of Errors\n\n";
            if (missingImageCount > 0)
                logText += $"{missingImageCount} order(s) with missing images.\n";
            if (invalidBackgroundCount > 0)
                logText += $"{invalidBackgroundCount} order(s) with invalid backgrounds.\n";
            if (missingUnitsCount > 0)
                logText += $"{missingUnitsCount} order(s) with missing units.\n";
            if (invalidUnitsCount > 0)
                logText += $"{invalidUnitsCount} order(s) with invalid units.\n";
            logText += $"\nError Details\n{logFileContent}";

            try
            {
                // create log file
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string logFileName = $"{Path.GetFileNameWithoutExtension(excelFileDialog.FileName)}.log";
                string logFile = Path.Combine(desktopPath, logFileName);
                File.WriteAllText(logFile, logText);
                MessageBox.Show($"Successfully created '{logFileName}' on your desktop!", "Log File Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the log file:\n\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // re-enable the form
            EnableForm();
        }

        private void ClearScreenButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ViewBackgroundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? openForm = Application.OpenForms["View_Backgrounds"];
            if (openForm == null)
            {
                View_Backgrounds viewBackgrounds = new(Backgrounds);
                viewBackgrounds.Show();
            }
            else
            {
                openForm.WindowState = FormWindowState.Normal;
                openForm.BringToFront();
            }
        }

        private void ViewUnitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form? openForm = Application.OpenForms["View_Units"];
            if (openForm == null)
            {
                View_Units viewUnits = new(Units);
                viewUnits.Show();
            }
            else
            {
                openForm.WindowState = FormWindowState.Normal;
                openForm.BringToFront();
            }
        }
    }
}
