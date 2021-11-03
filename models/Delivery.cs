using System;
using System.ComponentModel.DataAnnotations;

namespace megaDesk_Web.Models
{
    public class Delivery
    {
        public int DeliveryId { get; set; }
        public int lessThan1000Price { get; set; }
        public int lessThan2000Price { get; set; }
        public int moreThan2000Price { get; set; }
    }
}