namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            textBox1 = new TextBox();
            button1 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            XTextbox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            YTextbox = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.DarkViolet;
            label1.Location = new Point(299, 74);
            label1.Name = "label1";
            label1.Size = new Size(161, 20);
            label1.TabIndex = 0;
            label1.Text = "OYUNA HOŞ GELDİNİZ";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.Purple;
            textBox1.ForeColor = Color.Thistle;
            textBox1.Location = new Point(35, 28);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(726, 27);
            textBox1.TabIndex = 6;
            textBox1.Text = "ZAMANIN LABİRENTİNDE BERİL VE ECEM";
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // button1
            // 
            button1.ForeColor = Color.DarkViolet;
            button1.Location = new Point(206, 199);
            button1.Name = "button1";
            button1.Size = new Size(358, 178);
            button1.TabIndex = 3;
            button1.Text = "GİRİŞ YAP";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // XTextbox
            // 
            XTextbox.Location = new Point(403, 113);
            XTextbox.Name = "XTextbox";
            XTextbox.Size = new Size(125, 27);
            XTextbox.TabIndex = 1;
            XTextbox.TextChanged += XTextbox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(175, 120);
            label2.Name = "label2";
            label2.Size = new Size(150, 20);
            label2.TabIndex = 4;
            label2.Text = "X Koordinatını Giriniz";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(175, 151);
            label3.Name = "label3";
            label3.Size = new Size(149, 20);
            label3.TabIndex = 5;
            label3.Text = "Y Koordinatını Giriniz";
            // 
            // YTextbox
            // 
            YTextbox.Location = new Point(403, 151);
            YTextbox.Name = "YTextbox";
            YTextbox.Size = new Size(125, 27);
            YTextbox.TabIndex = 2;
            YTextbox.TextChanged += YTextbox_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(793, 450);
            Controls.Add(YTextbox);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(XTextbox);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox XTextbox;
        private Label label2;
        private Label label3;
        private TextBox YTextbox;
    }
}
