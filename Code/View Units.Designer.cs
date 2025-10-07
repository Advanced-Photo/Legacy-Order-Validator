namespace Legacy_Order_Validator
{
    partial class View_Units
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_Units));
            label1 = new Label();
            unitListBox = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(125, 29);
            label1.TabIndex = 0;
            label1.Text = "Valid Units:";
            // 
            // unitListBox
            // 
            unitListBox.FormattingEnabled = true;
            unitListBox.ItemHeight = 29;
            unitListBox.Location = new Point(12, 41);
            unitListBox.Name = "unitListBox";
            unitListBox.Size = new Size(310, 439);
            unitListBox.TabIndex = 1;
            // 
            // View_Units
            // 
            AutoScaleDimensions = new SizeF(12F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(334, 492);
            Controls.Add(unitListBox);
            Controls.Add(label1);
            Font = new Font("Calibri", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.White;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 6, 5, 6);
            MaximizeBox = false;
            Name = "View_Units";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "View Units";
            Load += View_Units_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox unitListBox;
    }
}