namespace TestTask
{
    partial class AppForm
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
            this.Log = new System.Windows.Forms.TextBox();
            this.defs_label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.defs_file_name = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hierarchy_label = new System.Windows.Forms.Label();
            this.hierarchy_file_name = new System.Windows.Forms.TextBox();
            this.OpenDataDialog = new System.Windows.Forms.OpenFileDialog();
            this.panel3 = new System.Windows.Forms.Panel();
            this.TextBox_CurrentTime = new System.Windows.Forms.TextBox();
            this.Time_label = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SaveDataDialog = new System.Windows.Forms.SaveFileDialog();
            this.CalculateButton = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Log
            // 
            this.Log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Log.BackColor = System.Drawing.SystemColors.Control;
            this.Log.Location = new System.Drawing.Point(0, 218);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(390, 150);
            this.Log.TabIndex = 0;
            this.Log.WordWrap = false;
            // 
            // defs_label
            // 
            this.defs_label.AutoSize = true;
            this.defs_label.Dock = System.Windows.Forms.DockStyle.Left;
            this.defs_label.Location = new System.Drawing.Point(0, 5);
            this.defs_label.Name = "defs_label";
            this.defs_label.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.defs_label.Size = new System.Drawing.Size(85, 17);
            this.defs_label.TabIndex = 1;
            this.defs_label.Text = "Список вершин";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.defs_label);
            this.panel2.Controls.Add(this.defs_file_name);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel2.Size = new System.Drawing.Size(366, 33);
            this.panel2.TabIndex = 11;
            // 
            // defs_file_name
            // 
            this.defs_file_name.Dock = System.Windows.Forms.DockStyle.Right;
            this.defs_file_name.Location = new System.Drawing.Point(141, 5);
            this.defs_file_name.Name = "defs_file_name";
            this.defs_file_name.Size = new System.Drawing.Size(225, 20);
            this.defs_file_name.TabIndex = 0;
            this.defs_file_name.Text = "Выберите файл...";
            this.defs_file_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.defs_file_name.Click += new System.EventHandler(this.defs_file_name_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hierarchy_label);
            this.panel1.Controls.Add(this.hierarchy_file_name);
            this.panel1.Location = new System.Drawing.Point(12, 51);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(366, 33);
            this.panel1.TabIndex = 11;
            // 
            // hierarchy_label
            // 
            this.hierarchy_label.AutoSize = true;
            this.hierarchy_label.Dock = System.Windows.Forms.DockStyle.Left;
            this.hierarchy_label.Location = new System.Drawing.Point(0, 5);
            this.hierarchy_label.Name = "hierarchy_label";
            this.hierarchy_label.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.hierarchy_label.Size = new System.Drawing.Size(97, 17);
            this.hierarchy_label.TabIndex = 1;
            this.hierarchy_label.Text = "Иерархия вершин";
            // 
            // hierarchy_file_name
            // 
            this.hierarchy_file_name.Dock = System.Windows.Forms.DockStyle.Right;
            this.hierarchy_file_name.Location = new System.Drawing.Point(141, 5);
            this.hierarchy_file_name.Name = "hierarchy_file_name";
            this.hierarchy_file_name.Size = new System.Drawing.Size(225, 20);
            this.hierarchy_file_name.TabIndex = 0;
            this.hierarchy_file_name.Text = "Выберите файл...";
            this.hierarchy_file_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.hierarchy_file_name.Click += new System.EventHandler(this.hierarchy_file_name_Click);
            // 
            // OpenDataDialog
            // 
            this.OpenDataDialog.Filter = "Data files (*.txt)|*.txt";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.TextBox_CurrentTime);
            this.panel3.Controls.Add(this.Time_label);
            this.panel3.Location = new System.Drawing.Point(12, 90);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel3.Size = new System.Drawing.Size(366, 33);
            this.panel3.TabIndex = 15;
            // 
            // TextBox_CurrentTime
            // 
            this.TextBox_CurrentTime.Dock = System.Windows.Forms.DockStyle.Right;
            this.TextBox_CurrentTime.Location = new System.Drawing.Point(266, 5);
            this.TextBox_CurrentTime.Name = "TextBox_CurrentTime";
            this.TextBox_CurrentTime.Size = new System.Drawing.Size(100, 20);
            this.TextBox_CurrentTime.TabIndex = 2;
            this.TextBox_CurrentTime.Text = "0.0";
            this.TextBox_CurrentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBox_CurrentTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBox_CurrentTime_KeyPress);
            // 
            // Time_label
            // 
            this.Time_label.AutoSize = true;
            this.Time_label.Dock = System.Windows.Forms.DockStyle.Left;
            this.Time_label.Location = new System.Drawing.Point(0, 5);
            this.Time_label.Name = "Time_label";
            this.Time_label.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.Time_label.Size = new System.Drawing.Size(73, 17);
            this.Time_label.TabIndex = 1;
            this.Time_label.Text = "Время кадра";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(233, 146);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(145, 23);
            this.SaveButton.TabIndex = 16;
            this.SaveButton.Text = "Сохранить результат";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SaveDataDialog
            // 
            this.SaveDataDialog.Filter = "Data files (*.txt)|*.txt";
            // 
            // CalculateButton
            // 
            this.CalculateButton.Location = new System.Drawing.Point(12, 146);
            this.CalculateButton.Name = "CalculateButton";
            this.CalculateButton.Size = new System.Drawing.Size(145, 23);
            this.CalculateButton.TabIndex = 16;
            this.CalculateButton.Text = "Расчет";
            this.CalculateButton.UseVisualStyleBackColor = true;
            this.CalculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(390, 368);
            this.Controls.Add(this.CalculateButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Log);
            this.Name = "AppForm";
            this.Text = "TestTask2";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Log;
        private System.Windows.Forms.Label defs_label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label hierarchy_label;
        private System.Windows.Forms.TextBox hierarchy_file_name;
        private System.Windows.Forms.OpenFileDialog OpenDataDialog;
        private System.Windows.Forms.TextBox defs_file_name;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Time_label;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.SaveFileDialog SaveDataDialog;
        private System.Windows.Forms.Button CalculateButton;
        private System.Windows.Forms.TextBox TextBox_CurrentTime;
    }
}

