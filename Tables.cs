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

        // String do caminho do ficheiro

        static readonly string caminho = @"Provider = Microsoft.ACE.OLEDB.12.0;
                        Data Source = WORK2GOData.accdb;
        Jet OLEDB:Database Password = ogednom ";

        // Conexão

        public readonly OleDbConnection connection = new OleDbConnection(caminho);

        // DataSet para as tabelas

        DataSet dset = new DataSet();

        // Adaptador para o DataSet

        OleDbDataAdapter adapter = new OleDbDataAdapter();

        Agend agend = new Agend();
        Places places = new Places();
        Subtasks subtasks = new Subtasks();
        Tags tags = new Tags();
        Tasks tasks = new Tasks();
        Teams teams = new Teams();
        Workers workers = new Workers();


        // String publica para dar a conhecer a table que está a ser visualisada

        public string Tabela { get; set; }

        private void Tables_Load(object sender, EventArgs e)
        {
            Modify_Button.Enabled = false;
            Remove_Button.Enabled = false;

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
        }


        // Função para atualizar as tabelas

        public void UpdateTable()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel connectar á base de dados\n" + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }



            string querry;
            if (Tabela == "tab_agend")
            {
                querry = "SELECT tab_agend.ID, tab_teams.Descricao," +
                    " tab_agend.idtask " +
                " FROM tab_teams INNER JOIN tab_agend " +
                "ON tab_teams.ID = tab_agend.idequipa;";
            }
            else { querry = "SELECT * FROM " + Tabela; }


            dset.Reset();
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "table");
















            sfDataGrid1.DataSource = null;
            sfDataGrid1.DataSource = dset.Tables["table"];
            sfDataGrid1.Update();

            connection.Close();


        }

        private void Add_Button_Click(object sender, EventArgs e)
        {

            if (Tabela == "tab_agend")
            {
                Agend agend = new Agend
                {
                    Tipo = "Add"
                };
                agend.ShowDialog();
            }
            if (Tabela == "tab_places")
            {

                places.Tipo = "Add";

                places.ShowDialog();
            }
            if (Tabela == "tab_tasks")
            {
                tasks.Tipo = "Add";

                tasks.ShowDialog();
            }
            if (Tabela == "tab_subtasks")
            {
                subtasks.Tipo = "Add";
                subtasks.ShowDialog();
            }
            if (Tabela == "tab_tags")
            {
                tags.Tipo = "Add";
                tags.ShowDialog();
            }
            if (Tabela == "tab_teams")
            {
                teams.Tipo = "Add";
                teams.ShowDialog();
            }
            if (Tabela == "tab_workers")
            {
                workers.Tipo = "Add";
                workers.ShowDialog();
            }
            // chama a form para adicionar campos a tabela
            // Update á tabela quando retorna ao usercontrol
            UpdateTable();
        }
        private void Modify_Button_Click(object sender, EventArgs e)
        {
            // chama a form para modificar campos da tabela
            if (Tabela == "tab_agend")
            {
                agend.Tipo = "";
                agend.ShowDialog();
            }
            if (Tabela == "tab_places")
            {
                places.Tipo = "";
                places.ShowDialog();
            }
            if (Tabela == "tab_tasks")
            {
                tasks.Tipo = "";
                tasks.ShowDialog();
            }
            if (Tabela == "tab_subtasks")
            {
                subtasks.Tipo = "";
                subtasks.ShowDialog();
            }
            if (Tabela == "tab_tags")
            {
                tags.Tipo = "";
                tags.ShowDialog();
            }
            if (Tabela == "tab_teams")
            {
                teams.Tipo = "";
                teams.ShowDialog();
            }
            if (Tabela == "tab_workers")
            {
                workers.Tipo = "";
                workers.ShowDialog();
            }
            // Update á tabela quando retorna ao usercontrol
            UpdateTable();
            Modify_Button.Enabled = false;
            Remove_Button.Enabled = false;
        }
        private void Remove_Button_Click(object sender, EventArgs e)
        {
            // Verifica a conexao
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel connectar á base de dados\n" + ex.Message, "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Pede Confirmação para apagar dados
            DialogResult response = MessageBox.Show("Tem a certeza?", "Apagar?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            // String com comando para apagar dados
            string querry = "DELETE ROW FROM " + Tabela + " WHERE ID = " + (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
            OleDbCommand oleDbCommand = new OleDbCommand(querry, connection);
            // se confirmado, apaga / tenta apagar dados
            if (response == DialogResult.Yes)
            {
                try
                {
                    oleDbCommand.ExecuteNonQuery();
                    MessageBox.Show("Dados apagados com sucesso", "",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possivel apagar os dados.\n " + ex.Message,
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            // Se não for confirmado, indica ao utilizador que foi cancelado
            else
            {
                MessageBox.Show("Cancelado", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Atualiza tabela
            UpdateTable();
            Modify_Button.Enabled = false;
            Remove_Button.Enabled = false;
        }
        private void Tables_Load_1(object sender, EventArgs e)
        {

        }
        private void SfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            Modify_Button.Enabled = true;
            Remove_Button.Enabled = true;
            DataSet ds = new DataSet();
            ds.Reset();
            if (connection.State != ConnectionState.Open)
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
                string querry = "SELECT Descricao FROM tab_teams WHERE ID = " + (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                adapter = new OleDbDataAdapter(querry, connection);
                adapter.Fill(ds, "tabled");

                agend.Id = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                agend.Idequipa = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                agend.Idtask = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2];

            }
            else if (Tabela == "tab_places")
            {
                places.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                places.Localizacao = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                places.X = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2];
                places.Y = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[3];
            }
            else if (Tabela == "tab_subtasks")
            {
                subtasks.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                subtasks.IDTask = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                subtasks.Desc = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2];
                subtasks.Type = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[3];

                connection.Close();
            }
            else if (Tabela == "tab_tasks")
            {
                tasks.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                tasks.Descricao = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                tasks.IDPlace = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2];


                connection.Close();

            }
            else if (Tabela == "tab_workers")
            {
                workers.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                workers.Nome = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                workers.IDEquipa = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2];
                if (((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[3].GetType().ToString() != "System.DBNull")
                {
                    workers.Img = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[3];
                }
                workers.Cod = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[4];
                connection.Close();
            }
            else if (Tabela == "tab_teams")
            {
                teams.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                teams.Descricao = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                string querry = "SELECT ID, Nome, Cod FROM tab_workers WHERE IDEquipa = '" + (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0] + "'";
                adapter = new OleDbDataAdapter(querry, connection);
                adapter.Fill(ds, "tabled");

                connection.Close();
            }
            else if (Tabela == "tab_tags")
            {
                tags.ID = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                tags.Ref = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                if ((string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2] == "Sim")
                {
                    tags.Taken = true;

                }
                else
                {
                    tags.Taken = false;
                }
                string querry = "SELECT * FROM tab_tasks WHERE RefTag = '" + (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1] + "'";
                adapter = new OleDbDataAdapter(querry, connection);
                adapter.Fill(ds, "tabled");

                connection.Close();
            }
        }
        // Botão de Exportar do outro projeto
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
            if (saveFilterDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
                //Message box confirmation to view the created workbook.
                if (MessageBox.Show(this.sfDataGrid1, "Quer guardar esta exportação?", "Exportação Excel",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {

                    //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                    System.Diagnostics.Process.Start(saveFilterDialog.FileName);
                }
            }
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

        private void sfDataGrid1_Click(object sender, EventArgs e)
        {

        }
    }
}
