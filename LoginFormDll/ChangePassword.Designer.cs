namespace LoginWindow
{
    partial class ChangePassword
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangePassword));
            bannerPanel = new Panel();
            keyIcon = new PictureBox();
            label1 = new Label();
            systemNameLabel = new Label();
            versionLabel = new Label();
            usernameLabel = new Label();
            oldPasswordTextBox = new TextBox();
            passwordLabel = new Label();
            newPasswordTextBox = new TextBox();
            acceptButton = new Button();
            cancelButton = new Button();
            statusStrip = new StatusStrip();
            languageLabel = new ToolStripStatusLabel();
            capsLockLabel = new ToolStripStatusLabel();
            acceptPasswordTextBox = new TextBox();
            label2 = new Label();
            bannerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)keyIcon).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // bannerPanel
            // 
            bannerPanel.BackColor = SystemColors.GradientActiveCaption;
            bannerPanel.Controls.Add(keyIcon);
            bannerPanel.Controls.Add(label1);
            bannerPanel.Controls.Add(systemNameLabel);
            bannerPanel.Controls.Add(versionLabel);
            bannerPanel.Dock = DockStyle.Top;
            bannerPanel.Location = new Point(0, 0);
            bannerPanel.Margin = new Padding(4, 3, 4, 3);
            bannerPanel.Name = "bannerPanel";
            bannerPanel.Size = new Size(436, 115);
            bannerPanel.TabIndex = 0;
            // 
            // keyIcon
            // 
            keyIcon.BackColor = Color.Transparent;
            keyIcon.ImageLocation = "C:\\Домашка\\БД\\Course\\CourseDB\\LoginWindow\\keys.png";
            keyIcon.Location = new Point(7, 7);
            keyIcon.Margin = new Padding(4, 3, 4, 3);
            keyIcon.Name = "keyIcon";
            keyIcon.Size = new Size(70, 67);
            keyIcon.SizeMode = PictureBoxSizeMode.StretchImage;
            keyIcon.TabIndex = 0;
            keyIcon.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 9.75F);
            label1.Location = new Point(4, 75);
            label1.Name = "label1";
            label1.Size = new Size(420, 21);
            label1.TabIndex = 3;
            label1.Text = "Изменить пароль";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // systemNameLabel
            // 
            systemNameLabel.BackColor = Color.LemonChiffon;
            systemNameLabel.Font = new Font("Arial", 9.75F);
            systemNameLabel.Location = new Point(4, 9);
            systemNameLabel.Margin = new Padding(4, 0, 4, 0);
            systemNameLabel.Name = "systemNameLabel";
            systemNameLabel.Size = new Size(420, 32);
            systemNameLabel.TabIndex = 1;
            systemNameLabel.Text = "АИС Отдел кадров";
            systemNameLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // versionLabel
            // 
            versionLabel.BackColor = Color.FromArgb(255, 215, 2);
            versionLabel.Font = new Font("Arial", 9.75F);
            versionLabel.Location = new Point(4, 43);
            versionLabel.Margin = new Padding(4, 0, 4, 0);
            versionLabel.Name = "versionLabel";
            versionLabel.Size = new Size(420, 29);
            versionLabel.TabIndex = 2;
            versionLabel.Text = "Версия 0.0.0.0";
            versionLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Font = new Font("Arial", 9.75F);
            usernameLabel.Location = new Point(7, 118);
            usernameLabel.Margin = new Padding(4, 0, 4, 0);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(106, 16);
            usernameLabel.TabIndex = 4;
            usernameLabel.Text = "Прежний пароль";
            // 
            // oldPasswordTextBox
            // 
            oldPasswordTextBox.Location = new Point(154, 116);
            oldPasswordTextBox.Margin = new Padding(4, 3, 4, 3);
            oldPasswordTextBox.Name = "oldPasswordTextBox";
            oldPasswordTextBox.Size = new Size(268, 23);
            oldPasswordTextBox.TabIndex = 5;
            oldPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Arial", 9.75F);
            passwordLabel.Location = new Point(7, 158);
            passwordLabel.Margin = new Padding(4, 0, 4, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(92, 16);
            passwordLabel.TabIndex = 6;
            passwordLabel.Text = "Новый пароль";
            // 
            // newPasswordTextBox
            // 
            newPasswordTextBox.Location = new Point(154, 156);
            newPasswordTextBox.Margin = new Padding(4, 3, 4, 3);
            newPasswordTextBox.Name = "newPasswordTextBox";
            newPasswordTextBox.Size = new Size(268, 23);
            newPasswordTextBox.TabIndex = 6;
            newPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // acceptButton
            // 
            acceptButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            acceptButton.BackColor = SystemColors.ButtonFace;
            acceptButton.Location = new Point(22, 232);
            acceptButton.Margin = new Padding(4, 3, 4, 3);
            acceptButton.Name = "acceptButton";
            acceptButton.Size = new Size(91, 24);
            acceptButton.TabIndex = 8;
            acceptButton.Text = "Применить";
            acceptButton.UseVisualStyleBackColor = false;
            acceptButton.Click += AcceptButton_Click;
            // 
            // cancelButton
            // 
            cancelButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            cancelButton.BackColor = SystemColors.ButtonFace;
            cancelButton.Location = new Point(322, 232);
            cancelButton.Margin = new Padding(4, 3, 4, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(91, 24);
            cancelButton.TabIndex = 9;
            cancelButton.Text = "Отмена";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += CancelButton_Click;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = SystemColors.GradientActiveCaption;
            statusStrip.GripStyle = ToolStripGripStyle.Visible;
            statusStrip.Items.AddRange(new ToolStripItem[] { languageLabel, capsLockLabel });
            statusStrip.Location = new Point(0, 259);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new Padding(1, 0, 16, 0);
            statusStrip.RenderMode = ToolStripRenderMode.Professional;
            statusStrip.RightToLeft = RightToLeft.No;
            statusStrip.Size = new Size(436, 22);
            statusStrip.TabIndex = 10;
            // 
            // languageLabel
            // 
            languageLabel.Name = "languageLabel";
            languageLabel.Size = new Size(138, 17);
            languageLabel.Text = "Язык ввода Английский";
            // 
            // capsLockLabel
            // 
            capsLockLabel.AutoSize = false;
            capsLockLabel.ImageAlign = ContentAlignment.MiddleRight;
            capsLockLabel.Name = "capsLockLabel";
            capsLockLabel.Overflow = ToolStripItemOverflow.Always;
            capsLockLabel.Size = new Size(258, 17);
            capsLockLabel.Text = "Клавиша CapsLock нажата";
            // 
            // acceptPasswordTextBox
            // 
            acceptPasswordTextBox.Location = new Point(154, 195);
            acceptPasswordTextBox.Margin = new Padding(4, 3, 4, 3);
            acceptPasswordTextBox.Name = "acceptPasswordTextBox";
            acceptPasswordTextBox.Size = new Size(268, 23);
            acceptPasswordTextBox.TabIndex = 7;
            acceptPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 9.75F);
            label2.Location = new Point(7, 197);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(130, 16);
            label2.TabIndex = 11;
            label2.Text = "Подтвердите пароль";
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(436, 281);
            Controls.Add(acceptPasswordTextBox);
            Controls.Add(label2);
            Controls.Add(cancelButton);
            Controls.Add(acceptButton);
            Controls.Add(newPasswordTextBox);
            Controls.Add(passwordLabel);
            Controls.Add(oldPasswordTextBox);
            Controls.Add(usernameLabel);
            Controls.Add(bannerPanel);
            Controls.Add(statusStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "ChangePassword";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Изменить пораль";
            InputLanguageChanged += Form_InputLanguageChanged;
            KeyDown += LoginForm_KeyDown;
            bannerPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)keyIcon).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Panel bannerPanel;
        private System.Windows.Forms.PictureBox keyIcon;
        private System.Windows.Forms.Label systemNameLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.TextBox oldPasswordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox newPasswordTextBox;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel languageLabel;
        private System.Windows.Forms.ToolStripStatusLabel capsLockLabel;
        private Label label1;

        #endregion

        private TextBox acceptPasswordTextBox;
        private Label label2;
    }
}