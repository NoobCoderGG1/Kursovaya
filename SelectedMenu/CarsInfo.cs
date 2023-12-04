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

namespace Kursovaya.SelectedMenu
{
    public partial class CarsInfo : UserControl
    {
        DataBase connect = new DataBase();
        MySqlCommand command;
        MySqlDataAdapter dataadapter;
        DataTable datatable;
        static public object selectedRow;
        public CarsInfo()
        {
            InitializeComponent();
            connect.Connection();
            LoadFields();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                connect.conn.Open(); //Открытие соединения.
                command = new MySqlCommand("SELECT * FROM cars", connect.conn); //Инициализация запроса и адреса, куда отправить SQL-запрос через конструктор.
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

        private void LoadBtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connect.conn.Close();
                connect.conn.Open();
                command = new MySqlCommand("INSERT INTO cars(car_id, car_parking, car_color, car_brand, car_number, car_model) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "')", connect.conn);
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
                command = new MySqlCommand("DELETE FROM cars WHERE car_id = '" + textBox1.Text + "' ", connect.conn);
                command.ExecuteNonQuery();
                connect.conn.Close();
                LoadData();
                MessageBox.Show("Data successfully deleted");
            }

            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void UpdBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connect.conn.Close();
                connect.conn.Open();
                command = new MySqlCommand("UPDATE cars SET car_parking = '" + textBox2.Text + "', car_color = '" + textBox3.Text + "', car_brand = '" + textBox4.Text + "' , car_number = '" + textBox5.Text + "' , car_model = '" + textBox7.Text + "' WHERE car_id = '" + textBox1.Text + "' ", connect.conn);
                command.ExecuteNonQuery();
                connect.conn.Close();
                LoadData();
                MessageBox.Show("Data successfully updated");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SortBtn_Click(object sender, EventArgs e)
        {
            string selectedColumn = comboBox1.SelectedItem.ToString();
            string filterQuery = $"SELECT * FROM cars ORDER BY {selectedColumn} ASC";
            MySqlCommand cmd = new MySqlCommand(filterQuery, connect.conn);
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;
            dataTable.Clear();
            dataAdapter.Fill(dataTable);
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            try
            {
                connect.conn.Close();
                connect.conn.Open();
                string selectedColumn = comboBox1.SelectedItem.ToString();
                string searchTerm = textBox6.Text;
                string searchQuery = $"SELECT * FROM cars WHERE {selectedColumn} LIKE @searchTerm";
                MySqlCommand cmd = new MySqlCommand(searchQuery, connect.conn);
                cmd.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                dataGridView1.DataSource = dataTable;
                dataTable.Clear();
                dataAdapter.Fill(dataTable);
                connect.conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        private void LoadFields()
        {
            try
            {
                connect.conn.Close();
                connect.conn.Open();
                string columnsQuery = "SHOW COLUMNS FROM cars";
                MySqlCommand columnsCmd = new MySqlCommand(columnsQuery, connect.conn);
                MySqlDataReader reader = columnsCmd.ExecuteReader();
                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    string columnName = reader["Field"].ToString();
                    comboBox1.Items.Add(columnName);
                }
                connect.conn.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void HistoryRepairBtn_Click(object sender, EventArgs e)
        {
            selectedRow = dataGridView1.CurrentCell.Value;
            RepairHistoryForm.getForm.ShowDialog();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                PersonellManagement.selectedRow = dataGridView1.Rows[0];
                RoutesForm.getForm.ShowDialog();
            }
        }
    }
}
