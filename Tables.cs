using Syncfusion.WinForms.DataGridConverter;
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
            if (Tabela == "tab_tasks")
            {
                querry = "SELECT tab_tasks.ID, tab_tasks.Descricao AS Tarefa, tab_subtasks.[Desc] AS SubTarefa, tab_places.Localizacao," 
                    + " tab_subtasks.Type AS Tipo,  tab_tasks.Active AS Ativo, tab_tasks.RefTag as Referencia " 
                    + " FROM((tab_tasks LEFT OUTER JOIN " 
                    + " tab_places ON tab_tasks.IDPlace = tab_places.ID) LEFT OUTER JOIN " 
                    + " tab_subtasks ON tab_tasks.ID = tab_subtasks.IDTask) ";
                dset.Reset();
                adapter = new OleDbDataAdapter(querry, connection);
                adapter.Fill(dset);
                sfDataGrid1.DataSource = dset;
            }
            else if (Tabela == "tab_agend")
            {
                querry = "SELECT tab_agend.ID, tab_teams.Descricao AS Equipa, tab_tasks.Descricao AS Tarefa " 
                    + " FROM((tab_agend LEFT JOIN " 
                    + " tab_tasks ON tab_agend.idtask = tab_tasks.ID) LEFT JOIN " 
                    + " tab_teams ON tab_agend.idequipa = tab_teams.ID) ";
                dset.Reset();
                adapter = new OleDbDataAdapter(querry, connection);
                adapter.Fill(dset);
                sfDataGrid1.DataSource = dset;
            }
            else if (Tabela == "tab_workers")
            {
                querry = " SELECT tab_workers.ID, tab_workers.Nome, tab_teams.Descricao AS Equipa, tab_workers.img, tab_workers.Cod " 
                    + " FROM(tab_workers INNER JOIN " 
                    + " tab_teams ON tab_workers.IDEquipa = tab_teams.ID) ";
                dset.Reset();
                adapter = new OleDbDataAdapter(querry, connection);
                adapter.Fill(dset);
                sfDataGrid1.DataSource = dset;
            }
            else if (Tabela == "tab_tags")
            {
                querry = "SELECT ID, Ref AS Referencia, taken AS Utilizado FROM tab_tags";
                dset.Reset();
                adapter = new OleDbDataAdapter(querry, connection);
                adapter.Fill(dset);
                sfDataGrid1.DataSource = dset;
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
            // check connection
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
            if (Tabela == "tab_tasks")
            {
                deleteid = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                querry = "UPDATE tab_tasks SET [Active] = @Active WHERE [ID] = " + deleteid;
                oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@Active", OleDbType.LongVarChar).Value = "Não";
            }
            else
            {
                querry = "DELETE FROM " + Tabela + " WHERE ID = " + deleteid;
                oleDbCommand = new OleDbCommand(querry, connection);
            }
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
            // check connection
            // checks if values are null or not, and gets data from the row of the according table
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
                string CheckNull = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1].GetType().ToString();
                if (CheckNull != "System.DBNull")
                {
                    places.Localizacao = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                    places.X = ((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2].ToString();
                    places.Y = ((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[3].ToString();
                }
            }
            else if (Tabela == "tab_tasks")
            {
                tasks.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                string CheckNull = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[4].GetType().ToString();
                if (CheckNull != "Sytem.DBNull")
                {
                    tasks.Descricao = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[4];
                }
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
                    //tasks.IDPlace = oleDbCommand.ExecuteScalar().ToString();
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
                tags.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
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
                    querry = "SELECT ID FROM tab_teams WHERE Descricao = '" + (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2] + "'";
                    OleDbCommand command = new OleDbCommand(querry, connection);
                    workers.IDEquipa = command.ExecuteScalar().ToString();
                }
            }
            else
            {
                subtasks.IDTask = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                string CheckNull = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2].GetType().ToString();
                if (CheckNull != "Sytem.DBNull")
                {
                    subtasks.Desc = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2];
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
        private void SfDataGrid1_DoubleClick(object sender, EventArgs e)
        {
            // On Double click (tasks only)
            // Shows subtasks modify window
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
                string checktype = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[3].GetType().ToString();
                if (checktype != "Syste,.DBNull")
                {
                    if (OtherCheck != "System.DBNull")
                    {
                        querry = "SELECT ID FROM tab_subtasks WHERE IDTask = " + (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0] + " AND Desc = \"" + (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2] + "\"";
                        OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
                        subtasks.ID = (int)oleDbCommand.ExecuteScalar();
                        subtasks.IDTask = tasks.ID;
                        subtasks.Desc = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2];
                        subtasks.Type = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[3];
                    }
                }
                subtasks.ShowDialog();
            }
        }
        private void Subtbtn_Click(object sender, EventArgs e)
        {
            // on button click (tasks only)
            // adds a subtask
            if (Tabela == "tab_tasks")
            {
                subtasks.Tipo = "Add";
                subtasks.Text = "Adicionar SubTarefas";
                subtasks.ShowDialog();
                UpdateTable();
            }
        }
    }
}
