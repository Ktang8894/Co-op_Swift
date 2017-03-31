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
    public partial class ResetForm1: Form
    {
        private Label sqLabel;
        private Label answerLabel;
        private TextBox answerText;
        private Button confirmButton;
        private Button cancelButton;
        private TextBox questionTextBox;
        private String userName;

        public ResetForm1(String user)
        {
            InitializeComponent();
            userName = user;
        }

        private void InitializeComponent()
        {
      this.sqLabel = new System.Windows.Forms.Label();
      this.answerLabel = new System.Windows.Forms.Label();
      this.answerText = new System.Windows.Forms.TextBox();
      this.confirmButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.questionTextBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // sqLabel
      // 
      this.sqLabel.AutoSize = true;
      this.sqLabel.BackColor = System.Drawing.Color.Transparent;
      this.sqLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.sqLabel.ForeColor = System.Drawing.Color.White;
      this.sqLabel.Location = new System.Drawing.Point(12, 24);
      this.sqLabel.Name = "sqLabel";
      this.sqLabel.Size = new System.Drawing.Size(147, 20);
      this.sqLabel.TabIndex = 1;
      this.sqLabel.Text = "Security Question:";
      // 
      // answerLabel
      // 
      this.answerLabel.AutoSize = true;
      this.answerLabel.BackColor = System.Drawing.Color.Transparent;
      this.answerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.answerLabel.ForeColor = System.Drawing.Color.White;
      this.answerLabel.Location = new System.Drawing.Point(89, 60);
      this.answerLabel.Name = "answerLabel";
      this.answerLabel.Size = new System.Drawing.Size(70, 20);
      this.answerLabel.TabIndex = 2;
      this.answerLabel.Text = "Answer:";
      // 
      // answerText
      // 
      this.answerText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.answerText.Location = new System.Drawing.Point(165, 54);
      this.answerText.Name = "answerText";
      this.answerText.PasswordChar = '$';
      this.answerText.Size = new System.Drawing.Size(181, 26);
      this.answerText.TabIndex = 4;
      this.answerText.UseSystemPasswordChar = true;
      // 
      // confirmButton
      // 
      this.confirmButton.BackColor = System.Drawing.Color.Transparent;
      this.confirmButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.confirmButton.Location = new System.Drawing.Point(200, 99);
      this.confirmButton.Name = "confirmButton";
      this.confirmButton.Size = new System.Drawing.Size(134, 47);
      this.confirmButton.TabIndex = 6;
      this.confirmButton.Text = "Confirm";
      this.confirmButton.UseVisualStyleBackColor = false;
      this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.BackColor = System.Drawing.Color.Transparent;
      this.cancelButton.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cancelButton.Location = new System.Drawing.Point(39, 101);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(134, 45);
      this.cancelButton.TabIndex = 7;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.UseVisualStyleBackColor = false;
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // questionTextBox
      // 
      this.questionTextBox.Enabled = false;
      this.questionTextBox.Location = new System.Drawing.Point(165, 22);
      this.questionTextBox.Name = "questionTextBox";
      this.questionTextBox.Size = new System.Drawing.Size(181, 22);
      this.questionTextBox.TabIndex = 9;
      this.questionTextBox.Text = "Insert Question";
      // 
      // ResetForm1
      // 
      this.AcceptButton = this.confirmButton;
      this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Small;
      this.ClientSize = new System.Drawing.Size(378, 169);
      this.Controls.Add(this.questionTextBox);
      this.Controls.Add(this.cancelButton);
      this.Controls.Add(this.confirmButton);
      this.Controls.Add(this.answerText);
      this.Controls.Add(this.answerLabel);
      this.Controls.Add(this.sqLabel);
      this.Name = "ResetForm1";
      this.Text = "Reset Password";
      this.Load += new System.EventHandler(this.ResetForm1_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {

          //use SQL to find if the answer given matches sql
          Boolean isTrue = SQL.checkAnswerWithDatabase(userName,answerText.Text);

            if(isTrue)
            {
                FormCollection fc = Application.OpenForms;
                bool FormFound = false;
                foreach (Form frm in fc)
                {
                    if (frm.Name == "ResetForm2")
                    {
                        frm.Focus();
                        FormFound = true;
                        this.Hide();
                    }
                }

                if (FormFound == false)
                {
                    ResetForm2 form = new ResetForm2(userName,this);
                    form.ShowDialog();
                }
            }
            else
            {
              MessageBox.Show("Your answer does not match the one on file. Please try again.", "Password Mismatch", 
                                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }



        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetForm1_Load(object sender, EventArgs e)
        {
          //load user's security question into 'question' textbox on the form
          SQL.loadUserSecurityQuestion(userName, questionTextBox);
        }
    }
}
