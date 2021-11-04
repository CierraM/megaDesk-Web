using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace megaDesk_Web.Models
{
    public class DeskQuote
    {
        public int DeskQuoteID { get; set; }
        [Display(Name = "Customer Name")]
        public string CustomerName { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public DateTime QuoteDate { get; set; }
        public Decimal Price { get; set; }
        public int DeskId { get; set; }
        [Display(Name = "Shipping Option")]
        public int DeliveryId { get; set; }

        //Navigation Properties
        public Desk Desk { get; set; }
        public Delivery Delivery { get; set;}

        private const int _BASE_DESK_PRICE = 200;
        private const int _COST_PER_SQUARE_INCH = 1;
        private const int _COST_PER_DRAWER = 50;

        private int _surfaceArea;
        private int _extraAreaCost;
        private int _drawersCost;
        private int _materialCost;
        private int _shippingCost;

        public void calcPrice(MegaDeskWebContext context) {
            // var surfaceMaterialPrices = context.DesktopMaterial
            // .where(d => d.DesktopMaterialId == this.DesktopMaterialId);

            //calculate surface area
            _surfaceArea = this.Desk.Width * this.Desk.Depth;
            _extraAreaCost = _surfaceArea - 1000;
            //calculate the drawers cost
            _drawersCost = this.Desk.NumberOfDrawers * _COST_PER_DRAWER;

            //calculate the materials cost

            //calculate shipping price

            //calculate Total
            this.Price = _BASE_DESK_PRICE + _extraAreaCost + _materialCost + _shippingCost + _drawersCost;

        }
        
    }
}