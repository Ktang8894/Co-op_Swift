using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Co_Op_Swift
{
    public partial class Story : Form
    {
        string UN, pn;
        public Story(string username,string proj)
        {
            UN = username;
            pn = proj;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SQL.ExecuteStory(UN, nameTB.Text, descTB.Text);
            string name = nameTB.Text;
            SQL.acceptStory(pn, name);
            this.Close();
        }
    }
}
