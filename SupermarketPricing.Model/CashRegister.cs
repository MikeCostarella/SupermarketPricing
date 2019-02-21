using System.Collections.Generic;

namespace SupermarketPricing.Model
{
    public class CashRegister
    {
        public Supermarket Supermarket { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int ComputeTotalPrice()
        {
            var totalPrice = 0;
            var itemDictionary = new Dictionary<string, int>();
            foreach (var item in ShoppingCart.Items)
            {
                if (itemDictionary.ContainsKey(item.Sku))
                {
                    var currentCount = itemDictionary.GetValueOrDefault(item.Sku);
                    itemDictionary[item.Sku] = currentCount + 1;
                }
                else
                {
                    itemDictionary.Add(item.Sku, 1);
                }
            }
            foreach (var key in itemDictionary.Keys)
            {
                totalPrice += Supermarket.PriceCatalog.ComputePriceOfItemWithQuantity(key, itemDictionary.GetValueOrDefault(key));
            }
            return totalPrice;
        }
    }
}
