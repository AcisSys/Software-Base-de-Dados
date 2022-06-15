using Syncfusion.WinForms.DataGrid.Enums;
using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.XlsIO;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
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
        private void SfDataGrid1_QueryRowStyle(object sender, Syncfusion.WinForms.DataGrid.Events.QueryRowStyleEventArgs e)
        {
            if (e.RowType == RowType.DefaultRow)
            {
                if (e.RowIndex % 2 == 0)
                    e.Style.BackColor = Color.WhiteSmoke;
                else
                    e.Style.BackColor = Color.White;
            }
        }
        public static string Caminho { get; set; }
        OleDbConnection connection = new OleDbConnection(Tables.Caminho);
        Agend agend = new Agend();
        Places places = new Places();
        Tags tags = new Tags();
        Tasks tasks = new Tasks();
        Teams teams = new Teams();
        Workers workers = new Workers();
        Subtasks subtasks = new Subtasks();
        OleDbDataAdapter adapter;
        public string Tabela { get; set; }
        string querry;
        private void Tables_Load(object sender, EventArgs e)
        {
            Modify_Button.Enabled = false;
            Remove_Button.Enabled = false;
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
            if (Tabela == "tab_tasks")
            {
                DataSet1TableAdapters.DataTable1TableAdapter dadapter = new DataSet1TableAdapters.DataTable1TableAdapter();
                DataSet1.DataTable1DataTable dt = new DataSet1.DataTable1DataTable();
                dadapter.Fill(dt);
                sfDataGrid1.DataSource = null;
                sfDataGrid1.DataSource = dt;
                // sfDataGrid1.Columns.Add(new GridButtonColumn() { MappingName = "Adicionar SubTarefa", });
            }
            else if (Tabela == "tab_agend")
            {
                DataSet1TableAdapters.DataTable2TableAdapter dadapter = new DataSet1TableAdapters.DataTable2TableAdapter();
                DataSet1.DataTable2DataTable dt = new DataSet1.DataTable2DataTable();
                dadapter.Fill(dt);
                sfDataGrid1.DataSource = null;
                sfDataGrid1.DataSource = dt;
            }
            else if (Tabela == "tab_workers")
            {
                DataSet1TableAdapters.DataTable3TableAdapter dadapter = new DataSet1TableAdapters.DataTable3TableAdapter();
                DataSet1.DataTable3DataTable dt = new DataSet1.DataTable3DataTable();
                dadapter.Fill(dt);
                sfDataGrid1.DataSource = null;
                sfDataGrid1.DataSource = dt;
            }
            else if (Tabela == "tab_tags")
            {
                DataSet1TableAdapters.tab_tagsTableAdapter dadapter = new DataSet1TableAdapters.tab_tagsTableAdapter();
                DataSet1.tab_tagsDataTable dt = new DataSet1.tab_tagsDataTable();
                dadapter.Fill(dt);
                sfDataGrid1.DataSource = null;
                sfDataGrid1.DataSource = dt;
            }
            else
            {
                querry = "SELECT * FROM " + Tabela;
                dset.Reset();
                adapter = new OleDbDataAdapter(querry, connection);
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
            else if (Tabela == "tab_tasks")
            {
                tasks.Tipo = "Add";
                tasks.ShowDialog();
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
            else if (Tabela == "tab_tasks")
            {
                tasks.Tipo = "";
                tasks.ShowDialog();
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
            OleDbCommand oleDbCommand;
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
            int deleteid = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];

            // Tabela is the name of the table 
            querry = "DELETE FROM " + Tabela + " WHERE ID = " + deleteid;
            oleDbCommand = new OleDbCommand(querry, connection);
            if (response == DialogResult.Yes)
            {
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                    int rowsChanged = oleDbCommand.ExecuteNonQuery();
                    // Says that data was deleted
                    MessageBox.Show("Dados apagados com sucesso", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Gives Error Message
                    MessageBox.Show("Não foi possivel apagar os dados.\n " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // Cancels the Action
                MessageBox.Show("Cancelado", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            // Updates the DataGridView
            UpdateTable();
            Modify_Button.Enabled = false;
            Remove_Button.Enabled = false;
        }
        private void SfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
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
                string IdTeamsCheck = ((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1].GetType().ToString();
                if (IdTeamsCheck != "System.DBNull")
                {
                    string location = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                    querry = "SELECT ID FROM tab_teams WHERE Descricao =  \"" + location + "\"";
                    OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                    agend.Idequipa = oleDbCommand.ExecuteScalar().ToString();
                }
                string IdTasksCheck = ((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2].GetType().ToString();
                if (IdTasksCheck != "System.DBNull")
                {
                    string location = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2];
                    querry = "SELECT ID FROM tab_tasks WHERE Descricao = \"" + location + "\"";
                    OleDbCommand ocommand = new OleDbCommand(querry, connection);
                    agend.Idtask = ocommand.ExecuteScalar().ToString();
                }
            }
            else if (Tabela == "tab_places")
            {
                places.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                places.Localizacao = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                places.X = ((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2].ToString();
                places.Y = ((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[3].ToString();
            }
            else if (Tabela == "tab_tasks")
            {
                tasks.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                tasks.Descricao = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[4];
                string ActiveCheck = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[5].ToString();
                if (ActiveCheck == "Não")
                {
                    tasks.Active = false;
                }
                else
                {
                    tasks.Active = true;
                }
                string IdRefCheck = ((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[6].GetType().ToString();
                if (IdRefCheck != "System.DBNull")
                {
                    tasks.RefTag = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[6].ToString();
                }
                string IdPlaceCheck = ((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1].GetType().ToString();
                if (IdPlaceCheck != "System.DBNull" && IdPlaceCheck != "null")
                {
                    string location = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                    querry = "SELECT ID FROM tab_places WHERE Localizacao =  \"" + location + "\"";
                    OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                    tasks.IDPlace = oleDbCommand.ExecuteScalar().ToString();
                }
            }
            else if (Tabela == "tab_teams")
            {
                teams.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                teams.Descricao = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
            }
            else if (Tabela == "tab_tags")
            {
                tags.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                tags.Ref = Convert.ToInt32(((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1]);
            }
            else if (Tabela == "tab_workers")
            {
                workers.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                workers.Name = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                workers.Cod = ((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[3].ToString();
                querry = "SELECT ID FROM tab_teams WHERE Descricao = '" + (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[4] + "'";
                OleDbCommand command = new OleDbCommand(querry, connection);
                workers.IDEquipa = command.ExecuteScalar().ToString();
            }
            else
            {
                subtasks.IDTask = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                subtasks.Desc = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2];
            }
        }
        private void Exportar_Click(object sender, EventArgs e)
        {
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
        private void SfDataGrid1_DoubleClick(object sender, EventArgs e)
        {
            if (Tabela == "tab_tasks")
            {
                Subtasks subtasks = new Subtasks();
                subtasks.ShowDialog();
            }
        }
        private void SfDataGrid1_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            if (Tabela == "tab_tasks")
            {
                string querry;
                string OtherCheck = ((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2].GetType().ToString();
                if (OtherCheck != "System.DBNull")
                {
                    querry = "SELECT ID FROM tab_subtasks WHERE IDTask = " + (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0] + " AND Desc = \"" + (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2] + "\"";
                    OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                    subtasks.ID = (int)oleDbCommand.ExecuteScalar();
                    subtasks.IDTask = tasks.ID;
                    subtasks.Desc = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2];
                    subtasks.Type = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[3];
                }
                subtasks.ShowDialog();
            }
        }

        private void Subtbtn_Click(object sender, EventArgs e)
        {
            if (Tabela == "tab_tasks")
            {
                subtasks.Tipo = "Add";
                subtasks.Text = "Adicionar SubTarefas";
                subtasks.ShowDialog();
                UpdateTable();
            }
        }

        private void sfDataGrid1_Click(object sender, EventArgs e)
        {

        }
    }
}
