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
    public partial class Add_Category : Form
    {
        DataBase dataBase = new DataBase();

        public Add_Category()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var name = textBoxName.Text;

            var addQuery = $"insert into Category(name_category) values('{name}')";

            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Запис успішно створений!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
        }
    }
}
