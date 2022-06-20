using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
namespace Software_Base_de_Dados
{
    public partial class Form1 : Form
    {
        // Nao alterar a chave ou qualquer código relacionado á encriptação de dados
        readonly Title title = new Title();
        readonly Tables table = new Tables();
        Conexao conexao = new Conexao();
        string tabela = "";
        string Provid;
        string DSource;
        string Password;
        static readonly string key = "bbce2ea2315a1916";

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
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            conexao.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            // Gets Connection String and Unencrypt it
            if (!File.Exists("ChaveConexao.txt"))
            {
                MessageBox.Show("Não existe uma conexão, configure uma", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexao.ShowDialog();
            }
            if (File.Exists("ChaveConexao.txt"))
            {
                using (var reader = new StreamReader("ChaveConexao.txt"))
                {
                    Provid = reader.ReadLine();
                    DSource = reader.ReadLine();
                    Password = reader.ReadLine();
                }
                if (Provid != null)
                {
                    var decryptedString = AesOperation.DecryptString(key, Provid.Substring(11, Provid.Length - 12));
                    string prov = decryptedString;
                    var decryptedString2 = AesOperation.DecryptString(key, DSource.Substring(14, DSource.Length - 15));
                    string pat = decryptedString2;
                    var decryptedString3 = AesOperation.DecryptString(key, Password.Substring(30, Password.Length - 30));
                    string pass = decryptedString3;
                    try
                    {
                        Tables.Caminho = "Provider = " + prov + "; Data Source = " + pat + "; Jet OLEDB:Database Password = " + pass;
                        OleDbConnection con = new OleDbConnection(Tables.Caminho);
                        con.Open();
                    }
                    catch (Exception ex)
                    {
                        // Error in bad connection
                        MessageBox.Show("Erro na conexão, verifique a chave de conexão.\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }
    }
}