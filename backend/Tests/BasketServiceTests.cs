using Moq;
using Xunit;
using ShoppingBasketBackend.Models;
using ShoppingBasketBackend.Repositories;
using ShoppingBasketBackend.Services;

namespace ShoppingBasketBackend.Tests
{
    public class BasketServiceTests
    {
        [Fact]
        public async Task GenerateReceiptAsync_ShouldCalculateCorrectTotals_WhenNoDiscounts()
        {
            // Arrange: Create a sample basket with two items.
            var basket = new ShoppingBasket
            {
                Items = new List<BasketItem>
                {
                    new BasketItem
                    {
                        Product = new Product { Name = "Soup", Price = 0.65M },
                        Quantity = 2
                    },
                    new BasketItem
                    {
                        Product = new Product { Name = "Bread", Price = 0.80M },
                        Quantity = 1
                    }
                }
            };

            // For this test, create a discount mock that returns 0 discount.
            var mockDiscount = new Mock<IDiscount>();
            mockDiscount.Setup(d => d.CalculateDiscount(It.IsAny<ShoppingBasket>())).Returns(0M);
            mockDiscount.Setup(d => d.CalculateItemDiscount(It.IsAny<BasketItem>(), It.IsAny<ShoppingBasket>())).Returns(0M);
            var discounts = new List<IDiscount> { mockDiscount.Object };

            // Create a fake receipt repository using Moq.
            var mockReceiptRepository = new Mock<IReceiptRepository>();
            mockReceiptRepository.Setup(r => r.AddAsync(It.IsAny<Receipt>())).Returns(Task.CompletedTask);
            mockReceiptRepository.Setup(r => r.SaveChangesAsync()).Returns(Task.CompletedTask);

            IBasketService basketService = new BasketService(discounts, mockReceiptRepository.Object);

            // Act: Generate the receipt.
            var receipt = await basketService.GenerateReceiptAsync(basket);

            // Assert: Expected totals.
            // Expected SubTotal = (2 * 0.65) + (1 * 0.80) = 2.10M
            Assert.Equal(2.10M, receipt.SubTotal);
            Assert.Equal(0M, receipt.TotalDiscount); // Since discounts return 0.
            Assert.Equal(2.10M, receipt.Total);
            Assert.Equal(2, receipt.Items.Count);

            // Verify repository calls.
            mockReceiptRepository.Verify(r => r.AddAsync(It.IsAny<Receipt>()), Times.Once);
            mockReceiptRepository.Verify(r => r.SaveChangesAsync(), Times.Once);
        }
    }
}
