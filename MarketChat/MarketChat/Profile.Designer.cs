namespace MarketChat
{
    partial class Profile
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
            dataGridView1 = new DataGridView();
            button5 = new Button();
            button4 = new Button();
            textBoxEmail = new TextBox();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            label3 = new Label();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(203, 37);
            label1.TabIndex = 6;
            label1.Text = "Perfil (Cliente)";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 49);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(378, 386);
            dataGridView1.TabIndex = 16;
            // 
            // button5
            // 
            button5.Location = new Point(501, 98);
            button5.Name = "button5";
            button5.Size = new Size(238, 43);
            button5.TabIndex = 28;
            button5.Text = "Ver os meus produtos à venda";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(501, 49);
            button4.Name = "button4";
            button4.Size = new Size(238, 43);
            button4.TabIndex = 27;
            button4.Text = "Eliminar Conta";
            button4.UseVisualStyleBackColor = true;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(501, 309);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(238, 27);
            textBoxEmail.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(556, 286);
            label2.Name = "label2";
            label2.Size = new Size(111, 20);
            label2.TabIndex = 25;
            label2.Text = "Nome do dado";
            // 
            // button1
            // 
            button1.Location = new Point(501, 147);
            button1.Name = "button1";
            button1.Size = new Size(238, 43);
            button1.TabIndex = 29;
            button1.Text = "Ver os meus chats";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(501, 400);
            button2.Name = "button2";
            button2.Size = new Size(238, 43);
            button2.TabIndex = 30;
            button2.Text = "Alterar dado";
            button2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(501, 367);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(238, 27);
            textBox1.TabIndex = 32;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(556, 344);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 31;
            label3.Text = "Valor do dado";
            // 
            // button3
            // 
            button3.Location = new Point(501, 196);
            button3.Name = "button3";
            button3.Size = new Size(238, 43);
            button3.TabIndex = 33;
            button3.Text = "Tornar-me Vendedor";
            button3.UseVisualStyleBackColor = true;
            // 
            // Profile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 544);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(textBoxEmail);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "Profile";
            Text = "Form7";
            Load += this.Profile_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private Button button5;
        private Button button4;
        private TextBox textBoxEmail;
        private Label label2;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private Label label3;
        private Button button3;
    }
}