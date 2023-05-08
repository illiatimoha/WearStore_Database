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
    public partial class Add_Product : Form
    {
        DataBase dataBase = new DataBase();
        
        public Add_Product()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var name = textBoxName.Text;
            var material = textBoxIdMaterial.Text;
            var idSklad = textBoxIdSklad.Text;
            var idCategory = textBoxIdCategory.Text;

            var addQuery = $"insert into Product(name_product, id_material, id_sklad, id_category) " +
                $"values('{name}', '{material}', '{idSklad}', '{idCategory}')";

            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Запис успішно створений!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            textBoxIdMaterial.Text = "";
            textBoxIdSklad.Text = "";
            textBoxIdCategory.Text = "";
        }
    }
}
