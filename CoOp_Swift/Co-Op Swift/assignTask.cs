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
    public partial class AssignTask : Form
    {
        string _userName,_proj;
        public AssignTask(string username, string projName)
        {
            InitializeComponent();
            _proj = projName;
            _userName = username;
            //SQL.getTasks(taskCB, projName); //this doesnt work for sure
            // SQL.getUndoneTask(taskCB, username, projName);
            //SQL.getUserTask(currentLB, username, projName);
            Sql.GetProjectMembers(memberLB, username, projName); // i think i made the sql for this right
            DataTable sprintIDs = StoryTask.GetProjectSprintIDs(_proj);

            //get tasks and put their names in the corresponding listbox
            foreach (DataRow r in sprintIDs.Rows)
            {
                //get all task ids from the sprint ids
                DataTable taskIDs = StoryTask.GetProjectTaskIDs(int.Parse(r["SprintID"].ToString()));

                //retrieve and add tasks to their correct lists
                foreach (DataRow row in taskIDs.Rows)
                    StoryTask.GetTaskNameForAssign(taskCB, completeLB, int.Parse(row["Task_ID"].ToString()));
            }

            

        }

        private void AssignTaskLoad(object sender, EventArgs e)
        {
            if(!Sql.IsManager(_userName,_proj)) // THIS SQL NEEDS TO BE DONE
            {
              MessageBox.Show("Not a manager. Cannot edit.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
                Close();
                
            }
        }

        private void MemberLbSelectedIndexChanged(object sender, EventArgs e)
        {
            currentLB.Items.Clear();
            if(memberLB.SelectedItem !=null)
            {
                string s = memberLB.GetItemText(memberLB.SelectedItem);
                string firstname, lastname;
                string[] substrings = s.Split(' ');

                firstname = substrings[0];
                lastname = substrings[1];

                DataTable sprintIDs = StoryTask.GetProjectSprintIDs(_proj);

                //get tasks and put their names in the corresponding listbox
                foreach (DataRow r in sprintIDs.Rows)
                {
                    //get all task ids from the sprint ids
                    DataTable taskIDs = StoryTask.GetProjectTaskIDs(int.Parse(r["SprintID"].ToString()));

                    //retrieve and add tasks to their correct lists
                    foreach (DataRow row in taskIDs.Rows)
                        StoryTask.GetTaskNameForUser(currentLB, completeLB, Sql.GetUserId(firstname, lastname), int.Parse(row["Task_ID"].ToString()));
                }
                //SQL.getUserTask(currentLB, SQL.getUserID(firstname, lastname), proj);
            }
           
        }

        private void AssignClick1(object sender, EventArgs e)
        {
            if (memberLB.Text.Equals(""))
            {
                MessageBox.Show("No user selected.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else if (taskCB.Text.Equals(""))
            {
                MessageBox.Show("No Task selected.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            else
            {
                string s = memberLB.GetItemText(memberLB.SelectedItem);
                string firstname, lastname;
                string[] substrings = s.Split(' ');
                firstname = substrings[0];
                lastname = substrings[1];
                Sql.ExecuteAssignTask(Sql.GetUserId(firstname, lastname), taskCB.Text, StoryTask.GetTaskId(taskCB.Text)); // I THINK THIS SQL WORKS
            }
                
        }
        
    }
}
