using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
namespace Software_Base_de_Dados
{
    public partial class Form1 : Form
    {
        // Nao alterar a chave ou qualquer código relacionado á encriptação de dados.
        readonly Title title = new Title();
        readonly Tables table = new Tables();
        ControlsTasks controlTasks = new ControlsTasks();
        Conexao conexao = new Conexao();
        string tabela = "";
        string Provid;
        string DSource;
        string Password;
        string camexpo;
        static readonly string key = "bbce2ea2315a1916";
        public Form1()
        {
            // Mostra o Titulo e o tipo de DockStyle é Fill, Aumentando o tamanho proporcionalmente consoante o tamanho da aplicação
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
            panel1.Controls.Add(controlTasks);
            controlTasks.Dock = DockStyle.Fill;
        }
        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            conexao.ShowDialog();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            // Gets connection string and unencrypt it.
            if (!File.Exists("ChaveConexao.txt"))
            {
                // If file doesnt exist, asks to setup a conection
                MessageBox.Show("Não existe uma conexão, configure uma", "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                conexao.ShowDialog();
            }
            // if file exists, reads file
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
                    // decrypt text to get connection string
                    var decryptedString = AesOperation.DecryptString(key, Provid.Substring(11, Provid.Length - 12));
                    string prov = decryptedString;
                    var decryptedString2 = AesOperation.DecryptString(key, DSource.Substring(14, DSource.Length - 15));
                    string pat = decryptedString2;
                    var decryptedString3 = AesOperation.DecryptString(key, Password.Substring(30, Password.Length - 30));
                    string pass = decryptedString3;
                    try
                    {
                        // try opening a connection with the decrypted string
                        Tables.Caminho = "Provider = " + prov + "; Data Source = " + pat + "; Jet OLEDB:Database Password = " + pass;
                        OleDbConnection con = new OleDbConnection(Tables.Caminho);
                        camexpo = pat;
                        con.Open();
                    }
                    catch (Exception ex)
                    {
                        // Invalid Connection requires the connection to be setup again
                        MessageBox.Show("Erro na conexão, verifique a chave de conexão.\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
        }

        private void ExportData_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog diag = new FolderBrowserDialog();
            diag.Description = "Onde deseja guardar a cópia?";
            if (diag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string folder = diag.SelectedPath;  //selected folder path
                File.Copy(camexpo, folder + "/WORK2GOData.accdb");

            }
        }
    }
}