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
    public partial class assignTask : Form
    {
        string userName,proj;
        public assignTask(string username, string projName)
        {
            InitializeComponent();
            proj = projName;
            userName = username;
            //SQL.getTasks(taskCB, projName); //this doesnt work for sure
            // SQL.getUndoneTask(taskCB, username, projName);
            //SQL.getUserTask(currentLB, username, projName);
            SQL.getProjectMembers(memberLB, username, projName); // i think i made the sql for this right
            DataTable sprint_IDs = StoryTask.getProject_sprintIDs(proj);

            //get tasks and put their names in the corresponding listbox
            foreach (DataRow r in sprint_IDs.Rows)
            {
                //get all task ids from the sprint ids
                DataTable task_IDs = StoryTask.getProject_taskIDs(int.Parse(r["SprintID"].ToString()));

                //retrieve and add tasks to their correct lists
                foreach (DataRow row in task_IDs.Rows)
                    StoryTask.getTaskNameForAssign(taskCB, completeLB, int.Parse(row["Task_ID"].ToString()));
            }

            

        }

        private void assignTask_Load(object sender, EventArgs e)
        {
            if(!SQL.isManager(userName,proj)) // THIS SQL NEEDS TO BE DONE
            {
              MessageBox.Show("Not a manager. Cannot edit.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Exclamation,MessageBoxDefaultButton.Button1);
                Close();
                
            }
        }

        private void memberLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentLB.Items.Clear();
            if(memberLB.SelectedItem !=null)
            {
                string s = memberLB.GetItemText(memberLB.SelectedItem);
                string firstname, lastname;
                string[] substrings = s.Split(' ');

                firstname = substrings[0];
                lastname = substrings[1];

                DataTable sprint_IDs = StoryTask.getProject_sprintIDs(proj);

                //get tasks and put their names in the corresponding listbox
                foreach (DataRow r in sprint_IDs.Rows)
                {
                    //get all task ids from the sprint ids
                    DataTable task_IDs = StoryTask.getProject_taskIDs(int.Parse(r["SprintID"].ToString()));

                    //retrieve and add tasks to their correct lists
                    foreach (DataRow row in task_IDs.Rows)
                        StoryTask.getTaskNameForUser(currentLB, completeLB, SQL.getUserID(firstname, lastname), int.Parse(row["Task_ID"].ToString()));
                }
                //SQL.getUserTask(currentLB, SQL.getUserID(firstname, lastname), proj);
            }
           
        }

        private void Assign_Click_1(object sender, EventArgs e)
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
                SQL.ExecuteAssignTask(SQL.getUserID(firstname, lastname), taskCB.Text, StoryTask.getTaskID(taskCB.Text)); // I THINK THIS SQL WORKS
            }
                
        }
        
    }
}
