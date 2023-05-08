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
    public partial class Add_Order : Form
    {
        DataBase dataBase = new DataBase();
        public Add_Order()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var idClient = textBoxIdClient.Text;
            var date = textBoxDate.Text;
            var status = textBoxStatus.Text;

            var addQuery = $"insert into Orders(id_client, date_order, status_order) values('{idClient}', '{date}', '{status}')";

            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Запис успішно створений!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxIdClient.Text = "";
            textBoxDate.Text = "";
            textBoxStatus.Text = "";
        }
    }
}
