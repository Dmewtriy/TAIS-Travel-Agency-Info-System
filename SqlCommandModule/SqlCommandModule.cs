using TAIS__Tourist_Agency_Info_System_.Data.Repositories;

namespace SqlCommandModule
{
    public partial class SqlCommandForm : Form
    {
        private InitRepos database;
        public SqlCommandForm(InitRepos initRepos)
        {
            database = initRepos;
            InitializeComponent();
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            string query = txtSqlQuery.Text
                .Replace("\r\n", " ")
                .Replace("\n", " ")
                .Replace("\t", " ")
                .Replace("\v", " ")
                .Trim();

            if (string.IsNullOrEmpty(query))
            {
                MessageBox.Show("Введите запрос!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstResults.Items.Clear(); // Очищаем старые результаты
            try
            {
                ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExecuteQuery(string query)
        {
            var results = database.carrierRep.SqlCommand(query); // Получаете список строк или объектов
            foreach (var item in results)
            {
                lstResults.Items.Add(item.ToString());
            }
            lblStatus.Text = $"Найдено записей: {lstResults.Items.Count}";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSqlQuery.Clear();
            lstResults.Items.Clear();
            lblStatus.Text = "Готов";
        }
    }
}