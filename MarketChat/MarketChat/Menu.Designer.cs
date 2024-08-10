namespace MarketChat
{
    partial class Menu
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
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(283, 65);
            label1.Name = "label1";
            label1.Size = new Size(169, 37);
            label1.TabIndex = 0;
            label1.Text = "MarketChat";
            label1.Click += label1_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F);
            button1.Location = new Point(32, 288);
            button1.Name = "button1";
            button1.Size = new Size(169, 78);
            button1.TabIndex = 1;
            button1.Text = "Listar Produto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnClickList;
            // 
            // button2
            // 
            button2.Location = new Point(283, 288);
            button2.Name = "button2";
            button2.Size = new Size(169, 78);
            button2.TabIndex = 2;
            button2.Text = "Ver Produtos";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BtnClickView;
            // 
            // button3
            // 
            button3.Location = new Point(555, 288);
            button3.Name = "button3";
            button3.Size = new Size(169, 78);
            button3.TabIndex = 3;
            button3.Text = "Chat";
            button3.UseVisualStyleBackColor = true;
            button3.Click += BtnClickChat;
            // 
            // button4
            // 
            button4.Location = new Point(12, 12);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 4;
            button4.Text = "Log Out";
            button4.UseVisualStyleBackColor = true;
            button4.Click += BtnClickBack;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Name = "Menu";
            Text = "Menu";
            Load += Menu_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}