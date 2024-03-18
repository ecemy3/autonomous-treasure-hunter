using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Agac : Engeller
    {
        Lokasyon_Listesi Lokasyon_Listesi = new Lokasyon_Listesi();
        public Agac(int kenarUzunlugu) : base(kenarUzunlugu)
        {
        }
        public Agac(Lokasyon_Listesi _Lokasyon_Listesi)
        {
            Lokasyon_Listesi = _Lokasyon_Listesi;
        }
        public void YerlestirAgac(Control.ControlCollection controls, Lokasyon lokasyon, int kenarUzunlugu,PaintEventArgs e)
        {
            int[] agacBoyutlari = { 2, 3, 4, 5 };

            foreach (int boyut in agacBoyutlari)
            {
                double standartSapma = Math.Sqrt(lokasyon.X);
                int agacSayisi = (int)Math.Round(lokasyon.X * 0.03);

                for (int i = 0; i < agacSayisi; i++)
                {
                    int agacBoyutu = boyut;
                    Point agacKonumu = GetRandomLocationSag(lokasyon, agacBoyutu, kenarUzunlugu);

                    bool cakismaVar = KontrolEt(controls, agacKonumu, agacBoyutu, kenarUzunlugu);
                    if (!cakismaVar)
                    {
                        PictureBox agacPictureBox = new PictureBox();
                        agacPictureBox.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "agac.jpg");
                        agacPictureBox.Name = "Yaz Ağacı";
                        agacPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        agacPictureBox.Size = new Size(kenarUzunlugu * agacBoyutu + agacBoyutu, kenarUzunlugu * agacBoyutu + agacBoyutu);
                        agacPictureBox.Location = agacKonumu;
                        agacPictureBox.Visible = false;
                        Rectangle agacrec = new Rectangle(agacKonumu.X, agacKonumu.Y, agacPictureBox.Width , agacPictureBox.Height);
                        Lokasyon_Listesi.LokasyonRects.Add(agacrec);
                        controls.Add(agacPictureBox);
                        Lokasyon_Listesi.LokasyonPictureBoxes.Add(agacPictureBox);
                    }
                    else
                    {
                        i--;
                    }
                }
            }
        }
        public void YerlestirKısAgac(Control.ControlCollection controls, Lokasyon lokasyon, int kenarUzunlugu, PaintEventArgs e)
        {
            int[] agacBoyutlari = { 2, 3, 4, 5 };

            foreach (int boyut in agacBoyutlari)
            {
                double standartSapma = Math.Sqrt(lokasyon.X);
                int agacSayisi = (int)Math.Round(lokasyon.X * 0.03);

                for (int i = 0; i < agacSayisi; i++)
                {
                    int agacBoyutu = boyut;
                    Point agacKonumu = GetRandomLocationSol(lokasyon, agacBoyutu, kenarUzunlugu);

                    bool cakismaVar = KontrolEt(controls, agacKonumu, agacBoyutu, kenarUzunlugu);
                    if (!cakismaVar)
                    {
                        PictureBox agacPictureBox = new PictureBox();
                        agacPictureBox.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "kısagacı.jpg");
                        agacPictureBox.Name = "Kış Ağacı";
                        agacPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        agacPictureBox.Size = new Size(kenarUzunlugu * agacBoyutu + agacBoyutu, kenarUzunlugu * agacBoyutu + agacBoyutu);
                        agacPictureBox.Location = agacKonumu;
                        agacPictureBox.Visible = false;
                        Rectangle kisagacrec = new Rectangle(agacKonumu.X, agacKonumu.Y, agacPictureBox.Width, agacPictureBox.Height);
                        Lokasyon_Listesi.LokasyonRects.Add(kisagacrec);

                        controls.Add(agacPictureBox);
                        Lokasyon_Listesi.LokasyonPictureBoxes.Add(agacPictureBox);
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
