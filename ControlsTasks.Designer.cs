namespace Software_Base_de_Dados
{
    partial class ControlsTasks
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlsTasks));
            this.sfDataGrid1 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.Add_Button = new System.Windows.Forms.Button();
            this.Modify_Button = new System.Windows.Forms.Button();
            this.Exportar = new System.Windows.Forms.Button();
            this.sfDataGrid2 = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.Remove_Button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // sfDataGrid1
            // 
            this.sfDataGrid1.AccessibleName = "Table";
            this.sfDataGrid1.AllowEditing = false;
            this.sfDataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfDataGrid1.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            this.sfDataGrid1.Location = new System.Drawing.Point(3, 3);
            this.sfDataGrid1.Name = "sfDataGrid1";
            this.sfDataGrid1.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;
            this.sfDataGrid1.Size = new System.Drawing.Size(804, 452);
            this.sfDataGrid1.Style.AddNewRowStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sfDataGrid1.Style.HeaderStyle.Font.Bold = true;
            this.sfDataGrid1.Style.HeaderStyle.Font.Size = 11F;
            this.sfDataGrid1.TabIndex = 5;
            this.sfDataGrid1.Text = "sfDataGrid1";
            this.sfDataGrid1.SelectionChanged += new Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventHandler(this.sfDataGrid1_SelectionChanged);
            // 
            // Add_Button
            // 
            this.Add_Button.AccessibleDescription = "Button to add Entries to the Data Chart";
            this.Add_Button.AccessibleName = " Add Entries";
            this.Add_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Add_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Add_Button.Image = ((System.Drawing.Image)(resources.GetObject("Add_Button.Image")));
            this.Add_Button.Location = new System.Drawing.Point(808, 390);
            this.Add_Button.Name = "Add_Button";
            this.Add_Button.Size = new System.Drawing.Size(164, 65);
            this.Add_Button.TabIndex = 6;
            this.Add_Button.Text = "Adicionar";
            this.Add_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Add_Button.UseVisualStyleBackColor = true;
            this.Add_Button.Click += new System.EventHandler(this.Add_Button_Click);
            // 
            // Modify_Button
            // 
            this.Modify_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Modify_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Modify_Button.Enabled = false;
            this.Modify_Button.Image = ((System.Drawing.Image)(resources.GetObject("Modify_Button.Image")));
            this.Modify_Button.Location = new System.Drawing.Point(808, 461);
            this.Modify_Button.Name = "Modify_Button";
            this.Modify_Button.Size = new System.Drawing.Size(164, 65);
            this.Modify_Button.TabIndex = 7;
            this.Modify_Button.Text = "Modificar";
            this.Modify_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Modify_Button.UseVisualStyleBackColor = true;
            this.Modify_Button.Click += new System.EventHandler(this.Modify_Button_Click);
            // 
            // Exportar
            // 
            this.Exportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exportar.Image = ((System.Drawing.Image)(resources.GetObject("Exportar.Image")));
            this.Exportar.Location = new System.Drawing.Point(808, 3);
            this.Exportar.Name = "Exportar";
            this.Exportar.Size = new System.Drawing.Size(164, 65);
            this.Exportar.TabIndex = 9;
            this.Exportar.Text = "Exportar";
            this.Exportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Exportar.UseVisualStyleBackColor = true;
            this.Exportar.Click += new System.EventHandler(this.Exportar_Click);
            // 
            // sfDataGrid2
            // 
            this.sfDataGrid2.AccessibleName = "Table";
            this.sfDataGrid2.AllowEditing = false;
            this.sfDataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sfDataGrid2.AutoSizeColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoSizeColumnsMode.AllCells;
            this.sfDataGrid2.Location = new System.Drawing.Point(3, 461);
            this.sfDataGrid2.Name = "sfDataGrid2";
            this.sfDataGrid2.NavigationMode = Syncfusion.WinForms.DataGrid.Enums.NavigationMode.Row;
            this.sfDataGrid2.Size = new System.Drawing.Size(804, 139);
            this.sfDataGrid2.Style.AddNewRowStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.sfDataGrid2.Style.HeaderStyle.Font.Bold = true;
            this.sfDataGrid2.Style.HeaderStyle.Font.Size = 11F;
            this.sfDataGrid2.TabIndex = 10;
            this.sfDataGrid2.Text = "sfDataGrid2";
            this.sfDataGrid2.SelectionChanged += new Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventHandler(this.sfDataGrid2_SelectionChanged);
            // 
            // Remove_Button
            // 
            this.Remove_Button.AccessibleDescription = "To delete entries of the Data Chart";
            this.Remove_Button.AccessibleName = "Erase Button";
            this.Remove_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.Remove_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Remove_Button.Enabled = false;
            this.Remove_Button.Image = ((System.Drawing.Image)(resources.GetObject("Remove_Button.Image")));
            this.Remove_Button.Location = new System.Drawing.Point(808, 532);
            this.Remove_Button.Name = "Remove_Button";
            this.Remove_Button.Size = new System.Drawing.Size(164, 65);
            this.Remove_Button.TabIndex = 11;
            this.Remove_Button.Text = "Apagar";
            this.Remove_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Remove_Button.UseVisualStyleBackColor = true;
            this.Remove_Button.Click += new System.EventHandler(this.Remove_Button_Click);
            // 
            // ControlsTasks
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.Remove_Button);
            this.Controls.Add(this.sfDataGrid2);
            this.Controls.Add(this.Exportar);
            this.Controls.Add(this.Modify_Button);
            this.Controls.Add(this.Add_Button);
            this.Controls.Add(this.sfDataGrid1);
            this.Name = "ControlsTasks";
            this.Size = new System.Drawing.Size(975, 600);
            this.Load += new System.EventHandler(this.ControlsTasks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sfDataGrid2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid1;
        private System.Windows.Forms.Button Add_Button;
        private System.Windows.Forms.Button Modify_Button;
        private System.Windows.Forms.Button Exportar;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDataGrid2;
        private System.Windows.Forms.Button Remove_Button;
    }
}
