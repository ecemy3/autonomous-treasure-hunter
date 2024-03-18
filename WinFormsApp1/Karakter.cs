using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Karakter : Engeller
    {
        // Özellikler
        public int ID { get; set; }
        public string Ad { get; set; }
        public Lokasyon Konum { get; set; } // Karakterin konumunu Lokasyon türünden tutuyoruz
        public int kenarUzunlugu;
        public int aralik = 1;
        public List<Point> karakterKoordinatlariListesi = new List<Point>();
        private Random random = new Random(); // Random nesnesini bir kere oluştur
        public int KarakterBoyutu;
        public PictureBox KarakterPictureBox;
        Point karakterKonumu;
        public Rectangle karaktergorusrect;
        public Rectangle karakterrect;
        public int randomHareket;
        public int random2;
        public int random3;
        public int counter = 0;
        public int yolcounter = 0;
        public int oncekiKatedilenYol = 0;
        public int katedilenYol = 0;
        public bool hazineGordu = false;
        public bool yonDegistir = false;
        public int randomKU;
        public int hazineBulunduSayacı = 0;
        public Lokasyon lokasyon1;
        public bool ilk = false;

        public List<Point> gorulenEngellerinKoordinatlariListesi = new List<Point>();
        public List<Point> bulunanHazinelerinKoordinatlariListesi = new List<Point>();
        public List<string> gorulenEngeller = new List<string>();
        public List<string> bulunanHazineler = new List<string>();
        public List<string> siralaHazineler = new List<string>();

        public List<string> altinHazineler = new List<string>();
        public List<string> gumusHazineler = new List<string>();
        public List<string> elmasHazineler = new List<string>();
        public List<string> bakirHazineler = new List<string>();


        public int ct = 0;
        public int counter2 = 0;
        public bool isNeedTemp = false;

        public bool ariVarMi = false;
        public bool kusVarMi = false;
        public bool kus2VarMi = false;

        public bool randomControl = false;
        public bool isReady = false;
        public int hazineFarkX;
        public int hazineFarkY;

        public bool isIntersect = false;

        Lokasyon_Listesi Lokasyon_Listesi;
        private int karakterKonumuY;
        private int karakterKonumuX;
        private int hareketYonuY = 0;
        private int hareketYonuX = 1;

        // Constructor
        public Karakter(int id, string ad, Lokasyon konum)
        {
            ID = id;
            Ad = ad;
            Konum = konum;
        }

        public Karakter(Lokasyon_Listesi _Lokasyon_Listesi) 
        {

            Lokasyon_Listesi = _Lokasyon_Listesi;

        }
        public Karakter()
        {

        }

        private void SetKarakterKonumu(Point konum)
        {
            if (Konum == null)
            {
                Konum = new Lokasyon(konum.X, konum.Y);
            }
            else
            {
                Konum.X = konum.X;
                Konum.Y = konum.Y;
            }
        }

        public void YerlestirKarakter(Control.ControlCollection controls, Lokasyon lokasyon, int kenarUzunlugu, PaintEventArgs e)
        {
            int KarakterBoyutu = 1;


            this.kenarUzunlugu = kenarUzunlugu;
            this.lokasyon1 = lokasyon;
            int x = random.Next(0, lokasyon.X);
            int y = random.Next(0, lokasyon.Y);

            karakterKonumu = new Point(x * (kenarUzunlugu + aralik) + 10, y * (kenarUzunlugu + aralik) + 10);

            bool cakismaVar = KontrolEt(controls, karakterKonumu, KarakterBoyutu, kenarUzunlugu);
            if (!cakismaVar)
            {

                SetKarakterKonumu(karakterKonumu);
                KarakterPictureBox = new PictureBox();
                KarakterPictureBox.Image = Image.FromFile(Application.StartupPath + "../../../myImage/" + "karakter.jpeg");
                KarakterPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                KarakterPictureBox.Size = new Size((kenarUzunlugu * KarakterBoyutu) + KarakterBoyutu, (kenarUzunlugu * KarakterBoyutu) + KarakterBoyutu);
                KarakterPictureBox.Location = karakterKonumu;
                controls.Add(KarakterPictureBox);

                this.karakterKonumuY = KarakterPictureBox.Location.Y;
                this.karakterKonumuX = KarakterPictureBox.Location.X;

                Point SolUst = new Point((karakterKonumu.X) - (kenarUzunlugu * 4), (karakterKonumu.Y) - (kenarUzunlugu * 4));
                Point SagAlt = new Point((karakterKonumu.X) + (kenarUzunlugu * 4), (karakterKonumu.Y) + (kenarUzunlugu * 4));

                if (SolUst.X < 0)
                {
                    SolUst.X = 0;
                    SolUst.Y = 0;
                }

                if (SagAlt.Y > 1000)
                {
                    SagAlt.Y = 1000;
                    SagAlt.X = 1000;
                }

                

                InitializeTimer();
            }
            else
            {
                YerlestirKarakter(controls, lokasyon, kenarUzunlugu, e);
            } 
        }
        // karakterin engel içinden geçmemesi için karakterin pictureboxının rectanglenı tutup bunu yön değiştirmesi için kullanmalıyız.
        // bu da aynı şekilde updatechracterin içinde güncellenmeli

        public void UpdateCharacter()
        {
            karaktergorusrect = new Rectangle((KarakterPictureBox.Location.X) - (kenarUzunlugu * 4) - KarakterBoyutu * 4, (KarakterPictureBox.Location.Y) - (kenarUzunlugu * 4) - KarakterBoyutu * 4, (kenarUzunlugu * 9) + KarakterBoyutu * 9, (kenarUzunlugu * 9) + KarakterBoyutu * 9);

            karakterrect = new Rectangle(KarakterPictureBox.Location, KarakterPictureBox.Size);

        }

        public void InitializeTimer()
        {
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick_Karakter;
            timer.Start(); 
        }

        public void Timer_Tick_Karakter(object sender, EventArgs e)
        {

            UpdateCharacter();

            int tempKonumY = karakterKonumuY;
            int tempKonumX = karakterKonumuX;

            karakterKonumuY -= hareketYonuY;
            karakterKonumuX -= hareketYonuX;
            try
            {
               
                int Random = random.Next(0, 2);
                if (karakterKonumuY == 9)
                {
                    karakterKonumuY = 10;
                    hareketYonuX = 0;
                    hareketYonuY = -1;
                    counter += 1;
                }
                else if(karakterKonumuY == 1001)
                {
                    karakterKonumuY = 1000;
                    hareketYonuX = 0;
                    hareketYonuY = 1;
                    counter += 1;
                }
                else if(karakterKonumuX == 9)
                {
                    karakterKonumuX = 10;
                    hareketYonuX = -1;
                    hareketYonuY = 0;
                    counter += 1;
                }
                else if(karakterKonumuX == 1001)
                {
                    karakterKonumuX = 1000;
                    hareketYonuX = 1;
                    hareketYonuY = 0;
                    counter+=1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            //if (counter >= 2)
            //{
            //    DugumuCoz();
            //}


            //bool DugumVarMi = DugumKontrol();
            double standartSapma = Math.Sqrt(Konum.X);
            int elmasHazineSayisi = (int)Math.Round(lokasyon1.X * 0.03);
                for (int i = 0; i < Lokasyon_Listesi.LokasyonRects.Count; i++)
                {
                    Rectangle rect = Lokasyon_Listesi.LokasyonRects[i];


                    if (rect.IntersectsWith(karaktergorusrect))
                    {
                        PictureBox pictureBoxToRemove = Lokasyon_Listesi.LokasyonPictureBoxes[i];
                        if (!gorulenEngellerinKoordinatlariListesi.Contains(pictureBoxToRemove.Location))
                        {
                            gorulenEngellerinKoordinatlariListesi.Add(pictureBoxToRemove.Location);

                        }

                        string gorulenEngel = "Engel! " + pictureBoxToRemove.Location + " konumunda " + pictureBoxToRemove.Name + " görüldü.";
                        if (!gorulenEngeller.Contains(gorulenEngel))
                        {
                            if (gorulenEngel.Contains("Arı"))
                            {
                                if (!ariVarMi)
                                {
                                    gorulenEngeller.Add(gorulenEngel);
                                    ariVarMi = true;
                                }
                            }
                            else if (gorulenEngel.Contains("Kuş") && gorulenEngel.Contains("Kuş2"))
                            {
                                if (!kus2VarMi)
                                {
                                    gorulenEngeller.Add(gorulenEngel);
                                    kus2VarMi = true;
                                }
                            }

                            else if (gorulenEngel.Contains("Kuş") && !gorulenEngel.Contains("Kuş2"))
                            {
                                if (!kusVarMi)
                                {
                                    gorulenEngeller.Add(gorulenEngel);
                                    kusVarMi = true;
                                }
                            }
                            else
                            {
                                gorulenEngeller.Add(gorulenEngel);
                            }

                        }

                        pictureBoxToRemove.Visible = true;

                    }

                    if (rect.IntersectsWith(karakterrect) && !hazineGordu)
                    {

                        randomHareket = random.Next(0, 2);
                        oncekiKatedilenYol = katedilenYol;
                        katedilenYol = 0;
                        counter = 0;
                        carpmaKontrol(tempKonumY, tempKonumX, randomHareket);

                    }


                    for (int j = 0; j < Lokasyon_Listesi.Hazineler.Count; j++)
                    {
                        PictureBox hazine = Lokasyon_Listesi.HazinelerPictureBoxes[j];
                        

                        Rectangle rect2 = Lokasyon_Listesi.Hazineler[j];
                        if (rect2.IntersectsWith(karaktergorusrect))
                        {
                            hazineGordu = true;
                            hazine.Visible = true;
                            //hazine 50, 20
                            //karakter 40, 30
                            hazineFarkX = (karakterKonumuX - rect2.X);
                            hazineFarkY = (karakterKonumuY - rect2.Y);

                            if (hazineFarkX < 0)
                            {
                                hareketYonuX = -1;
                                hareketYonuY = 0;
                                if (yonDegistir)
                                    continue;
                                break;
                            }

                            else if (hazineFarkX > 0)
                            {
                                hareketYonuX = 1;
                                hareketYonuY = 0;
                                if (yonDegistir)
                                    continue;
                                break;
                            }

                            else if (hazineFarkY < 0)
                            {
                                hareketYonuY = -1;
                                hareketYonuX = 0;
                                if (yonDegistir)
                                    continue;
                                break;

                            }
                            else if (hazineFarkY > 0)
                            {
                                hareketYonuY = 1;
                                hareketYonuX = 0;
                                if (yonDegistir)
                                    continue;
                                break;
                            }
                        }

                        if (rect2.IntersectsWith(karakterrect))
                        {

                            if (!bulunanHazinelerinKoordinatlariListesi.Contains(hazine.Location))
                            {
                                bulunanHazinelerinKoordinatlariListesi.Add(hazine.Location);
                            }
                            Lokasyon_Listesi.Hazineler.Remove(rect2);
                            Lokasyon_Listesi.HazinelerPictureBoxes.Remove(hazine);

                            string bulunanHazine = "Hazine! " + hazine.Location + " konumunda " + hazine.Name + " bulundu.";
                            if (!bulunanHazineler.Contains(bulunanHazine))
                            {
                                bulunanHazineler.Add(bulunanHazine);
                                hazineBulunduSayacı += 1;
                            }
                            hazineGordu = false;
                            hazine.Visible = false;
                        }
                    }
                }
                if (KarakterPictureBox != null)
                {

                    if (hazineBulunduSayacı == elmasHazineSayisi * 4)
                    {
                        if (!ilk)
                        {
                            hareketYonuY = 0;
                            hareketYonuX = 0;
                            ilk = true;

                            HazineSirala();
                        }

                    }

                    KarakterPictureBox.Location = new Point(karakterKonumuX, karakterKonumuY);

                    if (!Lokasyon_Listesi.karakteringectiginoktalar.Contains(KarakterPictureBox.Location))
                    {
                        Lokasyon_Listesi.karakteringectiginoktalar.Add(KarakterPictureBox.Location);
                        counter2 = 0;
                        randomControl = false;
                    }
                    else
                    {
                        counter2 += 1;


                        if (!randomControl)
                        {
                            randomKU = random.Next(5, (int)(lokasyon1.X/(6)));
                            randomControl = true;
                        }
                        if (counter2 == kenarUzunlugu * randomKU + 1)
                        {
                            isNeedTemp = true;
                            randomControl = false;
                            hareketKontrol(tempKonumY, tempKonumX, randomHareket);
                            counter2 = 0;
                        }

                    }

                }
            }

        private void HazineSirala()
        {
            foreach(string hazine in bulunanHazineler)
            {
                if (hazine.Contains("Altın"))
                {
                    altinHazineler.Add(hazine);
                }

                if (hazine.Contains("Gümüş"))
                {
                    gumusHazineler.Add(hazine);
                }

                if (hazine.Contains("Elmas"))
                {
                    elmasHazineler.Add(hazine);
                }

                if (hazine.Contains("Bakır"))
                {
                    bakirHazineler.Add(hazine);
                }

            }
            foreach (string str in altinHazineler)
            {
                siralaHazineler.Add(str);
            }
            foreach (string str in gumusHazineler)
            {
                siralaHazineler.Add(str);
            }
            foreach (string str in elmasHazineler)
            {
                siralaHazineler.Add(str);
            }
            foreach (string str in bakirHazineler)
            {
                siralaHazineler.Add(str);
            }
            isReady = true;
        }

        public void DugumuCoz()
        {

            if (ct == 0)
            {
                random2 = random.Next(12, Konum.X / 10 + 10);
                random3 = random.Next(0, 2);
                ct = 1;
            }

            if (hareketYonuX == 1)
            {
                hareketYonuX = 1;
                if (karakterKonumuX == random2 * kenarUzunlugu)
                {
                    hareketYonuX = 0;
                    if (random3 == 0)
                        hareketYonuY = 1;
                    else
                        hareketYonuY = -1;
                    counter = 0;
                    ct = 0;
                }
            }
            else if (hareketYonuX == -1)
            {
                hareketYonuX = -1;
                if (karakterKonumuX == random2 * kenarUzunlugu)
                {
                    hareketYonuX = 0;
                    if (random3 == 0)
                        hareketYonuY = 1;
                    else
                        hareketYonuY = -1;
                    counter = 0;
                    ct = 0;
                }
            }
            else if (hareketYonuY == 1)
            {
                hareketYonuY = 1;
                if (karakterKonumuY == random2 * kenarUzunlugu)
                {
                    hareketYonuY = 0;
                    if (random3 == 0)
                        hareketYonuX = 1;
                    else
                        hareketYonuX = -1;
                    counter = 0;
                    ct = 0;
                }
            }
            else if (hareketYonuY == -1)
            {
                hareketYonuY = -1;
                if (karakterKonumuY == random2 * kenarUzunlugu)
                {
                    hareketYonuY = 0;
                    if (random3 == 0)
                        hareketYonuX = 1;
                    else
                        hareketYonuX = -1;
                    counter = 0;
                    ct = 0;
                }
            }
        }

        private void carpmaKontrol(int tempKonumY, int tempKonumX, int randomHareket)
        {
            if (hareketYonuX == 1)//sol
            {
                if (randomHareket == 0)
                {
                    hareketYonuY = -1;
                    hareketYonuX = 0;
                    karakterKonumuX = tempKonumX + 1;
                    if (hazineGordu)
                        yonDegistir = true;

                }
                else
                {
                    hareketYonuY = 1;
                    hareketYonuX = 0;
                    karakterKonumuX = tempKonumX + 1;
                    if (hazineGordu)
                        yonDegistir = true;

                }
            }

            else if (hareketYonuX == -1)//sağ
            {
                if (randomHareket == 0)
                {
                    hareketYonuY = 1;
                    hareketYonuX = 0;
                    karakterKonumuX = tempKonumX - 1;
                    if (hazineGordu)
                        yonDegistir = true;

                }
                else
                {
                    hareketYonuY = -1;
                    hareketYonuX = 0;
                    karakterKonumuX = tempKonumX - 1;
                    if (hazineGordu)
                        yonDegistir = true;

                }
            }

            else if (hareketYonuY == 1)//yukarı
            {
                if (randomHareket == 0)
                {
                    hareketYonuY = 0;
                    hareketYonuX = 1;
                    karakterKonumuY = tempKonumY + 1;
                    if (hazineGordu)
                        yonDegistir = true;

                }
                else
                {
                    hareketYonuY = 0;
                    hareketYonuX = -1;
                    karakterKonumuY = tempKonumY + 1;
                    if (hazineGordu)
                        yonDegistir = true;

                }
            }

            else if (hareketYonuY == -1)//aşağı
            {
                if (randomHareket == 0)
                {
                    hareketYonuY = 0;
                    hareketYonuX = 1;
                    karakterKonumuY = tempKonumY - 1;
                    if (hazineGordu)
                        yonDegistir = true;
                }
                else
                {
                    hareketYonuY = 0;
                    hareketYonuX = -1;
                    karakterKonumuY = tempKonumY - 1;
                    if (hazineGordu)
                        yonDegistir = true;
                }
            }
        }

        private void hareketKontrol(int tempKonumY, int tempKonumX, int Random)
        {
            if (hareketYonuX == 1)//sol
            {
                if (Random == 0)
                {
                    hareketYonuY = -1;
                    hareketYonuX = 0;
                }
                else
                {
                    hareketYonuY = 1;
                    hareketYonuX = 0;
                }
            }

            else if (hareketYonuX == -1)//sağ
            {
                if (Random == 0)
                {
                    hareketYonuY = 1;
                    hareketYonuX = 0;
                        
                }
                else
                {
                    hareketYonuY = -1;
                    hareketYonuX = 0;
                }
            }

            else if (hareketYonuY == 1)//yukarı
            {
                if (Random == 0)
                {
                    hareketYonuY = 0;
                    hareketYonuX = 1;
                        
                }
                else
                {
                    hareketYonuY = 0;
                    hareketYonuX = -1;
                }
            }

            else if (hareketYonuY == -1)//aşağı
            {
                if (Random == 0)
                {
                    hareketYonuY = 0;
                    hareketYonuX = 1;
                }
                else
                {
                    hareketYonuY = 0;
                    hareketYonuX = -1;
                }
            }
        }

    }
}
    