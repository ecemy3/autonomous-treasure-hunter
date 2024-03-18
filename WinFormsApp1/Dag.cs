using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Dag : Engeller
    {
        Lokasyon_Listesi Lokasyon_Listesi;
        public Dag(int kenarUzunlugu) : base(kenarUzunlugu){}
        public Dag(Lokasyon_Listesi _Lokasyon_Listesi)
        {
            Lokasyon_Listesi = _Lokasyon_Listesi;
        }
        public void YerlestirDaglar(Control.ControlCollection controls, Lokasyon lokasyon, int kenarUzunlugu,PaintEventArgs e)
        {
            
            int[] dagBoyutlari = { 15 };
            

            foreach (int boyut in dagBoyutlari)
            {
                double standartSapma = Math.Sqrt(lokasyon.X);
                int dagSayisi = (int)Math.Round(lokasyon.X * 0.03);

                for (int i = 0; i < dagSayisi; i++)
                {
                    int dagBoyutu = boyut;
                    Point dagKonumu = GetRandomLocationSag(lokasyon, dagBoyutu, kenarUzunlugu);

                    bool cakismaVar = KontrolEt(controls, dagKonumu, dagBoyutu, kenarUzunlugu);

                    if (!cakismaVar)
                    {
                        PictureBox dagPictureBox = new PictureBox();
                        dagPictureBox.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "yazdag.jpg");
                        dagPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        dagPictureBox.Name = "Yaz Dağı";
                        dagPictureBox.Size = new Size(kenarUzunlugu * dagBoyutu + dagBoyutu, kenarUzunlugu * dagBoyutu + dagBoyutu);
                        dagPictureBox.Location = dagKonumu;
                        dagPictureBox.Visible = false;
                        Rectangle dagrec = new Rectangle(dagKonumu.X, dagKonumu.Y, dagPictureBox.Width, dagPictureBox.Height);
                        Lokasyon_Listesi.LokasyonRects.Add(dagrec);
                        controls.Add(dagPictureBox);
                        Lokasyon_Listesi.LokasyonPictureBoxes.Add(dagPictureBox);
                    }
                    else
                    {
                        i--;
                    }
                }
            }

        }

        public void YerlestirKısDaglar(Control.ControlCollection controls, Lokasyon lokasyon, int kenarUzunlugu, PaintEventArgs e)
        {
            int[] dagBoyutlari = { 15 };

            foreach (int boyut in dagBoyutlari)
            {
                double standartSapma = Math.Sqrt(lokasyon.X);
                int dagSayisi = (int)Math.Round(lokasyon.X * 0.03);
                //int dagSayisi = 1;
                for (int i = 0; i < dagSayisi; i++)
                {
                    int dagBoyutu = boyut;
                    Point dagKonumu = GetRandomLocationSol(lokasyon, dagBoyutu, kenarUzunlugu);
                    //Point dagKonumu = new Point(210, 210);
                    bool cakismaVar = KontrolEt(controls, dagKonumu, dagBoyutu, kenarUzunlugu);
                    if (!cakismaVar)
                    {
                        PictureBox dagPictureBox = new PictureBox();
                        dagPictureBox.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "kısdag.jpg");
                        dagPictureBox.Name = "Kış Dağı";
                        dagPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        dagPictureBox.Visible = false;
                        dagPictureBox.Size = new Size(kenarUzunlugu * dagBoyutu + dagBoyutu, kenarUzunlugu * dagBoyutu + dagBoyutu);
                        dagPictureBox.Location = dagKonumu;
                        Rectangle kisdagrec = new Rectangle(dagKonumu.X, dagKonumu.Y, dagPictureBox.Width, dagPictureBox.Height);
                        Lokasyon_Listesi.LokasyonRects.Add(kisdagrec);
                        controls.Add(dagPictureBox);
                        Lokasyon_Listesi.LokasyonPictureBoxes.Add(dagPictureBox);
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
