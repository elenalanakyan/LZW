namespace LZW
{
    partial class LZW
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
            this.encodeButton = new System.Windows.Forms.Button();
            this.decodeButton = new System.Windows.Forms.Button();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.SelectFileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // encodeButton
            // 
            this.encodeButton.Location = new System.Drawing.Point(23, 66);
            this.encodeButton.Name = "encodeButton";
            this.encodeButton.Size = new System.Drawing.Size(153, 29);
            this.encodeButton.TabIndex = 0;
            this.encodeButton.Text = "Закодировать файл";
            this.encodeButton.UseVisualStyleBackColor = true;
            this.encodeButton.Click += new System.EventHandler(this.encodeButton_Click);
            // 
            // decodeButton
            // 
            this.decodeButton.Location = new System.Drawing.Point(191, 66);
            this.decodeButton.Name = "decodeButton";
            this.decodeButton.Size = new System.Drawing.Size(157, 29);
            this.decodeButton.TabIndex = 1;
            this.decodeButton.Text = "Декодировать файл";
            this.decodeButton.UseVisualStyleBackColor = true;
            this.decodeButton.Click += new System.EventHandler(this.decodeButton_Click);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(23, 23);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.ReadOnly = true;
            this.filePathTextBox.Size = new System.Drawing.Size(210, 27);
            this.filePathTextBox.TabIndex = 2;
            // 
            // SelectFileButton
            // 
            this.SelectFileButton.Location = new System.Drawing.Point(254, 23);
            this.SelectFileButton.Name = "SelectFileButton";
            this.SelectFileButton.Size = new System.Drawing.Size(94, 29);
            this.SelectFileButton.TabIndex = 3;
            this.SelectFileButton.Text = "...";
            this.SelectFileButton.UseVisualStyleBackColor = true;
            this.SelectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // LZW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 124);
            this.Controls.Add(this.SelectFileButton);
            this.Controls.Add(this.filePathTextBox);
            this.Controls.Add(this.decodeButton);
            this.Controls.Add(this.encodeButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LZW";
            this.Text = "LZW";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button encodeButton;
        private System.Windows.Forms.Button decodeButton;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Button SelectFileButton;
    }
}
