using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Co_Op_Swift
{
    public partial class SecurityQuestion: Form
    {
        private Label _sqLabel;
        private Label _answerLabel;
        private TextBox _answerText;
        private Button _confirmButton;
        private Button _cancelButton;
        private TextBox _questionTextBox;
        private string _userName;

        public SecurityQuestion(string user)
        {
            InitializeComponent();
            _userName = user;
        }

        private void InitializeComponent()
        {
      this._sqLabel = new System.Windows.Forms.Label();
      this._answerLabel = new System.Windows.Forms.Label();
      this._answerText = new System.Windows.Forms.TextBox();
      this._confirmButton = new System.Windows.Forms.Button();
      this._cancelButton = new System.Windows.Forms.Button();
      this._questionTextBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // sqLabel
      // 
      this._sqLabel.AutoSize = true;
      this._sqLabel.BackColor = System.Drawing.Color.Transparent;
      this._sqLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._sqLabel.ForeColor = System.Drawing.Color.White;
      this._sqLabel.Location = new System.Drawing.Point(12, 24);
      this._sqLabel.Name = "_sqLabel";
      this._sqLabel.Size = new System.Drawing.Size(147, 20);
      this._sqLabel.TabIndex = 1;
      this._sqLabel.Text = "Security Question:";
      // 
      // answerLabel
      // 
      this._answerLabel.AutoSize = true;
      this._answerLabel.BackColor = System.Drawing.Color.Transparent;
      this._answerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._answerLabel.ForeColor = System.Drawing.Color.White;
      this._answerLabel.Location = new System.Drawing.Point(89, 60);
      this._answerLabel.Name = "_answerLabel";
      this._answerLabel.Size = new System.Drawing.Size(70, 20);
      this._answerLabel.TabIndex = 2;
      this._answerLabel.Text = "Answer:";
      // 
      // answerText
      // 
      this._answerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._answerText.Location = new System.Drawing.Point(165, 54);
      this._answerText.Name = "_answerText";
      this._answerText.PasswordChar = '$';
      this._answerText.Size = new System.Drawing.Size(181, 26);
      this._answerText.TabIndex = 4;
      this._answerText.UseSystemPasswordChar = true;
      // 
      // confirmButton
      // 
      this._confirmButton.BackColor = System.Drawing.Color.Transparent;
      this._confirmButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._confirmButton.Location = new System.Drawing.Point(200, 99);
      this._confirmButton.Name = "_confirmButton";
      this._confirmButton.Size = new System.Drawing.Size(134, 47);
      this._confirmButton.TabIndex = 6;
      this._confirmButton.Text = "Confirm";
      this._confirmButton.UseVisualStyleBackColor = false;
      this._confirmButton.Click += new System.EventHandler(this.ConfirmButtonClick);
      // 
      // cancelButton
      // 
      this._cancelButton.BackColor = System.Drawing.Color.Transparent;
      this._cancelButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._cancelButton.Location = new System.Drawing.Point(39, 101);
      this._cancelButton.Name = "_cancelButton";
      this._cancelButton.Size = new System.Drawing.Size(134, 45);
      this._cancelButton.TabIndex = 7;
      this._cancelButton.Text = "Cancel";
      this._cancelButton.UseVisualStyleBackColor = false;
      this._cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
      // 
      // questionTextBox
      // 
      this._questionTextBox.Enabled = false;
      this._questionTextBox.Location = new System.Drawing.Point(165, 22);
      this._questionTextBox.Name = "_questionTextBox";
      this._questionTextBox.Size = new System.Drawing.Size(181, 22);
      this._questionTextBox.TabIndex = 9;
      this._questionTextBox.Text = "Insert Question";
      // 
      // ResetForm1
      // 
      this.AcceptButton = this._confirmButton;
      this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Small;
      this.ClientSize = new System.Drawing.Size(378, 169);
      this.Controls.Add(this._questionTextBox);
      this.Controls.Add(this._cancelButton);
      this.Controls.Add(this._confirmButton);
      this.Controls.Add(this._answerText);
      this.Controls.Add(this._answerLabel);
      this.Controls.Add(this._sqLabel);
      this.Name = "ResetForm1";
      this.Text = "Reset Password";
      this.Load += new System.EventHandler(this.ResetForm1Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        private void Label1Click(object sender, EventArgs e)
        {

        }

        private void ConfirmButtonClick(object sender, EventArgs e)
        {

          //use SQL to find if the answer given matches sql
          bool isTrue = Sql.CheckAnswerWithDatabase(_userName,_answerText.Text);

            if(isTrue)
            {
                FormCollection fc = Application.OpenForms;
                bool formFound = false;
                foreach (Form frm in fc)
                {
                    if (frm.Name == "ResetForm2")
                    {
                        frm.Focus();
                        formFound = true;
                        this.Hide();
                    }
                }

                if (formFound == false)
                {
                    ResetForm2 form = new ResetForm2(_userName,this);
                    form.ShowDialog();
                }
            }
            else
            {
              MessageBox.Show("Your answer does not match the one on file. Please try again.", "Password Mismatch", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }



        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetForm1Load(object sender, EventArgs e)
        {
          //load user's security question into 'question' textbox on the form
          Sql.LoadUserSecurityQuestion(_userName, _questionTextBox);
        }
    }
}
