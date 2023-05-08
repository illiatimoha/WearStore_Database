using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WearDataBase
{
    public partial class Add_Product_Details : Form
    {
        DataBase dataBase = new DataBase();

        public Add_Product_Details()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var idProduct = textBoxIdProduct.Text;
            var size = textBoxSize.Text;
            var idColor = textBoxIdColor.Text;
            var price = textBoxPrice.Text;

            var addQuery = $"insert into Product_Details(id_product, size, id_color, price) " +
                $"values('{idProduct}', '{size}', '{idColor}', '{price}')";

            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Запис успішно створений!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxIdProduct.Text = "";
            textBoxSize.Text = "";
            textBoxIdColor.Text = "";
            textBoxPrice.Text = "";
        }
    }
}
