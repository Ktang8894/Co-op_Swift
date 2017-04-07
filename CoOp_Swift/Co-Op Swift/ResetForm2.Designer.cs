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
      this.passwordTextBox.Location = new System.Drawing.Point(193, 21);
      this.passwordTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.passwordTextBox.Name = "passwordTextBox";
      this.passwordTextBox.Size = new System.Drawing.Size(116, 23);
      this.passwordTextBox.TabIndex = 0;
      this.passwordTextBox.UseSystemPasswordChar = true;
      // 
      // confirmTextBox
      // 
      this.confirmTextBox.Location = new System.Drawing.Point(193, 56);
      this.confirmTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.confirmTextBox.Name = "confirmTextBox";
      this.confirmTextBox.Size = new System.Drawing.Size(116, 23);
      this.confirmTextBox.TabIndex = 1;
      this.confirmTextBox.UseSystemPasswordChar = true;
      // 
      // passwordLabel
      // 
      this.passwordLabel.AutoSize = true;
      this.passwordLabel.BackColor = System.Drawing.Color.Transparent;
      this.passwordLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.passwordLabel.ForeColor = System.Drawing.Color.White;
      this.passwordLabel.Location = new System.Drawing.Point(41, 18);
      this.passwordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.passwordLabel.Name = "passwordLabel";
      this.passwordLabel.Size = new System.Drawing.Size(147, 26);
      this.passwordLabel.TabIndex = 2;
      this.passwordLabel.Text = "New Password:";
      // 
      // confirmLabel
      // 
      this.confirmLabel.AutoSize = true;
      this.confirmLabel.BackColor = System.Drawing.Color.Transparent;
      this.confirmLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.confirmLabel.ForeColor = System.Drawing.Color.White;
      this.confirmLabel.Location = new System.Drawing.Point(13, 54);
      this.confirmLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.confirmLabel.Name = "confirmLabel";
      this.confirmLabel.Size = new System.Drawing.Size(180, 26);
      this.confirmLabel.TabIndex = 3;
      this.confirmLabel.Text = "Confirm Password:";
      // 
      // confirmButton
      // 
      this.confirmButton.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.confirmButton.Location = new System.Drawing.Point(18, 94);
      this.confirmButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.confirmButton.Name = "confirmButton";
      this.confirmButton.Size = new System.Drawing.Size(291, 32);
      this.confirmButton.TabIndex = 4;
      this.confirmButton.Text = "Confirm";
      this.confirmButton.UseVisualStyleBackColor = true;
      this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
      // 
      // ResetForm2
      // 
      this.AcceptButton = this.confirmButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 18F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.Control;
      this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Small1;
      this.ClientSize = new System.Drawing.Size(332, 145);
      this.Controls.Add(this.confirmButton);
      this.Controls.Add(this.confirmLabel);
      this.Controls.Add(this.passwordLabel);
      this.Controls.Add(this.confirmTextBox);
      this.Controls.Add(this.passwordTextBox);
      this.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.ForeColor = System.Drawing.SystemColors.ControlText;
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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