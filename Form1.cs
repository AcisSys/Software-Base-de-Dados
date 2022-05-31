using System;
using System.IO;
using System.Windows.Forms;

namespace Software_Base_de_Dados
{
    public partial class Form1 : Form
    {

        // Inicia os UserControls
        readonly Title title = new Title();
        readonly Tables table = new Tables();
        string tabela = "";
        public Form1()
        {
            InitializeComponent();
            panel1.Controls.Add(title);
            title.Dock = DockStyle.Fill;
        }

        private void Agend_Button_Click(object sender, EventArgs e)
        {
            tabela = "tab_agend";
            table.Tabela = tabela;
            table.UpdateTable();
            panel1.Controls.Clear();
            panel1.Controls.Add(table);
            table.Dock = DockStyle.Fill;
        }

        private void Places_Button_Click(object sender, EventArgs e)
        {
            tabela = "tab_places";
            table.Tabela = tabela;
            table.UpdateTable();
            panel1.Controls.Clear();
            panel1.Controls.Add(table);
            table.Dock = DockStyle.Fill;
        }

        private void Tags_Button_Click(object sender, EventArgs e)
        {
            tabela = "tab_tags";
            table.Tabela = tabela;
            table.UpdateTable();
            panel1.Controls.Clear();
            panel1.Controls.Add(table);
            table.Dock = DockStyle.Fill;
        }

        private void Workers_Button_Click(object sender, EventArgs e)
        {
            tabela = "tab_workers";
            table.Tabela = tabela;
            table.UpdateTable();
            panel1.Controls.Clear();
            panel1.Controls.Add(table);
            table.Dock = DockStyle.Fill;
        }

        private void Teams_Button_Click(object sender, EventArgs e)
        {
            tabela = "tab_teams";
            table.Tabela = tabela;
            table.UpdateTable();
            panel1.Controls.Clear();
            panel1.Controls.Add(table);
            table.Dock = DockStyle.Fill;
        }

        private void Tasks_Button_Click(object sender, EventArgs e)
        {
            tabela = "tab_tasks";
            table.Tabela = tabela;
            table.UpdateTable();
            panel1.Controls.Clear();
            panel1.Controls.Add(table);
            table.Dock = DockStyle.Fill;
        }

        private void SubTasks_Button_Click(object sender, EventArgs e)
        {
            tabela = "tab_subtasks";
            table.Tabela = tabela;
            table.UpdateTable();
            panel1.Controls.Clear();
            panel1.Controls.Add(table);
            table.Dock = DockStyle.Fill;
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Conexao conexao = new Conexao();
            conexao.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Tables.caminho = File.ReadAllText("FILENAME.txt");
        }
    }
}