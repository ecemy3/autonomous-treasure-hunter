using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Kaya : Engeller
    {
        Lokasyon_Listesi Lokasyon_Listesi = new Lokasyon_Listesi();
        public Kaya(int kenarUzunlugu) : base(kenarUzunlugu){}

        public Kaya(Lokasyon_Listesi _Lokasyon_Listesi)
        {
            Lokasyon_Listesi = _Lokasyon_Listesi;
        }
        public void YerlestirKayalar(Control.ControlCollection controls, Lokasyon lokasyon, int kenarUzunlugu, PaintEventArgs e)
        {
            int[] kayaBoyutlari = { 2, 3 };

            foreach (int boyut in kayaBoyutlari)
            {
                double standartSapma = Math.Sqrt(lokasyon.X);
                int kayaSayisi = (int)Math.Round(lokasyon.X * 0.03);

                for (int i = 0; i < kayaSayisi; i++)
                {
                    int kayaBoyutu = boyut;
                    Point kayaKonumu = GetRandomLocation(lokasyon, kayaBoyutu, kenarUzunlugu);

                    bool cakismaVar = KontrolEt(controls, kayaKonumu, kayaBoyutu, kenarUzunlugu);
                    if (!cakismaVar)
                    {
                        PictureBox kayaPictureBox = new PictureBox();
                        kayaPictureBox.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "kaya.jpg");
                        kayaPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        kayaPictureBox.Name = "Kaya";
                        kayaPictureBox.Size = new Size(kenarUzunlugu * kayaBoyutu + kayaBoyutu, kenarUzunlugu * kayaBoyutu + kayaBoyutu);
                        kayaPictureBox.Location = kayaKonumu;
                        kayaPictureBox.Visible = false;
                        Rectangle kayarec = new Rectangle(kayaKonumu.X, kayaKonumu.Y, kayaPictureBox.Width, kayaPictureBox.Height);
                        Lokasyon_Listesi.LokasyonRects.Add(kayarec);

                        controls.Add(kayaPictureBox);
                        Lokasyon_Listesi.LokasyonPictureBoxes.Add(kayaPictureBox);
                    }
                    else
                    {
                        i--;
                    }
                }
            }
        }

    }
}
