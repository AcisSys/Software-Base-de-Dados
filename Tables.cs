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


        // String publica para dar a conhecer a table que está a ser visualisada

        public string Tabela { get; set; }
        public string Tabela2 { get; set; }



        // Outras forms
        Agend agend = new Agend();
        Places places = new Places();
        Subtasks subtasks = new Subtasks();
        Tags tags = new Tags();
        Teams teams = new Teams();
        Workers workers = new Workers();





        private void Tables_Load(object sender, EventArgs e)
        {

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

            querry = "SELECT * FROM " + Tabela2;
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(dset, "tabled");
            sfDataGrid2.DataSource = dset.Tables["tabled"];
            connection.Close();
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
           
            if (Tabela == "tab_agend") 
            {
                Agend agend = new Agend();
                agend.tipo = "Add";
                agend.ShowDialog();
            }
            if (Tabela == "tab_places")
            {
                Places places = new Places();
                places.tipo = "Add";
                places.ShowDialog();
            }
            if (Tabela == "tab_tasks")
            {
                Tasks tasks = new Tasks();
                tasks.tipo = "Add";
                tasks.ShowDialog();
            }
            if (Tabela == "tab_subtasks")
            {
                Subtasks subtasks = new Subtasks();
                subtasks.tipo = "Add";
                subtasks.ShowDialog();
            }
            if (Tabela == "tab_tags")
            {
                Tags tags = new Tags();
                tags.tipo = "Add";
                tags.ShowDialog();
            }
            if (Tabela == "tab_teams")
            {
                Teams teams = new Teams();
                teams.tipo = "Add";
                teams.ShowDialog();
            }
            if (Tabela == "tab_workers")
            {
                Workers workers = new Workers();
                workers.tipo = "Add";
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
                Agend agend = new Agend();
                agend.tipo = "";
                agend.ShowDialog();
            }
            if (Tabela == "tab_places")
            {
                Places places = new Places();
                places.tipo = "";
                places.ShowDialog();
            }
            if (Tabela == "tab_tasks")
            {
                Tasks tasks = new Tasks();
                tasks.tipo = "";
                tasks.ShowDialog();
            }
            if (Tabela == "tab_subtasks")
            {
                Subtasks subtasks = new Subtasks();
                subtasks.tipo = "";
                subtasks.ShowDialog();
            }
            if (Tabela == "tab_tags")
            {
                Tags tags = new Tags();
                tags.tipo = "";
                tags.ShowDialog();
            }
            if (Tabela == "tab_teams")
            {
                Teams teams = new Teams();
                teams.tipo = "";
                teams.ShowDialog();
            }
            if (Tabela == "tab_workers")
            {
                Workers workers = new Workers();
                workers.tipo = "";
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

            string querry = "DELETE ROW FROM " + Tabela + " WHERE ID = "+ (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
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

        private void sfDataGrid1_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            
            DataSet ds = new DataSet();
            string querry = "SELECT * FROM " + Tabela2 + " WHERE ID = " + (string)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[1];
            adapter = new OleDbDataAdapter(querry, connection);
            adapter.Fill(ds, "tabled");
            sfDataGrid2.DataSource = ds.Tables["tabled"];
            connection.Close();
        }
    }
}
