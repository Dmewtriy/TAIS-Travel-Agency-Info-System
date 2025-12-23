using System.Drawing;
using System.Windows.Forms;

namespace LoginFormDll
{
    partial class LoginForm
    {
        private PictureBox logoBox;
        private Label userLabel;
        private Label passLabel;
        private TextBox userText;
        private TextBox passText;
        private Button okButton;
        private Button cancelButton;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel statusLeft;
        private ToolStripStatusLabel statusRight;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            logoBox = new PictureBox();
            userLabel = new Label();
            userText = new TextBox();
            passLabel = new Label();
            passText = new TextBox();
            okButton = new Button();
            cancelButton = new Button();
            statusStrip = new StatusStrip();
            statusLeft = new ToolStripStatusLabel();
            toolStripSpring = new ToolStripStatusLabel() { Spring = true };
            statusRight = new ToolStripStatusLabel();
            headerName = new Panel();
            AIS = new Label();
            headerVersion = new Panel();
            Version = new Label();
            headerEnterText = new Panel();
            EnterLoginPassword = new Label();
            ((System.ComponentModel.ISupportInitialize)logoBox).BeginInit();
            statusStrip.SuspendLayout();
            headerName.SuspendLayout();
            headerVersion.SuspendLayout();
            headerEnterText.SuspendLayout();
            SuspendLayout();
            // 
            // logoBox
            // 
            logoBox.Location = new Point(8, 8);
            logoBox.Name = "logoBox";
            logoBox.Size = new Size(64, 64);
            logoBox.SizeMode = PictureBoxSizeMode.StretchImage;
            logoBox.TabIndex = 1;
            logoBox.TabStop = false;
            logoBox.Image = Image.FromFile("../../../../LoginFormDll/keys.png");
            // 
            // userLabel
            // 
            userLabel.AutoSize = true;
            userLabel.Location = new Point(8, 88);
            userLabel.Name = "userLabel";
            userLabel.Size = new Size(109, 15);
            userLabel.TabIndex = 2;
            userLabel.Text = "Имя пользователя";
            // 
            // userText
            // 
            userText.Location = new Point(164, 88);
            userText.Name = "userText";
            userText.Size = new Size(250, 23);
            userText.TabIndex = 3;
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Location = new Point(8, 117);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(49, 15);
            passLabel.TabIndex = 4;
            passLabel.Text = "Пароль";
            // 
            // passText
            // 
            passText.Location = new Point(164, 117);
            passText.Name = "passText";
            passText.Size = new Size(250, 23);
            passText.TabIndex = 5;
            passText.UseSystemPasswordChar = true;
            // 
            // okButton
            // 
            okButton.BackColor = Color.FromArgb(240, 240, 240);
            okButton.Location = new Point(37, 175);
            okButton.Name = "okButton";
            okButton.Size = new Size(80, 28);
            okButton.TabIndex = 6;
            okButton.Text = "Вход";
            okButton.UseVisualStyleBackColor = false;
            okButton.Click += OkButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(240, 240, 240);
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new Point(334, 175);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(80, 28);
            cancelButton.TabIndex = 7;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = false;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new ToolStripItem[] { statusLeft, toolStripSpring, statusRight });
            statusStrip.Location = new Point(0, 219);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(423, 22);
            statusStrip.TabIndex = 8;
            // 
            // statusLeft
            // 
            statusLeft.Name = "statusLeft";
            statusLeft.Size = new Size(138, 17);
            statusLeft.Text = "Язык ввода Английский";
            // 
            // toolStripSpring
            // 
            toolStripSpring.Name = "toolStripSpring";
            toolStripSpring.Size = new Size(0, 17);
            // 
            // statusRight
            // 
            statusRight.Name = "statusRight";
            statusRight.Size = new Size(0, 17);
            // 
            // headerName
            // 
            headerName.BackColor = Color.FromArgb(255, 255, 230);
            headerName.Controls.Add(AIS);
            headerName.Location = new Point(80, 8);
            headerName.Name = "headerName";
            headerName.Size = new Size(334, 20);
            headerName.TabIndex = 3;
            // 
            // AIS
            // 
            AIS.AutoSize = true;
            AIS.Font = new Font("Segoe UI", 10F);
            AIS.Location = new Point(205, 1);
            AIS.Name = "AIS";
            AIS.Size = new Size(129, 19);
            AIS.TabIndex = 0;
            AIS.Text = "АИС Отдел кадров";
            // 
            // headerVersion
            // 
            headerVersion.BackColor = Color.Gold;
            headerVersion.Controls.Add(Version);
            headerVersion.Location = new Point(80, 30);
            headerVersion.Name = "headerVersion";
            headerVersion.Size = new Size(334, 20);
            headerVersion.TabIndex = 4;
            // 
            // Version
            // 
            Version.AutoSize = true;
            Version.Font = new Font("Segoe UI", 10F);
            Version.Location = new Point(236, 0);
            Version.Name = "Version";
            Version.Size = new Size(98, 19);
            Version.TabIndex = 0;
            Version.Text = "Версия 1.0.0.0";
            // 
            // headerEnterText
            // 
            headerEnterText.BackColor = Color.White;
            headerEnterText.Controls.Add(EnterLoginPassword);
            headerEnterText.Location = new Point(80, 52);
            headerEnterText.Name = "headerEnterText";
            headerEnterText.Size = new Size(334, 20);
            headerEnterText.TabIndex = 9;
            // 
            // EnterLoginPassword
            // 
            EnterLoginPassword.AutoSize = true;
            EnterLoginPassword.Font = new Font("Segoe UI", 10F);
            EnterLoginPassword.Location = new Point(95, 0);
            EnterLoginPassword.Name = "EnterLoginPassword";
            EnterLoginPassword.Size = new Size(239, 19);
            EnterLoginPassword.TabIndex = 0;
            EnterLoginPassword.Text = "Введите имя пользователя и пароль";
            // 
            // LoginForm
            // 
            AcceptButton = okButton;
            BackColor = Color.FromArgb(185, 209, 234);
            CancelButton = cancelButton;
            ClientSize = new Size(423, 241);
            Controls.Add(headerEnterText);
            Controls.Add(headerVersion);
            Controls.Add(headerName);
            Controls.Add(logoBox);
            Controls.Add(userLabel);
            Controls.Add(userText);
            Controls.Add(passLabel);
            Controls.Add(passText);
            Controls.Add(okButton);
            Controls.Add(cancelButton);
            Controls.Add(statusStrip);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Вход";
            ((System.ComponentModel.ISupportInitialize)logoBox).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            headerName.ResumeLayout(false);
            headerName.PerformLayout();
            headerVersion.ResumeLayout(false);
            headerVersion.PerformLayout();
            headerEnterText.ResumeLayout(false);
            headerEnterText.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Panel headerName;
        private Label AIS;
        private Panel headerVersion;
        private Label Version;
        private Panel headerEnterText;
        private Label EnterLoginPassword;
        private ToolStripStatusLabel toolStripSpring;
    }
}
