namespace Co_Op_Swift
{
  partial class ReleasePlan
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.projectNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.selectProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.teamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.assignRolesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.assignTasksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.dashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.ideaBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.timeLineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.releasePlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sprintPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.memberNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.dataGridView1 = new System.Windows.Forms.DataGridView();
      this.addSprint = new System.Windows.Forms.Button();
      this.startMonth = new System.Windows.Forms.TextBox();
      this.startDay = new System.Windows.Forms.TextBox();
      this.startYear = new System.Windows.Forms.TextBox();
      this.endYear = new System.Windows.Forms.TextBox();
      this.endDay = new System.Windows.Forms.TextBox();
      this.endMonth = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.menuStrip1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectNameToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.ideaBoxToolStripMenuItem,
            this.timeLineToolStripMenuItem,
            this.releasePlanToolStripMenuItem,
            this.sprintPlanToolStripMenuItem,
            this.memberNameToolStripMenuItem});
      this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
      this.menuStrip1.Size = new System.Drawing.Size(1187, 28);
      this.menuStrip1.TabIndex = 2;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // projectNameToolStripMenuItem
      // 
      this.projectNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.selectProjectToolStripMenuItem,
            this.importToolStripMenuItem,
            this.teamToolStripMenuItem,
            this.assignRolesToolStripMenuItem,
            this.assignTasksToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.settingsToolStripMenuItem});
      this.projectNameToolStripMenuItem.Name = "projectNameToolStripMenuItem";
      this.projectNameToolStripMenuItem.Size = new System.Drawing.Size(67, 24);
      this.projectNameToolStripMenuItem.Text = "Project";
      // 
      // createToolStripMenuItem
      // 
      this.createToolStripMenuItem.Name = "createToolStripMenuItem";
      this.createToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.createToolStripMenuItem.Text = "Create Project";
      // 
      // selectProjectToolStripMenuItem
      // 
      this.selectProjectToolStripMenuItem.Name = "selectProjectToolStripMenuItem";
      this.selectProjectToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.selectProjectToolStripMenuItem.Text = "Select Project";
      this.selectProjectToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.selectProjectToolStripMenuItem_DropDownItemClicked);
      // 
      // importToolStripMenuItem
      // 
      this.importToolStripMenuItem.Name = "importToolStripMenuItem";
      this.importToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.importToolStripMenuItem.Text = "Import";
      // 
      // teamToolStripMenuItem
      // 
      this.teamToolStripMenuItem.Name = "teamToolStripMenuItem";
      this.teamToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.teamToolStripMenuItem.Text = "Team Members";
      this.teamToolStripMenuItem.Click += new System.EventHandler(this.teamToolStripMenuItem_Click);
      // 
      // assignRolesToolStripMenuItem
      // 
      this.assignRolesToolStripMenuItem.Name = "assignRolesToolStripMenuItem";
      this.assignRolesToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.assignRolesToolStripMenuItem.Text = "Assign Roles";
      this.assignRolesToolStripMenuItem.Click += new System.EventHandler(this.assignRolesToolStripMenuItem_Click);
      // 
      // assignTasksToolStripMenuItem
      // 
      this.assignTasksToolStripMenuItem.Name = "assignTasksToolStripMenuItem";
      this.assignTasksToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.assignTasksToolStripMenuItem.Text = "Assign Tasks";
      this.assignTasksToolStripMenuItem.Click += new System.EventHandler(this.assignTasksToolStripMenuItem_Click);
      // 
      // deleteToolStripMenuItem
      // 
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.deleteToolStripMenuItem.Text = "Delete";
      // 
      // settingsToolStripMenuItem
      // 
      this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
      this.settingsToolStripMenuItem.Size = new System.Drawing.Size(187, 26);
      this.settingsToolStripMenuItem.Text = "Settings";
      // 
      // dashboardToolStripMenuItem
      // 
      this.dashboardToolStripMenuItem.Name = "dashboardToolStripMenuItem";
      this.dashboardToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
      this.dashboardToolStripMenuItem.Text = "Dashboard";
      this.dashboardToolStripMenuItem.Click += new System.EventHandler(this.dashboardToolStripMenuItem_Click);
      // 
      // ideaBoxToolStripMenuItem
      // 
      this.ideaBoxToolStripMenuItem.Name = "ideaBoxToolStripMenuItem";
      this.ideaBoxToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
      this.ideaBoxToolStripMenuItem.Text = "IdeaBox";
      this.ideaBoxToolStripMenuItem.Click += new System.EventHandler(this.ideaBoxToolStripMenuItem_Click);
      // 
      // timeLineToolStripMenuItem
      // 
      this.timeLineToolStripMenuItem.Name = "timeLineToolStripMenuItem";
      this.timeLineToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
      this.timeLineToolStripMenuItem.Text = "Task View";
      this.timeLineToolStripMenuItem.Click += new System.EventHandler(this.timeLineToolStripMenuItem_Click);
      // 
      // releasePlanToolStripMenuItem
      // 
      this.releasePlanToolStripMenuItem.Name = "releasePlanToolStripMenuItem";
      this.releasePlanToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
      this.releasePlanToolStripMenuItem.Text = "Release Plan";
      // 
      // sprintPlanToolStripMenuItem
      // 
      this.sprintPlanToolStripMenuItem.Name = "sprintPlanToolStripMenuItem";
      this.sprintPlanToolStripMenuItem.Size = new System.Drawing.Size(92, 24);
      this.sprintPlanToolStripMenuItem.Text = "Sprint Plan";
      this.sprintPlanToolStripMenuItem.Click += new System.EventHandler(this.sprintPlanToolStripMenuItem_Click);
      // 
      // memberNameToolStripMenuItem
      // 
      this.memberNameToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
      this.memberNameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountToolStripMenuItem,
            this.logoutToolStripMenuItem});
      this.memberNameToolStripMenuItem.Name = "memberNameToolStripMenuItem";
      this.memberNameToolStripMenuItem.Size = new System.Drawing.Size(121, 24);
      this.memberNameToolStripMenuItem.Text = "Member Name";
      // 
      // accountToolStripMenuItem
      // 
      this.accountToolStripMenuItem.Name = "accountToolStripMenuItem";
      this.accountToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
      this.accountToolStripMenuItem.Text = "Account";
      // 
      // logoutToolStripMenuItem
      // 
      this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
      this.logoutToolStripMenuItem.Size = new System.Drawing.Size(138, 26);
      this.logoutToolStripMenuItem.Text = "Logout";
      this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
      // 
      // dataGridView1
      // 
      this.dataGridView1.AllowDrop = true;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
      this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.dataGridView1.Location = new System.Drawing.Point(271, 47);
      this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.dataGridView1.Name = "dataGridView1";
      this.dataGridView1.RowTemplate.Height = 24;
      this.dataGridView1.Size = new System.Drawing.Size(899, 473);
      this.dataGridView1.TabIndex = 3;
      // 
      // addSprint
      // 
      this.addSprint.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.addSprint.Location = new System.Drawing.Point(13, 254);
      this.addSprint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.addSprint.Name = "addSprint";
      this.addSprint.Size = new System.Drawing.Size(243, 63);
      this.addSprint.TabIndex = 4;
      this.addSprint.Text = "Add New Sprint";
      this.addSprint.UseVisualStyleBackColor = true;
      this.addSprint.Click += new System.EventHandler(this.addSprint_Click);
      // 
      // startMonth
      // 
      this.startMonth.Location = new System.Drawing.Point(100, 197);
      this.startMonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.startMonth.Name = "startMonth";
      this.startMonth.Size = new System.Drawing.Size(39, 22);
      this.startMonth.TabIndex = 5;
      this.startMonth.Text = "MM";
      // 
      // startDay
      // 
      this.startDay.Location = new System.Drawing.Point(144, 197);
      this.startDay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.startDay.Name = "startDay";
      this.startDay.Size = new System.Drawing.Size(39, 22);
      this.startDay.TabIndex = 6;
      this.startDay.Text = "DD";
      // 
      // startYear
      // 
      this.startYear.Location = new System.Drawing.Point(188, 197);
      this.startYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.startYear.Name = "startYear";
      this.startYear.Size = new System.Drawing.Size(65, 22);
      this.startYear.TabIndex = 7;
      this.startYear.Text = "YYYY";
      // 
      // endYear
      // 
      this.endYear.Location = new System.Drawing.Point(188, 225);
      this.endYear.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.endYear.Name = "endYear";
      this.endYear.Size = new System.Drawing.Size(65, 22);
      this.endYear.TabIndex = 10;
      this.endYear.Text = "YYYY";
      // 
      // endDay
      // 
      this.endDay.Location = new System.Drawing.Point(144, 225);
      this.endDay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.endDay.Name = "endDay";
      this.endDay.Size = new System.Drawing.Size(39, 22);
      this.endDay.TabIndex = 9;
      this.endDay.Text = "DD";
      // 
      // endMonth
      // 
      this.endMonth.Location = new System.Drawing.Point(100, 225);
      this.endMonth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
      this.endMonth.Name = "endMonth";
      this.endMonth.Size = new System.Drawing.Size(39, 22);
      this.endMonth.TabIndex = 8;
      this.endMonth.Text = "MM";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(4, 199);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(84, 20);
      this.label1.TabIndex = 11;
      this.label1.Text = "Start Date:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(15, 226);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(75, 20);
      this.label2.TabIndex = 12;
      this.label2.Text = "End Date:";
      // 
      // releasePlan
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.LightCoral;
      this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Large;
      this.ClientSize = new System.Drawing.Size(1187, 535);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.endYear);
      this.Controls.Add(this.endDay);
      this.Controls.Add(this.endMonth);
      this.Controls.Add(this.startYear);
      this.Controls.Add(this.startDay);
      this.Controls.Add(this.startMonth);
      this.Controls.Add(this.addSprint);
      this.Controls.Add(this.dataGridView1);
      this.Controls.Add(this.menuStrip1);
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "releasePlan";
      this.Text = "Co-Op Swift";
      this.Load += new System.EventHandler(this.releasePlan_Load);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem projectNameToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem teamToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem dashboardToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ideaBoxToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem timeLineToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem releasePlanToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sprintPlanToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem memberNameToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    private System.Windows.Forms.DataGridView dataGridView1;
    private System.Windows.Forms.Button addSprint;
    private System.Windows.Forms.TextBox startMonth;
    private System.Windows.Forms.TextBox startDay;
    private System.Windows.Forms.TextBox startYear;
    private System.Windows.Forms.TextBox endYear;
    private System.Windows.Forms.TextBox endDay;
    private System.Windows.Forms.TextBox endMonth;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.ToolStripMenuItem selectProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignTasksToolStripMenuItem;
    }
}