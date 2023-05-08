using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WearDataBase
{
    enum RowState
    {
        Existed,
        New,
        Modified,
        ModifiedNew,
        Deleted
    }

    public partial class Main : Form
    {
        DataBase dataBase = new DataBase();
        int selectedRow;

        public Main()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CreateColumns_Sklad();
            RefreshDataGrid_Sklad(dataGridView_Sklad);
            CreateColumns_Category();
            RefreshDataGrid_Category(dataGridView_Category);
            CreateColumns_Client();
            RefreshDataGrid_Client(dataGridView_Client);
            CreateColumns_Product();
            RefreshDataGrid_Product(dataGridView_Product);
            CreateColumns_Orders();
            RefreshDataGrid_Orders(dataGridView_Order);
            CreateColumns_OrderDetails();
            RefreshDataGrid_Order_Details(dataGridView_OrderDetails);
            CreateColumns_Town();
            RefreshDataGrid_Town(dataGridView_Town);
            CreateColumns_ProductDetails();
            RefreshDataGrid_ProductDetails(dataGridView_ProductDetails);
            CreateColumns_Material();
            RefreshDataGrid_Material(dataGridView_Material);
            CreateColumns_Color();
            RefreshDataGrid_Color(dataGridView_Color);
            
        }

        // Створення колонок в dataGrid.Sklad
        private void CreateColumns_Sklad()
        {
            dataGridView_Sklad.Columns.Add("id_sklad", "ID_Складу");
            dataGridView_Sklad.Columns.Add("address_sklad", "Адреса складу");
            dataGridView_Sklad.Columns.Add("id_town", "ID_Міста");
            dataGridView_Sklad.Columns.Add("IsNew", string.Empty);
        }
        
        // Зчитування даних 1 рядка
        private void ReadSingleRow_Sklad(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), RowState.ModifiedNew);
        }

        // Створення колонок в dataGrid.Category
        private void CreateColumns_Category()
        {
            dataGridView_Category.Columns.Add("id_category", "ID_Категорії");
            dataGridView_Category.Columns.Add("name_category", "Назва Категорії");
            dataGridView_Category.Columns.Add("IsNew", string.Empty);
        }
        // Зчитування даних 1 рядка
        private void ReadSingleRow_Category(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1),  RowState.ModifiedNew);
        }


        // Створення колонок в dataGrid.Client
        private void CreateColumns_Client()
        {
            dataGridView_Client.Columns.Add("id_client", "ID_Клієнта");
            dataGridView_Client.Columns.Add("name_client", "Ім'я");
            dataGridView_Client.Columns.Add("surname_client", "Прізвище");
            dataGridView_Client.Columns.Add("phone_number", "Номер телефону");
            dataGridView_Client.Columns.Add("IsNew", string.Empty);
        }
        // Зчитування даних 1 рядка
        private void ReadSingleRow_Client(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetString(2), record.GetString(3), RowState.ModifiedNew);
        }


        // Створення колонок в dataGrid.Product
        private void CreateColumns_Product()
        {
            dataGridView_Product.Columns.Add("id_product", "ID_Продукту");
            dataGridView_Product.Columns.Add("name_product", "Назва продукту");
            dataGridView_Product.Columns.Add("id_material", "ID_Матеріалу");
            dataGridView_Product.Columns.Add("id_sklad", "ID_Складу");
            dataGridView_Product.Columns.Add("id_category", "ID_Категорії");
            dataGridView_Product.Columns.Add("IsNew", string.Empty);
        }
        // Зчитування даних 1 рядка
        private void ReadSingleRow_Product(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), record.GetInt32(2), record.GetInt32(3), record.GetInt32(4), RowState.ModifiedNew);
        }


        // Створення колонок в dataGrid.Orders
        private void CreateColumns_Orders()
        {
            dataGridView_Order.Columns.Add("id_order", "ID_Замовлення");
            dataGridView_Order.Columns.Add("id_client", "ID_Клієнта");
            dataGridView_Order.Columns.Add("date_order", "Дата замовлення");
            dataGridView_Order.Columns.Add("status_order", "Статус");
            dataGridView_Order.Columns.Add("IsNew", string.Empty);
        }
        // Зчитування даних 1 рядка
        private void ReadSingleRow_Orders(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetDateTime(2), record.GetString(3), RowState.ModifiedNew);
        }


        // Створення колонок в dataGrid.OrderDetails
        private void CreateColumns_OrderDetails()
        {
            dataGridView_OrderDetails.Columns.Add("id_record", "ID_Запису");
            dataGridView_OrderDetails.Columns.Add("id_order", "ID_Замовлення");
            dataGridView_OrderDetails.Columns.Add("id_info", "ID_Деталі_продукту");
            dataGridView_OrderDetails.Columns.Add("amount", "Кількість");
            dataGridView_OrderDetails.Columns.Add("branchNP", "Відділення Нової Пошти");
            dataGridView_OrderDetails.Columns.Add("id_town", "ID_Міста");
            dataGridView_OrderDetails.Columns.Add("IsNew", string.Empty);
        }
        // Зчитування даних 1 рядка
        private void ReadSingleRow_OrderDetails(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetInt32(3), record.GetInt32(4), record.GetInt32(5), RowState.ModifiedNew);
        }

        // Створення колонок в dataGrid.Town
        private void CreateColumns_Town()
        {
            dataGridView_Town.Columns.Add("id_town", "ID_Міста");
            dataGridView_Town.Columns.Add("town_name", "Назва міста");
            dataGridView_Town.Columns.Add("IsNew", string.Empty);
        }
        // Зчитування даних 1 рядка
        private void ReadSingleRow_Town(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }

        // Створення колонок в dataGrid.ProductDetails
        private void CreateColumns_ProductDetails()
        {
            dataGridView_ProductDetails.Columns.Add("id_info", "ID_Деталі_продукту");
            dataGridView_ProductDetails.Columns.Add("id_product", "ID_Продукту");
            dataGridView_ProductDetails.Columns.Add("size", "Розмір");
            dataGridView_ProductDetails.Columns.Add("id_color", "ID_Кольору");
            dataGridView_ProductDetails.Columns.Add("price", "Ціна");
            dataGridView_ProductDetails.Columns.Add("IsNew", string.Empty);
        }
        // Зчитування даних 1 рядка
        private void ReadSingleRow_ProductDetails(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetInt32(1), record.GetInt32(2), record.GetInt32(3), record.GetInt32(4), RowState.ModifiedNew);
        }

        // Створення колонок в dataGrid.Material
        private void CreateColumns_Material()
        {
            dataGridView_Material.Columns.Add("id_material", "ID_Матеріалу");
            dataGridView_Material.Columns.Add("name_material", "Назва матеріалу");
            dataGridView_Material.Columns.Add("IsNew", string.Empty);
        }
        // Зчитування даних 1 рядка
        private void ReadSingleRow_Material(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1), RowState.ModifiedNew);
        }

        // Створення колонок в dataGrid.Color
        private void CreateColumns_Color()
        {
            dataGridView_Color.Columns.Add("id_color", "ID_Кольору");
            dataGridView_Color.Columns.Add("name_color", "Назва кольору");
            dataGridView_Color.Columns.Add("IsNew", string.Empty);
        }
        // Зчитування даних 1 рядка
        private void ReadSingleRow_Color(DataGridView dgw, IDataRecord record)
        {
            dgw.Rows.Add(record.GetInt32(0), record.GetString(1),  RowState.ModifiedNew);
        }

        // Оновлення таблиці Sklad
        private void RefreshDataGrid_Sklad(DataGridView dgw) 
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Sklad";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read()) 
            {
                ReadSingleRow_Sklad(dgw, reader);
            }
            reader.Close();
        }

        // Оновлення таблиці Category
        private void RefreshDataGrid_Category(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Category";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Category(dgw, reader);
            }
            reader.Close();
        }

        // Оновлення таблиці Client
        private void RefreshDataGrid_Client(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Client";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Client(dgw, reader);
            }
            reader.Close();
        }

        // Оновлення таблиці Product
        private void RefreshDataGrid_Product(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Product";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Product(dgw, reader);
            }
            reader.Close();
        }

        // Оновлення таблиці Orders
        private void RefreshDataGrid_Orders(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Orders";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Orders(dgw, reader);
            }
            reader.Close();
        }

        // Оновлення таблиці OrderDetails
        private void RefreshDataGrid_Order_Details(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Order_Details";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_OrderDetails(dgw, reader);
            }
            reader.Close();
        }

        // Оновлення таблиці Town
        private void RefreshDataGrid_Town(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Town";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Town(dgw, reader);
            }
            reader.Close();
        }

        // Оновлення таблиці ProductDetails
        private void RefreshDataGrid_ProductDetails(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Product_Details";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_ProductDetails(dgw, reader);
            }
            reader.Close();
        }

        // Оновлення таблиці Material
        private void RefreshDataGrid_Material(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Material";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Material(dgw, reader);
            }
            reader.Close();
        }

        // Оновлення таблиці Color
        private void RefreshDataGrid_Color(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string queryString = $"select * from Color";

            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Color(dgw, reader);
            }
            reader.Close();
        }




        /// <summary>
        /// 1 Закладка Sklad
        /// </summary>


        // Показ даних в dataGrid
        private void dataGridView_Sklad_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_Sklad.Rows[selectedRow];

                textBoxId_Sklad.Text = row.Cells[0].Value.ToString(); 
                textBoxAddress_Sklad.Text = row.Cells[1].Value.ToString();
                textBoxIdTown_Sklad.Text = row.Cells[2].Value.ToString();

            }
        }

        // Очищення поля запису Sklad
        private void ClearFields_Sklad()
        {
            textBoxId_Sklad.Text = "";
            textBoxAddress_Sklad.Text = "";
            textBoxIdTown_Sklad.Text = "";
        }


        // Релізації пошуку даних в таблиці Sklad БД
        private void Search_Sklad(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Sklad where concat (id_sklad, address_sklad, id_town) like '%" + textBoxSearch.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Sklad(dgw, reader);
            }
            reader.Close();
        }

        // Видалення рядка з таблиці
        private void deleteRow_Sklad()
        {
            int index = dataGridView_Sklad.CurrentCell.RowIndex;

            dataGridView_Sklad.Rows[index].Visible = false;

            if (dataGridView_Sklad.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView_Sklad.Rows[index].Cells[3].Value = RowState.Deleted;
                return;
            }

            dataGridView_Sklad.Rows[index].Cells[3].Value = RowState.Deleted;

        }

        // Оновлення даних в таблиці Sklad
        private void Update_Sklad()
        {
            dataBase.openConnection();
            for(int index = 0; index < dataGridView_Sklad.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView_Sklad.Rows[index].Cells[3].Value;

                if(rowState == RowState.Existed)
                {
                    continue;
                }

                if(rowState == RowState.Deleted) 
                {
                    var id = Convert.ToInt32(dataGridView_Sklad.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Sklad where id_sklad = {id}";
                    
                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if(rowState == RowState.Modified)
                {
                    var id = dataGridView_Sklad.Rows[index].Cells[0].Value.ToString();
                    var address = dataGridView_Sklad.Rows[index].Cells[1].Value.ToString();
                    var idTown = dataGridView_Sklad.Rows[index].Cells[2].Value.ToString();

                    var stringQuery = $"update Sklad set address_sklad = '{address}', id_town = '{idTown}' where id_sklad = '{id}'";
                    var command = new SqlCommand (stringQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }
        
        // Метод для змінення даних в Sklad
        private void Change_Sklad() 
        {
            var selectedRowIndex = dataGridView_Sklad.CurrentCell.RowIndex;
            var id = textBoxId_Sklad.Text;
            var address = textBoxAddress_Sklad.Text;
            var idTown = textBoxIdTown_Sklad.Text;

            if (dataGridView_Sklad.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView_Sklad.Rows[selectedRowIndex].SetValues(id, address, idTown);
                dataGridView_Sklad.Rows[selectedRowIndex].Cells[3].Value = RowState.Modified;
            }
        }

        // Очистка полей запису
        private void buttonClear_Sklad_Click(object sender, EventArgs e)
        {
            ClearFields_Sklad();
        }

        // Перезавантаження вікна DataGrid та очищення полей запису
        private void buttonRefresh_Sklad_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_Sklad(dataGridView_Sklad);
            ClearFields_Sklad();
        }
        
        // Поле пошуку даних в БД
        private void textBoxSearch_Sklad_TextChanged(object sender, EventArgs e)
        {
            Search_Sklad(dataGridView_Sklad);
        }

        // Кнопка для додавання нового запису в БД
        private void buttonNew_Sklad_Click(object sender, EventArgs e)
        {
            Add_Sklad add_Sklad = new Add_Sklad();
            add_Sklad.Show();
        }

        // Кнопка видалення запису з БД
        private void buttonDelete_Sklad_Click(object sender, EventArgs e)
        {
            deleteRow_Sklad();
            ClearFields_Sklad();

        }

        // Кнопка внесеня змін в запис
        private void buttonChange_Sklad_Click(object sender, EventArgs e)
        {
            Change_Sklad();
            ClearFields_Sklad();
        }

        //Кнопка збереження змін в записі
        private void buttonSave_Sklad_Click(object sender, EventArgs e)
        {
            Update_Sklad();
        }


        /// <summary>
        /// 2 Закладка Category
        /// </summary>

        private void dataGridView_Category_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_Category.Rows[selectedRow];

                textBoxID_Category.Text = row.Cells[0].Value.ToString();
                textBoxName_Category.Text = row.Cells[1].Value.ToString();
            }
        }

        // Очищення поля запису Category
        private void ClearFields_Category()
        {
            textBoxID_Category.Text = "";
            textBoxName_Category.Text = "";
        }

        // Релізації пошуку даних в таблиці Category БД
        private void Search_Category(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Category where concat (id_category, name_category) like '%" + textBoxSearch_Category.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Category(dgw, reader);
            }
            reader.Close();
        }

        // Видалення рядка з таблиці Category
        private void deleteRow_Category()
        {
            int index = dataGridView_Category.CurrentCell.RowIndex;

            dataGridView_Category.Rows[index].Visible = false;

            if (dataGridView_Category.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView_Category.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }

            dataGridView_Category.Rows[index].Cells[2].Value = RowState.Deleted;

        }

        // Оновлення даних в таблиці Category БД
        private void Update_Category()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView_Category.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView_Category.Rows[index].Cells[2].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView_Category.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Category where id_category = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView_Category.Rows[index].Cells[0].Value.ToString();
                    var name = dataGridView_Category.Rows[index].Cells[1].Value.ToString();

                    var stringQuery = $"update Category set name_category = '{name}' where id_category = '{id}'";
                    var command = new SqlCommand(stringQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        // Метод для змінення даних в Category
        private void Change_Category()
        {
            var selectedRowIndex = dataGridView_Category.CurrentCell.RowIndex;
            var id = textBoxID_Category.Text;
            var name = textBoxName_Category.Text;

            if (dataGridView_Category.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView_Category.Rows[selectedRowIndex].SetValues(id, name);
                dataGridView_Category.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
        }

        // Очистка полей запису Category
        private void buttonClear_Category_Click(object sender, EventArgs e)
        {
            ClearFields_Category();
        }

        // Перезавантаження вікна DataGrid та очищення полей запису в Category
        private void buttonRefresh_Category_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_Category(dataGridView_Category);
            ClearFields_Category();
        }

        // Поле пошуку даних в Category
        private void textBoxSearch_Category_TextChanged(object sender, EventArgs e)
        {
            Search_Category(dataGridView_Category);
        }

        // Кнопка для додавання нового запису в БД
        private void buttonNew_Category_Click(object sender, EventArgs e)
        {
            Add_Category add_Category = new Add_Category();
            add_Category.Show();
        }

        // Кнопка видалення запису з Category
        private void buttonDelete_Category_Click(object sender, EventArgs e)
        {
            deleteRow_Category();
            ClearFields_Category();
        }

        // Кнопка внесеня змін в записі
        private void buttonChange_Category_Click(object sender, EventArgs e)
        {
            Change_Category();
            ClearFields_Category();
        }

        //Кнопка збереження змін в записі
        private void buttonSave_Category_Click(object sender, EventArgs e)
        {
            Update_Category();
        }


        /// <summary>
        /// 3 Закладка Client
        /// </summary>

        private void dataGridView_Client_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_Client.Rows[selectedRow];

                textBoxID_Client.Text = row.Cells[0].Value.ToString();
                textBoxName_Client.Text = row.Cells[1].Value.ToString();
                textBoxSurname_Client.Text = row.Cells[2].Value.ToString();
                textBoxPhone_Client.Text = row.Cells[3].Value.ToString();
            }
        }

        // Очищення поля запису Client
        private void ClearFields_Client()
        {
            textBoxID_Client.Text = "";
            textBoxName_Client.Text = "";
            textBoxSurname_Client.Text = "";
            textBoxPhone_Client.Text = "";
        }

        // Релізації пошуку даних в таблиці Client БД
        private void Search_Client(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Client where concat (id_client, name_client, surname_client, phone_client) like '%" + textBoxSearch_Client.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Client(dgw, reader);
            }
            reader.Close();
        }

        // Видалення рядка з таблиці Client
        private void deleteRow_Client()
        {
            int index = dataGridView_Client.CurrentCell.RowIndex;

            dataGridView_Client.Rows[index].Visible = false;

            if (dataGridView_Client.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView_Client.Rows[index].Cells[4].Value = RowState.Deleted;
                return;
            }

            dataGridView_Client.Rows[index].Cells[4].Value = RowState.Deleted;

        }

        // Оновлення даних в таблиці Client БД
        private void Update_Client()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView_Client.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView_Client.Rows[index].Cells[4].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView_Client.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Client where id_client = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView_Client.Rows[index].Cells[0].Value.ToString();
                    var name = dataGridView_Client.Rows[index].Cells[1].Value.ToString();
                    var surName = dataGridView_Client.Rows[index].Cells[2].Value.ToString();
                    var phone = dataGridView_Client.Rows[index].Cells[3].Value.ToString();

                    var stringQuery = $"update Client set name_client = '{name}', surname_client = '{surName}', phone_client = '{phone}' where id_client = '{id}'";
                    var command = new SqlCommand(stringQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        // Метод для змінення даних в Client
        private void Change_Client()
        {
            var selectedRowIndex = dataGridView_Client.CurrentCell.RowIndex;
            var id = textBoxID_Client.Text;
            var name = textBoxName_Client.Text;
            var surName = textBoxSurname_Client.Text;
            var phone = textBoxPhone_Client.Text;

            if (dataGridView_Client.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView_Client.Rows[selectedRowIndex].SetValues(id, name, surName, phone);
                dataGridView_Client.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
            }
        }

        // Очистка полей запису Client
        private void buttonClear_Client_Click(object sender, EventArgs e)
        {
            ClearFields_Client();
        }

        // Перезавантаження вікна DataGrid та очищення полей запису в Client
        private void buttonRefresh_Cleint_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_Client(dataGridView_Client);
            ClearFields_Client();
        }

        // Поле пошуку даних в Client
        private void textBoxSearch_Client_TextChanged(object sender, EventArgs e)
        {
            Search_Client(dataGridView_Client);
        }

        // Кнопка для додавання нового запису в БД
        private void buttonNew_Client_Click(object sender, EventArgs e)
        {
            Add_Client add_Client = new Add_Client();
            add_Client.Show();
        }

        // Кнопка видалення запису з Client
        private void buttonDelete_Client_Click(object sender, EventArgs e)
        {
            deleteRow_Client();
            ClearFields_Client();
        }

        // Кнопка внесеня змін в записі
        private void buttonChange_Client_Click(object sender, EventArgs e)
        {
            Change_Client();
            ClearFields_Client();
        }

        //Кнопка збереження змін в записі
        private void buttonSave_Client_Click(object sender, EventArgs e)
        {
            Update_Client();
        }




        /// <summary>
        /// 4 Закладка Product
        /// </summary>

        private void dataGridView_Product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_Product.Rows[selectedRow];

                textBoxID_Product.Text = row.Cells[0].Value.ToString();
                textBoxName_Product.Text = row.Cells[1].Value.ToString();
                textBoxIdMaterial_Product.Text = row.Cells[2].Value.ToString();
                textBoxIdSklad_Product.Text = row.Cells[3].Value.ToString();
                textBoxIdCategory_Product.Text = row.Cells[4].Value.ToString();
            }
        }

        // Очищення поля запису Product
        private void ClearFields_Product()
        {
            textBoxID_Product.Text = "";
            textBoxName_Product.Text = "";
            textBoxIdMaterial_Product.Text = "";
            textBoxIdSklad_Product.Text = "";
            textBoxIdCategory_Product.Text = "";
        }

        // Релізації пошуку даних в таблиці Product БД
        private void Search_Product(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Product where concat (id_product, name_product, id_material, id_sklad, id_category) like '%" + textBoxSearch_Product.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Product(dgw, reader);
            }
            reader.Close();
        }

        // Видалення рядка з таблиці Product
        private void deleteRow_Product()
        {
            int index = dataGridView_Product.CurrentCell.RowIndex;

            dataGridView_Product.Rows[index].Visible = false;

            if (dataGridView_Product.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView_Product.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }

            dataGridView_Product.Rows[index].Cells[5].Value = RowState.Deleted;

        }

        // Оновлення даних в таблиці Product БД
        private void Update_Product()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView_Product.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView_Product.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView_Product.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Product where id_product = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var idProduct = dataGridView_Product.Rows[index].Cells[0].Value.ToString();
                    var nameProduct = dataGridView_Product.Rows[index].Cells[1].Value.ToString();
                    var idMaterial = dataGridView_Product.Rows[index].Cells[2].Value.ToString();
                    var idSklad = dataGridView_Product.Rows[index].Cells[3].Value.ToString();
                    var idCategory = dataGridView_Product.Rows[index].Cells[4].Value.ToString();

                    var stringQuery = $"update Product set name_product = '{nameProduct}', id_material = '{idMaterial}', id_sklad = '{idSklad}', id_category = '{idCategory}' where id_product = '{idProduct}'";
                    var command = new SqlCommand(stringQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        // Метод для змінення даних в Product
        private void Change_Product()
        {
            var selectedRowIndex = dataGridView_Product.CurrentCell.RowIndex;
            var idProduct = textBoxID_Product.Text;
            var name = textBoxName_Product.Text;
            var idMaterial = textBoxIdMaterial_Product.Text;
            var idSklad = textBoxIdSklad_Product.Text;
            var idCategory = textBoxIdCategory_Product.Text;

            if (dataGridView_Product.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView_Product.Rows[selectedRowIndex].SetValues(idProduct, name, idMaterial, idSklad, idCategory);
                dataGridView_Product.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
            }
        }

        // Очистка полей запису Product
        private void buttonClear_Product_Click(object sender, EventArgs e)
        {
            ClearFields_Product();
        }

        // Перезавантаження вікна DataGrid та очищення полей запису в Product
        private void buttonRefresh_Product_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_Product(dataGridView_Product);
            ClearFields_Product();
        }

        // Поле пошуку даних в Product
        private void textBoxSearch_Product_TextChanged(object sender, EventArgs e)
        {
            Search_Product(dataGridView_Product);
        }

        // Кнопка для додавання нового запису в БД
        private void buttonNew_Product_Click(object sender, EventArgs e)
        {
            Add_Product add_Product = new Add_Product();
            add_Product.Show();
        }

        // Кнопка видалення запису з Product
        private void buttonDelete_Product_Click(object sender, EventArgs e)
        {
            deleteRow_Product();
            ClearFields_Product();
        }

        // Кнопка внесеня змін в записі
        private void buttonChange_Product_Click(object sender, EventArgs e)
        {
            Change_Product();
            ClearFields_Product();
        }

        //Кнопка збереження змін в записі
        private void buttonSave_Product_Click(object sender, EventArgs e)
        {
            Update_Product();
        }


        /// <summary>
        /// 5 Закладка Order
        /// </summary>

        private void dataGridView_Order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_Order.Rows[selectedRow];

                textBoxID_Order.Text = row.Cells[0].Value.ToString();
                textBoxIdClient_Order.Text = row.Cells[1].Value.ToString();
                textBoxDate_Order.Text = row.Cells[2].Value.ToString();
                textBoxStatus_Order.Text = row.Cells[3].Value.ToString();
            }
        }

        // Очищення поля запису Order
        private void ClearFields_Order()
        {
            textBoxID_Order.Text = "";
            textBoxIdClient_Order.Text = "";
            textBoxDate_Order.Text = "";
            textBoxStatus_Order.Text = "";
        }

        // Релізації пошуку даних в таблиці Orders БД
        private void Search_Orders(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Orders where concat (id_order, id_client, date_order, status_order) like '%" + textBoxSearch_Order.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Orders(dgw, reader);
            }
            reader.Close();
        }

        // Видалення рядка з таблиці Order
        private void deleteRow_Order()
        {
            int index = dataGridView_Order.CurrentCell.RowIndex;

            dataGridView_Order.Rows[index].Visible = false;

            if (dataGridView_Order.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView_Order.Rows[index].Cells[4].Value = RowState.Deleted;
                return;
            }

            dataGridView_Order.Rows[index].Cells[4].Value = RowState.Deleted;

        }

        // Оновлення даних в таблиці Order БД
        private void Update_Order()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView_Order.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView_Order.Rows[index].Cells[4].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView_Order.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Orders where id_order = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var id = dataGridView_Order.Rows[index].Cells[0].Value.ToString();
                    var idClient = dataGridView_Order.Rows[index].Cells[1].Value.ToString();
                    var dateOrder = dataGridView_Order.Rows[index].Cells[2].Value.ToString();
                    var status = dataGridView_Order.Rows[index].Cells[3].Value.ToString();

                    var stringQuery = $"update Orders set id_client = '{idClient}', date_order = '{dateOrder}', status_order = '{status}' where id_order = '{id}'";
                    var command = new SqlCommand(stringQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        // Метод для змінення даних в Order
        private void Change_Order()
        {
            var selectedRowIndex = dataGridView_Order.CurrentCell.RowIndex;
            var id = textBoxID_Order.Text;
            var idClient = textBoxIdClient_Order.Text;
            var date = textBoxDate_Order.Text;
            var status = textBoxStatus_Order.Text;
            
            if (dataGridView_Order.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView_Order.Rows[selectedRowIndex].SetValues(id, idClient, date, status);
                dataGridView_Order.Rows[selectedRowIndex].Cells[4].Value = RowState.Modified;
            }
        }

        // Очистка полей запису Order
        private void buttonClear_Order_Click(object sender, EventArgs e)
        {
            ClearFields_Order();
        }

        // Перезавантаження вікна DataGrid та очищення полей запису в Order
        private void buttonRefresh_Order_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_Orders(dataGridView_Order);
            ClearFields_Order();
        }

        // Поле пошуку даних в Order
        private void textBoxSearch_Order_TextChanged(object sender, EventArgs e)
        {
            Search_Orders(dataGridView_Order);
        }

        // Кнопка для додавання нового запису в БД
        private void buttonNew_Order_Click(object sender, EventArgs e)
        {
            Add_Order add_Order = new Add_Order();
            add_Order.Show();
        }

        // Кнопка видалення запису з Order
        private void buttonDelete_Order_Click(object sender, EventArgs e)
        {
            deleteRow_Order();
            ClearFields_Order();
        }

        // Кнопка внесеня змін в записі
        private void buttonChange_Order_Click(object sender, EventArgs e)
        {
            Change_Order();
            ClearFields_Order();
        }

        //Кнопка збереження змін в записі
        private void buttonSave_Order_Click(object sender, EventArgs e)
        {
            Update_Order();
        }



        /// <summary>
        /// 6 Закладка Order_Details
        /// </summary>

        private void dataGridView_OrderDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_OrderDetails.Rows[selectedRow];

                textBoxIdRecord_OrderDetails.Text = row.Cells[0].Value.ToString();
                textBoxIdOrder_OrderDetails.Text = row.Cells[1].Value.ToString();
                textBoxIdInfo_OrderDetails.Text = row.Cells[2].Value.ToString();
                textBoxAmount_OrderDetails.Text = row.Cells[3].Value.ToString();                
                textBoxNovaPoshta_OrderDetails.Text = row.Cells[4].Value.ToString();
                textBoxIdTown_OrderDetails.Text = row.Cells[5].Value.ToString();
            }
        }

        // Очищення поля запису Order_Details
        private void ClearFields_OrderDetails()
        {
            textBoxIdRecord_OrderDetails.Text = "";
            textBoxIdOrder_OrderDetails.Text = "";
            textBoxIdInfo_OrderDetails.Text = "";
            textBoxAmount_OrderDetails.Text = "";
            textBoxIdTown_OrderDetails.Text = "";
            textBoxNovaPoshta_OrderDetails.Text = "";
        }

        // Релізації пошуку даних в таблиці Order_Details БД
        private void Search_OrderDetails(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Order_Details where concat (id_record, id_order, id_info, amount, branchNP, id_town) like '%" + textBoxSearch_OrderDetails.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_OrderDetails(dgw, reader);
            }
            reader.Close();
        }

        // Видалення рядка з таблиці OrderDetails
        private void deleteRow_OrderDetails()
        {
            int index = dataGridView_OrderDetails.CurrentCell.RowIndex;

            dataGridView_OrderDetails.Rows[index].Visible = false;

            if (dataGridView_OrderDetails.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView_OrderDetails.Rows[index].Cells[6].Value = RowState.Deleted;
                return;
            }

            dataGridView_OrderDetails.Rows[index].Cells[6].Value = RowState.Deleted;

        }

        // Оновлення даних в таблиці OrderDetails БД
        private void Update_OrderDetails()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView_OrderDetails.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView_OrderDetails.Rows[index].Cells[6].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView_OrderDetails.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Order_Details where id_record = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var idRecord = dataGridView_OrderDetails.Rows[index].Cells[0].Value.ToString();
                    var idOrder = dataGridView_OrderDetails.Rows[index].Cells[1].Value.ToString();
                    var idInfo = dataGridView_OrderDetails.Rows[index].Cells[2].Value.ToString();
                    var amount = dataGridView_OrderDetails.Rows[index].Cells[3].Value.ToString();
                    var novaP = dataGridView_OrderDetails.Rows[index].Cells[4].Value.ToString();
                    var idTown = dataGridView_OrderDetails.Rows[index].Cells[5].Value.ToString();


                    var stringQuery = $"update Order_Details set id_order = '{idOrder}', id_info = '{idInfo}', amount = '{amount}', branchNP = '{novaP}', id_town = '{idTown}' where id_record = '{idRecord}'";
                    var command = new SqlCommand(stringQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        // Метод для змінення даних в OrderDetails
        private void Change_OrderDetails()
        {
            var selectedRowIndex = dataGridView_OrderDetails.CurrentCell.RowIndex;
            var idRecord = textBoxIdRecord_OrderDetails.Text;
            var idOrder = textBoxIdOrder_OrderDetails.Text;
            var idInfo = textBoxIdInfo_OrderDetails.Text;
            var amount = textBoxAmount_OrderDetails.Text;
            var novaP = textBoxNovaPoshta_OrderDetails.Text;
            var town = textBoxIdTown_OrderDetails.Text;

            if (dataGridView_OrderDetails.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView_OrderDetails.Rows[selectedRowIndex].SetValues(idRecord, idOrder, idInfo, amount, novaP, town);
                dataGridView_OrderDetails.Rows[selectedRowIndex].Cells[6].Value = RowState.Modified;
            }
        }

        // Очистка полей запису OrderDetails
        private void buttonClear_OrderDetails_Click(object sender, EventArgs e)
        {
            ClearFields_OrderDetails();
        }

        // Перезавантаження вікна DataGrid та очищення полей запису в OrderDetails
        private void buttonRefresh_OrderDetails_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_Order_Details(dataGridView_OrderDetails);
            ClearFields_OrderDetails();
        }

        // Поле пошуку даних в OrderDetails
        private void textBoxSearch_OrderDetails_TextChanged(object sender, EventArgs e)
        {
            Search_OrderDetails(dataGridView_OrderDetails);
        }

        // Кнопка для додавання нового запису в БД
        private void buttonNew_OrderDetails_Click(object sender, EventArgs e)
        {
            Add_Order_Details add_Order_Details = new Add_Order_Details();
            add_Order_Details.Show();
        }

        // Кнопка видалення запису з OrderDetails
        private void buttonDelete_OrderDetails_Click(object sender, EventArgs e)
        {
            deleteRow_OrderDetails();
            ClearFields_OrderDetails();
        }

        // Кнопка внесеня змін в записі
        private void buttonChange_OrderDetails_Click(object sender, EventArgs e)
        {
            Change_OrderDetails();
            ClearFields_OrderDetails();
        }

        //Кнопка збереження змін в записі
        private void buttonSave_OrderDetails_Click(object sender, EventArgs e)
        {
            Update_OrderDetails();
        }

        /// <summary>
        /// 7 Закладка Town
        /// </summary>

        private void dataGridView_Town_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_Town.Rows[selectedRow];

                textBoxID_Town.Text = row.Cells[0].Value.ToString();
                textBoxName_Town.Text = row.Cells[1].Value.ToString();
            }
        }

        // Очищення поля запису Town
        private void ClearFields_Town()
        {
            textBoxID_Town.Text = "";
            textBoxName_Town.Text = "";
        }

        // Релізації пошуку даних в таблиці Town БД
        private void Search_Town(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Town where concat (id_town, name_town) like '%" + textBoxSearch_Town.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Town(dgw, reader);
            }
            reader.Close();
        }

        // Видалення рядка з таблиці Town
        private void deleteRow_Town()
        {
            int index = dataGridView_Town.CurrentCell.RowIndex;

            dataGridView_Town.Rows[index].Visible = false;

            if (dataGridView_Town.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView_Town.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }

            dataGridView_Town.Rows[index].Cells[2].Value = RowState.Deleted;

        }

        // Оновлення даних в таблиці Town БД
        private void Update_Town()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView_Town.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView_Town.Rows[index].Cells[2].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView_Town.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Town where id_town = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var idTown = dataGridView_Town.Rows[index].Cells[0].Value.ToString();
                    var nameTown = dataGridView_Town.Rows[index].Cells[1].Value.ToString();


                    var stringQuery = $"update Town set name_town = '{nameTown}' where id_town = '{idTown}'";
                    var command = new SqlCommand(stringQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        // Метод для змінення даних в Town
        private void Change_Town()
        {
            var selectedRowIndex = dataGridView_OrderDetails.CurrentCell.RowIndex;
            var idTown = textBoxID_Town.Text;
            var nameTown = textBoxName_Town.Text;


            if (dataGridView_OrderDetails.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView_OrderDetails.Rows[selectedRowIndex].SetValues(idTown, nameTown);
                dataGridView_OrderDetails.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
        }

        // Очистка полей запису Town
        private void buttonClear_Town_Click(object sender, EventArgs e)
        {
            ClearFields_Town();
        }

        // Перезавантаження вікна DataGrid та очищення полей запису в Town
        private void buttonRefresh_Town_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_Town(dataGridView_Town);
            ClearFields_Town();
        }

        // Поле пошуку даних в Town
        private void textBoxSearch_Town_TextChanged(object sender, EventArgs e)
        {
            Search_Town(dataGridView_Town);
        }

        private void buttonNew_Town_Click(object sender, EventArgs e)
        {
            Add_Town add_Town = new Add_Town();
            add_Town.Show();
        }

        private void buttonDelete_Town_Click(object sender, EventArgs e)
        {
            deleteRow_Town();
            ClearFields_Town();
        }

        private void buttonChange_Town_Click(object sender, EventArgs e)
        {
            Change_Town();
            ClearFields_Town();
        }

        private void buttonSave_Town_Click(object sender, EventArgs e)
        {
            Update_Town();
        }

        /// <summary>
        /// 8 Закладка ProductDetails
        /// </summary>

        private void dataGridView_ProductDetails_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_ProductDetails.Rows[selectedRow];

                textBoxIdInfo_ProductDetails.Text = row.Cells[0].Value.ToString();
                textBoxIdProduct_ProductDetails.Text = row.Cells[1].Value.ToString();
                textBoxSize_ProductDetails.Text = row.Cells[2].Value.ToString();
                textBoxIdColor_ProductDetails.Text = row.Cells[3].Value.ToString();
                textBoxPrice_ProductDetails.Text = row.Cells[4].Value.ToString();

            }
        }

        // Очищення поля запису ProductDetails
        private void ClearFields_ProductDetails()
        {
            textBoxIdInfo_ProductDetails.Text = "";
            textBoxIdProduct_ProductDetails.Text = "";
            textBoxSize_ProductDetails.Text = "";
            textBoxIdColor_ProductDetails.Text = "";
            textBoxPrice_ProductDetails.Text = "";

        }

        // Релізації пошуку даних в таблиці ProductDetails БД
        private void Search_ProductDetails(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Product_Details where concat (id_info, id_product, size, id_color, price) like '%" + textBoxSearch_ProductDetails.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_ProductDetails(dgw, reader);
            }
            reader.Close();
        }

        // Видалення рядка з таблиці ProductDetails
        private void deleteRow_ProductDetails()
        {
            int index = dataGridView_ProductDetails.CurrentCell.RowIndex;

            dataGridView_ProductDetails.Rows[index].Visible = false;

            if (dataGridView_ProductDetails.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView_ProductDetails.Rows[index].Cells[5].Value = RowState.Deleted;
                return;
            }

            dataGridView_ProductDetails.Rows[index].Cells[5].Value = RowState.Deleted;

        }

        // Оновлення даних в таблиці ProductDetails БД
        private void Update_ProductDetails()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView_ProductDetails.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView_ProductDetails.Rows[index].Cells[5].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView_ProductDetails.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Product_Details where id_info = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var idInfo = dataGridView_ProductDetails.Rows[index].Cells[0].Value.ToString();
                    var idProduct = dataGridView_ProductDetails.Rows[index].Cells[1].Value.ToString();
                    var size = dataGridView_ProductDetails.Rows[index].Cells[2].Value.ToString();
                    var idColor = dataGridView_ProductDetails.Rows[index].Cells[3].Value.ToString();
                    var price = dataGridView_ProductDetails.Rows[index].Cells[4].Value.ToString();



                    var stringQuery = $"update Product_Details set id_product = '{idProduct}', size = '{size}', id_color = '{idColor}', price = '{price}' where id_info = '{idInfo}'";
                    var command = new SqlCommand(stringQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        // Метод для змінення даних в ProductDetails
        private void Change_ProductDetails()
        {
            var selectedRowIndex = dataGridView_ProductDetails.CurrentCell.RowIndex;
            var idInfo = textBoxIdInfo_ProductDetails.Text;
            var idProduct = textBoxIdProduct_ProductDetails.Text;
            var size = textBoxSize_ProductDetails.Text;
            var idColor = textBoxIdColor_ProductDetails.Text;
            var price = textBoxPrice_ProductDetails.Text;

            if (dataGridView_ProductDetails.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView_ProductDetails.Rows[selectedRowIndex].SetValues(idInfo, idProduct, size, idColor, price);
                dataGridView_ProductDetails.Rows[selectedRowIndex].Cells[5].Value = RowState.Modified;
            }
        }

        // Очистка полей запису ProductDetails
        private void buttonClear_ProductDetails_Click(object sender, EventArgs e)
        {
            ClearFields_ProductDetails();
        }

        // Перезавантаження вікна DataGrid та очищення полей запису в ProductDetails
        private void buttonRefresh_ProductDetails_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_ProductDetails(dataGridView_ProductDetails);
            ClearFields_ProductDetails();
        }

        // Поле пошуку даних в ProductDetails
        private void textBoxSearch_ProductDetails_TextChanged(object sender, EventArgs e)
        {
            Search_ProductDetails(dataGridView_ProductDetails);
        }

        private void buttonNew_ProductDetails_Click(object sender, EventArgs e)
        {
            Add_Product_Details add_Product_Details = new Add_Product_Details();
            add_Product_Details.Show();
        }

        private void buttonDelete_ProductDetails_Click(object sender, EventArgs e)
        {
            deleteRow_ProductDetails();
            ClearFields_ProductDetails();
        }

        private void buttonChange_ProductDetails_Click(object sender, EventArgs e)
        {
            Change_ProductDetails();
            ClearFields_ProductDetails();
        }

        private void buttonSave_ProductDetails_Click(object sender, EventArgs e)
        {
            Update_ProductDetails();
        }

        /// <summary>
        /// 9 Закладка Material
        /// </summary>

        private void dataGridView_Material_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_Material.Rows[selectedRow];

                textBoxID_Material.Text = row.Cells[0].Value.ToString();
                textBoxName_Material.Text = row.Cells[1].Value.ToString();
            }
        }

        // Очищення поля запису Material
        private void ClearFields_Material()
        {
            textBoxID_Material.Text = "";
            textBoxName_Material.Text = "";
        }

        // Релізації пошуку даних в таблиці Material БД
        private void Search_Material(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Material where concat (id_material, name_material) like '%" + textBoxSearch_Material.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Material(dgw, reader);
            }
            reader.Close();
        }

        // Видалення рядка з таблиці Material
        private void deleteRow_Material()
        {
            int index = dataGridView_Material.CurrentCell.RowIndex;

            dataGridView_Material.Rows[index].Visible = false;

            if (dataGridView_Material.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView_Material.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }

            dataGridView_Material.Rows[index].Cells[2].Value = RowState.Deleted;

        }

        // Оновлення даних в таблиці Material БД
        private void Update_Material()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView_Material.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView_Material.Rows[index].Cells[2].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView_Material.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Material where id_material = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var idMaterial = dataGridView_Material.Rows[index].Cells[0].Value.ToString();
                    var nameMaterial = dataGridView_Material.Rows[index].Cells[1].Value.ToString();


                    var stringQuery = $"update Material set name_material = '{nameMaterial}' where id_material = '{idMaterial}'";
                    var command = new SqlCommand(stringQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        // Метод для змінення даних в Material
        private void Change_Material()
        {
            var selectedRowIndex = dataGridView_ProductDetails.CurrentCell.RowIndex;
            var idMaterial = textBoxID_Material.Text;
            var nameMaterial = textBoxName_Material.Text;


            if (dataGridView_ProductDetails.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView_ProductDetails.Rows[selectedRowIndex].SetValues(idMaterial, nameMaterial);
                dataGridView_ProductDetails.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
        }

        // Очистка полей запису Material
        private void buttonClear_Material_Click(object sender, EventArgs e)
        {
            ClearFields_Material();
        }

        // Перезавантаження вікна DataGrid та очищення полей запису в Material
        private void buttonRefresh_Material_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_Material(dataGridView_Material);
            ClearFields_Material();
        }

        // Поле пошуку даних в Material
        private void textBoxSearch_Material_TextChanged(object sender, EventArgs e)
        {
            Search_Material(dataGridView_Material);
        }

        private void buttonNew_Material_Click(object sender, EventArgs e)
        {
            Add_Material add_Material = new Add_Material();
            add_Material.Show();
        }

        private void buttonDelete_Material_Click(object sender, EventArgs e)
        {
            deleteRow_Material();
            ClearFields_Material();
        }

        private void buttonChange_Material_Click(object sender, EventArgs e)
        {
            Change_Material();
            ClearFields_Material();
        }

        private void buttonSave_Material_Click(object sender, EventArgs e)
        {
            Update_Material();
        }

        /// <summary>
        /// 10 Закладка Color
        /// </summary>

        private void dataGridView_Color_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = e.RowIndex;
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView_Color.Rows[selectedRow];

                textBoxID_Color.Text = row.Cells[0].Value.ToString();
                textBoxName_Color.Text = row.Cells[1].Value.ToString();
            }
        }

        // Очищення поля запису Color
        private void ClearFields_Color()
        {
            textBoxID_Color.Text = "";
            textBoxName_Color.Text = "";
        }

        // Релізації пошуку даних в таблиці Color БД
        private void Search_Color(DataGridView dgw)
        {
            dgw.Rows.Clear();

            string searchString = $"select * from Color where concat (id_color, name_color) like '%" + textBoxSearch_Color.Text + "%'";

            SqlCommand command = new SqlCommand(searchString, dataBase.getConnection());

            dataBase.openConnection();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ReadSingleRow_Color(dgw, reader);
            }
            reader.Close();
        }

        // Видалення рядка з таблиці Color
        private void deleteRow_Color()
        {
            int index = dataGridView_Color.CurrentCell.RowIndex;

            dataGridView_Color.Rows[index].Visible = false;

            if (dataGridView_Color.Rows[index].Cells[0].Value.ToString() == string.Empty)
            {
                dataGridView_Color.Rows[index].Cells[2].Value = RowState.Deleted;
                return;
            }

            dataGridView_Color.Rows[index].Cells[2].Value = RowState.Deleted;

        }

        // Оновлення даних в таблиці Color БД
        private void Update_Color()
        {
            dataBase.openConnection();
            for (int index = 0; index < dataGridView_Color.Rows.Count; index++)
            {
                var rowState = (RowState)dataGridView_Color.Rows[index].Cells[2].Value;

                if (rowState == RowState.Existed)
                {
                    continue;
                }

                if (rowState == RowState.Deleted)
                {
                    var id = Convert.ToInt32(dataGridView_Color.Rows[index].Cells[0].Value);
                    var deleteQuery = $"delete from Color where id_color = {id}";

                    var command = new SqlCommand(deleteQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }

                if (rowState == RowState.Modified)
                {
                    var idColor = dataGridView_Color.Rows[index].Cells[0].Value.ToString();
                    var nameColor = dataGridView_Color.Rows[index].Cells[1].Value.ToString();


                    var stringQuery = $"update Color set name_color = '{nameColor}' where id_color = '{idColor}'";
                    var command = new SqlCommand(stringQuery, dataBase.getConnection());
                    command.ExecuteNonQuery();
                }
            }
            dataBase.closeConnection();
        }

        // Метод для змінення даних в Color
        private void Change_Color()
        {
            var selectedRowIndex = dataGridView_Color.CurrentCell.RowIndex;
            var idColor = textBoxID_Color.Text;
            var nameColor = textBoxName_Color.Text;


            if (dataGridView_Color.Rows[selectedRowIndex].Cells[0].Value.ToString() != string.Empty)
            {
                dataGridView_Color.Rows[selectedRowIndex].SetValues(idColor, nameColor);
                dataGridView_Color.Rows[selectedRowIndex].Cells[2].Value = RowState.Modified;
            }
        }

        // Очистка полей запису Color
        private void buttonClear_Color_Click(object sender, EventArgs e)
        {
            ClearFields_Color();
        }

        // Перезавантаження вікна DataGrid та очищення полей запису в Color
        private void buttonRefresh_Color_Click(object sender, EventArgs e)
        {
            RefreshDataGrid_Color(dataGridView_Color);
            ClearFields_Color();
        }

        // Поле пошуку даних в Color
        private void textBoxSearch_Color_TextChanged(object sender, EventArgs e)
        {
            Search_Color(dataGridView_Color);
        }

        private void buttonNew_Color_Click(object sender, EventArgs e)
        {
            Add_Color add_Color = new Add_Color();
            add_Color.Show();
        }

        private void buttonDelete_Color_Click(object sender, EventArgs e)
        {
            deleteRow_Color();
            ClearFields_Color();
        }

        private void buttonChange_Color_Click(object sender, EventArgs e)
        {
            Change_Color();
            ClearFields_Color();
        }

        private void buttonSave_Color_Click(object sender, EventArgs e)
        {
            Update_Color();
        }
    }
}