using NUnit.Framework;
using SupermarketPricing.Model;
using System.Collections.Generic;

namespace SupermarketPricing.NUnitTesting
{
    public class SupermarketPricingTests
    {
        private Supermarket _supermarket;

        [SetUp]
        public void Setup()
        {
            _supermarket = new Supermarket
            {
                PriceCatalog = new PriceCatalog
                {
                    PriceOfferings = new List<PriceOffering>
                    {
                        new PriceOffering
                        {
                            Item = new Item { Sku = "A" },
                            Price = 50,
                            SpecialOffer = "3 for 130"
                        },
                        new PriceOffering
                        {
                            Item = new Item { Sku = "B" },
                            Price = 30,
                            SpecialOffer = "2 for 45"
                        },
                        new PriceOffering
                        {
                            Item = new Item { Sku = "C" },
                            Price = 20,
                            SpecialOffer = ""
                        },
                        new PriceOffering
                        {
                            Item = new Item { Sku = "D" },
                            Price = 15,
                            SpecialOffer = ""
                        }
                    }
                }
            };
        }

        [Test]
        public void CanSuccessfullyCheckoutShoppingCart()
        {
            // Arrange
            var shoppingCart = new ShoppingCart
            {
                Items = new List<Item>
                {
                    new Item { Sku = "A" },
                    new Item { Sku = "B" },
                    new Item { Sku = "C" },
                    new Item { Sku = "D" }
                }
            };
            var cashRegister = new CashRegister
            {
                Supermarket = _supermarket,
                ShoppingCart = shoppingCart
            };

            // Act
            var totalPrice = cashRegister.ComputeTotalPrice();

            // Assert
            Assert.AreEqual(115, totalPrice);
        }

        [Test]
        public void CanSuccessfullyCheckoutSpecialOffers()
        {
            // Arrange
            var shoppingCart = new ShoppingCart
            {
                Items = new List<Item>
                {
                    new Item { Sku = "A" },
                    new Item { Sku = "A" },
                    new Item { Sku = "A" },
                    new Item { Sku = "B" },
                    new Item { Sku = "B" },
                    new Item { Sku = "C" },
                    new Item { Sku = "D" }
                }
            };
            var cashRegister = new CashRegister
            {
                Supermarket = _supermarket,
                ShoppingCart = shoppingCart
            };

            // Act
            var totalPrice = cashRegister.ComputeTotalPrice();

            // Assert
            Assert.AreEqual(210, totalPrice);
        }
    }
}