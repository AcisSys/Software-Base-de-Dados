using System;
using System.Data;
using System.Data.OleDb;
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
            currentT = "tasks";


        }
        private void Add_Button_Click(object sender, EventArgs e)
        {
            if (currentT == "tasks")
            {
                tasks.Tipo = "Add";
                tasks.ShowDialog();
                UpdateTable();
                Add_Button.Enabled = false;
            }
            else if (currentT == "subtasks")
            {

                subtasks.ShowDialog();
                UpdateSubTasks();
                Add_Button.Enabled = false;
            }
        }

        private void Modify_Button_Click(object sender, EventArgs e)
        {
            if (currentT == "tasks")
            {
                tasks.Tipo = "";
                tasks.ShowDialog();
                UpdateTable();
            }



            else if (currentT == "subtasks")
            {
                subtasks.Id = (int)((DataRowView)sfDataGrid2.SelectedItem).Row.ItemArray[0];
                subtasks.Tipo = "add";
                subtasks.Text = "Modificar SubTarefas";
                subtasks.ShowDialog();
                UpdateSubTasks();
            }
            Modify_Button.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            subtasks.Tipo = "Add";
            subtasks.Text = "Adicionar SubTarefas";
            subtasks.IdTask = (int)((DataRowView)sfDataGrid1.SelectedItem).Row.ItemArray[0];
            subtasks.ShowDialog();
            UpdateTable();
        }

        private void sfDataGrid2_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            Modify_Button.Enabled = true;
            Add_Button.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
