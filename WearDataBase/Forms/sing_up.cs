using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WearDataBase
{
    public partial class sing_up : Form
    {
        DataBase dataBase = new DataBase();
        public sing_up()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            var login = textBox_login2.Text;
            var password = textBox_password2.Text;
            string queryString = $"insert into Register(login_user, password_user) values ('{login}', '{password}')";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Акаунт успішно створений!", "Успішно!");
                log_in form_login = new log_in();
                this.Hide();
                form_login.ShowDialog();
            }
            else
            {
                MessageBox.Show("Акаунт не створено!");
            }
            dataBase.closeConnection();
        }

        private Boolean checkUser()
        {
            var loginUser = textBox_login2.Text;
            var passwordUser = textBox_password2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string queryString = $"select id_user, login_user, password_user from Register where login_user = '{loginUser}' and password_user = '{passwordUser}'";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                MessageBox.Show("Користувач вже зареєстрований!");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void sing_up_Load(object sender, EventArgs e)
        {
            textBox_password2.PasswordChar = '*';
            pictureBox3.Visible = false;
            textBox_login2.MaxLength = 50;
            textBox_password2.MaxLength = 50;
        }

        private void buttonClear1_Click(object sender, EventArgs e)
        {
            textBox_login2.Text = "";
            textBox_password2.Text = "";
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            textBox_password2.UseSystemPasswordChar = false;
            pictureBox3.Visible = false;
            pictureBox2.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox_password2.UseSystemPasswordChar = true;
            pictureBox3.Visible = true;
            pictureBox2.Visible = false;
        }
    }
}
