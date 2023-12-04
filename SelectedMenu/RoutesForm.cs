using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kursovaya.SelectedMenu
{
    public partial class RoutesForm : Form
    {
        public static RoutesForm frm;
        DataBase connect = new DataBase();
        MySqlCommand command;
        MySqlDataAdapter dataadapter;
        DataTable datatable;

        public RoutesForm()
        {
            InitializeComponent();
            connect.Connection();
            LoadFields();
        }

        public static RoutesForm getForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new RoutesForm();
                }
                return frm;
            }
        }
        private void LoadData()
        {
            try
            {
                connect.conn.Close();
                connect.conn.Open(); //Открытие соединения.
                command = new MySqlCommand("SELECT * FROM routes WHERE employer_id = '"+comboBox1.SelectedValue.ToString()+"' ", connect.conn); //Инициализация запроса и адреса, куда отправить SQL-запрос через конструктор.
                command.ExecuteNonQuery(); //Отправка запроса.
                datatable = new DataTable(); //Создание таблицы, которая содержит ряды и столбцы.
                dataadapter = new MySqlDataAdapter(command); //Получение ответа, предоставляет интерфейс таблице.
                dataadapter.Fill(datatable); //Заполнение datatable из dataadapter
                dataGridView1.DataSource = datatable.DefaultView; // Для вывода.

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadComboBox()
        {
            string sql = "SELECT * FROM employers";
            using (MySqlCommand cmd = new MySqlCommand(sql, connect.conn))
            {
                cmd.CommandType = CommandType.Text;
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                comboBox1.ValueMember = "employer_id";
                comboBox1.DisplayMember = "employer_id";
                comboBox1.DataSource = table;
            }
            comboBox1.SelectedValue = PersonellManagement.selectedRow.Cells[0].Value;
            sql = "SELECT * FROM cars";
            using (MySqlCommand cmd = new MySqlCommand(sql, connect.conn))
            {
                cmd.CommandType = CommandType.Text;
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(table);
                comboBox2.ValueMember = "car_id";
                comboBox2.DisplayMember = "car_id";
                comboBox2.DataSource = table;
            }
        }


        private void RoutesForm_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadData();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox2.SelectedValue = dataGridView1.CurrentRow.Cells[2].Value;
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void AllRoutesBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connect.conn.Close();
                connect.conn.Open(); //Открытие соединения.
                command = new MySqlCommand("SELECT * FROM routes", connect.conn); //Инициализация запроса и адреса, куда отправить SQL-запрос через конструктор.
                command.ExecuteNonQuery(); //Отправка запроса.
                datatable = new DataTable(); //Создание таблицы, которая содержит ряды и столбцы.
                dataadapter = new MySqlDataAdapter(command); //Получение ответа, предоставляет интерфейс таблице.
                dataadapter.Fill(datatable); //Заполнение datatable из dataadapter
                dataGridView1.DataSource = datatable.DefaultView; // Для вывода.

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FindRouteBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connect.conn.Close();
                connect.conn.Open(); //Открытие соединения.
                command = new MySqlCommand("SELECT * FROM routes WHERE route_id = '" + textBox2.Text + "' ", connect.conn); //Инициализация запроса и адреса, куда отправить SQL-запрос через конструктор.
                command.ExecuteNonQuery(); //Отправка запроса.
                datatable = new DataTable(); //Создание таблицы, которая содержит ряды и столбцы.
                dataadapter = new MySqlDataAdapter(command); //Получение ответа, предоставляет интерфейс таблице.
                dataadapter.Fill(datatable); //Заполнение datatable из dataadapter
                dataGridView1.DataSource = datatable.DefaultView; // Для вывода.

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connect.conn.Close();
                connect.conn.Open();
                command = new MySqlCommand("INSERT INTO routes(route_id, employer_id, car_id, route_dist) VALUES ('" + textBox2.Text + "','" + comboBox1.SelectedValue.ToString() + "','" + comboBox2.SelectedValue.ToString() + "','" + textBox4.Text + "')", connect.conn);
                command.ExecuteNonQuery();
                connect.conn.Close();
                LoadData();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connect.conn.Close();
                connect.conn.Open();
                command = new MySqlCommand("DELETE FROM routes WHERE route_id = '" + textBox2.Text + "' ", connect.conn);
                command.ExecuteNonQuery();
                connect.conn.Close();
                LoadData();
                MessageBox.Show("Data successfully deleted");
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void SortBtn_Click(object sender, EventArgs e)
        {
            string selectedColumn = comboBox3.SelectedItem.ToString();
            string filterQuery = $"SELECT * FROM routes ORDER BY {selectedColumn} ASC";
            MySqlCommand cmd = new MySqlCommand(filterQuery, connect.conn);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;
            dataTable.Clear();
            dataAdapter.Fill(dataTable);
        }
        private void LoadFields()
        {
            try
            {
                connect.conn.Close();
                connect.conn.Open();
                string columnsQuery = "SHOW COLUMNS FROM routes";
                MySqlCommand columnsCmd = new MySqlCommand(columnsQuery, connect.conn);
                MySqlDataReader reader = columnsCmd.ExecuteReader();
                comboBox3.Items.Clear();
                while (reader.Read())
                {
                    string columnName = reader["Field"].ToString();
                    comboBox3.Items.Add(columnName);
                }
                connect.conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void FindCarBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connect.conn.Close();
                connect.conn.Open(); //Открытие соединения.
                command = new MySqlCommand("SELECT * FROM routes WHERE car_id = '" + comboBox2.SelectedValue.ToString() + "' ", connect.conn); //Инициализация запроса и адреса, куда отправить SQL-запрос через конструктор.
                command.ExecuteNonQuery(); //Отправка запроса.
                datatable = new DataTable(); //Создание таблицы, которая содержит ряды и столбцы.
                dataadapter = new MySqlDataAdapter(command); //Получение ответа, предоставляет интерфейс таблице.
                dataadapter.Fill(datatable); //Заполнение datatable из dataadapter
                dataGridView1.DataSource = datatable.DefaultView; // Для вывода.

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
