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
    public partial class assignRole : Form
    {
        string userName;
        string Proj;
        public assignRole(string username, string projName)
        {
            //sql to take in people who are in the same project.
            InitializeComponent();
            // SQL.getProjectMembers(memberLBox, username, projName); // I THINK THIS SQL WORKS
            SQL.getProjectMembers(memberLBox, username, projName); // I THINK THIS SQL WORKS

            userName = username;
            Proj = projName;
        }

        private void assignRole_Load(object sender, EventArgs e)
        {
            /*Console.Write("WOOWOWOW");
            if (!SQL.isOwner(userName, Proj))  // THIS SQL NEEDS TO BE DONE
            {
                
                MessageBox.Show("Not an owner. Cannot edit.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                Close();
            }*/
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(memberLBox.SelectedItem == null)
            {
                //do nothing
            }
            else {
                string s = memberLBox.GetItemText(memberLBox.SelectedItem);
                string firstname, lastname;
                string[] substrings = s.Split(' ');

                firstname = substrings[0];
                lastname = substrings[1];
                string enter = SQL.getPosition(SQL.getUserID(firstname, lastname), Proj);
            Console.Write("test:" + enter);
            roleTB.Text = enter;
                 }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sql to update the database that their roles are changed.
            if (memberLBox.SelectedItems.Count == 0)
            {
                MessageBox.Show("No user selected.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else if (roleCB.Text.Equals(""))
            {
                MessageBox.Show("No role selected.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {


                string s = memberLBox.GetItemText(memberLBox.SelectedItem);
                string firstname, lastname;
                string[] substrings = s.Split(' ');

                firstname = substrings[0];
                lastname = substrings[1];

                SQL.ExecuteChangePosition(SQL.getUserID(firstname, lastname), roleCB.Text, Proj); // I THINK THIS SQL WORKS
                roleTB.Text = roleCB.Text;
                Console.Write("works" + roleCB.Text);
            }


        }

        
    }
}
