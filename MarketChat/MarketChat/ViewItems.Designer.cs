namespace MarketChat
{
    partial class ViewItems
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
            button2 = new Button();
            listViewProdutos = new ListView();
            SuspendLayout();
            // 
            // button2
            // 
            button2.Location = new Point(33, 12);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 9;
            button2.Text = "Menu";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BtnClickBack;
            // 
            // listViewProdutos
            // 
            listViewProdutos.Location = new Point(33, 73);
            listViewProdutos.Name = "listViewProdutos";
            listViewProdutos.Size = new Size(835, 465);
            listViewProdutos.TabIndex = 10;
            listViewProdutos.UseCompatibleStateImageBehavior = false;
            listViewProdutos.View = View.Details;
            // 
            // ViewItems
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(880, 550);
            Controls.Add(listViewProdutos);
            Controls.Add(button2);
            Name = "ViewItems";
            Text = "ViewItems";
            Load += ViewItems_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button2;
        private ListView listViewProdutos;
    }
}