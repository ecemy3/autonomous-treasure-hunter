using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Arilar : Hareketli_Engeller
    {
        Lokasyon_Listesi Lokasyon_Listesi = new Lokasyon_Listesi();
        private PictureBox AriPictureBox;
        private PictureBox redPictureBox2;
        private int AriKonumuX;
        private int baslangicAriKonumu;
        private int ariHareketYonu = 1;
        private int kenarUzunlugu;

        public Arilar(int kenarUzunlugu) : base(kenarUzunlugu) { }
        public Arilar(Hareketli_Engeller hareketliEngeller) { }
        public Arilar(Lokasyon_Listesi _Lokasyon_Listesi)
        {
            Lokasyon_Listesi = _Lokasyon_Listesi;
        }


        public void YerlestirAri(Control.ControlCollection controls, Lokasyon lokasyon, int kenarUzunlugu, PaintEventArgs e)
        {
            int AriBoyutu = 2;
            this.kenarUzunlugu = kenarUzunlugu;

            Point AriKonumu = GetRandomLocation(lokasyon, AriBoyutu, kenarUzunlugu);

            bool cakismaVar = KontrolEt(controls, AriKonumu, AriBoyutu, kenarUzunlugu);
            if (!cakismaVar)
            {
                AriPictureBox = new PictureBox();
                AriPictureBox.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "arımor.gif");
                AriPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                AriPictureBox.Size = new Size(kenarUzunlugu * AriBoyutu + AriBoyutu, kenarUzunlugu * AriBoyutu + AriBoyutu);
                AriPictureBox.Name = "Arı";
                AriPictureBox.Visible = false;
                controls.Add(AriPictureBox);
                Lokasyon_Listesi.LokasyonPictureBoxes.Add(AriPictureBox);
                AriPictureBox.Location = AriKonumu;
                baslangicAriKonumu = AriPictureBox.Location.X;
                this.AriKonumuX = AriPictureBox.Location.X;

                redPictureBox2 = new PictureBox();
                redPictureBox2.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "red.png");
                redPictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                redPictureBox2.Size = new Size(kenarUzunlugu * 6 + 6, kenarUzunlugu * AriBoyutu + AriBoyutu);
                redPictureBox2.Name = "Arı";
                redPictureBox2.Location = new Point(AriKonumu.X - kenarUzunlugu * 2 - AriBoyutu, AriKonumu.Y);
                redPictureBox2.Visible = false;
                controls.Add(redPictureBox2);
                Rectangle arirec = new Rectangle(AriKonumu.X - kenarUzunlugu * 2, AriKonumu.Y, redPictureBox2.Width, redPictureBox2.Height);
                Lokasyon_Listesi.LokasyonRects.Add(arirec);
                Lokasyon_Listesi.LokasyonPictureBoxes.Add(redPictureBox2);

                InitializeTimer();

            }
            else
            {
                YerlestirAri(controls, lokasyon, kenarUzunlugu, e);
            }
        }

        public void InitializeTimer()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += Timer_Tick_Ari;
            timer.Start();
        }

        public void Timer_Tick_Ari(object sender, EventArgs e)
        {

            AriKonumuX += ariHareketYonu;
            try
            {
                if (((AriKonumuX - baslangicAriKonumu) == kenarUzunlugu * 2 + 4) || ((AriKonumuX - baslangicAriKonumu) == -(kenarUzunlugu * 2)) || AriKonumuX <= 10)
                {
                    ariHareketYonu *= -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            if(AriPictureBox!= null)
            {
                AriPictureBox.Location = new Point(AriKonumuX, AriPictureBox.Location.Y);
            }
            
        }

    }


}
