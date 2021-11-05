using System;
using System.ComponentModel.DataAnnotations;

namespace megaDesk_Web.Models
{
    public class DesktopMaterial
    {
        [Display(Name = "Desktop Material")]
        public int DesktopMaterialId { get; set; }
        public int Price { get; set; }
        public string MaterialName { get; set; }

        

    }
}