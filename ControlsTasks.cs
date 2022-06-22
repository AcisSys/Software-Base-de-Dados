using Syncfusion.WinForms.DataGridConverter;
using Syncfusion.XlsIO;
using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
namespace Software_Base_de_Dados
{
    public partial class ControlsTasks : UserControl
    {
        public ControlsTasks()
        {
            InitializeComponent();
        }
        public string Tabela;
        string querry;
        DataSet dset = new DataSet();
        DataSet dataSet = new DataSet();
        OleDbDataAdapter adapter;
        OleDbConnection connection = new OleDbConnection(Tables.Caminho);
        Tasks tasks = new Tasks();
        string currentT;
        Subtasks subtasks = new Subtasks();
        void UpdateTable()
        {
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
            /*querry = "SELECT tab_tasks.ID, tab_tasks.Descricao AS Tarefa, tab_subtasks.[Desc] AS SubTarefa, tab_places.Localizacao,"
                    + " tab_subtasks.Type AS Tipo,  tab_tasks.Active AS Ativo, tab_tasks.RefTag as Referencia "
                    + " FROM((tab_tasks LEFT OUTER JOIN "
                    + " tab_places ON tab_tasks.IDPlace = tab_places.ID) LEFT OUTER JOIN "
                    + " tab_subtasks ON tab_tasks.ID = tab_subtasks.IDTask) ";*/
            querry = "SELECT * FROM tab_tasks";
            dset.Reset();
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset);
            sfDataGrid1.DataSource = null;
            sfDataGrid1.DataSource = dset;
            Modify_Button.Enabled = false;
            Add_Button.Enabled = false;
            Remove_Button.Enabled = false;
            Exportar.Enabled = false;
            sfDataGrid1.Update();
            connection.Close();
        }
        void UpdateSubTasks()
        {
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
            querry = "SELECT ID , [Desc] AS Descrição, [Type] AS Tipo FROM tab_subtasks WHERE IDTask = " + (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
            dataSet.Reset();
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dataSet);
            sfDataGrid2.DataSource = null;
            sfDataGrid2.DataSource = dataSet;
            sfDataGrid2.Update();
            connection.Close();
        }
        private void ControlsTasks_Load(object sender, EventArgs e)
        {
            Add_Button.Enabled = false;
            Remove_Button.Enabled = false;
            Exportar.Enabled = false;
            Modify_Button.Enabled = false;
            // Check connection
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
            UpdateTable();
        }
        private void sfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            UpdateSubTasks();
            Add_Button.Enabled = true;
            Modify_Button.Enabled = true;
            Remove_Button.Enabled = true;
            Exportar.Enabled = true;
            currentT = "tasks";
            tasks.Id = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
            tasks.Descricao = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
            tasks.IdPlace = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2].ToString();
            if ( (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[3] == "Não")
            {
                tasks.Active = false;
            }
            else
            {
                tasks.Active = true;
            }
            string CheckNull = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[4].GetType().ToString();
            if (CheckNull != "Systyem.DBNull")
            {
                tasks.RefTag = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[4].ToString();
            }
        }
        private void sfDataGrid2_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            Modify_Button.Enabled = true;
            Add_Button.Enabled = true;
            Remove_Button.Enabled = true;
            Exportar.Enabled = true;
            currentT = "subtasks";
            subtasks.Id = (int)((DataRowView)sfDataGrid2.SelectedItem).Row.ItemArray[0];
            subtasks.Desc = (string)((DataRowView)sfDataGrid2.SelectedItem).Row.ItemArray[1].ToString();
            subtasks.IdTask = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
            subtasks.Tipo = (string)((DataRowView)sfDataGrid2.SelectedItem).Row.ItemArray[2].ToString();
        }
        private void Add_Button_Click(object sender, EventArgs e)
        {
            if (currentT == "tasks")
            {
                tasks.Tipo = "Add";
                tasks.ShowDialog();
                
                Add_Button.Enabled = false;
            }
            else if (currentT == "subtasks")
            {
                subtasks.ShowDialog();
                UpdateSubTasks();
                Add_Button.Enabled = false;
            }
            UpdateTable();
            sfDataGrid2.DataSource = null;
        }
        private void Modify_Button_Click(object sender, EventArgs e)
        {
            if (currentT == "tasks")
            {
                tasks.Tipo = "";
                tasks.ShowDialog();
            }
            else if (currentT == "subtasks")
            {
                subtasks.Tipo = "";
                subtasks.Text = "Modificar SubTarefas";
                subtasks.ShowDialog();
                UpdateSubTasks();
            }
            UpdateTable();
            sfDataGrid2.DataSource = null;
            Modify_Button.Enabled = false;
        }
        private void Exportar_Click(object sender, EventArgs e)
        {
            var excelEngine = new ExcelEngine();
            // exoport current shown table
            var options = new ExcelExportingOptions
            {
                ExcelVersion = ExcelVersion.Excel2013
            };
            if (currentT == "tasks")
            {
                excelEngine = sfDataGrid1.ExportToExcel(sfDataGrid1.View, options);
            }
            else
            {
                excelEngine = sfDataGrid2.ExportToExcel(sfDataGrid2.View, options);
            }
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
            Exportar.Enabled = false;
            UpdateTable();
            sfDataGrid2.DataSource = null;
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
            int deleteid;
            // Tabela is the name of the table 
            if (currentT == "tasks")
            {
                deleteid = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                querry = "UPDATE tab_tasks SET [Active] = @Active WHERE [ID] = " + deleteid;
                oleDbCommand = new OleDbCommand(querry, connection);
                oleDbCommand.Parameters.Add("@Active", OleDbType.LongVarChar).Value = "Não";
            }
            else
            {
                deleteid = (int)((DataRowView)sfDataGrid2.SelectedItem).Row.ItemArray[0];
                querry = "DELETE FROM tab_subtasks WHERE ID = " + deleteid;
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
            sfDataGrid2.DataSource = null;
            Modify_Button.Enabled = false;
            Remove_Button.Enabled = false;
        }
    }
}
