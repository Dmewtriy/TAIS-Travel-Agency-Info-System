using TAIS__Tourist_Agency_Info_System_.Entities.Class;
using TAIS__Tourist_Agency_Info_System_.Entities.Enums;

namespace EmployeeModule
{
    public partial class EmployeeEditForm : Form
    {
        // Результат работы формы
        public Employee ResultEmployee { get; private set; }

        // Списки данных
        private List<Position> allPositions;
        private Employee existingEmployee;
        private bool isEditMode;

        // Конструктор для создания нового сотрудника
        public EmployeeEditForm(List<Position> allPositions)
        {
            InitializeComponent();
            this.allPositions = allPositions ?? new List<Position>();
            this.isEditMode = false;

            InitializeForm();
            this.Text = "Создание сотрудника";
        }

        // Конструктор для редактирования существующего сотрудника
        public EmployeeEditForm(List<Position> allPositions, Employee existingEmployee)
        {
            InitializeComponent();
            this.allPositions = allPositions ?? new List<Position>();
            this.isEditMode = true;
            this.existingEmployee = existingEmployee;
            ResultEmployee = existingEmployee;

            InitializeForm();
            LoadEmployeeData(existingEmployee);
            this.Text = "Редактирование сотрудника";
        }

        private void InitializeForm()
        {
            // Заполнение выпадающих списков
            FillComboBoxes();

            // Установка начальных значений
            birthdayPicker.Value = DateTime.Today.AddYears(-25); // По умолчанию 25 лет
            timeWorkNumeric.Value = 0;
        }

        private void FillComboBoxes()
        {
            // Заполнение списка должностей
            positionComboBox.Items.Clear();
            foreach (var Position in allPositions)
            {
                positionComboBox.Items.Add(Position.Title);
            }

            if (positionComboBox.Items.Count > 0)
                positionComboBox.SelectedIndex = 0;

            // Заполнение списка пола
            genderComboBox.Items.Clear();
            genderComboBox.Items.Add("Мужской");
            genderComboBox.Items.Add("Женский");

            if (genderComboBox.Items.Count > 0)
                genderComboBox.SelectedIndex = 0;
        }

        private void LoadEmployeeData(Employee employee)
        {
            try
            {
                // Личные данные
                surnameTextBox.Text = employee.LastName;
                nameTextBox.Text = employee.FirstName;
                patronymicTextBox.Text = employee.MiddleName;

                // Пол
                if (employee.Gender == Gender.M)
                    genderComboBox.SelectedIndex = 0;
                else if (employee.Gender == Gender.W)
                    genderComboBox.SelectedIndex = 1;

                // Дата рождения
                birthdayPicker.Value = employee.BirthDate;

                // Адрес
                if (employee.Street != null)
                {
                    streetTextBox.Text = employee.Street.Name;
                }

                // Рабочие данные
                timeWorkNumeric.Value = (decimal)employee.WorkExperience;

                // Должность
                if (employee.Position != null)
                {
                    for (int i = 0; i < positionComboBox.Items.Count; i++)
                    {
                        if (positionComboBox.Items[i].ToString() == employee.Position.Title)
                        {
                            positionComboBox.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Валидация обязательных полей
                if (string.IsNullOrWhiteSpace(surnameTextBox.Text))
                {
                    MessageBox.Show("Введите фамилию", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    surnameTextBox.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                {
                    MessageBox.Show("Введите имя", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    nameTextBox.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(streetTextBox.Text))
                {
                    MessageBox.Show("Введите улицу", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    streetTextBox.Focus();
                    return;
                }

                if (positionComboBox.SelectedItem == null)
                {
                    MessageBox.Show("Выберите должность", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    positionComboBox.Focus();
                    return;
                }

                // Получение выбранной должности
                string selectedPositionName = positionComboBox.SelectedItem.ToString();
                Position selectedPosition = allPositions.FirstOrDefault(p => p.Title == selectedPositionName);

                if (selectedPosition == null)
                {
                    MessageBox.Show("Выбранная должность не найдена", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Пол
                Gender gender = Gender.M;
                if (genderComboBox.SelectedIndex == 1)
                    gender = Gender.W;

                // Создание адреса
                Street address = new Street(
                    0,
                    streetTextBox.Text.Trim()
                );

                if (isEditMode && existingEmployee != null)
                {
                    // Редактирование существующего сотрудника
                    existingEmployee.LastName = surnameTextBox.Text.Trim();
                    existingEmployee.FirstName = nameTextBox.Text.Trim();
                    existingEmployee.MiddleName = patronymicTextBox.Text?.Trim();
                    existingEmployee.Gender = gender;
                    existingEmployee.BirthDate = birthdayPicker.Value;
                    existingEmployee.Street = address;
                    existingEmployee.WorkExperience = (int)timeWorkNumeric.Value;
                    existingEmployee.Position = selectedPosition;

                    ResultEmployee = existingEmployee;
                }
                else
                {
                    // Создание нового сотрудника
                    ResultEmployee = new Employee(
                        id: 0,
                        firstName: nameTextBox.Text.Trim(),
                        middleName: patronymicTextBox.Text?.Trim(),
                        lastName: surnameTextBox.Text.Trim(),
                        birthDate: birthdayPicker.Value,
                        gender: gender,
                        workExperience: (decimal)timeWorkNumeric.Value,
                        streetId: address.Id,
                        positionId: selectedPosition.Id
                    );
                }
                ResultEmployee.Street = address;
                ResultEmployee.Position = selectedPosition;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}