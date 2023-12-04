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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kursovaya.SelectedMenu
{
    public partial class ForceView : UserControl
    {
        DataBase connect = new DataBase();
        MySqlCommand command;
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        string selectedTableName;

        public ForceView()
        {
            InitializeComponent();
            connect.Connection();
            LoadTables();

        }
        private void LoadTables()
        {
            try
            {
                connect.conn.Close();
                connect.conn.Open();
                DataTable tableSchema = connect.conn.GetSchema("Tables");
                comboBox1.Items.Clear();
                foreach (DataRow row in tableSchema.Rows)
                {
                    string tableName = row["TABLE_NAME"].ToString();
                    comboBox1.Items.Add(tableName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedTableName = comboBox1.SelectedItem.ToString();
            string query = "SELECT * FROM " + selectedTableName;
            using (MySqlCommand cmd = new MySqlCommand(query, connect.conn))
            {
                cmd.CommandText = query;
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet, selectedTableName);
                dataGridView1.DataSource = dataSet.Tables[selectedTableName];
            }

        }
    }
}
