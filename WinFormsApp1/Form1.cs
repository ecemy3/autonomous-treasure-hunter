namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void XTextbox_TextChanged(object sender, EventArgs e)
        {



        }

        private void YTextbox_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string X = XTextbox.Text;
            string Y = YTextbox.Text;
            Form2 form2 = new Form2(X,Y);
            form2.WindowState = FormWindowState.Maximized;
            form2.Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form boyutunu belirli bir geniþlik ve yükseklikte ayarlamak için:
            this.Size = new Size(1020, 1020); // Panel baþýna 10 piksel yer býrakýyoruz

          
        }
    }
}
