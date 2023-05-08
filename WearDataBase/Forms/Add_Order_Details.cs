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
    public partial class Add_Order_Details : Form
    {
        DataBase dataBase = new DataBase();
        public Add_Order_Details()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var idOrder = textBoxIdOrder.Text;
            var idInfo = textBoxIdInfo.Text;
            var amount = textBoxCount.Text;
            var novaPoshta = textBoxNovaPoshta.Text;
            var town = textBoxTown.Text;

            var addQuery = $"insert into Order_Details(id_order, id_info, amount, branchNP, id_town) " +
                $"values('{idOrder}','{idInfo}', '{amount}', '{novaPoshta}', '{town}')";

            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Запис успішно створений!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxIdOrder.Text = "";
            textBoxIdInfo.Text = "";
            textBoxCount.Text = "";
            textBoxNovaPoshta.Text = "";
            textBoxTown.Text = "";
        }
    }
}
