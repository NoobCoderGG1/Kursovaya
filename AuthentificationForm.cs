using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kursovaya
{
    public partial class AuthentificationForm : Form
    {
        DataBase connect = new DataBase();
        public MySqlCommand cmd;
        public MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlDataReader reader;
        public AuthentificationForm()
        {
            InitializeComponent();
            connect.Connection();
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            connect.conn.Close();
            connect.conn.Open();
            cmd = new MySqlCommand("SELECT * FROM admins WHERE admin_login = '" + textBox1.Text + "' AND admin_password = '" + textBox2.Text + "'", connect.conn);
            reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Read();

                string name = reader.GetString(1);
                string password = reader.GetString(2);
                if (name == textBox1.Text && password == textBox2.Text) { 
                    MessageBox.Show("Аутентификация прошла успешно.");
                    this.Hide();
                    new MainMenu().ShowDialog();
                }

            }
        }
    }
}
