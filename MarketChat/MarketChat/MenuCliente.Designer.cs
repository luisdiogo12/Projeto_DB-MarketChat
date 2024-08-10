namespace MarketChat
{
    partial class MenuCliente
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
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // button4
            // 
            button4.Location = new Point(12, 12);
            button4.Name = "button4";
            button4.Size = new Size(94, 29);
            button4.TabIndex = 5;
            button4.Text = "Log Out";
            button4.UseVisualStyleBackColor = true;
            button4.Click += BtnClickBack;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label1.Location = new Point(282, 63);
            label1.Name = "label1";
            label1.Size = new Size(169, 37);
            label1.TabIndex = 6;
            label1.Text = "MarketChat";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 9F);
            button1.Location = new Point(32, 293);
            button1.Name = "button1";
            button1.Size = new Size(169, 78);
            button1.TabIndex = 7;
            button1.Text = "Ver Perfil";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnClickProfile;
            // 
            // button2
            // 
            button2.Location = new Point(282, 293);
            button2.Name = "button2";
            button2.Size = new Size(169, 78);
            button2.TabIndex = 8;
            button2.Text = "Ver Produtos";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BtnClickView;
            // 
            // button3
            // 
            button3.Location = new Point(548, 293);
            button3.Name = "button3";
            button3.Size = new Size(169, 78);
            button3.TabIndex = 9;
            button3.Text = "Chat";
            button3.UseVisualStyleBackColor = true;
            button3.Click += BtnClickChat;
            // 
            // MenuCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(button4);
            Name = "MenuCliente";
            Text = "Menu";
            Load += MenuCliente_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button4;
        private Label label1;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}