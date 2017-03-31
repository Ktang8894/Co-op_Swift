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
    public partial class RegForm : Form
    {
        private Label passwordLabel;
        private Label firstLabel;
        private Label lastLabel;
        private Label passLabel;
        private TextBox firstText;
        private TextBox lastText;
        private TextBox userText;
        private TextBox passText;
        private TextBox confirmText;
        private Label sqLabel;
        private ListBox listBox1;
        private Label answerLabel;
        private TextBox answerText;
        private Button doneButton;
        private Label label1;
        private Button cancel_button;
        private Label userLabel;

        public RegForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
      this.userLabel = new System.Windows.Forms.Label();
      this.passwordLabel = new System.Windows.Forms.Label();
      this.firstLabel = new System.Windows.Forms.Label();
      this.lastLabel = new System.Windows.Forms.Label();
      this.passLabel = new System.Windows.Forms.Label();
      this.firstText = new System.Windows.Forms.TextBox();
      this.lastText = new System.Windows.Forms.TextBox();
      this.userText = new System.Windows.Forms.TextBox();
      this.passText = new System.Windows.Forms.TextBox();
      this.confirmText = new System.Windows.Forms.TextBox();
      this.sqLabel = new System.Windows.Forms.Label();
      this.listBox1 = new System.Windows.Forms.ListBox();
      this.answerLabel = new System.Windows.Forms.Label();
      this.answerText = new System.Windows.Forms.TextBox();
      this.doneButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.cancel_button = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // userLabel
      // 
      this.userLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.userLabel.AutoSize = true;
      this.userLabel.BackColor = System.Drawing.Color.Transparent;
      this.userLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.userLabel.ForeColor = System.Drawing.Color.White;
      this.userLabel.Location = new System.Drawing.Point(15, 115);
      this.userLabel.Name = "userLabel";
      this.userLabel.Size = new System.Drawing.Size(174, 26);
      this.userLabel.TabIndex = 0;
      this.userLabel.Text = "Email(Username):";
      this.userLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // passwordLabel
      // 
      this.passwordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.passwordLabel.BackColor = System.Drawing.Color.Transparent;
      this.passwordLabel.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.passwordLabel.ForeColor = System.Drawing.Color.White;
      this.passwordLabel.Location = new System.Drawing.Point(11, 175);
      this.passwordLabel.MaximumSize = new System.Drawing.Size(0, 100);
      this.passwordLabel.Name = "passwordLabel";
      this.passwordLabel.Size = new System.Drawing.Size(178, 17);
      this.passwordLabel.TabIndex = 1;
      this.passwordLabel.Text = "Confirm Password:\r\n";
      this.passwordLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      this.passwordLabel.Click += new System.EventHandler(this.passwordLabel_Click);
      // 
      // firstLabel
      // 
      this.firstLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.firstLabel.AutoSize = true;
      this.firstLabel.BackColor = System.Drawing.Color.Transparent;
      this.firstLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.firstLabel.ForeColor = System.Drawing.Color.White;
      this.firstLabel.Location = new System.Drawing.Point(71, 52);
      this.firstLabel.Name = "firstLabel";
      this.firstLabel.Size = new System.Drawing.Size(118, 26);
      this.firstLabel.TabIndex = 2;
      this.firstLabel.Text = "First Name:";
      this.firstLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // lastLabel
      // 
      this.lastLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lastLabel.AutoSize = true;
      this.lastLabel.BackColor = System.Drawing.Color.Transparent;
      this.lastLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lastLabel.ForeColor = System.Drawing.Color.White;
      this.lastLabel.Location = new System.Drawing.Point(75, 81);
      this.lastLabel.Name = "lastLabel";
      this.lastLabel.Size = new System.Drawing.Size(114, 26);
      this.lastLabel.TabIndex = 3;
      this.lastLabel.Text = "Last Name:";
      this.lastLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // passLabel
      // 
      this.passLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.passLabel.AutoSize = true;
      this.passLabel.BackColor = System.Drawing.Color.Transparent;
      this.passLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.passLabel.ForeColor = System.Drawing.Color.White;
      this.passLabel.Location = new System.Drawing.Point(87, 143);
      this.passLabel.Name = "passLabel";
      this.passLabel.Size = new System.Drawing.Size(102, 26);
      this.passLabel.TabIndex = 4;
      this.passLabel.Text = "Password:";
      this.passLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // firstText
      // 
      this.firstText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.firstText.Location = new System.Drawing.Point(194, 50);
      this.firstText.Name = "firstText";
      this.firstText.Size = new System.Drawing.Size(302, 23);
      this.firstText.TabIndex = 6;
      // 
      // lastText
      // 
      this.lastText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.lastText.Location = new System.Drawing.Point(194, 84);
      this.lastText.Name = "lastText";
      this.lastText.Size = new System.Drawing.Size(302, 23);
      this.lastText.TabIndex = 7;
      // 
      // userText
      // 
      this.userText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.userText.Location = new System.Drawing.Point(194, 114);
      this.userText.Name = "userText";
      this.userText.Size = new System.Drawing.Size(302, 23);
      this.userText.TabIndex = 8;
      // 
      // passText
      // 
      this.passText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.passText.Location = new System.Drawing.Point(194, 143);
      this.passText.Name = "passText";
      this.passText.Size = new System.Drawing.Size(302, 23);
      this.passText.TabIndex = 9;
      this.passText.UseSystemPasswordChar = true;
      // 
      // confirmText
      // 
      this.confirmText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.confirmText.Location = new System.Drawing.Point(194, 171);
      this.confirmText.Name = "confirmText";
      this.confirmText.Size = new System.Drawing.Size(302, 23);
      this.confirmText.TabIndex = 10;
      this.confirmText.UseSystemPasswordChar = true;
      // 
      // sqLabel
      // 
      this.sqLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.sqLabel.BackColor = System.Drawing.Color.Transparent;
      this.sqLabel.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.sqLabel.ForeColor = System.Drawing.Color.White;
      this.sqLabel.Location = new System.Drawing.Point(16, 201);
      this.sqLabel.MaximumSize = new System.Drawing.Size(0, 110);
      this.sqLabel.Name = "sqLabel";
      this.sqLabel.Size = new System.Drawing.Size(173, 29);
      this.sqLabel.TabIndex = 11;
      this.sqLabel.Text = "Security Question:";
      this.sqLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // listBox1
      // 
      this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.listBox1.FormattingEnabled = true;
      this.listBox1.ItemHeight = 20;
      this.listBox1.Items.AddRange(new object[] {
            "In what city or town does your nearest sibling live?",
            "What time of day were you born?",
            "What is the name of the first person you kissed?",
            "What is the name of your elementary/primary school?"});
      this.listBox1.Location = new System.Drawing.Point(194, 199);
      this.listBox1.Name = "listBox1";
      this.listBox1.Size = new System.Drawing.Size(302, 24);
      this.listBox1.TabIndex = 12;
      this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
      // 
      // answerLabel
      // 
      this.answerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.answerLabel.AutoSize = true;
      this.answerLabel.BackColor = System.Drawing.Color.Transparent;
      this.answerLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.answerLabel.ForeColor = System.Drawing.Color.White;
      this.answerLabel.Location = new System.Drawing.Point(105, 227);
      this.answerLabel.Name = "answerLabel";
      this.answerLabel.Size = new System.Drawing.Size(84, 26);
      this.answerLabel.TabIndex = 13;
      this.answerLabel.Text = "Answer:";
      this.answerLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      this.answerLabel.Click += new System.EventHandler(this.answerLabel_Click);
      // 
      // answerText
      // 
      this.answerText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.answerText.Location = new System.Drawing.Point(194, 229);
      this.answerText.Name = "answerText";
      this.answerText.Size = new System.Drawing.Size(302, 23);
      this.answerText.TabIndex = 14;
      // 
      // doneButton
      // 
      this.doneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.doneButton.BackColor = System.Drawing.Color.Transparent;
      this.doneButton.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.doneButton.Location = new System.Drawing.Point(273, 270);
      this.doneButton.Name = "doneButton";
      this.doneButton.Size = new System.Drawing.Size(138, 49);
      this.doneButton.TabIndex = 15;
      this.doneButton.Text = "Register";
      this.doneButton.UseVisualStyleBackColor = false;
      this.doneButton.Click += new System.EventHandler(this.doneButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(149, 9);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(234, 38);
      this.label1.TabIndex = 16;
      this.label1.Text = "Create Account";
      this.label1.Click += new System.EventHandler(this.label1_Click);
      // 
      // cancel_button
      // 
      this.cancel_button.BackColor = System.Drawing.Color.Transparent;
      this.cancel_button.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.cancel_button.Location = new System.Drawing.Point(106, 270);
      this.cancel_button.Name = "cancel_button";
      this.cancel_button.Size = new System.Drawing.Size(139, 49);
      this.cancel_button.TabIndex = 17;
      this.cancel_button.Text = "Cancel";
      this.cancel_button.UseVisualStyleBackColor = false;
      this.cancel_button.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // RegForm
      // 
      this.AcceptButton = this.doneButton;
      this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Small;
      this.ClientSize = new System.Drawing.Size(525, 338);
      this.Controls.Add(this.cancel_button);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.doneButton);
      this.Controls.Add(this.answerText);
      this.Controls.Add(this.answerLabel);
      this.Controls.Add(this.listBox1);
      this.Controls.Add(this.sqLabel);
      this.Controls.Add(this.confirmText);
      this.Controls.Add(this.passText);
      this.Controls.Add(this.userText);
      this.Controls.Add(this.lastText);
      this.Controls.Add(this.firstText);
      this.Controls.Add(this.passLabel);
      this.Controls.Add(this.lastLabel);
      this.Controls.Add(this.firstLabel);
      this.Controls.Add(this.passwordLabel);
      this.Controls.Add(this.userLabel);
      this.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Name = "RegForm";
      this.Text = "Registration";
      this.Load += new System.EventHandler(this.RegForm_Load);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

    private void RegForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void questionView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void doneButton_Click(object sender, EventArgs e)
        {
          //check if form is finished correctly and completely
          if(Conditions.regFormPasses(firstText.Text,lastText.Text,passText.Text,confirmText.Text,answerText.Text))
          {
            //execute registration query
            SQL.ExecuteRegistration(userText.Text,passText.Text,lastText.Text,firstText.Text,answerText.Text);

            this.Close();

          }
          // Initalize login credentials

        }


        private void passwordLabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
          this.Close();
        }

    private void answerLabel_Click(object sender, EventArgs e)
    {

    }
  }
}
