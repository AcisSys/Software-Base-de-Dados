using System;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
namespace Software_Base_de_Dados
{
    // Security risk on changin connection (password shows if file exists)
    public partial class Conexao : Form
    {
        public Conexao()
        {
            InitializeComponent();
        }
        static readonly string key = "bbce2ea2315a1916";
        string Provid;
        string DSource;
        string Password;
        string decryptedString3;
        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                sfToolTip1.Show("Introduza a chave de conexão antes de continuar");
                return;
            }
            if (!File.Exists("ChaveConexao.txt"))
            {
                File.Create("ChaveConexao.txt").Close();
                using (StreamWriter sw = File.AppendText("ChaveConexao.txt"))
                {
                    Provid = textBox1.Text;
                    DSource = textBox2.Text;
                    textBox3.Text = decryptedString3;
                    Password = textBox3.Text;
                    var encryptedString = AesOperation.EncryptString(key, Provid);
                    sw.WriteLine("Provider = " + encryptedString + ";");
                    var encryptedString2 = AesOperation.EncryptString(key, DSource);
                    sw.WriteLine("Data Source = " + encryptedString2 + ";");
                    var encryptedString3 = AesOperation.EncryptString(key, Password);
                    sw.WriteLine("Jet OLEDB:Database Password = " + encryptedString3);
                }
            }
            else
            {
                File.WriteAllText("ChaveConexao.txt", String.Empty);
                using (StreamWriter sw = File.AppendText("ChaveConexao.txt"))
                {
                    Provid = textBox1.Text;
                    DSource = textBox2.Text;
                    Password = textBox3.Text;
                    try
                    {
                        Tables.Caminho = "Provider = " + Provid + "; Data Source = " + DSource + "; Jet OLEDB:Database Password = " + Password;
                        OleDbConnection con = new OleDbConnection(Tables.Caminho);
                        con.Open();
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro na conexão, verifique a chave de conexão.\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    var encryptedString = AesOperation.EncryptString(key, Provid);
                    sw.WriteLine("Provider = " + encryptedString + ";");
                    var encryptedString2 = AesOperation.EncryptString(key, DSource);
                    sw.WriteLine("Data Source = " + encryptedString2 + ";");
                    var encryptedString3 = AesOperation.EncryptString(key, Password);
                    sw.WriteLine("Jet OLEDB:Database Password = " + encryptedString3);
                }
            }
            this.Close();
        }
        private void Button1_MouseLeave_1(object sender, EventArgs e)
        {
            sfToolTip1.Hide();
        }
        private void Conexao_Load(object sender, EventArgs e)
        {
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
                    textBox1.Text = decryptedString;
                    var decryptedString2 = AesOperation.DecryptString(key, DSource.Substring(14, DSource.Length - 15));
                    textBox2.Text = decryptedString2;
                    decryptedString3 = AesOperation.DecryptString(key, Password.Substring(30, Password.Length - 30));
                    textBox3.Text = decryptedString3;
                }
            }
        }
    }
}