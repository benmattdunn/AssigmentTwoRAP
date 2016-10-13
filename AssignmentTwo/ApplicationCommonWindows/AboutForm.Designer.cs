namespace AssignmentTwo.ApplicationCommonWindows
{
    partial class AboutForm
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.GroupBoxAbout = new System.Windows.Forms.GroupBox();
            this.AboutRichTextBox = new System.Windows.Forms.RichTextBox();
            this.GroupBoxAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(106, 227);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // GroupBoxAbout
            // 
            this.GroupBoxAbout.Controls.Add(this.AboutRichTextBox);
            this.GroupBoxAbout.Location = new System.Drawing.Point(13, 13);
            this.GroupBoxAbout.Name = "GroupBoxAbout";
            this.GroupBoxAbout.Size = new System.Drawing.Size(259, 208);
            this.GroupBoxAbout.TabIndex = 1;
            this.GroupBoxAbout.TabStop = false;
            // 
            // AboutRichTextBox
            // 
            this.AboutRichTextBox.Enabled = false;
            this.AboutRichTextBox.Location = new System.Drawing.Point(7, 20);
            this.AboutRichTextBox.Name = "AboutRichTextBox";
            this.AboutRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.AboutRichTextBox.Size = new System.Drawing.Size(246, 182);
            this.AboutRichTextBox.TabIndex = 0;
            this.AboutRichTextBox.Text = "";
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.GroupBoxAbout);
            this.Controls.Add(this.CloseButton);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About";
            this.TopMost = true;
            this.GroupBoxAbout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.GroupBox GroupBoxAbout;
        private System.Windows.Forms.RichTextBox AboutRichTextBox;
    }
}