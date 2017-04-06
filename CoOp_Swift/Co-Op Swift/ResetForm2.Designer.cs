namespace Co_Op_Swift
{
    partial class ResetForm2
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
      this.passwordTextBox = new System.Windows.Forms.TextBox();
      this.confirmTextBox = new System.Windows.Forms.TextBox();
      this.passwordLabel = new System.Windows.Forms.Label();
      this.confirmLabel = new System.Windows.Forms.Label();
      this.confirmButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // passwordTextBox
      // 
      this.passwordTextBox.Location = new System.Drawing.Point(155, 77);
      this.passwordTextBox.Name = "passwordTextBox";
      this.passwordTextBox.Size = new System.Drawing.Size(100, 20);
      this.passwordTextBox.TabIndex = 0;
      this.passwordTextBox.UseSystemPasswordChar = true;
      // 
      // confirmTextBox
      // 
      this.confirmTextBox.Location = new System.Drawing.Point(155, 113);
      this.confirmTextBox.Name = "confirmTextBox";
      this.confirmTextBox.Size = new System.Drawing.Size(100, 20);
      this.confirmTextBox.TabIndex = 1;
      this.confirmTextBox.UseSystemPasswordChar = true;
      // 
      // passwordLabel
      // 
      this.passwordLabel.AutoSize = true;
      this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.passwordLabel.Location = new System.Drawing.Point(32, 75);
      this.passwordLabel.Name = "passwordLabel";
      this.passwordLabel.Size = new System.Drawing.Size(117, 20);
      this.passwordLabel.TabIndex = 2;
      this.passwordLabel.Text = "New Password:";
      // 
      // confirmLabel
      // 
      this.confirmLabel.AutoSize = true;
      this.confirmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.confirmLabel.Location = new System.Drawing.Point(8, 111);
      this.confirmLabel.Name = "confirmLabel";
      this.confirmLabel.Size = new System.Drawing.Size(141, 20);
      this.confirmLabel.TabIndex = 3;
      this.confirmLabel.Text = "Confirm Password:";
      // 
      // confirmButton
      // 
      this.confirmButton.Location = new System.Drawing.Point(155, 149);
      this.confirmButton.Name = "confirmButton";
      this.confirmButton.Size = new System.Drawing.Size(100, 38);
      this.confirmButton.TabIndex = 4;
      this.confirmButton.Text = "Confirm";
      this.confirmButton.UseVisualStyleBackColor = true;
      this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
      // 
      // ResetForm2
      // 
      this.AcceptButton = this.confirmButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(284, 220);
      this.Controls.Add(this.confirmButton);
      this.Controls.Add(this.confirmLabel);
      this.Controls.Add(this.passwordLabel);
      this.Controls.Add(this.confirmTextBox);
      this.Controls.Add(this.passwordTextBox);
      this.Name = "ResetForm2";
      this.Text = "ResetForm2";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox confirmTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label confirmLabel;
        private System.Windows.Forms.Button confirmButton;
    }
}