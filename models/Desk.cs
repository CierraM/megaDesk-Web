using System;
using System.ComponentModel.DataAnnotations;

namespace megaDesk_Web.Models
{
    public class Desk
    {
        public int DeskId { get; set; }
        public int Width { get; set; }
        public int Depth { get; set; }
        [Display(Name = "Number of Drawers")]
        public  int NumberOfDrawers { get; set; }
        
               
        [Display(Name = "Desktop Material")]
        public int DesktopMaterialId { get; set; }
        public int SurfaceArea { get; set; }
        
        //Navigation properties
        [Display(Name = "Desktop Material")] 
        public DesktopMaterial DesktopMaterial { get; set; }
    }
}