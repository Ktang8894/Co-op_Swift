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
      string username;
      Form reset1;

        public ResetForm2(string name, Form frm)
        {
            InitializeComponent();
            username = name;
            reset1 = frm;
        }


        private void confirmButton_Click(object sender, EventArgs e)
        {

          if(Conditions.resetform2Passes(passwordTextBox.Text,confirmTextBox.Text))
          {
            Sql.ExecutePasswordReset(username,passwordTextBox.Text);

            reset1.Close();
            this.Close();
          }
        }

    }
}
