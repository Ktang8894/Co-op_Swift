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
    public partial class ResetForm2 : Form
    {
      string _username;
      Form _reset1;

        public ResetForm2(string name, Form frm)
        {
            InitializeComponent();
            _username = name;
            _reset1 = frm;
        }


        private void ConfirmButtonClick(object sender, EventArgs e)
        {

          if(Conditions.Resetform2Passes(passwordTextBox.Text,confirmTextBox.Text))
          {
            Sql.ExecutePasswordReset(_username,passwordTextBox.Text);

            _reset1.Close();
            this.Close();
          }
        }

    }
}
