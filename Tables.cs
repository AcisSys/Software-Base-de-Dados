﻿using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.XlsIO;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
namespace Software_Base_de_Dados
{
    public partial class Tables : UserControl
    {
        public Tables()
        {
            InitializeComponent();
        }
        public static string Caminho { get; set; }
        public string Tabela { get; set; }
        OleDbConnection connection = new OleDbConnection(Tables.Caminho);
        Agend agend = new Agend();
        Places places = new Places();
        Tags tags = new Tags();
        Teams teams = new Teams();
        Workers workers = new Workers();
        Subtasks subtasks = new Subtasks();
        OleDbDataAdapter adapter;
        OleDbCommand oleDbCommand;
        string query;
        int deleteid;
        private void Tables_Load(object sender, EventArgs e)
        {
            Modify_Button.Enabled = false;
            Remove_Button.Enabled = false;
            // Check connection
            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection.ConnectionString = Caminho;
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        public void UpdateTable()
        {
            // Check connection
            // Gets Table for the table to be shown accordingly
            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection.ConnectionString = Caminho;
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            DataSet dset = new DataSet();
            if (Tabela == "tab_agend")
            {
                query = "SELECT tab_agend.ID AS Id, tab_teams.Descricao AS Equipa, tab_tasks.Descricao AS Tarefa "
                    + " FROM((tab_agend LEFT JOIN "
                    + " tab_tasks ON tab_agend.idtask = tab_tasks.ID) LEFT JOIN "
                    + " tab_teams ON tab_agend.idequipa = tab_teams.ID) ";
                dset.Reset();
                adapter = new OleDbDataAdapter(query, connection);
                adapter.Fill(dset);
                sfDataGrid1.DataSource = dset;
            }
            else if (Tabela == "tab_workers")
            {
                query = " SELECT tab_workers.ID AS Id, tab_workers.Nome, tab_teams.Descricao AS Equipa, tab_workers.img AS Imagem, tab_workers.Cod AS Código"
                    + " FROM(tab_workers INNER JOIN "
                    + " tab_teams ON tab_workers.IDEquipa = tab_teams.ID) ";
                dset.Reset();
                adapter = new OleDbDataAdapter(query, connection);
                adapter.Fill(dset);
                sfDataGrid1.DataSource = dset;
            }
            else if (Tabela == "tab_tags")
            {
                query = "SELECT ID AS Id, Ref AS Referência, taken AS Usado FROM tab_tags";
                dset.Reset();
                adapter = new OleDbDataAdapter(query, connection);
                adapter.Fill(dset);
                sfDataGrid1.DataSource = dset;
            }
            else if (Tabela == "tab_places")
            {
                query = "SELECT ID AS Id, LocaLizacao As Localização, X, Y FROM tab_places";
                dset.Reset();
                adapter = new OleDbDataAdapter(query, connection);
                adapter.Fill(dset);
                sfDataGrid1.DataSource = dset;
            }
            else if (Tabela == "tab_teams")
            {
                query = "SELECT ID AS Id, Descricao As Descrição FROM tab_teams";
                dset.Reset();
                adapter = new OleDbDataAdapter(query, connection);
                adapter.Fill(dset);
                sfDataGrid1.DataSource = dset;
            }
            else
            {
                query = "SELECT * FROM " + Tabela;
                dset.Reset();
                adapter = new OleDbDataAdapter(query, connection);
                adapter.Fill(dset);
                sfDataGrid1.DataSource = dset;
            }
            Modify_Button.Enabled = false;
            Remove_Button.Enabled = false;
            sfDataGrid1.Update();
            connection.Close();
        }
        private void Add_Button_Click(object sender, EventArgs e)
        {
            // check connection
            // specify action (add data) and shows window
            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Modify_Button.Enabled = false;
            Remove_Button.Enabled = false;
            if (Tabela == "tab_agend")
            {
                agend.Tipo = "Add";
                agend.ShowDialog();
            }
            else if (Tabela == "tab_places")
            {
                places.Tipo = "Add";
                places.ShowDialog();
            }
            else if (Tabela == "tab_tags")
            {
                tags.Tipo = "Add";
                tags.ShowDialog();
            }
            else if (Tabela == "tab_teams")
            {
                teams.Tipo = "Add";
                teams.ShowDialog();
            }
            else
            {
                workers.Tipo = "Add";
                workers.ShowDialog();
            }
            UpdateTable();
        }
        private void Modify_Button_Click(object sender, EventArgs e)
        {
            // check connection
            // specify action (modify data) and shows window
            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            if (Tabela == "tab_agend")
            {
                agend.Tipo = "";
                agend.ShowDialog();
            }
            else if (Tabela == "tab_places")
            {
                places.Tipo = "";
                places.ShowDialog();
            }
            else if (Tabela == "tab_tags")
            {
                tags.Tipo = "";
                tags.ShowDialog();
            }
            else if (Tabela == "tab_teams")
            {
                teams.Tipo = "";
                teams.ShowDialog();
            }
            else
            {
                workers.Tipo = "";
                workers.ShowDialog();
            }
            UpdateTable();
            Modify_Button.Enabled = false;
            Remove_Button.Enabled = false;
        }
        private void Remove_Button_Click(object sender, EventArgs e)
        {
            // check connection

            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection.ConnectionString = Tables.Caminho;
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            // Ask for Confirmation
            DialogResult response = MessageBox.Show("Tem a certeza?", "Apagar?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            // ID of the row
            deleteid = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
            // Tabela is the name of the table 

            query = "DELETE FROM " + Tabela + " WHERE ID = " + deleteid;
            oleDbCommand = new OleDbCommand(query, connection);

            if (response == DialogResult.Yes)
            {
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                    // Says that data was deleted
                    MessageBox.Show("Dados apagados com sucesso", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Gives error message.
                    MessageBox.Show("Não foi possivel apagar os dados.\n " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // Cancels the action.
                MessageBox.Show("Cancelado", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Updates the DataGridView.
            UpdateTable();
            Modify_Button.Enabled = false;
            Remove_Button.Enabled = false;
        }
        private void SfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            // Check connection.
            // Checks if values are null or not, and gets data from the row of the according table.
            if (connection.State == ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            Modify_Button.Enabled = true;
            Remove_Button.Enabled = true;
            DataSet ds = new DataSet();
            ds.Reset();
            if (Tabela == "tab_agend")
            {
                agend.Id = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
            }
            else if (Tabela == "tab_places")
            {
                places.Id = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                string CheckNull = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1].GetType().ToString();
                if (CheckNull != "System.DBNull")
                {
                    places.Localizacao = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                    places.X = ((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2].ToString();
                    places.Y = ((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[3].ToString();
                }

            }
            else if (Tabela == "tab_teams")
            {
                teams.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                string CheckNull = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1].GetType().ToString();
                if (CheckNull != "Systyem.DBNull")
                {
                    teams.Descricao = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                }
            }
            else if (Tabela == "tab_tags")
            {
                tags.Id = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                string CheckNull = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1].GetType().ToString();
                if (CheckNull != "System.DBNull")
                {
                    tags.Ref = Convert.ToInt32(((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1]);
                }
            }
            else if (Tabela == "tab_workers")
            {
                workers.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                string CheckNull = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1].GetType().ToString();
                if (CheckNull != "System.DBNull")
                {
                    workers.Name = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                    workers.Cod = ((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[4].ToString();
                    query = "SELECT ID FROM tab_teams WHERE Descricao = '" + (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2] + "'";
                    oleDbCommand = new OleDbCommand(query, connection);
                    workers.IdEquipa = oleDbCommand.ExecuteScalar().ToString();
                }
            }

        }
        private void Exportar_Click(object sender, EventArgs e)
        {
            // exoport current shown table
            var options = new ExcelExportingOptions
            {
                ExcelVersion = ExcelVersion.Excel2013
            };
            var excelEngine = sfDataGrid1.ExportToExcel(sfDataGrid1.View, options);
            var workBook = excelEngine.Excel.Workbooks[0];
            SaveFileDialog saveFilterDialog = new SaveFileDialog
            {
                FilterIndex = 2,
                Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx|Excel 2013 File(*.xlsx)|*.xlsx"
            };
            if (saveFilterDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream stream = saveFilterDialog.OpenFile())
                {
                    if (saveFilterDialog.FilterIndex == 1)
                        workBook.Version = ExcelVersion.Excel97to2003;
                    else if (saveFilterDialog.FilterIndex == 2)
                        workBook.Version = ExcelVersion.Excel2010;
                    else
                        workBook.Version = ExcelVersion.Excel2013;
                    workBook.SaveAs(stream);
                }
                if (MessageBox.Show(this.sfDataGrid1, "Quer guardar esta exportação?", "Exportação Excel",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(saveFilterDialog.FileName);
                }
            }
        }
    }
}
