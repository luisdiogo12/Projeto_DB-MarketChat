namespace MarketChat
{
    partial class MenuFuncionario
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
            button1 = new Button();
            button5 = new Button();
            button4 = new Button();
            label1 = new Label();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            button3 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(526, 195);
            button1.Name = "button1";
            button1.Size = new Size(238, 43);
            button1.TabIndex = 39;
            button1.Text = "Chats como especialista";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnClickChat;
            // 
            // button5
            // 
            button5.Location = new Point(526, 146);
            button5.Name = "button5";
            button5.Size = new Size(238, 43);
            button5.TabIndex = 38;
            button5.Text = "Adicionar/Alterar Produto";
            button5.UseVisualStyleBackColor = true;
            button5.Click += BtnClickList;
            // 
            // button4
            // 
            button4.Location = new Point(526, 48);
            button4.Name = "button4";
            button4.Size = new Size(238, 43);
            button4.TabIndex = 37;
            button4.Text = "Gerir Funcionários";
            button4.UseVisualStyleBackColor = true;
            button4.Click += BtnClickGerir;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(37, 8);
            label1.Name = "label1";
            label1.Size = new Size(268, 37);
            label1.TabIndex = 33;
            label1.Text = "Menu (Funcionário)";
            // 
            // button2
            // 
            button2.Location = new Point(37, 97);
            button2.Name = "button2";
            button2.Size = new Size(238, 43);
            button2.TabIndex = 40;
            button2.Text = "Ver Estastisticas";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BtnClickStats;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(37, 146);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(455, 245);
            dataGridView1.TabIndex = 41;
            // 
            // button3
            // 
            button3.Location = new Point(37, 409);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 42;
            button3.Text = "Log Out";
            button3.UseVisualStyleBackColor = true;
            button3.Click += BtnClickBack;
            // 
            // button6
            // 
            button6.Location = new Point(526, 97);
            button6.Name = "button6";
            button6.Size = new Size(238, 43);
            button6.TabIndex = 43;
            button6.Text = "Ver Produtos";
            button6.UseVisualStyleBackColor = true;
            button6.Click += BtnClickView;
            // 
            // MenuFuncionario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button6);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(label1);
            Name = "MenuFuncionario";
            Text = "Form8";
            Load += MenuFuncionario_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button5;
        private Button button4;
        private Label label1;
        private Button button2;
        private DataGridView dataGridView1;
        private Button button3;
        private Button button6;
    }
}