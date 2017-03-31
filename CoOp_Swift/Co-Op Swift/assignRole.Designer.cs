namespace Co_Op_Swift
{
    partial class assignRole
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
      this.memberLBox = new System.Windows.Forms.ListBox();
      this.roleCB = new System.Windows.Forms.ComboBox();
      this.button1 = new System.Windows.Forms.Button();
      this.label1 = new System.Windows.Forms.Label();
      this.roleTB = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
      this.SuspendLayout();
      // 
      // memberLBox
      // 
      this.memberLBox.FormattingEnabled = true;
      this.memberLBox.ItemHeight = 16;
      this.memberLBox.Location = new System.Drawing.Point(13, 35);
      this.memberLBox.Margin = new System.Windows.Forms.Padding(4);
      this.memberLBox.Name = "memberLBox";
      this.memberLBox.Size = new System.Drawing.Size(162, 116);
      this.memberLBox.TabIndex = 0;
      this.memberLBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
      // 
      // roleCB
      // 
      this.roleCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.roleCB.FormattingEnabled = true;
      this.roleCB.Items.AddRange(new object[] {
            "Developer",
            "Project Owner",
            "Manager",
            "Client"});
      this.roleCB.Location = new System.Drawing.Point(181, 37);
      this.roleCB.Margin = new System.Windows.Forms.Padding(4);
      this.roleCB.Name = "roleCB";
      this.roleCB.Size = new System.Drawing.Size(182, 24);
      this.roleCB.TabIndex = 1;
      // 
      // button1
      // 
      this.button1.BackColor = System.Drawing.Color.Transparent;
      this.button1.Font = new System.Drawing.Font("Trebuchet MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.button1.ForeColor = System.Drawing.Color.Black;
      this.button1.Location = new System.Drawing.Point(183, 115);
      this.button1.Margin = new System.Windows.Forms.Padding(4);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(178, 36);
      this.button1.TabIndex = 2;
      this.button1.Text = "Change";
      this.button1.UseVisualStyleBackColor = false;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.BackColor = System.Drawing.Color.Transparent;
      this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label1.ForeColor = System.Drawing.Color.White;
      this.label1.Location = new System.Drawing.Point(225, 64);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(93, 20);
      this.label1.TabIndex = 3;
      this.label1.Text = "Current Role";
      // 
      // roleTB
      // 
      this.roleTB.Location = new System.Drawing.Point(183, 85);
      this.roleTB.Margin = new System.Windows.Forms.Padding(4);
      this.roleTB.Name = "roleTB";
      this.roleTB.Size = new System.Drawing.Size(178, 22);
      this.roleTB.TabIndex = 4;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.BackColor = System.Drawing.Color.Transparent;
      this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.Color.White;
      this.label2.Location = new System.Drawing.Point(63, 15);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(63, 20);
      this.label2.TabIndex = 5;
      this.label2.Text = "Member";
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.BackColor = System.Drawing.Color.Transparent;
      this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.Color.White;
      this.label3.Location = new System.Drawing.Point(254, 15);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(37, 20);
      this.label3.TabIndex = 6;
      this.label3.Text = "Role";
      // 
      // assignRole
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Small;
      this.ClientSize = new System.Drawing.Size(379, 165);
      this.Controls.Add(this.label3);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.roleTB);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.roleCB);
      this.Controls.Add(this.memberLBox);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "assignRole";
      this.Text = "assignRole";
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox memberLBox;
        private System.Windows.Forms.ComboBox roleCB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox roleTB;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
  }
}