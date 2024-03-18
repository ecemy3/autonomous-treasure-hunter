using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Engeller
    {
        Random random = new Random();
        public int kenarUzunlugu;
     
        public string ImageFileName { get; set; }
        public int fark = 0;
        public int Boyut { get; set; }

        public Engeller(int kenarUzunlugu)
        {
            this.kenarUzunlugu = kenarUzunlugu;
          
        }
        public Engeller(){}

        public Point GetRandomLocation(Lokasyon lokasyon, int boyut, int kenarUzunlugu)
        {
            int max_X = lokasyon.Y;
            int max_Y = lokasyon.X;

            
            int x = random.Next(0, max_X - boyut); 
            int y = random.Next(0, max_Y);

            x = (x * (kenarUzunlugu + 1)) + 10;
            y = (y * (kenarUzunlugu + 1)) + 10;

            return new Point(x, y);
        }

        public Point GetRandomLocationHazine(Lokasyon lokasyon, int boyut, int kenarUzunlugu)
        {
            int max_X = lokasyon.Y;
            int max_Y = lokasyon.X;


            int x = random.Next(0, max_X - kenarUzunlugu * 3);
            int y = random.Next(0, max_Y - kenarUzunlugu * 3);

            x = (x * (kenarUzunlugu + 1)) + 10;
            y = (y * (kenarUzunlugu + 1)) + 10;

            return new Point(x, y);
        }

        public Point GetRandomLocationSol(Lokasyon lokasyon, int boyut, int kenarUzunlugu)
        {
            int max_X = lokasyon.Y / 2;

            int max_Y = lokasyon.X;

            int x = random.Next(0, max_X - boyut); 
            int y = random.Next(0, max_Y);


            x = (x * (kenarUzunlugu + 1)) + 10;
            y = (y * (kenarUzunlugu + 1)) + 10;
            return new Point(x, y);
        }

        public Point GetRandomLocationSag(Lokasyon lokasyon, int boyut, int kenarUzunlugu)
        {
            int max_X = (lokasyon.Y / 2) + (lokasyon.Y / 2); 
            int max_Y = lokasyon.X;

            int x = random.Next((max_X / 2) + 1, max_X - boyut);
            int y = random.Next(0, max_Y - boyut);

            x = (x * (kenarUzunlugu + 1)) + 10 ;
            y = (y * (kenarUzunlugu + 1)) + 10 ;
            return new Point(x, y);
        }

        public bool KontrolEt(Control.ControlCollection controls, Point konum, int boyut, int kenarUzunlugu)
        {
            foreach (Control ctrl in controls)
            {
                if (ctrl is PictureBox)
                {
                    PictureBox pb = (PictureBox)ctrl;
                    if (pb != null)
                    {
                        if (konum.X < pb.Location.X + pb.Width &&
                            konum.X + boyut * kenarUzunlugu > pb.Location.X &&
                            konum.Y < pb.Location.Y + pb.Height &&
                            konum.Y + boyut * kenarUzunlugu > pb.Location.Y)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
