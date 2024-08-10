namespace MarketChat
{
    partial class VendedorProfile
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
            textBoxEmail = new TextBox();
            label2 = new Label();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            label3 = new Label();
            dataGridView2 = new DataGridView();
            button4 = new Button();
            button5 = new Button();
            textBox1 = new TextBox();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(267, 37);
            label1.TabIndex = 5;
            label1.Text = "Nome do Vendedor";
            label1.Click += label1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 49);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(378, 313);
            dataGridView1.TabIndex = 15;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(588, 450);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(169, 27);
            textBoxEmail.TabIndex = 18;
            textBoxEmail.TextChanged += textBoxEmail_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(453, 450);
            label2.Name = "label2";
            label2.Size = new Size(126, 20);
            label2.TabIndex = 17;
            label2.Text = "ID do comentário";
            label2.Click += label2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 368);
            button3.Name = "button3";
            button3.Size = new Size(182, 43);
            button3.TabIndex = 16;
            button3.Text = "Like no vendedor";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(573, 49);
            button2.Name = "button2";
            button2.Size = new Size(206, 43);
            button2.TabIndex = 19;
            button2.Text = "Iniciar Chat com vendedor";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(208, 368);
            button1.Name = "button1";
            button1.Size = new Size(182, 43);
            button1.TabIndex = 20;
            button1.Text = "Deslike no vendedor";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 414);
            label3.Name = "label3";
            label3.Size = new Size(93, 20);
            label3.TabIndex = 21;
            label3.Text = "Comentários";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 437);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(378, 148);
            dataGridView2.TabIndex = 22;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // button4
            // 
            button4.Location = new Point(437, 483);
            button4.Name = "button4";
            button4.Size = new Size(168, 43);
            button4.TabIndex = 23;
            button4.Text = "Like no comentário";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(611, 483);
            button5.Name = "button5";
            button5.Size = new Size(168, 43);
            button5.TabIndex = 24;
            button5.Text = "Deslike no comentário";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 591);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(378, 27);
            textBox1.TabIndex = 25;
            textBox1.Text = "Comentário de texto";
            // 
            // button6
            // 
            button6.Location = new Point(411, 583);
            button6.Name = "button6";
            button6.Size = new Size(168, 43);
            button6.TabIndex = 26;
            button6.Text = "Comentar";
            button6.UseVisualStyleBackColor = true;
            // 
            // VendedorProfile
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 652);
            Controls.Add(button6);
            Controls.Add(textBox1);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(dataGridView2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(button2);
            Controls.Add(textBoxEmail);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "VendedorProfile";
            Text = "Form6";
            Load += VendedorProfile_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dataGridView1;
        private TextBox textBoxEmail;
        private Label label2;
        private Button button3;
        private Button button2;
        private Button button1;
        private Label label3;
        private DataGridView dataGridView2;
        private Button button4;
        private Button button5;
        private TextBox textBox1;
        private Button button6;
    }
}