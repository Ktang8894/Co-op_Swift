namespace Co_Op_Swift
{
  partial class ideaBox
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
      this.components = new System.ComponentModel.Container();
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
      this.taskTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.releasePlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sprintPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.memberNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.accountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rightClickMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.storyLB = new System.Windows.Forms.ListBox();
      this.descTB = new System.Windows.Forms.TextBox();
      this.refreshButton = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.menuStrip1.SuspendLayout();
      this.rightClickMenuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectNameToolStripMenuItem,
            this.dashboardToolStripMenuItem,
            this.ideaBoxToolStripMenuItem,
            this.taskTreeToolStripMenuItem,
            this.releasePlanToolStripMenuItem,
            this.sprintPlanToolStripMenuItem,
            this.memberNameToolStripMenuItem});
      this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
      this.menuStrip1.Size = new System.Drawing.Size(701, 28);
      this.menuStrip1.TabIndex = 1;
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
      // 
      // taskTreeToolStripMenuItem
      // 
      this.taskTreeToolStripMenuItem.Name = "taskTreeToolStripMenuItem";
      this.taskTreeToolStripMenuItem.Size = new System.Drawing.Size(83, 24);
      this.taskTreeToolStripMenuItem.Text = "Task Tree";
      this.taskTreeToolStripMenuItem.Click += new System.EventHandler(this.taskTreeToolStripMenuItem_Click);
      // 
      // releasePlanToolStripMenuItem
      // 
      this.releasePlanToolStripMenuItem.Name = "releasePlanToolStripMenuItem";
      this.releasePlanToolStripMenuItem.Size = new System.Drawing.Size(104, 24);
      this.releasePlanToolStripMenuItem.Text = "Release Plan";
      this.releasePlanToolStripMenuItem.Click += new System.EventHandler(this.releasePlanToolStripMenuItem_Click);
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
      // rightClickMenuStrip
      // 
      this.rightClickMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
      this.rightClickMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
      this.rightClickMenuStrip.Name = "rightClickMenuStrip";
      this.rightClickMenuStrip.Size = new System.Drawing.Size(115, 30);
      this.rightClickMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.rightClickMenuStrip_Opening);
      // 
      // newToolStripMenuItem
      // 
      this.newToolStripMenuItem.Name = "newToolStripMenuItem";
      this.newToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
      this.newToolStripMenuItem.Text = "New";
      this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
      // 
      // storyLB
      // 
      this.storyLB.FormattingEnabled = true;
      this.storyLB.ItemHeight = 16;
      this.storyLB.Location = new System.Drawing.Point(158, 106);
      this.storyLB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.storyLB.Name = "storyLB";
      this.storyLB.Size = new System.Drawing.Size(106, 308);
      this.storyLB.TabIndex = 2;
      this.storyLB.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
      // 
      // descTB
      // 
      this.descTB.Location = new System.Drawing.Point(271, 106);
      this.descTB.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.descTB.Multiline = true;
      this.descTB.Name = "descTB";
      this.descTB.ReadOnly = true;
      this.descTB.Size = new System.Drawing.Size(264, 308);
      this.descTB.TabIndex = 3;
      // 
      // refreshButton
      // 
      this.refreshButton.BackColor = System.Drawing.Color.Transparent;
      this.refreshButton.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.refreshButton.Location = new System.Drawing.Point(158, 422);
      this.refreshButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.refreshButton.Name = "refreshButton";
      this.refreshButton.Size = new System.Drawing.Size(377, 71);
      this.refreshButton.TabIndex = 5;
      this.refreshButton.Text = "Refresh";
      this.refreshButton.UseVisualStyleBackColor = false;
      this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(280, 41);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(98, 29);
      this.label1.TabIndex = 6;
      this.label1.Text = "IdeaBox";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(179, 73);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(346, 23);
      this.label2.TabIndex = 7;
      this.label2.Text = "Right-click the window to create a new idea";
      // 
      // ideaBox
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.SkyBlue;
      this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Large;
      this.ClientSize = new System.Drawing.Size(701, 506);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.refreshButton);
      this.Controls.Add(this.descTB);
      this.Controls.Add(this.storyLB);
      this.Controls.Add(this.menuStrip1);
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "ideaBox";
      this.Text = "Co-Op Swift";
      this.Load += new System.EventHandler(this.ideaBox_Load);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ideaBox_MouseDown);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.rightClickMenuStrip.ResumeLayout(false);
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
    private System.Windows.Forms.ToolStripMenuItem taskTreeToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem releasePlanToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sprintPlanToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem memberNameToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem accountToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip rightClickMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ListBox storyLB;
        private System.Windows.Forms.TextBox descTB;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.ToolStripMenuItem selectProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignRolesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem assignTasksToolStripMenuItem;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
  }
}