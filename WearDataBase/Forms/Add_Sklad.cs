using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WearDataBase
{
    public partial class Add_Sklad : Form
    {
        DataBase dataBase = new DataBase();

        public Add_Sklad()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            dataBase.openConnection();

            var address = textBoxAddress.Text;
            var idTown = textBoxIdTown.Text;

            var addQuery = $"insert into Sklad(address_sklad, id_town) values('{address}', '{idTown}')";

            var command = new SqlCommand(addQuery, dataBase.getConnection());
            command.ExecuteNonQuery();

            MessageBox.Show("Запис успішно створений!", "Успіх!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            dataBase.closeConnection();
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxAddress.Text = "";
        }
    }
}
