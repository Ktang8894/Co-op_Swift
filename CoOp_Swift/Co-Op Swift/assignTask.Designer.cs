namespace Co_Op_Swift
{
    partial class assignTask
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
            this.memberLB = new System.Windows.Forms.ListBox();
            this.currentLB = new System.Windows.Forms.ListBox();
            this.taskCB = new System.Windows.Forms.ComboBox();
            this.Assign = new System.Windows.Forms.Button();
            this.completeLB = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // memberLB
            // 
            this.memberLB.FormattingEnabled = true;
            this.memberLB.Location = new System.Drawing.Point(26, 24);
            this.memberLB.Name = "memberLB";
            this.memberLB.Size = new System.Drawing.Size(120, 121);
            this.memberLB.TabIndex = 0;
            this.memberLB.SelectedIndexChanged += new System.EventHandler(this.memberLB_SelectedIndexChanged);
            // 
            // currentLB
            // 
            this.currentLB.FormattingEnabled = true;
            this.currentLB.Location = new System.Drawing.Point(152, 24);
            this.currentLB.Name = "currentLB";
            this.currentLB.Size = new System.Drawing.Size(120, 43);
            this.currentLB.TabIndex = 1;
            // 
            // taskCB
            // 
            this.taskCB.FormattingEnabled = true;
            this.taskCB.Location = new System.Drawing.Point(278, 24);
            this.taskCB.Name = "taskCB";
            this.taskCB.Size = new System.Drawing.Size(117, 21);
            this.taskCB.TabIndex = 2;
            this.taskCB.Text = "Task to be assigned";
            // 
            // Assign
            // 
            this.Assign.BackColor = System.Drawing.Color.Transparent;
            this.Assign.Font = new System.Drawing.Font("Trebuchet MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Assign.Location = new System.Drawing.Point(278, 50);
            this.Assign.Name = "Assign";
            this.Assign.Size = new System.Drawing.Size(116, 68);
            this.Assign.TabIndex = 3;
            this.Assign.Text = "Assign";
            this.Assign.UseVisualStyleBackColor = false;
            this.Assign.Click += new System.EventHandler(this.Assign_Click_1);
            // 
            // completeLB
            // 
            this.completeLB.FormattingEnabled = true;
            this.completeLB.Location = new System.Drawing.Point(152, 86);
            this.completeLB.Name = "completeLB";
            this.completeLB.Size = new System.Drawing.Size(120, 56);
            this.completeLB.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(152, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Current";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(152, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Complete";
            // 
            // assignTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Co_Op_Swift.Properties.Resources.Background_Dark_Small;
            this.ClientSize = new System.Drawing.Size(423, 202);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.completeLB);
            this.Controls.Add(this.Assign);
            this.Controls.Add(this.taskCB);
            this.Controls.Add(this.currentLB);
            this.Controls.Add(this.memberLB);
            this.Name = "assignTask";
            this.Text = "assignTask";
            this.Load += new System.EventHandler(this.assignTask_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox memberLB;
        private System.Windows.Forms.ListBox currentLB;
        private System.Windows.Forms.ComboBox taskCB;
        private System.Windows.Forms.Button Assign;
        private System.Windows.Forms.ListBox completeLB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}