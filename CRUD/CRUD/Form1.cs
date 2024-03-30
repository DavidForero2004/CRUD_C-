using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string code = txtcode.Text;
            string name = txtname.Text;
            string description = txtdescription.Text;
            double price = double.Parse(txtprice.Text);
            int stock = int.Parse(txtstock.Text);
            //conexion y query a la db
            string sql = $"INSERT INTO products(name, description, PRICE, stock) VALUES ('{name}', '{description}', {price}, {stock});";
            MySqlConnection connectionDB = connection.conexion();
            connectionDB.Open();

            try
            {
                MySqlCommand command = new MySqlCommand(sql, connectionDB);
                command.ExecuteNonQuery();
                MessageBox.Show("Product registred");
                clean();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error to save: {ex.Message}");
            }
            finally
            {
                connectionDB.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            string id = txtcode.Text;
            string name = txtname.Text;
            string description = txtdescription.Text;
            double price = double.Parse(txtprice.Text);
            int stock = int.Parse(txtstock.Text);

     
            string sql = $"UPDATE products set  name='{name}', description='{description}', price={price}, stock={stock} WHERE id = {id}";
            MySqlConnection connectionDB = connection.conexion();
            connectionDB.Open();

            try
            {
                MySqlCommand command = new MySqlCommand(sql, connectionDB);
                command.ExecuteNonQuery();
                MessageBox.Show("product modify");
                clean();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"error to modify: {ex.Message}");
            }
            finally
            {
                connectionDB.Close();
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string code = txtcode.Text;

            //contenedor que guardara los datos de la consulta
            MySqlDataReader reader = null;
            string sql = $"SELECT * FROM products where id={code};";
            MySqlConnection connectionDB = connection.conexion();
            connectionDB.Open();

            try
            {
                MySqlCommand command = new MySqlCommand(sql, connectionDB);
                reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        txtid.Text = reader.GetInt32(0).ToString();
                        txtname.Text = reader.GetString(1);
                        txtdescription.Text = reader.GetString(2);
                        txtprice.Text = reader.GetDouble(3).ToString();
                        txtstock.Text = reader.GetInt32(4).ToString();
                    }
                }
                else
                {
                    MessageBox.Show($"Not found product with code: {code}");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"error to search {ex.Message}");
            }
            finally
            {
                connectionDB.Close();
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            string code = txtcode.Text;


            string sql = $"DELETE FROM products WHERE id = {code}";
            MySqlConnection connectionDB = connection.conexion();
            connectionDB.Open();

            try
            {
                MySqlCommand command = new MySqlCommand(sql, connectionDB);
                command.ExecuteNonQuery();
                MessageBox.Show("product deleted");
                clean();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"error to delete: {ex.Message}");
            }
            finally
            {
                connectionDB.Close();
            }
        }

        private void btnclean_Click(object sender, EventArgs e)
        {
            clean();
        }
        private void clean()
        {
            txtid.Text = "";
            txtcode.Text = "";
            txtname.Text = "";
            txtdescription.Text = "";
            txtprice.Text = "";
            txtstock.Text = "";
        }
    }
}
