using System;
using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    public partial class Form1 : Form
    {
        readonly Title title = new Title();
        readonly Tables table = new Tables();
        string tabela = "";
        public Form1()
        {
            InitializeComponent();
            panel1.Controls.Add(title);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Agend_Button_Click(object sender, EventArgs e)
        {


            // NAO ALTERAR ORDEM DESTAS LINHAS
            tabela = "tab_agend";
            table.Tabela2 = "tab_teams";
            table.Tabela = tabela;
            table.UpdateTable();
            panel1.Controls.Clear();
            //table.Anchor = (AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Left);
            panel1.Controls.Add(table);
            

        }

        private void Places_Button_Click(object sender, EventArgs e)
        {
            tabela = "tab_places";
            table.Tabela = tabela;
            table.Tabela2 = "tab_teams";
            table.UpdateTable();
            panel1.Controls.Clear();
            panel1.Controls.Add(table);
        }

        private void Tags_Button_Click(object sender, EventArgs e)
        {
            tabela = "tab_tags";
            table.Tabela = tabela;
            table.UpdateTable();
            panel1.Controls.Clear();
            panel1.Controls.Add(table);
        }

        private void Workers_Button_Click(object sender, EventArgs e)
        {
            tabela = "tab_workers";
            table.Tabela2 = "tab_teams";
            table.Tabela = tabela;
            table.UpdateTable();
            panel1.Controls.Clear();
            panel1.Controls.Add(table);
        }

        private void Teams_Button_Click(object sender, EventArgs e)
        {
            tabela = "tab_teams";
            
            table.Tabela = tabela;
            table.UpdateTable();
            panel1.Controls.Clear();
            panel1.Controls.Add(table);
        }

        private void Tasks_Button_Click(object sender, EventArgs e)
        {
            tabela = "tab_tasks";
            table.Tabela2 = "tab_places";
            table.Tabela = tabela;
            table.UpdateTable();
            panel1.Controls.Clear();
            panel1.Controls.Add(table);
        }

        private void SubTasks_Button_Click(object sender, EventArgs e)
        {
            tabela = "tab_subtasks";
            table.Tabela2 = "tab_tasks";
            table.Tabela = tabela;
            table.UpdateTable();
            panel1.Controls.Clear();
            panel1.Controls.Add(table);
        }

        private void Exportar_Click(object sender, EventArgs e)
        {

        }
    }
}