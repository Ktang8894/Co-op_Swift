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
        string _un, _pn;
        public Story(string username,string proj)
        {
            _un = username;
            _pn = proj;
            InitializeComponent();
        }

        private void Button1Click(object sender, EventArgs e)
        {
            Sql.ExecuteStory(_un, nameTB.Text, descTB.Text);
            string name = nameTB.Text;
            Sql.AcceptStory(_pn, name);
            this.Close();
        }
    }
}
