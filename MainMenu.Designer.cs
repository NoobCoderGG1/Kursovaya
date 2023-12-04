namespace Kursovaya
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.panel1 = new System.Windows.Forms.Panel();
            this.PersonManageBtn = new System.Windows.Forms.Button();
            this.CarViewInfoBtn = new System.Windows.Forms.Button();
            this.ForceViewBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::Kursovaya.Properties.Resources.lkI20BLTBdE;
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(875, 355);
            this.panel1.TabIndex = 0;
            // 
            // PersonManageBtn
            // 
            this.PersonManageBtn.Location = new System.Drawing.Point(239, 373);
            this.PersonManageBtn.Name = "PersonManageBtn";
            this.PersonManageBtn.Size = new System.Drawing.Size(131, 65);
            this.PersonManageBtn.TabIndex = 1;
            this.PersonManageBtn.Text = "Управление сотрудниками";
            this.PersonManageBtn.UseVisualStyleBackColor = true;
            this.PersonManageBtn.Click += new System.EventHandler(this.PersonManageBtn_Click);
            // 
            // CarViewInfoBtn
            // 
            this.CarViewInfoBtn.Location = new System.Drawing.Point(512, 373);
            this.CarViewInfoBtn.Name = "CarViewInfoBtn";
            this.CarViewInfoBtn.Size = new System.Drawing.Size(131, 65);
            this.CarViewInfoBtn.TabIndex = 2;
            this.CarViewInfoBtn.Text = "Управление транспортом";
            this.CarViewInfoBtn.UseVisualStyleBackColor = true;
            this.CarViewInfoBtn.Click += new System.EventHandler(this.CarViewInfoBtn_Click);
            // 
            // ForceViewBtn
            // 
            this.ForceViewBtn.Location = new System.Drawing.Point(376, 373);
            this.ForceViewBtn.Name = "ForceViewBtn";
            this.ForceViewBtn.Size = new System.Drawing.Size(130, 65);
            this.ForceViewBtn.TabIndex = 3;
            this.ForceViewBtn.Text = "Просмотр данных";
            this.ForceViewBtn.UseVisualStyleBackColor = true;
            this.ForceViewBtn.Click += new System.EventHandler(this.ForceViewBtn_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Kursovaya.Properties.Resources.lkI20BLTBdE;
            this.ClientSize = new System.Drawing.Size(899, 450);
            this.Controls.Add(this.ForceViewBtn);
            this.Controls.Add(this.CarViewInfoBtn);
            this.Controls.Add(this.PersonManageBtn);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.Text = "Park Control";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenu_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button PersonManageBtn;
        private System.Windows.Forms.Button CarViewInfoBtn;
        private System.Windows.Forms.Button ForceViewBtn;
    }
}