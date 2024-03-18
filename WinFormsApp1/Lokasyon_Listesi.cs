using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public class Lokasyon_Listesi
    {
        public List<Rectangle> LokasyonRects;
        public List<PictureBox> LokasyonPictureBoxes = new List<PictureBox>();
        public List<Rectangle> Hazineler;
        public List<Point> karakteringectiginoktalar;
        public List<PictureBox> HazinelerPictureBoxes = new List<PictureBox>();
        public Lokasyon_Listesi()
        {
            LokasyonRects = new List<Rectangle>();
            Hazineler = new List<Rectangle>();
            karakteringectiginoktalar = new List<Point>();
        }
    }
}
