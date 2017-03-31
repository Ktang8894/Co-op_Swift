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
  public partial class ideaBox : Form
  {
    string userName, pn;
    public ideaBox(String username, String projectName)
    {
        InitializeComponent();
        SQL.getStories(storyLB, username, SQL.getProjectID(projectName));
        projectNameToolStripMenuItem.Text = projectName;
        pn = projectName;
        userName = username;
        memberNameToolStripMenuItem.Text = username;
        ideaBoxToolStripMenuItem.Font = new Font(ideaBoxToolStripMenuItem.Font, FontStyle.Bold);

        /***************************** this is for select a project drop down menu **********************************/

        //get all project ids associated with the user ids
        DataTable proj_ids = SQL.getUserProjectIDs(SQL.getOwnerUserID(memberNameToolStripMenuItem.Text));

        string proj_name;

        // get all project names associated with the project ids
        foreach (DataRow row in proj_ids.Rows)
        {
          //put project names in select project drop down menu
          proj_name = SQL.getProjectName(int.Parse(row["Proj_ID"].ToString()));
          selectProjectToolStripMenuItem.DropDownItems.Add(proj_name);
        }
      /*************************************************************************************************************/
    
    }


    private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Dashboard frm = new Dashboard(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void taskTreeToolStripMenuItem_Click(object sender, EventArgs e)
    {
      taskTree frm = new taskTree(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void releasePlanToolStripMenuItem_Click(object sender, EventArgs e)
    {
      releasePlan frm = new releasePlan(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void sprintPlanToolStripMenuItem_Click(object sender, EventArgs e)
    {
      sprintPlan frm = new sprintPlan(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Login frm2 = new Login();
      frm2.Show();
      this.Close();
    }

    private void teamToolStripMenuItem_Click(object sender, EventArgs e)
    {
      addMembers frm = new addMembers(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
      frm.Show();
    }

        

        private void ideaBox_Load(object sender, EventArgs e)
        {

        }

        private void rightClickMenuStrip_Opening(object sender, CancelEventArgs e)
        {

        }

        private void ideaBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //do something
            }
            if (e.Button == MouseButtons.Right)
            {
                rightClickMenuStrip.Show(this, new Point(e.X, e.Y));
                Console.Write("owrk");
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            TextBox lb = new TextBox();
            lb.Width = 75;
            lb.Height = 150;
            lb.Multiline = true;
            lb.Location = this.PointToClient(Cursor.Position);
            this.Controls.Add(lb);
            */
            Story frm = new Story(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
            frm.Show();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = storyLB.GetItemText(storyLB.SelectedItem);
            descTB.Text = SQL.getStoryDesc(name, pn);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //does stuff to send it to the sprint plan.
            string name = storyLB.GetItemText(storyLB.SelectedItem);
            SQL.acceptStory(projectNameToolStripMenuItem.Text, name);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            storyLB.Items.Clear();
            SQL.getStories(storyLB, userName, SQL.getProjectID(pn));

        }

        private void assignRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!SQL.isOwner(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text))  // THIS SQL NEEDS TO BE DONE
            {

                MessageBox.Show("Not an owner. Cannot edit.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            }
            else
            {
                assignRole frm = new assignRole(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
                frm.Show();
            }
        }

        private void assignTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            assignTask frm = new assignTask(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
            frm.Show();
        }

        private void selectProjectToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          //get the name of the drop down item that was clicked
          string proj_name = e.ClickedItem.ToString();

          FormCollection fc = Application.OpenForms;
          bool isFound = false;
          foreach (Form frm in fc)
          {
            if (frm.Name == "Main")
            {
              frm.Focus();
              isFound = true;
              this.Hide();
            }
          }

          if (isFound == false)
          {
            Dashboard frm = new Dashboard(memberNameToolStripMenuItem.Text, proj_name);
            frm.Show();
            this.Hide();
          }
        }
    }
}
