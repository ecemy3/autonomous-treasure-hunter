using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Kuslar : Hareketli_Engeller
    {
        private PictureBox kusPictureBox;
        private PictureBox kus2PictureBox;
        private PictureBox redPictureBox;
        private PictureBox redPictureBox2;
        private int kusKonumuY;
        private int kirmizikusKonumuY;
        private int baslangicKusKonumu;
        private int baslangicKusKonumukirmizi;
        private int hareketYonu = 1;
        private int kirmiziHareketYonu = 1;
        private int kenarUzunlugu;
   
        Lokasyon_Listesi Lokasyon_Listesi = new Lokasyon_Listesi();
        public Kuslar(int kenarUzunlugu) : base(kenarUzunlugu) { }
        public Kuslar(Lokasyon_Listesi _Lokasyon_Listesi)
        {
            Lokasyon_Listesi = _Lokasyon_Listesi;
        }
      
        public Kuslar(Hareketli_Engeller hareketliEngeller){}
        public void YerlestirKus(Control.ControlCollection controls, Lokasyon lokasyon, int kenarUzunlugu, PaintEventArgs e)
        {
            int kusBoyutu = 2;
            this.kenarUzunlugu=kenarUzunlugu;

            Point kusKonumu = GetRandomLocation(lokasyon, 1, kenarUzunlugu);

            bool cakismaVar = KontrolEt(controls, kusKonumu, kusBoyutu, kenarUzunlugu);
            if (!cakismaVar)
            {
                kusPictureBox = new PictureBox();
                kusPictureBox.Image = Image.FromFile(@Application.StartupPath + "../../../myImage/" + "kus.gif");
                kusPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                kusPictureBox.Size = new Size(kenarUzunlugu * kusBoyutu + kusBoyutu, kenarUzunlugu * kusBoyutu + kusBoyutu);
                kusPictureBox.Name = "Kuş";
                Lokasyon_Listesi.LokasyonPictureBoxes.Add(kusPictureBox);
                controls.Add(kusPictureBox);
                kusPictureBox.Visible = false;
                kusPictureBox.Location = kusKonumu;
                baslangicKusKonumu = kusPictureBox.Location.Y;
                this.kusKonumuY = kusPictureBox.Location.Y;

                redPictureBox = new PictureBox();
                redPictureBox.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "red.png");
                redPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                redPictureBox.Name = "Kuş";
                redPictureBox.Size = new Size(kenarUzunlugu * kusBoyutu + kusBoyutu, kenarUzunlugu * 10);
                redPictureBox.Location = new Point(kusKonumu.X, kusKonumu.Y - kenarUzunlugu * 4 - 4);
                redPictureBox.Visible= false;
                controls.Add(redPictureBox);
                Rectangle kusrec = new Rectangle(kusKonumu.X, kusKonumu.Y - kenarUzunlugu * 4, redPictureBox.Width, redPictureBox.Height);
                Lokasyon_Listesi.LokasyonRects.Add(kusrec);
                Lokasyon_Listesi.LokasyonPictureBoxes.Add(redPictureBox);

                InitializeTimer();
            }
            else
            {
                YerlestirKus(controls, lokasyon, kenarUzunlugu, e);
               
            }
        }

        public void YerlestirKus2(Control.ControlCollection controls, Lokasyon lokasyon, int kenarUzunlugu)
        {
            int kusBoyutu = 2;

            Point kusKonumu = GetRandomLocation(lokasyon, 1, kenarUzunlugu);

            bool cakismaVar = KontrolEt(controls, kusKonumu, kusBoyutu, kenarUzunlugu);
            if (!cakismaVar)
            {
                kus2PictureBox = new PictureBox();
                kus2PictureBox.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "kus2gif.gif");
                kus2PictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                kus2PictureBox.Name = "Kuş";
                kus2PictureBox.Size = new Size(kenarUzunlugu * kusBoyutu + kusBoyutu, kenarUzunlugu * kusBoyutu + kusBoyutu);
                kus2PictureBox.Visible = false;
                controls.Add(kus2PictureBox);
                Lokasyon_Listesi.LokasyonPictureBoxes.Add(kus2PictureBox);
                kus2PictureBox.Location = kusKonumu;
                baslangicKusKonumukirmizi = kus2PictureBox.Location.Y;
                this.kirmizikusKonumuY = kus2PictureBox.Location.Y;

                redPictureBox2 = new PictureBox();
                redPictureBox2.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "red.png");
                redPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                redPictureBox2.Name = "Kuş";
                redPictureBox2.Size = new Size(kenarUzunlugu * kusBoyutu + kusBoyutu, kenarUzunlugu * 10);
                redPictureBox2.Location = new Point(kusKonumu.X, kusKonumu.Y - kenarUzunlugu * 4 - 4);
                redPictureBox2.Visible = false;
                controls.Add(redPictureBox2);
                Rectangle kus2rec = new Rectangle(kusKonumu.X, kusKonumu.Y - kenarUzunlugu * 4, redPictureBox2.Width, redPictureBox2.Height);
                Lokasyon_Listesi.LokasyonRects.Add(kus2rec);
                Lokasyon_Listesi.LokasyonPictureBoxes.Add(redPictureBox2);



                InitializeTimer();
            }
            else
            {
                YerlestirKus2(controls, lokasyon, kenarUzunlugu);

            }
        }
        public void InitializeTimer()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100; 
            timer.Tick += Timer_Tick_Kus;
            timer.Tick += Timer_Tick_Kus2;
            timer.Start();
        }
        public void Timer_Tick_Kus(object sender, EventArgs e)
        {
            kusKonumuY += hareketYonu;
            try
            {
                if (((kusKonumuY - baslangicKusKonumu) == kenarUzunlugu * 4) || ((kusKonumuY - baslangicKusKonumu) == -(kenarUzunlugu * 4 + 4)) || kusKonumuY <= 10)
                {                  
                    hareketYonu *= -1;                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }



            if(kusPictureBox!=null)
            {
                kusPictureBox.Location = new Point(kusPictureBox.Location.X, kusKonumuY);
            }
           

         
            
        }

        public void Timer_Tick_Kus2(object sender, EventArgs e)
        {          
            kirmizikusKonumuY += kirmiziHareketYonu;
            try
            {
               
                if (((kirmizikusKonumuY - baslangicKusKonumukirmizi) == kenarUzunlugu * 4) || ((kirmizikusKonumuY - baslangicKusKonumukirmizi) == -(kenarUzunlugu * 4 + 4)) || kirmizikusKonumuY <= 10)
                {
                    kirmiziHareketYonu *= -1;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            if(kus2PictureBox!=null)
            {
                kus2PictureBox.Location = new Point(kus2PictureBox.Location.X, kirmizikusKonumuY);
            }    
        }
    }
  
}

