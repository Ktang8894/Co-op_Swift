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
  public partial class Form1 : Form
  {
    public Form1(String username)
    {
      InitializeComponent();

      memberNameToolStripMenuItem.Text = username;
      productBackLogToolStripMenuItem.Visible = false;
      sandboxToolStripMenuItem.Visible = false;
      releasePlanToolStripMenuItem.Visible = false;
      sprintPlanToolStripMenuItem.Visible = false;
      timeLineToolStripMenuItem.Visible = false;
   
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void projectNameToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }

    private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      
      Form2 frm2 = new Form2();
      frm2.Show();
      this.Close();

    }

    private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void createToolStripMenuItem_Click(object sender, EventArgs e)
    {
      productBackLogToolStripMenuItem.Visible = true;
      sandboxToolStripMenuItem.Visible = true;
      releasePlanToolStripMenuItem.Visible = true;
      sprintPlanToolStripMenuItem.Visible = true;
      timeLineToolStripMenuItem.Visible = true;
    }

        private void button1_Click(object sender, EventArgs e)
        {
            if (projectDescriptionTB.Enabled == false)
            {
                projectDescriptionTB.Enabled = true;
            }
            else
            {
                projectDescriptionTB.Enabled = false;
            }
        }
    }
}
