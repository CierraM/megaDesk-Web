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

        public int calcPrice(MegaDeskWebContext context) {
            var surfaceMaterialPrice = context.DesktopMaterial
            .Where(d => d.DesktopMaterialId == this.Desk.DesktopMaterialId)
            .FirstOrDefault();

            _materialCost = surfaceMaterialPrice.Price;

            //calculate surface area
            _surfaceArea = this.Desk.Width * this.Desk.Depth;

            int _costPerSquareInch = 1;

            if (_surfaceArea > 1000){
                _extraAreaCost = _surfaceArea * _costPerSquareInch;
            }

            if (_surfaceArea < 1000) {
            _extraAreaCost = 0;
            } else {
                _extraAreaCost = _surfaceArea - 1000;
            }
            //calculate the drawers cost
            _drawersCost = this.Desk.NumberOfDrawers * _COST_PER_DRAWER;

            //calculate shipping price
            var shippingPrice = context.Delivery
            .Where(d => d.DeliveryId == this.DeliveryId)
            .FirstOrDefault();

            //figure out price by size of desktop
            if (_surfaceArea < 1000) {
                _shippingCost = shippingPrice.lessThan1000Price;
            } else if (_surfaceArea <= 2000) {
                _shippingCost = shippingPrice.lessThan2000Price;
            } else {
                _shippingCost = shippingPrice.moreThan2000Price;
            }

            

            //calculate Total
            return  _BASE_DESK_PRICE + _extraAreaCost + _materialCost + _shippingCost + _drawersCost;

        }
        
    }
}