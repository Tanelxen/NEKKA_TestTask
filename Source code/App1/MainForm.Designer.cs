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
            this.data_label = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.data_file_name = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.args_label = new System.Windows.Forms.Label();
            this.args_file_name = new System.Windows.Forms.TextBox();
            this.OpenDataDialog = new System.Windows.Forms.OpenFileDialog();
            this.InterpolatorsComboBox = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.type_label = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SaveDataDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Log
            // 
            this.Log.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Log.BackColor = System.Drawing.SystemColors.Control;
            this.Log.Location = new System.Drawing.Point(0, 205);
            this.Log.Multiline = true;
            this.Log.Name = "Log";
            this.Log.ReadOnly = true;
            this.Log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Log.Size = new System.Drawing.Size(331, 149);
            this.Log.TabIndex = 0;
            // 
            // data_label
            // 
            this.data_label.AutoSize = true;
            this.data_label.Dock = System.Windows.Forms.DockStyle.Left;
            this.data_label.Location = new System.Drawing.Point(0, 5);
            this.data_label.Name = "data_label";
            this.data_label.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.data_label.Size = new System.Drawing.Size(48, 17);
            this.data_label.TabIndex = 1;
            this.data_label.Text = "Данные";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.data_label);
            this.panel2.Controls.Add(this.data_file_name);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel2.Size = new System.Drawing.Size(305, 33);
            this.panel2.TabIndex = 11;
            // 
            // data_file_name
            // 
            this.data_file_name.Dock = System.Windows.Forms.DockStyle.Right;
            this.data_file_name.Location = new System.Drawing.Point(80, 5);
            this.data_file_name.Name = "data_file_name";
            this.data_file_name.Size = new System.Drawing.Size(225, 20);
            this.data_file_name.TabIndex = 0;
            this.data_file_name.Text = "Выберите файл...";
            this.data_file_name.Click += new System.EventHandler(this.data_file_name_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.args_label);
            this.panel1.Controls.Add(this.args_file_name);
            this.panel1.Location = new System.Drawing.Point(12, 51);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel1.Size = new System.Drawing.Size(305, 33);
            this.panel1.TabIndex = 11;
            // 
            // args_label
            // 
            this.args_label.AutoSize = true;
            this.args_label.Dock = System.Windows.Forms.DockStyle.Left;
            this.args_label.Location = new System.Drawing.Point(0, 5);
            this.args_label.Name = "args_label";
            this.args_label.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.args_label.Size = new System.Drawing.Size(63, 17);
            this.args_label.TabIndex = 1;
            this.args_label.Text = "Аргументы";
            // 
            // args_file_name
            // 
            this.args_file_name.Dock = System.Windows.Forms.DockStyle.Right;
            this.args_file_name.Location = new System.Drawing.Point(80, 5);
            this.args_file_name.Name = "args_file_name";
            this.args_file_name.Size = new System.Drawing.Size(225, 20);
            this.args_file_name.TabIndex = 0;
            this.args_file_name.Text = "Выберите файл...";
            this.args_file_name.Click += new System.EventHandler(this.args_file_name_Click);
            // 
            // OpenDataDialog
            // 
            this.OpenDataDialog.Filter = "Data files (*.txt)|*.txt";
            // 
            // InterpolatorsComboBox
            // 
            this.InterpolatorsComboBox.FormattingEnabled = true;
            this.InterpolatorsComboBox.Location = new System.Drawing.Point(80, 5);
            this.InterpolatorsComboBox.Name = "InterpolatorsComboBox";
            this.InterpolatorsComboBox.Size = new System.Drawing.Size(225, 21);
            this.InterpolatorsComboBox.TabIndex = 14;
            this.InterpolatorsComboBox.SelectedIndexChanged += new System.EventHandler(this.InterpolatorsComboBox_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.type_label);
            this.panel3.Controls.Add(this.InterpolatorsComboBox);
            this.panel3.Location = new System.Drawing.Point(12, 90);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panel3.Size = new System.Drawing.Size(305, 33);
            this.panel3.TabIndex = 15;
            // 
            // type_label
            // 
            this.type_label.AutoSize = true;
            this.type_label.Dock = System.Windows.Forms.DockStyle.Left;
            this.type_label.Location = new System.Drawing.Point(0, 5);
            this.type_label.Name = "type_label";
            this.type_label.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.type_label.Size = new System.Drawing.Size(26, 17);
            this.type_label.TabIndex = 1;
            this.type_label.Text = "Тип";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 149);
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
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(331, 353);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.Log);
            this.Name = "AppForm";
            this.Text = "TestTask1";
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
        private System.Windows.Forms.Label data_label;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label args_label;
        private System.Windows.Forms.TextBox args_file_name;
        private System.Windows.Forms.OpenFileDialog OpenDataDialog;
        private System.Windows.Forms.ComboBox InterpolatorsComboBox;
        private System.Windows.Forms.TextBox data_file_name;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label type_label;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.SaveFileDialog SaveDataDialog;
    }
}

