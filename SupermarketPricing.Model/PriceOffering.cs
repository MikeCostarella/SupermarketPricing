using System;

namespace SupermarketPricing.Model
{
    public class PriceOffering
    {
        public Item Item { get; set; }
        public int Price { get; set; }
        public string SpecialOffer { get; set; }

        public  int ComputeSpecialOfferingPrice(int quantity)
        {
            // ToDo: make parsing and special offer language tougher in the future
            var substrings = SpecialOffer.Split();
            var specialQuantity = int.Parse(substrings[0]);
            var specialPrice = int.Parse(substrings[2]);
            if (quantity == specialQuantity)
            {
                return specialPrice;
            }
            else
            {
                return Price * quantity;
            }
        }
    }
}
