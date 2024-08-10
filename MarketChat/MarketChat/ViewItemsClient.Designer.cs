namespace MarketChat
{
    partial class ViewItemsClient
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
            dataGridViewProdutos = new DataGridView();
            textBoxEmail = new TextBox();
            label2 = new Label();
            button3 = new Button();
            label3 = new Label();
            dataGridView2 = new DataGridView();
            dataGridView3 = new DataGridView();
            label4 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            button1 = new Button();
            label6 = new Label();
            textBox2 = new TextBox();
            button2 = new Button();
            button4 = new Button();
            button5 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(251, 9);
            label1.Name = "label1";
            label1.Size = new Size(242, 37);
            label1.TabIndex = 3;
            label1.Text = "Produtos à venda";
            // 
            // dataGridViewProdutos
            // 
            dataGridViewProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProdutos.Location = new Point(251, 49);
            dataGridViewProdutos.Name = "dataGridViewProdutos";
            dataGridViewProdutos.RowHeadersWidth = 51;
            dataGridViewProdutos.Size = new Size(414, 554);
            dataGridViewProdutos.TabIndex = 4;
            dataGridViewProdutos.CellDoubleClick += dataGridViewProdutos_CellDoubleClick;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(828, 397);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(169, 27);
            textBoxEmail.TabIndex = 9;
            textBoxEmail.TextChanged += textBoxEmail_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(857, 374);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 8;
            label2.Text = "ID do produto";
            // 
            // button3
            // 
            button3.Location = new Point(843, 430);
            button3.Name = "button3";
            button3.Size = new Size(129, 43);
            button3.TabIndex = 7;
            button3.Text = "Ver Produto";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(12, 9);
            label3.Name = "label3";
            label3.Size = new Size(169, 28);
            label3.TabIndex = 10;
            label3.Text = "Filtros disponiveis";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 49);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(225, 251);
            dataGridView2.TabIndex = 11;
            dataGridView2.CellDoubleClick += dataGridView2_CellDoubleClick;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(12, 334);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(225, 269);
            dataGridView3.TabIndex = 13;
            dataGridView3.CellDoubleClick += dataGridView3_CellDoubleClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(12, 303);
            label4.Name = "label4";
            label4.Size = new Size(154, 28);
            label4.TabIndex = 12;
            label4.Text = "Filtros aplicados";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(828, 180);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(169, 27);
            textBox1.TabIndex = 16;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(857, 157);
            label5.Name = "label5";
            label5.Size = new Size(108, 20);
            label5.TabIndex = 15;
            label5.Text = "Nome do filtro";
            // 
            // button1
            // 
            button1.Location = new Point(767, 266);
            button1.Name = "button1";
            button1.Size = new Size(129, 43);
            button1.TabIndex = 14;
            button1.Text = "Adicionar filtro";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(857, 210);
            label6.Name = "label6";
            label6.Size = new Size(101, 20);
            label6.TabIndex = 17;
            label6.Text = "Valor do filtro";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(828, 233);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(169, 27);
            textBox2.TabIndex = 18;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button2
            // 
            button2.Location = new Point(818, 49);
            button2.Name = "button2";
            button2.Size = new Size(206, 62);
            button2.TabIndex = 19;
            button2.Text = "Iniciar/Abrir Chat com especialista";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BtnClickChat;
            // 
            // button4
            // 
            button4.Location = new Point(966, 574);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 20;
            button4.Text = "Menu";
            button4.UseVisualStyleBackColor = true;
            button4.Click += BtnClickBack;
            // 
            // button5
            // 
            button5.Location = new Point(902, 266);
            button5.Name = "button5";
            button5.Size = new Size(129, 43);
            button5.TabIndex = 21;
            button5.Text = "Limpar filtro";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // ViewItemsClient
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1072, 615);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(dataGridView3);
            Controls.Add(label4);
            Controls.Add(dataGridView2);
            Controls.Add(label3);
            Controls.Add(textBoxEmail);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(dataGridViewProdutos);
            Controls.Add(label1);
            Name = "ViewItemsClient";
            Text = "Form4";
            Load += ViewItemsClient_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridViewProdutos;
        private TextBox textBoxEmail;
        private Label label2;
        private Button button3;
        private Label label3;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private Label label4;
        private TextBox textBox1;
        private Label label5;
        private Button button1;
        private Label label6;
        private TextBox textBox2;
        private Button button2;
        private Button button4;
        private Button button5;
    }
}