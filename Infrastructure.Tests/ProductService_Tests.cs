using Xunit;
using Infrastructure.Services;

namespace Infrastructure.Tests;

public class ProductService_Tests

{
    
    public class ProductService_G_Tests
    {
        [Fact]
        public void AddProduct_ShouldIncreaseListCount()
        {
            // Arrange
            var service = new ProductService();

            // Act
            service.AddProduct("Nike Mercurial", 1299.99m);

            // Assert
            Assert.Equal(1, service.GetProducts().Count);
        }

        [Fact]
        public void GetProducts_ShouldReturnAddedProduct()
        {
            // Arrange
            var service = new ProductService();
            var p = service.AddProduct("Boll", 199m);

            // Act
            var list = service.GetProducts();

            // Assert
            Assert.Single(list);
            Assert.Equal(p.Id, list[0].Id);
            Assert.Equal("Boll", list[0].Name);
            Assert.Equal(199m, list[0].Price);
        }
    }
}


