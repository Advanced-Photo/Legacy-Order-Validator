namespace Legacy_Order_Validator
{
    partial class Order_Validator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order_Validator));
            excelFileButton = new Button();
            validateOrderButton = new Button();
            statusTextbox = new RichTextBox();
            clearScreenButton = new Button();
            mainMenuStrip = new MenuStrip();
            viewBackgroundsToolStripMenuItem = new ToolStripMenuItem();
            excelFileDialog = new OpenFileDialog();
            exportErrorsButton = new Button();
            viewUnitsToolStripMenuItem = new ToolStripMenuItem();
            mainMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // excelFileButton
            // 
            excelFileButton.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            excelFileButton.ForeColor = SystemColors.WindowText;
            excelFileButton.Location = new Point(12, 27);
            excelFileButton.Name = "excelFileButton";
            excelFileButton.Size = new Size(212, 37);
            excelFileButton.TabIndex = 0;
            excelFileButton.Text = "Select Excel File";
            excelFileButton.UseVisualStyleBackColor = true;
            excelFileButton.Click += ExcelFileButton_Click;
            // 
            // validateOrderButton
            // 
            validateOrderButton.Enabled = false;
            validateOrderButton.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            validateOrderButton.ForeColor = SystemColors.WindowText;
            validateOrderButton.Location = new Point(465, 27);
            validateOrderButton.Name = "validateOrderButton";
            validateOrderButton.Size = new Size(212, 37);
            validateOrderButton.TabIndex = 1;
            validateOrderButton.Text = "Validate Order";
            validateOrderButton.UseVisualStyleBackColor = true;
            validateOrderButton.Click += ValidateOrderButton_Click;
            // 
            // statusTextbox
            // 
            statusTextbox.Font = new Font("Calibri", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            statusTextbox.Location = new Point(12, 70);
            statusTextbox.Name = "statusTextbox";
            statusTextbox.ReadOnly = true;
            statusTextbox.Size = new Size(665, 451);
            statusTextbox.TabIndex = 2;
            statusTextbox.Text = "";
            // 
            // clearScreenButton
            // 
            clearScreenButton.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clearScreenButton.ForeColor = SystemColors.WindowText;
            clearScreenButton.Location = new Point(465, 527);
            clearScreenButton.Name = "clearScreenButton";
            clearScreenButton.Size = new Size(212, 37);
            clearScreenButton.TabIndex = 4;
            clearScreenButton.Text = "Clear Screen";
            clearScreenButton.UseVisualStyleBackColor = true;
            clearScreenButton.Click += ClearScreenButton_Click;
            // 
            // mainMenuStrip
            // 
            mainMenuStrip.Items.AddRange(new ToolStripItem[] { viewBackgroundsToolStripMenuItem, viewUnitsToolStripMenuItem });
            mainMenuStrip.Location = new Point(0, 0);
            mainMenuStrip.Name = "mainMenuStrip";
            mainMenuStrip.Size = new Size(689, 24);
            mainMenuStrip.TabIndex = 5;
            mainMenuStrip.Text = "menuStrip1";
            // 
            // viewBackgroundsToolStripMenuItem
            // 
            viewBackgroundsToolStripMenuItem.ForeColor = SystemColors.WindowText;
            viewBackgroundsToolStripMenuItem.Name = "viewBackgroundsToolStripMenuItem";
            viewBackgroundsToolStripMenuItem.Size = new Size(116, 20);
            viewBackgroundsToolStripMenuItem.Text = "View Backgrounds";
            viewBackgroundsToolStripMenuItem.Click += ViewBackgroundsToolStripMenuItem_Click;
            // 
            // excelFileDialog
            // 
            excelFileDialog.Filter = "Excel Files|*.xlsx";
            // 
            // exportErrorsButton
            // 
            exportErrorsButton.Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exportErrorsButton.ForeColor = SystemColors.WindowText;
            exportErrorsButton.Location = new Point(12, 527);
            exportErrorsButton.Name = "exportErrorsButton";
            exportErrorsButton.Size = new Size(212, 37);
            exportErrorsButton.TabIndex = 3;
            exportErrorsButton.Text = "Export Errors";
            exportErrorsButton.UseVisualStyleBackColor = true;
            exportErrorsButton.Visible = false;
            exportErrorsButton.Click += ExportErrorsButton_Click;
            // 
            // viewUnitsToolStripMenuItem
            // 
            viewUnitsToolStripMenuItem.ForeColor = SystemColors.ControlText;
            viewUnitsToolStripMenuItem.Name = "viewUnitsToolStripMenuItem";
            viewUnitsToolStripMenuItem.Size = new Size(74, 20);
            viewUnitsToolStripMenuItem.Text = "View Units";
            viewUnitsToolStripMenuItem.Click += ViewUnitsToolStripMenuItem_Click;
            // 
            // Order_Validator
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(689, 576);
            Controls.Add(exportErrorsButton);
            Controls.Add(clearScreenButton);
            Controls.Add(statusTextbox);
            Controls.Add(validateOrderButton);
            Controls.Add(excelFileButton);
            Controls.Add(mainMenuStrip);
            Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = mainMenuStrip;
            Margin = new Padding(4, 6, 4, 6);
            MaximizeBox = false;
            Name = "Order_Validator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Order Validator";
            Load += Order_Validator_Load;
            mainMenuStrip.ResumeLayout(false);
            mainMenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button excelFileButton;
        private Button validateOrderButton;
        private RichTextBox statusTextbox;
        private Button clearScreenButton;
        private MenuStrip mainMenuStrip;
        private ToolStripMenuItem viewBackgroundsToolStripMenuItem;
        private OpenFileDialog excelFileDialog;
        private Button exportErrorsButton;
        private ToolStripMenuItem viewUnitsToolStripMenuItem;
    }
}
