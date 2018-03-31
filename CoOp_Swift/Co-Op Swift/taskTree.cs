using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Co_Op_Swift
{
  public partial class TaskTree : Form
  {
    public TaskTree(string username, string projectName)
    {
      InitializeComponent();

      //get all project related sprint ids
      DataTable sprint_IDs = StoryTask.getProject_sprintIDs(projectName);

      //get tasks and put their names in the corresponding listbox
      foreach (DataRow r in sprint_IDs.Rows)
      {
        //get all task ids from the sprint ids
        DataTable task_IDs = StoryTask.getProject_taskIDs(int.Parse(r["SprintID"].ToString()));

        //retrieve and add tasks to their correct lists
        foreach (DataRow row in task_IDs.Rows)
          StoryTask.getTaskName(currentTasks, completedTasks, int.Parse(row["Task_ID"].ToString()));
      }

      projectNameToolStripMenuItem.Text = projectName;
      memberNameToolStripMenuItem.Text = username;
      taskTreeToolStripMenuItem.Font = new Font(taskTreeToolStripMenuItem.Font, FontStyle.Bold);


      // intially make developer panels invisible unitl a task is selected
      develop1.Visible = false;
      develop2.Visible = false;
      commentDetails.Visible = false;
      comments.Visible = false;
      comments2.Visible = false;
      userComments.Visible = false;
      comment.Visible = false;
      hideTaskInfo.Visible = false;

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

    private void dashboardToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Dashboard frm = new Dashboard(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void ideaBoxToolStripMenuItem_Click(object sender, EventArgs e)
    {
      IdeaBox frm = new IdeaBox(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void releasePlanToolStripMenuItem_Click(object sender, EventArgs e)
    {
      ReleasePlan frm = new ReleasePlan(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
      this.Close();
    }

    private void sprintPlanToolStripMenuItem_Click(object sender, EventArgs e)
    {
      SprintPlan frm = new SprintPlan(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
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
      AddMembers frm = new AddMembers(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text);
      frm.Show();
    }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void currentTasks_SelectedIndexChanged(object sender, EventArgs e)
    {
      int id, uid;
      string name;

      if(currentTasks.SelectedItem != null)
      {
        develop1.Visible = false;
        develop2.Visible = false;
        userComments.Items.Clear();

        //get task
        StoryTask.getTaskInfo(currentTasks.SelectedItem.ToString(), develop1, develop2, develop1Name, develop1Email, develop1Position,
                                                                                        develop2Name, develop2Email, develop2Position);

        //remove the selection of the item in the other box if one was selected
        if (completedTasks.SelectedItem != null)
          completedTasks.SetSelected(completedTasks.Items.IndexOf(completedTasks.SelectedItem), false);

        DataTable commentIDs = StoryTask.getCommentID(StoryTask.getTaskID(currentTasks.SelectedItem.ToString()));

        foreach (DataRow row in commentIDs.Rows)
        {
          id = int.Parse(row["CommentID"].ToString());
          uid = StoryTask.getCommenter(id);
          name = Sql.getFullName(uid);
          userComments.Items.Add(name);
        }

        comments.Visible = true;
        userComments.Visible = true;
        comment.Visible = true;
        hideTaskInfo.Visible = true;

      }
     
    }

    private void hideTaskInfo_Click(object sender, EventArgs e)
    {
      //remove the the selection from the listboxes(the highlight that shows an item was selected)
      if (currentTasks.SelectedItem != null)
        currentTasks.SetSelected(currentTasks.Items.IndexOf(currentTasks.SelectedItem), false);

      if (completedTasks.SelectedItem != null)
        completedTasks.SetSelected(completedTasks.Items.IndexOf(completedTasks.SelectedItem), false);

      develop1.Visible = false;
      develop2.Visible = false;
      commentDetails.Visible = false;
      comments.Visible = false;
      comments2.Visible = false;
      comment.Visible = false;
      userComments.Visible = false;
      hideTaskInfo.Visible = false;
    }

    private void comment_Click(object sender, EventArgs e)
    {
      string fullName = Sql.getFullName(Sql.getOwnerUserID(memberNameToolStripMenuItem.Text));
      
      if (currentTasks.SelectedItem != null)
      {
        AddComment frm = new AddComment(userComments, currentTasks,fullName);
        frm.ShowDialog();
      }
      else if (completedTasks.SelectedItem != null)
      {
        AddComment frm = new AddComment(userComments, completedTasks,fullName);
        frm.ShowDialog();
      }
    }

    private void userComments_SelectedIndexChanged(object sender, EventArgs e)
    {
      comments2.Visible = true;
      commentDetails.Visible = true;
      int task_id;
      DataTable comment_IDs;

      //get the id of the selected task
      if (currentTasks.SelectedItem != null)
        task_id = StoryTask.getTaskID(currentTasks.SelectedItem.ToString());
      else
        task_id = StoryTask.getTaskID(completedTasks.SelectedItem.ToString());

      //get the id of the person whose name was selected from comments list
      int userID = Sql.getOwnerUserID(Sql.getUsername(userComments.Text));

      //get the comment ids for the selected task
      comment_IDs = StoryTask.getCommentID(task_id);

      //find the correct comment from the userID and commentIDs
      StoryTask.loadCommentDetail(userID, comment_IDs, commentDetails);

    }

    private void completedTasks_SelectedIndexChanged(object sender, EventArgs e)
    {
      int id, uid;
      string name;

      if(completedTasks.SelectedItem != null)
      {
        userComments.Items.Clear();

        //get task
        StoryTask.getTaskInfo(completedTasks.SelectedItem.ToString(), develop1, develop2, develop1Name, develop1Email, develop1Position,
                                                                                          develop2Name, develop2Email, develop2Position);

        //remove the selection of the item in the other box if one was selected
        if (currentTasks.SelectedItem != null)
          currentTasks.SetSelected(currentTasks.Items.IndexOf(currentTasks.SelectedItem), false);

        DataTable commentIDs = StoryTask.getCommentID(StoryTask.getTaskID(completedTasks.SelectedItem.ToString()));

        foreach (DataRow row in commentIDs.Rows)
        {
          id = int.Parse(row["CommentID"].ToString());
          uid = StoryTask.getCommenter(id);
          name = Sql.getFullName(uid);
          userComments.Items.Add(name);
        }

        comments.Visible = true;
        userComments.Visible = true;
        comment.Visible = true;
        hideTaskInfo.Visible = true;
      }
     
    }

    private void completed_button_Click(object sender, EventArgs e)
    {
      //grab selected task
      string task = currentTasks.SelectedItem.ToString();

      //mark the task as completed in the TaskTable table
      StoryTask.mark_task_as_complete(task);

      bool isFound = false;

      //remove from current tasks list and add to completed tasks list
      foreach (string s in completedTasks.Items)
      {
        if (s.Equals(currentTasks.SelectedItem.ToString()))
        {
          isFound = true;
          break;
        }
      }

      if (!isFound)
        completedTasks.Items.Add(currentTasks.SelectedItem);

      currentTasks.Items.Remove(currentTasks.SelectedItem);
      completedTasks.SetSelected(completedTasks.Items.IndexOf(task), true);

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

        private void assignRolesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Sql.isOwner(memberNameToolStripMenuItem.Text, projectNameToolStripMenuItem.Text))  // THIS SQL NEEDS TO BE DONE
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
    }
}
