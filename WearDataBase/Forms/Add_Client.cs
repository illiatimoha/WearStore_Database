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
using System.Windows.Forms.VisualStyles;

namespace WearDataBase
{
    public partial class Add_Client : Form
    {
        DataBase dataBase = new DataBase();
        public Add_Client()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var name = textBoxName.Text;
            var surname = textBoxSurname.Text;
            var phone = textBoxPhone.Text;

            var addQuery = $"insert into Client(name_client, surname_client, phone_client) values('{name}', '{surname}', '{phone}')";

            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Запис успішно створений!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxName.Text = "";
            textBoxSurname.Text = "";
            textBoxPhone.Text = "";
        }
    }
}
