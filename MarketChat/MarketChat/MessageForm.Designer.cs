namespace MarketChat
{
    partial class MessageForm
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
            dataGridView1 = new DataGridView();
            button3 = new Button();
            textBoxMensagem = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(362, 12);
            label1.Name = "label1";
            label1.Size = new Size(83, 20);
            label1.TabIndex = 0;
            label1.Text = "Mensagens";
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Chat";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnClickBack;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 47);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 234);
            dataGridView1.TabIndex = 2;
            // 
            // button3
            // 
            button3.Location = new Point(654, 310);
            button3.Name = "button3";
            button3.Size = new Size(129, 43);
            button3.TabIndex = 10;
            button3.Text = "Enviar";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBoxMensagem
            // 
            textBoxMensagem.Location = new Point(12, 318);
            textBoxMensagem.Name = "textBoxMensagem";
            textBoxMensagem.Size = new Size(636, 27);
            textBoxMensagem.TabIndex = 9;
            textBoxMensagem.Text = "Mensagem de texto";
            // 
            // MessageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(textBoxMensagem);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "MessageForm";
            Text = "Mensagens";
            Load += MessageForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private DataGridView dataGridView1;
        private Button button3;
        private TextBox textBoxMensagem;
    }
}