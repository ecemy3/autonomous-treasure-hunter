using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Hazineler : Engeller
    {
        Lokasyon_Listesi Lokasyon_Listesi = new Lokasyon_Listesi();
        Rectangle altinhazinerect;
        Rectangle gumushazinerect;
        Rectangle elmashazinerect;
        public Hazineler(int kenarUzunlugu) : base(kenarUzunlugu) { }
        public Hazineler(Lokasyon_Listesi _Lokasyon_Listesi)
        {
            Lokasyon_Listesi = _Lokasyon_Listesi;
        }
        public Hazineler(Hareketli_Engeller hareketliEngeller)
        {

        }
        public void YerlestirAltınHazine(Control.ControlCollection controls, Lokasyon lokasyon, int kenarUzunlugu, PaintEventArgs e)
        {
            int[] altınHazineBoyutları = { 2 };

            foreach (int boyut in altınHazineBoyutları)
            {
                double standartSapma = Math.Sqrt(lokasyon.X);
                int altınHazineSayisi = (int)Math.Round(lokasyon.X * 0.03);
                for (int i = 0; i < altınHazineSayisi; i++)
                {
                    int altınHazineBoyutu = boyut;
                    Point altınHazineKonumu = GetRandomLocationHazine(lokasyon, altınHazineBoyutu, kenarUzunlugu);
                    bool cakismaVar = KontrolEt(controls, altınHazineKonumu, altınHazineBoyutu, kenarUzunlugu);
                    if (!cakismaVar)
                    {
                        PictureBox altınHazinePictureBox = new PictureBox();
                        altınHazinePictureBox.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "altınhazine.jpg");
                        altınHazinePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        altınHazinePictureBox.Name = "Altın Hazine";
                        altınHazinePictureBox.Size = new Size(kenarUzunlugu * altınHazineBoyutu + altınHazineBoyutu, kenarUzunlugu * altınHazineBoyutu + altınHazineBoyutu);
                        altınHazinePictureBox.Location = altınHazineKonumu;
                        altınHazinePictureBox.Visible = false;
                        altinhazinerect = new Rectangle(altınHazineKonumu.X, altınHazineKonumu.Y, altınHazinePictureBox.Width, altınHazinePictureBox.Height);

                        Lokasyon_Listesi.Hazineler.Add(altinhazinerect);

                        controls.Add(altınHazinePictureBox);
                        Lokasyon_Listesi.HazinelerPictureBoxes.Add(altınHazinePictureBox);
                    }
                    else
                    {
                        i--;
                    }

                }
            }

        }


        public void YerlestirGümüsHazine(Control.ControlCollection controls, Lokasyon lokasyon, int kenarUzunlugu, PaintEventArgs e)
        {
            int[] gümüsHazineBoyutları = { 2 };

            foreach (int boyut in gümüsHazineBoyutları)
            {
                double standartSapma = Math.Sqrt(lokasyon.X);
                int gümüsHazineSayisi = (int)Math.Round(standartSapma * 0.3);

                for (int i = 0; i < gümüsHazineSayisi; i++)
                {
                    int gümüsHazineBoyutu = boyut;
                    Point gümüsHazineKonumu = GetRandomLocationHazine(lokasyon, gümüsHazineBoyutu, kenarUzunlugu);

                    bool cakismaVar = KontrolEt(controls, gümüsHazineKonumu, gümüsHazineBoyutu, kenarUzunlugu);
                    if (!cakismaVar)
                    {
                        PictureBox GumusHazinePictureBox = new PictureBox();
                        GumusHazinePictureBox.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "gumushazine.jpg");
                        GumusHazinePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        GumusHazinePictureBox.Name = "Gümüş Hazine";
                        GumusHazinePictureBox.Size = new Size(kenarUzunlugu * gümüsHazineBoyutu + gümüsHazineBoyutu, kenarUzunlugu * gümüsHazineBoyutu + gümüsHazineBoyutu);
                        GumusHazinePictureBox.Location = gümüsHazineKonumu;
                        GumusHazinePictureBox.Visible = false;
                        gumushazinerect = new Rectangle(gümüsHazineKonumu.X, gümüsHazineKonumu.Y, GumusHazinePictureBox.Width, GumusHazinePictureBox.Height);
                        Lokasyon_Listesi.Hazineler.Add(gumushazinerect);

                        controls.Add(GumusHazinePictureBox);

                        Lokasyon_Listesi.HazinelerPictureBoxes.Add(GumusHazinePictureBox);

                    }
                    else
                    {
                        i--;
                    }
                }
            }

        }

        public void YerlestirElmasHazine(Control.ControlCollection controls, Lokasyon lokasyon, int kenarUzunlugu, PaintEventArgs e)
        {
            int[] elmasHazineBoyutları = { 2 };

            foreach (int boyut in elmasHazineBoyutları)
            {
                double standartSapma = Math.Sqrt(lokasyon.X);
                int elmasHazineSayisi = (int)Math.Round(lokasyon.X * 0.03);

                for (int i = 0; i < elmasHazineSayisi; i++)
                {
                    int elmasHazineBoyutu = boyut;
                    Point elmasHazineKonumu = GetRandomLocationHazine(lokasyon, elmasHazineBoyutu, kenarUzunlugu);

                    bool cakismaVar = KontrolEt(controls, elmasHazineKonumu, elmasHazineBoyutu, kenarUzunlugu);
                    if (!cakismaVar)
                    {
                        PictureBox ElmasHazinePictureBox = new PictureBox();
                        ElmasHazinePictureBox.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "elmas.jpg");
                        ElmasHazinePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        ElmasHazinePictureBox.Name = "Elmas Hazine";
                        ElmasHazinePictureBox.Size = new Size(kenarUzunlugu * elmasHazineBoyutu + elmasHazineBoyutu, kenarUzunlugu * elmasHazineBoyutu + elmasHazineBoyutu);
                        ElmasHazinePictureBox.Location = elmasHazineKonumu;
                        ElmasHazinePictureBox.Visible = false;
                        elmashazinerect = new Rectangle(elmasHazineKonumu.X, elmasHazineKonumu.Y, ElmasHazinePictureBox.Width, ElmasHazinePictureBox.Height);
                        Lokasyon_Listesi.Hazineler.Add(elmashazinerect);

                        controls.Add(ElmasHazinePictureBox);

                        Lokasyon_Listesi.HazinelerPictureBoxes.Add(ElmasHazinePictureBox);

                    }
                    else
                    {
                        i--;
                    }
                }
            }

        }


        public void YerlestirBakirHazine(Control.ControlCollection controls, Lokasyon lokasyon, int kenarUzunlugu, PaintEventArgs e)
        {
            int[] bakirHazineBoyutları = { 2 };

            foreach (int boyut in bakirHazineBoyutları)
            {
                double standartSapma = Math.Sqrt(lokasyon.X);
                int bakirHazineSayisi = (int)Math.Round(lokasyon.X * 0.03);

                for (int i = 0; i < bakirHazineSayisi; i++)
                {
                    int bakirHazineBoyutu = boyut;
                    Point bakirHazineKonumu = GetRandomLocationHazine(lokasyon, bakirHazineBoyutu, kenarUzunlugu);

                    bool cakismaVar = KontrolEt(controls, bakirHazineKonumu, bakirHazineBoyutu, kenarUzunlugu);
                    if (!cakismaVar)
                    {
                        PictureBox bakirHazinePictureBox = new PictureBox();
                        bakirHazinePictureBox.Image = Image.FromFile("../../../myImage/" + "bakır.jpg");
                        bakirHazinePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                        bakirHazinePictureBox.Name = "Bakır Hazine";
                        bakirHazinePictureBox.Size = new Size(kenarUzunlugu * bakirHazineBoyutu + bakirHazineBoyutu, kenarUzunlugu * bakirHazineBoyutu + bakirHazineBoyutu);
                        bakirHazinePictureBox.Location = bakirHazineKonumu;
                        bakirHazinePictureBox.Visible = false;
                        Rectangle bakirhazinerec = new Rectangle(bakirHazineKonumu.X, bakirHazineKonumu.Y, bakirHazinePictureBox.Width, bakirHazinePictureBox.Height);
                        Lokasyon_Listesi.Hazineler.Add(bakirhazinerec);
                        controls.Add(bakirHazinePictureBox);
                        Lokasyon_Listesi.HazinelerPictureBoxes.Add(bakirHazinePictureBox);
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
