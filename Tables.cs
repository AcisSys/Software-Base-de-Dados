using System;
using System.Data;
using System.Data.OleDb;
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
        public string Tabela2 { get; set; }
        private void Tables_Load(object sender, EventArgs e)
        {
            sfDataGrid2.DataSource = null;
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

            // Querry para o comando da base de dados

            string querry = "SELECT * FROM " + Tabela;

            // Limpa o DataSet

            dset.Reset();

            // Vai buscar os dados ao executar o comando QUERRY
            adapter = new OleDbDataAdapter(querry, connection);

            // Insere os dados no DataSet

            adapter.Fill(dset, "table");

            // Associa o DataGrid ao DataSet
            sfDataGrid1.DataSource = null;
            sfDataGrid1.DataSource = dset.Tables["table"];
            sfDataGrid1.Update();
            sfDataGrid2.DataSource = null;
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
        }

        private void Tables_Load_1(object sender, EventArgs e)
        {

        }

        private void SfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
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
                sfDataGrid2.DataSource = ds.Tables["tabled"];
                agend.Id = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
                agend.Idequipa = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                agend.Idtask = (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2];

            }
            if (Tabela == "tab_subtasks")
            {
                string querry = "SELECT * FROM " + Tabela2 + " WHERE ID = " + (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
                adapter = new OleDbDataAdapter(querry, connection);
                adapter.Fill(ds, "tabled");
                sfDataGrid2.DataSource = ds.Tables["tabled"];
                connection.Close();
            }
            if (Tabela == "tab_tasks")
            {
                string querry = "SELECT * FROM " + Tabela2 + " WHERE ID = " + (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2];
                adapter = new OleDbDataAdapter(querry, connection);
                adapter.Fill(ds, "tabled");
                sfDataGrid2.DataSource = ds.Tables["tabled"];
                connection.Close();

            }
            if (Tabela == "tab_workers")
            {
                string querry = "SELECT * FROM " + Tabela2 + " WHERE ID = " + (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[2];
                adapter = new OleDbDataAdapter(querry, connection);
                adapter.Fill(ds, "tabled");
                sfDataGrid2.DataSource = ds.Tables["tabled"];
                connection.Close();
            }
            if (Tabela == "tab_teams")
            {
                string querry = "SELECT ID, Nome, Cod FROM tab_workers WHERE IDEquipa = '" + (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0] + "'";
                adapter = new OleDbDataAdapter(querry, connection);
                adapter.Fill(ds, "tabled");
                sfDataGrid2.DataSource = ds.Tables["tabled"];
                connection.Close();
            }
            if (Tabela == "tab_tags")
            {
                string querry = "SELECT * FROM tab_tasks WHERE RefTag = '" + (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1] + "'";
                adapter = new OleDbDataAdapter(querry, connection);
                adapter.Fill(ds, "tabled");
                sfDataGrid2.DataSource = ds.Tables["tabled"];
                connection.Close();
            }
        }
    }
}
