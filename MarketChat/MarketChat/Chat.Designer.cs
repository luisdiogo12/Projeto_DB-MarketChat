namespace MarketChat
{
    partial class Chat
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
            label1 = new Label();
            button1 = new Button();
            dataGridConversas = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridConversas).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(382, 12);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 0;
            label1.Text = "Chat";
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Menu";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnClickBack;
            // 
            // dataGridConversas
            // 
            dataGridConversas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridConversas.Location = new Point(12, 47);
            dataGridConversas.Name = "dataGridConversas";
            dataGridConversas.RowHeadersWidth = 51;
            dataGridConversas.Size = new Size(776, 391);
            dataGridConversas.TabIndex = 2;
            dataGridConversas.CellContentClick += dataGridConversas_CellContentClick;
            // 
            // Chat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridConversas);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Chat";
            Text = "Chat";
            Load += Chat_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridConversas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private DataGridView dataGridConversas;
    }
}