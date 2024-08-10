namespace MarketChat
{
    partial class ViewItemsFuncionario
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
            button4 = new Button();
            textBox2 = new TextBox();
            label6 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            button1 = new Button();
            dataGridView3 = new DataGridView();
            label4 = new Label();
            dataGridView2 = new DataGridView();
            label3 = new Label();
            textBoxEmail = new TextBox();
            label2 = new Label();
            button3 = new Button();
            dataGridViewProdutos = new DataGridView();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutos).BeginInit();
            SuspendLayout();
            // 
            // button4
            // 
            button4.Location = new Point(962, 567);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 36;
            button4.Text = "Menu";
            button4.UseVisualStyleBackColor = true;
            button4.Click += BtnClickBack;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(824, 226);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(169, 27);
            textBox2.TabIndex = 34;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(853, 203);
            label6.Name = "label6";
            label6.Size = new Size(101, 20);
            label6.TabIndex = 33;
            label6.Text = "Valor do filtro";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(824, 173);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(169, 27);
            textBox1.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(853, 150);
            label5.Name = "label5";
            label5.Size = new Size(108, 20);
            label5.TabIndex = 31;
            label5.Text = "Nome do filtro";
            // 
            // button1
            // 
            button1.Location = new Point(839, 259);
            button1.Name = "button1";
            button1.Size = new Size(129, 43);
            button1.TabIndex = 30;
            button1.Text = "Adicionar filtro";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(8, 327);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(225, 269);
            dataGridView3.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(8, 296);
            label4.Name = "label4";
            label4.Size = new Size(154, 28);
            label4.TabIndex = 28;
            label4.Text = "Filtros aplicados";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(8, 42);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(225, 251);
            dataGridView2.TabIndex = 27;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(8, 2);
            label3.Name = "label3";
            label3.Size = new Size(169, 28);
            label3.TabIndex = 26;
            label3.Text = "Filtros disponiveis";
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(824, 390);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(169, 27);
            textBoxEmail.TabIndex = 25;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(853, 367);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 24;
            label2.Text = "ID do produto";
            // 
            // button3
            // 
            button3.Location = new Point(839, 423);
            button3.Name = "button3";
            button3.Size = new Size(129, 43);
            button3.TabIndex = 23;
            button3.Text = "Ver Produto";
            button3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewProdutos
            // 
            dataGridViewProdutos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewProdutos.Location = new Point(247, 42);
            dataGridViewProdutos.Name = "dataGridViewProdutos";
            dataGridViewProdutos.RowHeadersWidth = 51;
            dataGridViewProdutos.Size = new Size(414, 554);
            dataGridViewProdutos.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(247, 2);
            label1.Name = "label1";
            label1.Size = new Size(242, 37);
            label1.TabIndex = 21;
            label1.Text = "Produtos à venda";
            // 
            // ViewItemsFuncionario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1066, 604);
            Controls.Add(button4);
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
            Name = "ViewItemsFuncionario";
            Text = "Form1";
            Load += ViewItemsFuncionario_Load_1;
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewProdutos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button4;
        private TextBox textBox2;
        private Label label6;
        private TextBox textBox1;
        private Label label5;
        private Button button1;
        private DataGridView dataGridView3;
        private Label label4;
        private DataGridView dataGridView2;
        private Label label3;
        private TextBox textBoxEmail;
        private Label label2;
        private Button button3;
        private DataGridView dataGridViewProdutos;
        private Label label1;
    }
}