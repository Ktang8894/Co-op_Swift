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
  public partial class CreateProj : Form
  {
    static String name;

    public CreateProj(String username)
    {
      InitializeComponent();

      // default values
      projectStartDate.Text = DateTime.Now.ToShortDateString();
      releaseEndDate.Text = DateTime.Now.AddDays(35).ToShortDateString();
      timezoneBox.Text = "Select Timezone";

      //username to carry through to next form
      name = username;

      // put timezones from TimeZones table in timezone combobox
      SQL.getTimeZones(timezoneBox);

    }

    private void Form3_Load(object sender, EventArgs e)
    {

    }


    private void createProject_Click(object sender, EventArgs e)
    {
      //check if form is finished correctly and completely
      if(Conditions.projectFormPasses(projectName.Text,projectStartDate.Text,releaseEndDate.Text,timezoneBox.Text,
                              descriptionBox.Text,privateNo,privateYes))
      {
        int isPrivate;

        //check which radio button is checked for 'is project private'
        if (privateYes.Checked)
          isPrivate = 1;
        else
          isPrivate = 0;

        //get ID of the owner(creator) of the poject
        int id = SQL.getOwnerUserID(name);

        //get ID of the timezone
        //int tid = SQL.getTimeZoneID(timezoneBox.Text);
        int tid = 1;

      //put the project info in a list to send to 'addMembers' form
      List<object> project_info = new List<object>();
      project_info.Add(id);
      project_info.Add(projectName.Text);
      project_info.Add(releaseEndDate.Text);
      project_info.Add(tid);
      project_info.Add(projectStartDate.Text);
      project_info.Add(descriptionBox.Text);
      project_info.Add(isPrivate);

      FormCollection fc = Application.OpenForms;
      Form dash = new Form();

      foreach (Form frm1 in fc)
      {
        if (frm1.Name == "Dashboard")
        {
          dash = frm1;
        }
      }

      addMembers frm = new addMembers(name, projectName.Text,dash,this,true,project_info);
      frm.ShowDialog();      

      }

    }


    private void cancel_Click(object sender, EventArgs e)
    {
      // close the form
      this.Close();
    }

    private void descriptionBox_MouseClick(object sender, MouseEventArgs e)
    {
      descriptionBox.Clear();
    }

    private void projectName_MouseClick(object sender, MouseEventArgs e)
    {
      projectName.Clear();
    }

        
    }
}
