using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        OleDbDataAdapter adapter;
        OleDbConnection connection = new OleDbConnection(Tables.Caminho);
        private void ControlsTasks_Load(object sender, EventArgs e)
        {
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
    }
}
