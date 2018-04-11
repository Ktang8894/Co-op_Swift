namespace Co_Op_Swift
{
  partial class Login
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
      this.label2 = new System.Windows.Forms.Label();
      this.label4 = new System.Windows.Forms.Label();
      this.unInput = new System.Windows.Forms.TextBox();
      this.pwInput = new System.Windows.Forms.TextBox();
      this.LoginButton = new System.Windows.Forms.Button();
      this.button2 = new System.Windows.Forms.Button();
      this.button3 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.Font = new System.Drawing.Font("Trebuchet MS", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(39, 35);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(461, 42);
      this.label2.TabIndex = 1;
      this.label2.Text = "[WELCOME TO CO-OP SWIFT]";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.BackColor = System.Drawing.Color.Transparent;
      this.label4.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.Color.White;
      this.label4.Location = new System.Drawing.Point(53, 155);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(141, 36);
      this.label4.TabIndex = 3;
      this.label4.Text = "Password:";
      // 
      // unInput
      // 
      this.unInput.Location = new System.Drawing.Point(201, 113);
      this.unInput.Margin = new System.Windows.Forms.Padding(4);
      this.unInput.Name = "unInput";
      this.unInput.Size = new System.Drawing.Size(264, 22);
      this.unInput.TabIndex = 4;
      // 
      // pwInput
      // 
      this.pwInput.Location = new System.Drawing.Point(201, 161);
      this.pwInput.Margin = new System.Windows.Forms.Padding(4);
      this.pwInput.Name = "pwInput";
      this.pwInput.Size = new System.Drawing.Size(264, 22);
      this.pwInput.TabIndex = 5;
      this.pwInput.UseSystemPasswordChar = true;
      // 
      // LoginButton
      // 
      this.LoginButton.BackColor = System.Drawing.Color.Transparent;
      this.LoginButton.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.LoginButton.Location = new System.Drawing.Point(351, 212);
      this.LoginButton.Margin = new System.Windows.Forms.Padding(4);
      this.LoginButton.Name = "LoginButton";
      this.LoginButton.Size = new System.Drawing.Size(106, 56);
      this.LoginButton.TabIndex = 6;
      this.LoginButton.Text = "Login";
      this.LoginButton.UseVisualStyleBackColor = false;
      this.LoginButton.Click += new System.EventHandler(this.LoginButtonClick);
      // 
      // button2
      // 
      this.button2.BackColor = System.Drawing.Color.Transparent;
      this.button2.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button2.Location = new System.Drawing.Point(216, 212);
      this.button2.Margin = new System.Windows.Forms.Padding(4);
      this.button2.Name = "button2";
      this.button2.Size = new System.Drawing.Size(115, 56);
      this.button2.TabIndex = 7;
      this.button2.Text = "Register";
      this.button2.UseVisualStyleBackColor = false;
      this.button2.Click += new System.EventHandler(this.RegisterButtonClick);
      // 
      // button3
      // 
      this.button3.BackColor = System.Drawing.Color.Transparent;
      this.button3.Font = new System.Drawing.Font("Trebuchet MS", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button3.Location = new System.Drawing.Point(83, 212);
      this.button3.Margin = new System.Windows.Forms.Padding(4);
      this.button3.Name = "button3";
      this.button3.Size = new System.Drawing.Size(114, 56);
      this.button3.TabIndex = 8;
      this.button3.Text = "Reset Password";
      this.button3.UseVisualStyleBackColor = false;
      this.button3.Click += new System.EventHandler(this.ResetPasswordButtonClick);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Trebuchet MS", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(46, 103);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(148, 36);
      this.label1.TabIndex = 9;
      this.label1.Text = "Username:";
      // 
      // Login
      // 
      this.AcceptButton = this.LoginButton;
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.GrayText;
      this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Small;
      this.ClientSize = new System.Drawing.Size(536, 293);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button3);
      this.Controls.Add(this.button2);
      this.Controls.Add(this.LoginButton);
      this.Controls.Add(this.pwInput);
      this.Controls.Add(this.unInput);
      this.Controls.Add(this.label4);
      this.Controls.Add(this.label2);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "Login";
      this.Text = "Login";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox unInput;
    private System.Windows.Forms.TextBox pwInput;
    private System.Windows.Forms.Button LoginButton;
    private System.Windows.Forms.Button button2;
    private System.Windows.Forms.Button button3;
    private System.Windows.Forms.Label label1;
  }
}