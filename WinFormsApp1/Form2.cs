using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {

        private System.Windows.Forms.Timer timer;
        private int opacity = 100;
        public Lokasyon_Listesi Lokasyon_Listesi = new Lokasyon_Listesi();
        private Lokasyon lokasyon;
        private Engeller engeller;
        public Dag dag;
        public Agac agac;
        public Kaya kaya;
        public Duvar duvar;
        public Kuslar kuslar;
        public Arilar arilar;
        public Hazineler hazineler;
        public Karakter karakter;
        public bool isOk = false;
        public int kenarUzunlugu;
        int aralik = 1;
        int tempCount = 0;
        int tempCount2 = 0;

        public bool isIntersect = false;
        int control = 0;
        public Form2()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

        }


        public Form2(string X, string Y)
        {
            InitializeComponent();
            lokasyon = new Lokasyon(int.Parse(X), int.Parse(Y));
            engeller = new Engeller(kenarUzunlugu);
            agac = new Agac(Lokasyon_Listesi); 
            dag = new Dag(Lokasyon_Listesi);  
            kaya = new Kaya(Lokasyon_Listesi); 
            duvar = new Duvar(Lokasyon_Listesi);
            kuslar = new Kuslar(Lokasyon_Listesi); 
            arilar = new Arilar(Lokasyon_Listesi); 
            hazineler = new Hazineler(Lokasyon_Listesi);
            karakter = new Karakter(Lokasyon_Listesi);
            this.DoubleBuffered = true;
            Engel_Koordinatları.Size = new Size(500, 500); 
            Engel_Koordinatları.Location = new Point(1300, 20);
          
            this.Controls.Add(Engel_Koordinatları);

            Hazineler.Size = new Size(500, 500); 
            Hazineler.Location = new Point(1300, 600);
            this.Controls.Add(Hazineler);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Pen pen = new Pen(Color.Black);

            int windowWidth = ClientSize.Width;
            int windowHeight = ClientSize.Height;

            kenarUzunlugu = Math.Min((windowWidth - 60) / lokasyon.Y, (windowHeight - 60) / lokasyon.X);

            for (int i = 0; i <= lokasyon.X; i++)
            {
                e.Graphics.DrawLine(pen, new Point(10, 10 + i * (kenarUzunlugu + aralik)), new Point(10 + lokasyon.Y * (kenarUzunlugu + aralik), 10 + i * (kenarUzunlugu + aralik)));
                e.Graphics.PageScale = 0.5f;
            }

            for (int i = 0; i <= lokasyon.Y; i++)
            {
                e.Graphics.DrawLine(pen, new Point(10 + i * (kenarUzunlugu + aralik), 10), new Point(10 + i * (kenarUzunlugu + aralik), 10 + lokasyon.X * (kenarUzunlugu + aralik)));
                e.Graphics.PageScale = 0.5f;
            }

            if (control == 0)
            {
                agac.YerlestirAgac(this.Controls, lokasyon, kenarUzunlugu, e);
                kaya.YerlestirKayalar(this.Controls, lokasyon, kenarUzunlugu, e);
                dag.YerlestirDaglar(this.Controls, lokasyon, kenarUzunlugu, e);
                duvar.YerlestirDuvarlar(this.Controls, lokasyon, kenarUzunlugu, e);
                dag.YerlestirKısDaglar(this.Controls, lokasyon, kenarUzunlugu, e);
                agac.YerlestirKısAgac(this.Controls, lokasyon, kenarUzunlugu, e);
                kuslar.YerlestirKus(this.Controls, lokasyon, kenarUzunlugu, e);
                arilar.YerlestirAri(this.Controls, lokasyon, kenarUzunlugu, e);
                kuslar.YerlestirKus2(this.Controls, lokasyon, kenarUzunlugu);
                hazineler.YerlestirAltınHazine(this.Controls, lokasyon, kenarUzunlugu, e);
                hazineler.YerlestirGümüsHazine(this.Controls, lokasyon, kenarUzunlugu, e);
                hazineler.YerlestirElmasHazine(this.Controls, lokasyon, kenarUzunlugu, e);
                karakter.YerlestirKarakter(this.Controls, lokasyon, kenarUzunlugu, e);
                hazineler.YerlestirBakirHazine(this.Controls, lokasyon, kenarUzunlugu, e);
                control = 1;
            }

            karakter.karakterrect = new Rectangle(karakter.KarakterPictureBox.Location, karakter.KarakterPictureBox.Size);
            Graphics g = e.Graphics;

            Brush brush = Brushes.White;
            g.FillRectangle(brush, karakter.karaktergorusrect);


            if (karakter.gorulenEngeller.Count > tempCount)
            {
                Engel_Koordinatları.Items.Clear();
                foreach (string str in karakter.gorulenEngeller)
                {
                    tempCount = karakter.gorulenEngeller.Count;
                    string item = str;
                    Engel_Koordinatları.Items.Add(item); 
                }
            }

            if (karakter.bulunanHazineler.Count >tempCount2 )
            {
                Hazineler.Items.Clear();
                foreach (string str in karakter.bulunanHazineler)
                {
                    tempCount2 = karakter.bulunanHazineler.Count;
                    string item = str;
                    Hazineler.Items.Add(item); 
                }
            }

            if((lokasyon.X * 0.03) * 4 == karakter.bulunanHazineler.Count)
            {
                karakter.bulunanHazineler.Clear();
                Hazineler.Items.Clear();
                if (karakter.isReady)
                {
                    if (!isOk)
                    {
                        foreach (string str in karakter.siralaHazineler)
                        {
                            string item = str;
                            Hazineler.Items.Add(item); 
                        }
                    }
                    isOk = true;
                } 
            }


        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Size = new Size(2000, 1080);

        }

        

       
    }
}