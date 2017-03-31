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
  public partial class AddComment : Form
  {
    ListBox userComments;

    public AddComment(ListBox box, ListBox taskBox, string full_name)
    {
      InitializeComponent();
      userComments = box;
      nameBox.Text = full_name;
      taskNameBox.Text = taskBox.SelectedItem.ToString();
    }

    private void cancel_button_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void ok_button_Click(object sender, EventArgs e)
    {
      //get users username
      string username = SQL.getUsername(nameBox.Text);

      //get userID from the name given as input
      int uid = SQL.getOwnerUserID(username);
      
      //insert userID and comment into "Comments" table and retrieve the commentID
      int id = StoryTask.insertComment(uid, commentBox.Text);

      //insert task_id and comment_id into "TaskComments" table
      StoryTask.insertTaskComment(StoryTask.getTaskID(taskNameBox.Text),id);

      //add name to userComments box on taskTree form
      userComments.Items.Add(nameBox.Text);

      this.Close();
    }
  }
}
