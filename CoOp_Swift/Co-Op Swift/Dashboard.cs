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
  public partial class Dashboard : Form
  {
    public Dashboard(string username, string projectName)
    {
      InitializeComponent();

      memberNameToolStripMenuItem.Text = username;

      if (projectName.Length >= 1)
      {
        projectNameToolStripMenuItem.Text = projectName;
        dashboardToolStripMenuItem.Visible = true;
        dashboardToolStripMenuItem.Font = new Font(dashboardToolStripMenuItem.Font,FontStyle.Bold);
        ideaBoxToolStripMenuItem.Visible = true;
        releasePlanToolStripMenuItem.Visible = true;
        sprintPlanToolStripMenuItem.Visible = true;
        taskTreeToolStripMenuItem.Visible = true;
        assignRolesToolStripMenuItem.Visible = true;
        assignTasksToolStripMenuItem.Visible = true;
        inviteMembersToolStripMenuItem.Visible = true;

        projectDescriptionEditButton.Visible = true;
        projectDescriptionLabel.Visible = true;
        projectDescriptionTB.Visible = true;
        releaseButton.Visible = true;
        releaseLabel.Visible = true;
        releaseTextBox.Visible = true;
        doneButton.Visible = true;
        doneLabel.Visible = true;
        doneTextBox.Visible = true;
        activitiesTextBox.Visible = true;
        activityLabel.Visible = true;
        noProject.Visible = false;


        //get the project description for the user's project
        Sql.getProjectDescription(projectName, projectDescriptionTB);

        /***************************** this is for select a project drop down menu **********************************/

        //get all project ids associated with the user ids
        DataTable proj_ids = Sql.getUserProjectIDs(Sql.getOwnerUserID(memberNameToolStripMenuItem.Text));

        string proj_name;

        // get all project names associated with the project ids
        foreach (DataRow row in proj_ids.Rows)
        {
          //put project names in select project drop down menu
          proj_name = Sql.getProjectName(int.Parse(row["Proj_ID"].ToString()));
          selectProjectToolStripMenuItem.DropDownItems.Add(proj_name);
        }
        /*************************************************************************************************************/
      }
      else
      {
        dashboardToolStripMenuItem.Visible = false;
        ideaBoxToolStripMenuItem.Visible = false;
        releasePlanToolStripMenuItem.Visible = false;
        sprintPlanToolStripMenuItem.Visible = false;
        taskTreeToolStripMenuItem.Visible = false;
        assignRolesToolStripMenuItem.Visible = false;
        assignTasksToolStripMenuItem.Visible = false;
        inviteMembersToolStripMenuItem.Visible = false;

        projectDescriptionEditButton.Visible = false;
        projectDescriptionLabel.Visible = false;
        projectDescriptionTB.Visible = false;
        releaseButton.Visible = false;
        releaseLabel.Visible = false;
        releaseTextBox.Visible = false;
        doneButton.Visible = false;
        doneLabel.Visible = false;
        doneTextBox.Visible = false;
        activitiesTextBox.Visible = false;
        activityLabel.Visible = false;
        noProject.Visible = true;
      }
   
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        if(!projectNameToolStripMenuItem.Text.Equals("Project"))
            Sql.getStories(taskNameLB, memberNameToolStripMenuItem.Text, Sql.getProjectID(projectNameToolStripMenuItem.Text));

    }

    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void projectNameToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Login frm2 = new Login();
      frm2.Show();
      this.Close();

    }

    private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void createToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // create "create project" form and open it
      CreateProj frm3 = new CreateProj(memberNameToolStripMenuItem.Text);
      frm3.ShowDialog();
            
    }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            const int padding = 3;
            // get number of lines (first line is 0, so add 1)
            int numLines = this.projectDescriptionTB.GetLineFromCharIndex(this.projectDescriptionTB.TextLength) + 1;
            // get border thickness
            int border = this.projectDescriptionTB.Height - this.projectDescriptionTB.ClientSize.Height;
            // set height (height of one line * number of lines + spacing)
            this.projectDescriptionTB.Height = this.projectDescriptionTB.Font.Height * numLines + padding + border;
        }

        private void projectDescriptionEditButton_Click(object sender, EventArgs e)
        {
            if(projectDescriptionTB.Enabled == false)
            {
                projectDescriptionTB.Enabled = true;
            }
            else
            {
                projectDescriptionTB.Enabled = false;
            }
        }

        private void teamToolStripMenuItem_Click(object sender, EventArgs e)
        {
          AddMembers frm = new AddMembers(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
          frm.Show();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (releaseTextBox.Enabled == false)
            {
                releaseTextBox.Enabled = true;
            }
            else
            {
                releaseTextBox.Enabled = false;
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            const int padding = 3;
            // get number of lines (first line is 0, so add 1)
            int numLines = this.releaseTextBox.GetLineFromCharIndex(this.releaseTextBox.TextLength) + 1;
            // get border thickness
            int border = this.releaseTextBox.Height - this.releaseTextBox.ClientSize.Height;
            // set height (height of one line * number of lines + spacing)
            this.releaseTextBox.Height = this.releaseTextBox.Font.Height * numLines + padding + border;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (doneTextBox.Enabled == false)
            {
                doneTextBox.Enabled = true;
            }
            else
            {
                doneTextBox.Enabled = false;
            }
        }

        private void doneTextBox_TextChanged(object sender, EventArgs e)
        {
            const int padding = 3;
            // get number of lines (first line is 0, so add 1)
            int numLines = this.doneTextBox.GetLineFromCharIndex(this.doneTextBox.TextLength) + 1;
            // get border thickness
            int border = this.doneTextBox.Height - this.doneTextBox.ClientSize.Height;
            // set height (height of one line * number of lines + spacing)
            this.doneTextBox.Height = this.doneTextBox.Font.Height * numLines + padding + border;
        }

        private void ideaBoxToolStripMenuItem_Click(object sender, EventArgs e)
        {
          IdeaBox frm = new IdeaBox(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
          frm.Show();
          this.Close();
        }

        private void taskTreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
          TaskTree frm = new TaskTree(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
          frm.Show();
          this.Close();
        }

        private void releasePlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ReleasePlan frm = new ReleasePlan(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
           frm.Show();
           this.Close();
        }

        private void sprintPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
          SprintPlan frm = new SprintPlan(memberNameToolStripMenuItem.Text,projectNameToolStripMenuItem.Text);
          frm.Show();
          this.Close();
        }

        private void assignRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!Sql.isManager(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text))  // THIS SQL NEEDS TO BE DONE
            {

                MessageBox.Show("Not an owner. Cannot edit.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                
            }
            else
            {
                AssignRole frm = new AssignRole(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
                frm.Show();
            }
            
            
        }

        private void assignTasksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssignTask frm = new AssignTask(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
            frm.Show();
        }

        private void selectProjectToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
          //get the name of the drop down item that was clicked
          //string proj_name = e.ClickedItem.ToString();
          projectNameToolStripMenuItem.Text = e.ClickedItem.ToString();
          Sql.getProjectDescription(e.ClickedItem.ToString(), projectDescriptionTB);
            taskNameLB.Items.Clear();
            descTB.Text = "";
          Sql.getStories(taskNameLB, memberNameToolStripMenuItem.Text, Sql.getProjectID(projectNameToolStripMenuItem.Text));
            /*FormCollection fc = Application.OpenForms;
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
            }*/
        }

        private void taskNameLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(taskNameLB.SelectedItem != null)
            {
                string name = taskNameLB.GetItemText(taskNameLB.SelectedItem);
                descTB.Text = Sql.getStoryDesc(name, projectNameToolStripMenuItem.Text);


            }
        }

        private void selectProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    private void projectDescriptionLabel_TextChanged(object sender, EventArgs e)
    {

    }

    private void doneLabel_TextChanged(object sender, EventArgs e)
    {

    }

    private void activityLabel_TextChanged(object sender, EventArgs e)
    {

    }

    private void label1_Click(object sender, EventArgs e)
    {

    }
  }
}
