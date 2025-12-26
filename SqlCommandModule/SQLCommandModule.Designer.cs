namespace SqlCommandModule
{
    partial class SqlCommandForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SqlCommandForm));
            txtSqlQuery = new RichTextBox();
            lstResults = new ListBox();
            btnExecute = new Button();
            btnClear = new Button();
            lblStatus = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtSqlQuery
            // 
            txtSqlQuery.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSqlQuery.Font = new Font("Consolas", 10F);
            txtSqlQuery.Location = new Point(14, 32);
            txtSqlQuery.Margin = new Padding(4, 3, 4, 3);
            txtSqlQuery.Name = "txtSqlQuery";
            txtSqlQuery.Size = new Size(653, 115);
            txtSqlQuery.TabIndex = 0;
            txtSqlQuery.Text = "";
            // 
            // lstResults
            // 
            lstResults.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstResults.Font = new Font("Segoe UI", 9F);
            lstResults.FormattingEnabled = true;
            lstResults.HorizontalScrollbar = true;
            lstResults.ItemHeight = 15;
            lstResults.Location = new Point(14, 202);
            lstResults.Margin = new Padding(4, 3, 4, 3);
            lstResults.Name = "lstResults";
            lstResults.Size = new Size(653, 244);
            lstResults.TabIndex = 1;
            // 
            // btnExecute
            // 
            btnExecute.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExecute.Location = new Point(14, 155);
            btnExecute.Margin = new Padding(4, 3, 4, 3);
            btnExecute.Name = "btnExecute";
            btnExecute.Size = new Size(117, 35);
            btnExecute.TabIndex = 3;
            btnExecute.Text = "Выполнить";
            btnExecute.Click += btnExecute_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnClear.Location = new Point(138, 155);
            btnClear.Margin = new Padding(4, 3, 4, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(117, 35);
            btnClear.TabIndex = 2;
            btnClear.Text = "Очистить";
            btnClear.Click += btnClear_Click;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(14, 456);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(38, 15);
            lblStatus.TabIndex = 0;
            lblStatus.Text = "Готов";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 10);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(118, 15);
            label1.TabIndex = 4;
            label1.Text = "Введите SQL запрос:";
            // 
            // SqlCommandForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(681, 486);
            Controls.Add(lblStatus);
            Controls.Add(lstResults);
            Controls.Add(btnClear);
            Controls.Add(btnExecute);
            Controls.Add(txtSqlQuery);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(464, 340);
            Name = "SqlCommandForm";
            Text = "SQL Запросы";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.RichTextBox txtSqlQuery;
        private System.Windows.Forms.ListBox lstResults;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label1;
    }

    #endregion
}