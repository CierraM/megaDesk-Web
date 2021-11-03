using System;
using System.ComponentModel.DataAnnotations;

namespace megaDesk_Web.Models
{
    public class Desk
    {
        public int DeskId { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        public  int NumberOfDrawers { get; set; }
        public int DesktopMaterialId { get; set; }
        public int SurfaceArea { get; set; }
        
        //Navigation properties
        public DesktopMaterial DesktopMaterial { get; set; }
    }
}