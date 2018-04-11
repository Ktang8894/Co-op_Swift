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
        private Label _passwordLabel;
        private Label _firstLabel;
        private Label _lastLabel;
        private Label _passLabel;
        private TextBox _firstText;
        private TextBox _lastText;
        private TextBox _userText;
        private TextBox _passText;
        private TextBox _confirmText;
        private Label _sqLabel;
        private ListBox _listBox1;
        private Label _answerLabel;
        private TextBox _answerText;
        private Button _doneButton;
        private Label _label1;
        private Button _cancelButton;
        private Label _userLabel;

        public RegForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
      this._userLabel = new System.Windows.Forms.Label();
      this._passwordLabel = new System.Windows.Forms.Label();
      this._firstLabel = new System.Windows.Forms.Label();
      this._lastLabel = new System.Windows.Forms.Label();
      this._passLabel = new System.Windows.Forms.Label();
      this._firstText = new System.Windows.Forms.TextBox();
      this._lastText = new System.Windows.Forms.TextBox();
      this._userText = new System.Windows.Forms.TextBox();
      this._passText = new System.Windows.Forms.TextBox();
      this._confirmText = new System.Windows.Forms.TextBox();
      this._sqLabel = new System.Windows.Forms.Label();
      this._listBox1 = new System.Windows.Forms.ListBox();
      this._answerLabel = new System.Windows.Forms.Label();
      this._answerText = new System.Windows.Forms.TextBox();
      this._doneButton = new System.Windows.Forms.Button();
      this._label1 = new System.Windows.Forms.Label();
      this._cancelButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // userLabel
      // 
      this._userLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._userLabel.AutoSize = true;
      this._userLabel.BackColor = System.Drawing.Color.Transparent;
      this._userLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._userLabel.ForeColor = System.Drawing.Color.White;
      this._userLabel.Location = new System.Drawing.Point(15, 115);
      this._userLabel.Name = "_userLabel";
      this._userLabel.Size = new System.Drawing.Size(174, 26);
      this._userLabel.TabIndex = 0;
      this._userLabel.Text = "Email(Username):";
      this._userLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // passwordLabel
      // 
      this._passwordLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._passwordLabel.BackColor = System.Drawing.Color.Transparent;
      this._passwordLabel.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._passwordLabel.ForeColor = System.Drawing.Color.White;
      this._passwordLabel.Location = new System.Drawing.Point(13, 177);
      this._passwordLabel.MaximumSize = new System.Drawing.Size(0, 100);
      this._passwordLabel.Name = "_passwordLabel";
      this._passwordLabel.Size = new System.Drawing.Size(176, 17);
      this._passwordLabel.TabIndex = 1;
      this._passwordLabel.Text = "Confirm Password:\r\n";
      this._passwordLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      this._passwordLabel.Click += new System.EventHandler(this.PasswordLabelClick);
      // 
      // firstLabel
      // 
      this._firstLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._firstLabel.AutoSize = true;
      this._firstLabel.BackColor = System.Drawing.Color.Transparent;
      this._firstLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._firstLabel.ForeColor = System.Drawing.Color.White;
      this._firstLabel.Location = new System.Drawing.Point(71, 52);
      this._firstLabel.Name = "_firstLabel";
      this._firstLabel.Size = new System.Drawing.Size(118, 26);
      this._firstLabel.TabIndex = 2;
      this._firstLabel.Text = "First Name:";
      this._firstLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // lastLabel
      // 
      this._lastLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._lastLabel.AutoSize = true;
      this._lastLabel.BackColor = System.Drawing.Color.Transparent;
      this._lastLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._lastLabel.ForeColor = System.Drawing.Color.White;
      this._lastLabel.Location = new System.Drawing.Point(75, 81);
      this._lastLabel.Name = "_lastLabel";
      this._lastLabel.Size = new System.Drawing.Size(114, 26);
      this._lastLabel.TabIndex = 3;
      this._lastLabel.Text = "Last Name:";
      this._lastLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // passLabel
      // 
      this._passLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._passLabel.AutoSize = true;
      this._passLabel.BackColor = System.Drawing.Color.Transparent;
      this._passLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._passLabel.ForeColor = System.Drawing.Color.White;
      this._passLabel.Location = new System.Drawing.Point(87, 143);
      this._passLabel.Name = "_passLabel";
      this._passLabel.Size = new System.Drawing.Size(102, 26);
      this._passLabel.TabIndex = 4;
      this._passLabel.Text = "Password:";
      this._passLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // firstText
      // 
      this._firstText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._firstText.Location = new System.Drawing.Point(194, 50);
      this._firstText.Name = "_firstText";
      this._firstText.Size = new System.Drawing.Size(387, 23);
      this._firstText.TabIndex = 6;
      // 
      // lastText
      // 
      this._lastText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._lastText.Location = new System.Drawing.Point(194, 84);
      this._lastText.Name = "_lastText";
      this._lastText.Size = new System.Drawing.Size(387, 23);
      this._lastText.TabIndex = 7;
      // 
      // userText
      // 
      this._userText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._userText.Location = new System.Drawing.Point(194, 114);
      this._userText.Name = "_userText";
      this._userText.Size = new System.Drawing.Size(387, 23);
      this._userText.TabIndex = 8;
      // 
      // passText
      // 
      this._passText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._passText.Location = new System.Drawing.Point(194, 143);
      this._passText.Name = "_passText";
      this._passText.Size = new System.Drawing.Size(387, 23);
      this._passText.TabIndex = 9;
      this._passText.UseSystemPasswordChar = true;
      // 
      // confirmText
      // 
      this._confirmText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._confirmText.Location = new System.Drawing.Point(194, 171);
      this._confirmText.Name = "_confirmText";
      this._confirmText.Size = new System.Drawing.Size(387, 23);
      this._confirmText.TabIndex = 10;
      this._confirmText.UseSystemPasswordChar = true;
      // 
      // sqLabel
      // 
      this._sqLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._sqLabel.BackColor = System.Drawing.Color.Transparent;
      this._sqLabel.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._sqLabel.ForeColor = System.Drawing.Color.White;
      this._sqLabel.Location = new System.Drawing.Point(20, 201);
      this._sqLabel.MaximumSize = new System.Drawing.Size(0, 110);
      this._sqLabel.Name = "_sqLabel";
      this._sqLabel.Size = new System.Drawing.Size(169, 29);
      this._sqLabel.TabIndex = 11;
      this._sqLabel.Text = "Security Question:";
      this._sqLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // listBox1
      // 
      this._listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._listBox1.FormattingEnabled = true;
      this._listBox1.ItemHeight = 20;
      this._listBox1.Items.AddRange(new object[] {
            "In what city or town does your nearest sibling live?",
            "What time of day were you born?",
            "What is the name of the first person you kissed?",
            "What is the name of your elementary/primary school?"});
      this._listBox1.Location = new System.Drawing.Point(194, 199);
      this._listBox1.Name = "_listBox1";
      this._listBox1.Size = new System.Drawing.Size(387, 24);
      this._listBox1.TabIndex = 12;
      this._listBox1.SelectedIndexChanged += new System.EventHandler(this.ListBox1SelectedIndexChanged);
      // 
      // answerLabel
      // 
      this._answerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._answerLabel.AutoSize = true;
      this._answerLabel.BackColor = System.Drawing.Color.Transparent;
      this._answerLabel.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._answerLabel.ForeColor = System.Drawing.Color.White;
      this._answerLabel.Location = new System.Drawing.Point(105, 227);
      this._answerLabel.Name = "_answerLabel";
      this._answerLabel.Size = new System.Drawing.Size(84, 26);
      this._answerLabel.TabIndex = 13;
      this._answerLabel.Text = "Answer:";
      this._answerLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
      this._answerLabel.Click += new System.EventHandler(this.AnswerLabelClick);
      // 
      // answerText
      // 
      this._answerText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._answerText.Location = new System.Drawing.Point(194, 229);
      this._answerText.Name = "_answerText";
      this._answerText.Size = new System.Drawing.Size(387, 23);
      this._answerText.TabIndex = 14;
      // 
      // doneButton
      // 
      this._doneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this._doneButton.BackColor = System.Drawing.Color.Transparent;
      this._doneButton.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._doneButton.Location = new System.Drawing.Point(357, 267);
      this._doneButton.Name = "_doneButton";
      this._doneButton.Size = new System.Drawing.Size(226, 49);
      this._doneButton.TabIndex = 15;
      this._doneButton.Text = "Register";
      this._doneButton.UseVisualStyleBackColor = false;
      this._doneButton.Click += new System.EventHandler(this.DoneButtonClick);
      // 
      // label1
      // 
      this._label1.AutoSize = true;
      this._label1.BackColor = System.Drawing.Color.Transparent;
      this._label1.Font = new System.Drawing.Font("Trebuchet MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._label1.ForeColor = System.Drawing.Color.White;
      this._label1.Location = new System.Drawing.Point(187, 9);
      this._label1.Name = "_label1";
      this._label1.Size = new System.Drawing.Size(234, 38);
      this._label1.TabIndex = 16;
      this._label1.Text = "Create Account";
      this._label1.Click += new System.EventHandler(this.Label1Click);
      // 
      // cancel_button
      // 
      this._cancelButton.BackColor = System.Drawing.Color.Transparent;
      this._cancelButton.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this._cancelButton.Location = new System.Drawing.Point(194, 267);
      this._cancelButton.Name = "_cancelButton";
      this._cancelButton.Size = new System.Drawing.Size(157, 49);
      this._cancelButton.TabIndex = 17;
      this._cancelButton.Text = "Cancel";
      this._cancelButton.UseVisualStyleBackColor = false;
      this._cancelButton.Click += new System.EventHandler(this.CancelButtonClick);
      // 
      // RegForm
      // 
      this.AcceptButton = this._doneButton;
      this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Small;
      this.ClientSize = new System.Drawing.Size(610, 338);
      this.Controls.Add(this._cancelButton);
      this.Controls.Add(this._label1);
      this.Controls.Add(this._doneButton);
      this.Controls.Add(this._answerText);
      this.Controls.Add(this._answerLabel);
      this.Controls.Add(this._listBox1);
      this.Controls.Add(this._sqLabel);
      this.Controls.Add(this._confirmText);
      this.Controls.Add(this._passText);
      this.Controls.Add(this._userText);
      this.Controls.Add(this._lastText);
      this.Controls.Add(this._firstText);
      this.Controls.Add(this._passLabel);
      this.Controls.Add(this._lastLabel);
      this.Controls.Add(this._firstLabel);
      this.Controls.Add(this._passwordLabel);
      this.Controls.Add(this._userLabel);
      this.Font = new System.Drawing.Font("Trebuchet MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Name = "RegForm";
      this.Text = "Registration";
      this.Load += new System.EventHandler(this.RegFormLoad);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

    private void RegFormLoad(object sender, EventArgs e)
        {

        }

        private void GroupBox1Enter(object sender, EventArgs e)
        {

        }

        private void QuestionViewSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListBox1SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DoneButtonClick(object sender, EventArgs e)
        {
          //check if form is finished correctly and completely
          if(Conditions.RegFormPasses(_firstText.Text,_lastText.Text,_passText.Text,_confirmText.Text,_answerText.Text))
          {
            //execute registration query
            Sql.ExecuteRegistration(_userText.Text,_passText.Text,_lastText.Text,_firstText.Text,_answerText.Text);

            this.Close();

          }
          // Initalize login credentials

        }


        private void PasswordLabelClick(object sender, EventArgs e)
        {

        }

        private void Label1Click(object sender, EventArgs e)
        {

        }

        private void CancelButtonClick(object sender, EventArgs e)
        {
          this.Close();
        }

    private void AnswerLabelClick(object sender, EventArgs e)
    {

    }
  }
}
