using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Duvar : Engeller
    {
        Lokasyon_Listesi Lokasyon_Listesi = new Lokasyon_Listesi();
        public Duvar(int kenarUzunlugu) : base(kenarUzunlugu)
        {
        }
        public Duvar(Lokasyon_Listesi _Lokasyon_Listesi)
        {
            Lokasyon_Listesi = _Lokasyon_Listesi;
        }
        public void YerlestirDuvarlar(Control.ControlCollection controls, Lokasyon lokasyon, int kenarUzunlugu, PaintEventArgs e)
        {
            double standartSapma = Math.Sqrt(lokasyon.X);
            int duvarBoyutu = 10;
            int duvarSayisi = (int)Math.Round(lokasyon.X * 0.03);

            for (int i = 0; i < duvarSayisi; i++)
            {
                Point duvarKonumu = GetRandomLocation(lokasyon, 1, kenarUzunlugu);

                bool cakismaVar = KontrolEt(controls, duvarKonumu, duvarBoyutu, kenarUzunlugu);
                if (!cakismaVar)
                {
                    PictureBox duvarPictureBox = new PictureBox();
                    duvarPictureBox.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "duvar.png");
                    duvarPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    duvarPictureBox.Name = "Duvar";
                    duvarPictureBox.Size = new Size(kenarUzunlugu * duvarBoyutu + duvarBoyutu, kenarUzunlugu + 1);
                    duvarPictureBox.Location = duvarKonumu;
                    duvarPictureBox.Visible = false;
                    Rectangle duvarrec = new Rectangle(duvarKonumu.X, duvarKonumu.Y, duvarPictureBox.Width, duvarPictureBox.Height);
                  
                    Lokasyon_Listesi.LokasyonRects.Add(duvarrec);
                    controls.Add(duvarPictureBox);
                    Lokasyon_Listesi.LokasyonPictureBoxes.Add(duvarPictureBox);
                }
                else
                {
                    i--;
                }
            }
        }


    }
}
