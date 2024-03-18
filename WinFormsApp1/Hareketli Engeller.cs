using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Hareketli_Engeller
    {
        public Kuslar kuslar;
        public int kenarUzunlugu;
        //public Arilar arilar;
        Random random = new Random();
        
        public Hareketli_Engeller(int kenarUzunlugu)
        {
           
            this.kenarUzunlugu = kenarUzunlugu;
        }

        public Hareketli_Engeller()
        {

        }

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
