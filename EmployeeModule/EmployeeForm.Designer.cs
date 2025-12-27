namespace EmployeeModule
{
    partial class EmployeeForm
    {
        private System.ComponentModel.IContainer components = null;
        private SplitContainer mainSplitContainer;
        private Panel topPanel;
        private Panel filterPanel;
        private TableLayoutPanel filterTableLayout;
        private Label searchLabel;
        private TextBox searchTextBox;
        private Label positionFilterLabel;
        private ComboBox positionFilterComboBox;
        private Button applyFilterButton;
        private Button resetFilterButton;
        private DataGridView employeesDataGridView;
        private Button deleteEmployeeButton;
        private Button selectEmployeeButton;
        private Button addEmployeeButton;
        private Button editEmployeeButton;
        private Panel bottomPanel;
        private Panel employmentDetailsPanel;
        private TableLayoutPanel employmentFormTableLayout;
        private Label positionLabel;
        private ComboBox positionComboBox;
        private Label workplaceLabel;
        private TextBox workplaceTextBox;
        private Label eventDateLabel;
        private DateTimePicker eventDatePicker;
        private Label documentNumberLabel;
        private TextBox documentNumberTextBox;
        private Label documentTypeLabel;
        private TextBox documentTypeTextBox;
        private Label dismissalReasonLabel;
        private TextBox dismissalReasonTextBox;
        private Button deleteEmploymentButton;
        private Button addEmploymentButton;
        private DataGridView employmentHistoryDataGridView;
        private Button exitButton;
        private Label employmentHistoryLabel;
        private Label eventTypeLabel;
        private ComboBox eventTypeComboBox;

        private DataGridViewTextBoxColumn colEmployeeNumber;
        private DataGridViewTextBoxColumn colSurname;
        private DataGridViewTextBoxColumn colName;
        private DataGridViewTextBoxColumn colPatronymic;
        private DataGridViewTextBoxColumn colPosition;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            mainSplitContainer = new SplitContainer();
            topPanel = new Panel();
            filterPanel = new Panel();
            filterTableLayout = new TableLayoutPanel();
            searchLabel = new Label();
            searchTextBox = new TextBox();
            positionFilterLabel = new Label();
            positionFilterComboBox = new ComboBox();
            applyFilterButton = new Button();
            resetFilterButton = new Button();
            employeesDataGridView = new DataGridView();
            colEmployeeNumber = new DataGridViewTextBoxColumn();
            colSurname = new DataGridViewTextBoxColumn();
            colName = new DataGridViewTextBoxColumn();
            colPatronymic = new DataGridViewTextBoxColumn();
            colPosition = new DataGridViewTextBoxColumn();
            deleteEmployeeButton = new Button();
            selectEmployeeButton = new Button();
            editEmployeeButton = new Button();
            addEmployeeButton = new Button();
            bottomPanel = new Panel();
            employmentDetailsPanel = new Panel();
            employmentFormTableLayout = new TableLayoutPanel();
            positionLabel = new Label();
            positionComboBox = new ComboBox();
            workplaceLabel = new Label();
            workplaceTextBox = new TextBox();
            eventDateLabel = new Label();
            eventDatePicker = new DateTimePicker();
            documentNumberLabel = new Label();
            documentNumberTextBox = new TextBox();
            documentTypeLabel = new Label();
            documentTypeTextBox = new TextBox();
            eventTypeLabel = new Label();
            eventTypeComboBox = new ComboBox();
            dismissalReasonLabel = new Label();
            dismissalReasonTextBox = new TextBox();
            deleteEmploymentButton = new Button();
            addEmploymentButton = new Button();
            employmentHistoryLabel = new Label();
            employmentHistoryDataGridView = new DataGridView();
            exitButton = new Button();
            colHistoryEventDate = new DataGridViewTextBoxColumn();
            colHistoryPosition = new DataGridViewTextBoxColumn();
            colHistoryWorkplace = new DataGridViewTextBoxColumn();
            colHistoryEventType = new DataGridViewTextBoxColumn();
            colHistoryDocumentType = new DataGridViewTextBoxColumn();
            colHistoryDismissalReason = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)mainSplitContainer).BeginInit();
            mainSplitContainer.Panel1.SuspendLayout();
            mainSplitContainer.Panel2.SuspendLayout();
            mainSplitContainer.SuspendLayout();
            topPanel.SuspendLayout();
            filterPanel.SuspendLayout();
            filterTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)employeesDataGridView).BeginInit();
            bottomPanel.SuspendLayout();
            employmentDetailsPanel.SuspendLayout();
            employmentFormTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)employmentHistoryDataGridView).BeginInit();
            SuspendLayout();
            // 
            // mainSplitContainer
            // 
            mainSplitContainer.Dock = DockStyle.Fill;
            mainSplitContainer.Location = new Point(0, 0);
            mainSplitContainer.Name = "mainSplitContainer";
            mainSplitContainer.Orientation = Orientation.Horizontal;
            // 
            // mainSplitContainer.Panel1
            // 
            mainSplitContainer.Panel1.Controls.Add(topPanel);
            mainSplitContainer.Panel1MinSize = 300;
            // 
            // mainSplitContainer.Panel2
            // 
            mainSplitContainer.Panel2.Controls.Add(bottomPanel);
            mainSplitContainer.Panel2MinSize = 300;
            mainSplitContainer.Size = new Size(1200, 750);
            mainSplitContainer.SplitterDistance = 400;
            mainSplitContainer.SplitterWidth = 5;
            mainSplitContainer.TabIndex = 0;
            // 
            // topPanel
            // 
            topPanel.Controls.Add(filterPanel);
            topPanel.Controls.Add(employeesDataGridView);
            topPanel.Controls.Add(deleteEmployeeButton);
            topPanel.Controls.Add(selectEmployeeButton);
            topPanel.Controls.Add(editEmployeeButton);
            topPanel.Controls.Add(addEmployeeButton);
            topPanel.Dock = DockStyle.Fill;
            topPanel.Location = new Point(0, 0);
            topPanel.Name = "topPanel";
            topPanel.Padding = new Padding(10);
            topPanel.Size = new Size(1200, 400);
            topPanel.TabIndex = 0;
            // 
            // filterPanel
            // 
            filterPanel.Controls.Add(filterTableLayout);
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Location = new Point(10, 260);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(1180, 60);
            filterPanel.TabIndex = 0;
            // 
            // filterTableLayout
            // 
            filterTableLayout.ColumnCount = 6;
            filterTableLayout.ColumnStyles.Add(new ColumnStyle());
            filterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            filterTableLayout.ColumnStyles.Add(new ColumnStyle());
            filterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            filterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            filterTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15F));
            filterTableLayout.Controls.Add(searchLabel, 0, 0);
            filterTableLayout.Controls.Add(searchTextBox, 1, 0);
            filterTableLayout.Controls.Add(positionFilterLabel, 2, 0);
            filterTableLayout.Controls.Add(positionFilterComboBox, 3, 0);
            filterTableLayout.Controls.Add(applyFilterButton, 4, 0);
            filterTableLayout.Controls.Add(resetFilterButton, 5, 0);
            filterTableLayout.Dock = DockStyle.Fill;
            filterTableLayout.Location = new Point(0, 0);
            filterTableLayout.Name = "filterTableLayout";
            filterTableLayout.RowCount = 1;
            filterTableLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            filterTableLayout.Size = new Size(1180, 60);
            filterTableLayout.TabIndex = 0;
            // 
            // searchLabel
            // 
            searchLabel.Anchor = AnchorStyles.Left;
            searchLabel.AutoSize = true;
            searchLabel.Location = new Point(3, 22);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(92, 15);
            searchLabel.TabIndex = 0;
            searchLabel.Text = "Поиск по ФИО:";
            // 
            // searchTextBox
            // 
            searchTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            searchTextBox.Location = new Point(101, 18);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(324, 23);
            searchTextBox.TabIndex = 1;
            // 
            // positionFilterLabel
            // 
            positionFilterLabel.Anchor = AnchorStyles.Left;
            positionFilterLabel.AutoSize = true;
            positionFilterLabel.Location = new Point(431, 22);
            positionFilterLabel.Name = "positionFilterLabel";
            positionFilterLabel.Size = new Size(132, 15);
            positionFilterLabel.TabIndex = 2;
            positionFilterLabel.Text = "Фильтр по должности:";
            // 
            // positionFilterComboBox
            // 
            positionFilterComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            positionFilterComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            positionFilterComboBox.FormattingEnabled = true;
            positionFilterComboBox.Location = new Point(569, 18);
            positionFilterComboBox.Name = "positionFilterComboBox";
            positionFilterComboBox.Size = new Size(324, 23);
            positionFilterComboBox.TabIndex = 3;
            // 
            // applyFilterButton
            // 
            applyFilterButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            applyFilterButton.AutoSize = true;
            applyFilterButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            applyFilterButton.Location = new Point(899, 12);
            applyFilterButton.MinimumSize = new Size(0, 25);
            applyFilterButton.Name = "applyFilterButton";
            applyFilterButton.Padding = new Padding(5);
            applyFilterButton.Size = new Size(135, 35);
            applyFilterButton.TabIndex = 4;
            applyFilterButton.Text = "Применить";
            applyFilterButton.UseVisualStyleBackColor = true;
            // 
            // resetFilterButton
            // 
            resetFilterButton.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            resetFilterButton.AutoSize = true;
            resetFilterButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            resetFilterButton.Location = new Point(1040, 12);
            resetFilterButton.MinimumSize = new Size(0, 25);
            resetFilterButton.Name = "resetFilterButton";
            resetFilterButton.Padding = new Padding(5);
            resetFilterButton.Size = new Size(137, 35);
            resetFilterButton.TabIndex = 5;
            resetFilterButton.Text = "Сбросить";
            resetFilterButton.UseVisualStyleBackColor = true;
            // 
            // employeesDataGridView
            // 
            employeesDataGridView.AllowUserToAddRows = false;
            employeesDataGridView.AllowUserToDeleteRows = false;
            employeesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            employeesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employeesDataGridView.Columns.AddRange(new DataGridViewColumn[] { colEmployeeNumber, colSurname, colName, colPatronymic, colPosition });
            employeesDataGridView.Dock = DockStyle.Top;
            employeesDataGridView.Location = new Point(10, 10);
            employeesDataGridView.Name = "employeesDataGridView";
            employeesDataGridView.ReadOnly = true;
            employeesDataGridView.RowHeadersVisible = false;
            employeesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            employeesDataGridView.Size = new Size(1180, 250);
            employeesDataGridView.TabIndex = 1;
            // 
            // colEmployeeNumber
            // 
            colEmployeeNumber.HeaderText = "№";
            colEmployeeNumber.Name = "colEmployeeNumber";
            colEmployeeNumber.ReadOnly = true;
            // 
            // colSurname
            // 
            colSurname.HeaderText = "Фамилия";
            colSurname.Name = "colSurname";
            colSurname.ReadOnly = true;
            // 
            // colName
            // 
            colName.HeaderText = "Имя";
            colName.Name = "colName";
            colName.ReadOnly = true;
            // 
            // colPatronymic
            // 
            colPatronymic.HeaderText = "Отчество";
            colPatronymic.Name = "colPatronymic";
            colPatronymic.ReadOnly = true;
            // 
            // colPosition
            // 
            colPosition.HeaderText = "Должность";
            colPosition.Name = "colPosition";
            colPosition.ReadOnly = true;
            // 
            // deleteEmployeeButton
            // 
            deleteEmployeeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteEmployeeButton.AutoSize = true;
            deleteEmployeeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            deleteEmployeeButton.Location = new Point(337, 330);
            deleteEmployeeButton.MinimumSize = new Size(80, 35);
            deleteEmployeeButton.Name = "deleteEmployeeButton";
            deleteEmployeeButton.Padding = new Padding(10, 5, 10, 5);
            deleteEmployeeButton.Size = new Size(147, 35);
            deleteEmployeeButton.TabIndex = 4;
            deleteEmployeeButton.Text = "Удалить сотрудника";
            deleteEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // selectEmployeeButton
            // 
            selectEmployeeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            selectEmployeeButton.AutoSize = true;
            selectEmployeeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            selectEmployeeButton.Location = new Point(1106, 330);
            selectEmployeeButton.MinimumSize = new Size(80, 35);
            selectEmployeeButton.Name = "selectEmployeeButton";
            selectEmployeeButton.Padding = new Padding(10, 5, 10, 5);
            selectEmployeeButton.Size = new Size(84, 35);
            selectEmployeeButton.TabIndex = 3;
            selectEmployeeButton.Text = "Выбрать";
            selectEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // editEmployeeButton
            // 
            editEmployeeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            editEmployeeButton.AutoSize = true;
            editEmployeeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            editEmployeeButton.Location = new Point(174, 330);
            editEmployeeButton.MinimumSize = new Size(80, 35);
            editEmployeeButton.Name = "editEmployeeButton";
            editEmployeeButton.Padding = new Padding(10, 5, 10, 5);
            editEmployeeButton.Size = new Size(157, 35);
            editEmployeeButton.TabIndex = 6;
            editEmployeeButton.Text = "Изменить сотрудника";
            editEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // addEmployeeButton
            // 
            addEmployeeButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addEmployeeButton.AutoSize = true;
            addEmployeeButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addEmployeeButton.Location = new Point(13, 330);
            addEmployeeButton.MinimumSize = new Size(80, 35);
            addEmployeeButton.Name = "addEmployeeButton";
            addEmployeeButton.Padding = new Padding(10, 5, 10, 5);
            addEmployeeButton.Size = new Size(155, 35);
            addEmployeeButton.TabIndex = 5;
            addEmployeeButton.Text = "Добавить сотрудника";
            addEmployeeButton.UseVisualStyleBackColor = true;
            // 
            // bottomPanel
            // 
            bottomPanel.Controls.Add(employmentDetailsPanel);
            bottomPanel.Controls.Add(employmentHistoryLabel);
            bottomPanel.Controls.Add(employmentHistoryDataGridView);
            bottomPanel.Controls.Add(exitButton);
            bottomPanel.Dock = DockStyle.Fill;
            bottomPanel.Location = new Point(0, 0);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Padding = new Padding(10);
            bottomPanel.Size = new Size(1200, 345);
            bottomPanel.TabIndex = 0;
            // 
            // employmentDetailsPanel
            // 
            employmentDetailsPanel.Controls.Add(employmentFormTableLayout);
            employmentDetailsPanel.Controls.Add(deleteEmploymentButton);
            employmentDetailsPanel.Controls.Add(addEmploymentButton);
            employmentDetailsPanel.Dock = DockStyle.Top;
            employmentDetailsPanel.Location = new Point(10, 10);
            employmentDetailsPanel.Name = "employmentDetailsPanel";
            employmentDetailsPanel.Size = new Size(1180, 120);
            employmentDetailsPanel.TabIndex = 0;
            // 
            // employmentFormTableLayout
            // 
            employmentFormTableLayout.ColumnCount = 5;
            employmentFormTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0000038F));
            employmentFormTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.9999981F));
            employmentFormTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.9999981F));
            employmentFormTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.0000038F));
            employmentFormTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.9999981F));
            employmentFormTableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            employmentFormTableLayout.Controls.Add(positionLabel, 0, 0);
            employmentFormTableLayout.Controls.Add(positionComboBox, 0, 1);
            employmentFormTableLayout.Controls.Add(workplaceLabel, 1, 0);
            employmentFormTableLayout.Controls.Add(workplaceTextBox, 1, 1);
            employmentFormTableLayout.Controls.Add(eventDateLabel, 2, 0);
            employmentFormTableLayout.Controls.Add(eventDatePicker, 2, 1);
            employmentFormTableLayout.Controls.Add(documentNumberLabel, 3, 0);
            employmentFormTableLayout.Controls.Add(documentNumberTextBox, 3, 1);
            employmentFormTableLayout.Controls.Add(documentTypeLabel, 4, 0);
            employmentFormTableLayout.Controls.Add(documentTypeTextBox, 4, 1);
            employmentFormTableLayout.Controls.Add(eventTypeLabel, 0, 2);
            employmentFormTableLayout.Controls.Add(eventTypeComboBox, 0, 3);
            employmentFormTableLayout.Controls.Add(dismissalReasonLabel, 1, 2);
            employmentFormTableLayout.Controls.Add(dismissalReasonTextBox, 1, 3);
            employmentFormTableLayout.Dock = DockStyle.Left;
            employmentFormTableLayout.Location = new Point(0, 0);
            employmentFormTableLayout.Name = "employmentFormTableLayout";
            employmentFormTableLayout.RowCount = 4;
            employmentFormTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            employmentFormTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            employmentFormTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            employmentFormTableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            employmentFormTableLayout.Size = new Size(1000, 120);
            employmentFormTableLayout.TabIndex = 0;
            // 
            // positionLabel
            // 
            positionLabel.Anchor = AnchorStyles.Left;
            positionLabel.AutoSize = true;
            positionLabel.Location = new Point(3, 5);
            positionLabel.Name = "positionLabel";
            positionLabel.Size = new Size(72, 15);
            positionLabel.TabIndex = 0;
            positionLabel.Text = "Должность:";
            // 
            // positionComboBox
            // 
            positionComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            positionComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            positionComboBox.FormattingEnabled = true;
            positionComboBox.Location = new Point(3, 28);
            positionComboBox.Name = "positionComboBox";
            positionComboBox.Size = new Size(194, 23);
            positionComboBox.TabIndex = 1;
            // 
            // workplaceLabel
            // 
            workplaceLabel.Anchor = AnchorStyles.Left;
            workplaceLabel.AutoSize = true;
            workplaceLabel.Location = new Point(203, 5);
            workplaceLabel.Name = "workplaceLabel";
            workplaceLabel.Size = new Size(89, 15);
            workplaceLabel.TabIndex = 2;
            workplaceLabel.Text = "Место работы:";
            // 
            // workplaceTextBox
            // 
            workplaceTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            workplaceTextBox.Location = new Point(203, 28);
            workplaceTextBox.Name = "workplaceTextBox";
            workplaceTextBox.Size = new Size(193, 23);
            workplaceTextBox.TabIndex = 3;
            // 
            // eventDateLabel
            // 
            eventDateLabel.Anchor = AnchorStyles.Left;
            eventDateLabel.AutoSize = true;
            eventDateLabel.Location = new Point(402, 5);
            eventDateLabel.Name = "eventDateLabel";
            eventDateLabel.Size = new Size(172, 15);
            eventDateLabel.TabIndex = 4;
            eventDateLabel.Text = "Дата кадрового мероприятия:";
            // 
            // eventDatePicker
            // 
            eventDatePicker.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            eventDatePicker.Format = DateTimePickerFormat.Short;
            eventDatePicker.Location = new Point(402, 28);
            eventDatePicker.Name = "eventDatePicker";
            eventDatePicker.Size = new Size(193, 23);
            eventDatePicker.TabIndex = 5;
            // 
            // documentNumberLabel
            // 
            documentNumberLabel.Anchor = AnchorStyles.Left;
            documentNumberLabel.AutoSize = true;
            documentNumberLabel.Location = new Point(601, 5);
            documentNumberLabel.Name = "documentNumberLabel";
            documentNumberLabel.Size = new Size(185, 15);
            documentNumberLabel.TabIndex = 8;
            documentNumberLabel.Text = "Номер кадрового мероприятия:";
            // 
            // documentNumberTextBox
            // 
            documentNumberTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            documentNumberTextBox.Location = new Point(601, 28);
            documentNumberTextBox.Name = "documentNumberTextBox";
            documentNumberTextBox.Size = new Size(194, 23);
            documentNumberTextBox.TabIndex = 9;
            // 
            // documentTypeLabel
            // 
            documentTypeLabel.Anchor = AnchorStyles.Left;
            documentTypeLabel.AutoSize = true;
            documentTypeLabel.Location = new Point(801, 5);
            documentTypeLabel.Name = "documentTypeLabel";
            documentTypeLabel.Size = new Size(91, 15);
            documentTypeLabel.TabIndex = 10;
            documentTypeLabel.Text = "Вид документа:";
            // 
            // documentTypeTextBox
            // 
            documentTypeTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            documentTypeTextBox.Location = new Point(801, 28);
            documentTypeTextBox.Name = "documentTypeTextBox";
            documentTypeTextBox.Size = new Size(196, 23);
            documentTypeTextBox.TabIndex = 11;
            // 
            // eventTypeLabel
            // 
            eventTypeLabel.Anchor = AnchorStyles.Left;
            eventTypeLabel.AutoSize = true;
            eventTypeLabel.Location = new Point(3, 60);
            eventTypeLabel.Name = "eventTypeLabel";
            eventTypeLabel.Size = new Size(107, 15);
            eventTypeLabel.TabIndex = 14;
            eventTypeLabel.Text = "Вид мероприятия:";
            // 
            // eventTypeComboBox
            // 
            eventTypeComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            eventTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            eventTypeComboBox.FormattingEnabled = true;
            eventTypeComboBox.Location = new Point(3, 88);
            eventTypeComboBox.Name = "eventTypeComboBox";
            eventTypeComboBox.Size = new Size(194, 23);
            eventTypeComboBox.TabIndex = 15;
            // 
            // dismissalReasonLabel
            // 
            dismissalReasonLabel.Anchor = AnchorStyles.Left;
            dismissalReasonLabel.AutoSize = true;
            dismissalReasonLabel.Location = new Point(203, 55);
            dismissalReasonLabel.Name = "dismissalReasonLabel";
            dismissalReasonLabel.Size = new Size(142, 25);
            dismissalReasonLabel.TabIndex = 12;
            dismissalReasonLabel.Text = "Причины прекращения трудового договора:";
            // 
            // dismissalReasonTextBox
            // 
            dismissalReasonTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dismissalReasonTextBox.Location = new Point(203, 88);
            dismissalReasonTextBox.Name = "dismissalReasonTextBox";
            dismissalReasonTextBox.Size = new Size(193, 23);
            dismissalReasonTextBox.TabIndex = 13;
            // 
            // deleteEmploymentButton
            // 
            deleteEmploymentButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            deleteEmploymentButton.AutoSize = true;
            deleteEmploymentButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            deleteEmploymentButton.Location = new Point(1009, 80);
            deleteEmploymentButton.MinimumSize = new Size(80, 35);
            deleteEmploymentButton.Name = "deleteEmploymentButton";
            deleteEmploymentButton.Padding = new Padding(10, 5, 10, 5);
            deleteEmploymentButton.Size = new Size(81, 35);
            deleteEmploymentButton.TabIndex = 2;
            deleteEmploymentButton.Text = "Удалить";
            deleteEmploymentButton.UseVisualStyleBackColor = true;
            // 
            // addEmploymentButton
            // 
            addEmploymentButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            addEmploymentButton.AutoSize = true;
            addEmploymentButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            addEmploymentButton.Location = new Point(1001, 40);
            addEmploymentButton.MinimumSize = new Size(80, 35);
            addEmploymentButton.Name = "addEmploymentButton";
            addEmploymentButton.Padding = new Padding(10, 5, 10, 5);
            addEmploymentButton.Size = new Size(89, 35);
            addEmploymentButton.TabIndex = 1;
            addEmploymentButton.Text = "Добавить";
            addEmploymentButton.UseVisualStyleBackColor = true;
            // 
            // employmentHistoryLabel
            // 
            employmentHistoryLabel.AutoSize = true;
            employmentHistoryLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            employmentHistoryLabel.Location = new Point(13, 140);
            employmentHistoryLabel.Name = "employmentHistoryLabel";
            employmentHistoryLabel.Size = new Size(136, 19);
            employmentHistoryLabel.TabIndex = 2;
            employmentHistoryLabel.Text = "Трудовая книжка:";
            // 
            // employmentHistoryDataGridView
            // 
            employmentHistoryDataGridView.AllowUserToAddRows = false;
            employmentHistoryDataGridView.AllowUserToDeleteRows = false;
            employmentHistoryDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            employmentHistoryDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            employmentHistoryDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            employmentHistoryDataGridView.Columns.AddRange(new DataGridViewColumn[] { colHistoryEventDate, colHistoryPosition, colHistoryWorkplace, colHistoryEventType, colHistoryDocumentType, colHistoryDismissalReason });
            employmentHistoryDataGridView.Location = new Point(10, 165);
            employmentHistoryDataGridView.Name = "employmentHistoryDataGridView";
            employmentHistoryDataGridView.ReadOnly = true;
            employmentHistoryDataGridView.RowHeadersVisible = false;
            employmentHistoryDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            employmentHistoryDataGridView.Size = new Size(1180, 140);
            employmentHistoryDataGridView.TabIndex = 1;
            // 
            // exitButton
            // 
            exitButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            exitButton.AutoSize = true;
            exitButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            exitButton.Location = new Point(1110, 310);
            exitButton.MinimumSize = new Size(80, 35);
            exitButton.Name = "exitButton";
            exitButton.Padding = new Padding(10, 5, 10, 5);
            exitButton.Size = new Size(80, 35);
            exitButton.TabIndex = 3;
            exitButton.Text = "Выйти";
            exitButton.UseVisualStyleBackColor = true;
            // 
            // colHistoryEventDate
            // 
            colHistoryEventDate.HeaderText = "Дата мероприятия";
            colHistoryEventDate.Name = "colHistoryEventDate";
            colHistoryEventDate.ReadOnly = true;
            // 
            // colHistoryPosition
            // 
            colHistoryPosition.HeaderText = "Должность";
            colHistoryPosition.Name = "colHistoryPosition";
            colHistoryPosition.ReadOnly = true;
            // 
            // colHistoryWorkplace
            // 
            colHistoryWorkplace.HeaderText = "Место работы";
            colHistoryWorkplace.Name = "colHistoryWorkplace";
            colHistoryWorkplace.ReadOnly = true;
            // 
            // colHistoryEventType
            // 
            colHistoryEventType.HeaderText = "Вид мероприятия";
            colHistoryEventType.Name = "colHistoryEventType";
            colHistoryEventType.ReadOnly = true;
            // 
            // colHistoryDocumentType
            // 
            colHistoryDocumentType.HeaderText = "Вид документа";
            colHistoryDocumentType.Name = "colHistoryDocumentType";
            colHistoryDocumentType.ReadOnly = true;
            // 
            // colHistoryDismissalReason
            // 
            colHistoryDismissalReason.HeaderText = "Причина увольнения";
            colHistoryDismissalReason.Name = "colHistoryDismissalReason";
            colHistoryDismissalReason.ReadOnly = true;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 750);
            Controls.Add(mainSplitContainer);
            MinimumSize = new Size(1216, 789);
            Name = "EmployeeForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Управление сотрудниками";
            mainSplitContainer.Panel1.ResumeLayout(false);
            mainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)mainSplitContainer).EndInit();
            mainSplitContainer.ResumeLayout(false);
            topPanel.ResumeLayout(false);
            topPanel.PerformLayout();
            filterPanel.ResumeLayout(false);
            filterTableLayout.ResumeLayout(false);
            filterTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)employeesDataGridView).EndInit();
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            employmentDetailsPanel.ResumeLayout(false);
            employmentDetailsPanel.PerformLayout();
            employmentFormTableLayout.ResumeLayout(false);
            employmentFormTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)employmentHistoryDataGridView).EndInit();
            ResumeLayout(false);
        }

        private DataGridViewTextBoxColumn colHistoryEventDate;
        private DataGridViewTextBoxColumn colHistoryPosition;
        private DataGridViewTextBoxColumn colHistoryWorkplace;
        private DataGridViewTextBoxColumn colHistoryEventType;
        private DataGridViewTextBoxColumn colHistoryDocumentType;
        private DataGridViewTextBoxColumn colHistoryDismissalReason;
    }
}