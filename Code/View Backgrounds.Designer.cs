namespace Legacy_Order_Validator
{
    partial class View_Backgrounds
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_Backgrounds));
            label1 = new Label();
            backgroundListBox = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(200, 29);
            label1.TabIndex = 0;
            label1.Text = "Valid Backgrounds:";
            // 
            // backgroundListBox
            // 
            backgroundListBox.FormattingEnabled = true;
            backgroundListBox.ItemHeight = 29;
            backgroundListBox.Location = new Point(12, 41);
            backgroundListBox.Name = "backgroundListBox";
            backgroundListBox.Size = new Size(310, 439);
            backgroundListBox.TabIndex = 1;
            // 
            // View_Backgrounds
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(334, 492);
            Controls.Add(backgroundListBox);
            Controls.Add(label1);
            Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "View_Backgrounds";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View Backgrounds";
            Load += View_Backgrounds_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox backgroundListBox;
    }
}