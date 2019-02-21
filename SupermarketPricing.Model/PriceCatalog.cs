using System.Linq;
using System.Collections.Generic;

namespace SupermarketPricing.Model
{
    public class PriceCatalog
    {
        public List<PriceOffering> PriceOfferings { get; set; }

        public int ComputePriceOfItemWithQuantity(string name, int quantity)
        {
            var priceOffering = PriceOfferings.FirstOrDefault(offering => offering.Item.Sku == name);
            if (string.IsNullOrEmpty(priceOffering.SpecialOffer))
                return priceOffering.Price;
            else
            {
                return priceOffering.ComputeSpecialOfferingPrice(quantity);
            }
        }
    }
}
