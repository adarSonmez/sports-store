using System;
using System.Linq;
using Moq;
using SportsStore.Controllers;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using Xunit;

namespace SportsStore.Test;

public class HomeControllerTests
{
    [Fact]
    public void Can_Use_Repository()
    {
        // Arrange
        var mock = new Mock<IStoreRepository>();
        mock.Setup(m => m.Products).Returns(
            new Product[]
                {
                    new() { ProductId = 1, Name = "P1" },
                    new() { ProductId = 2, Name = "P2" }
                }
                .AsQueryable()
        );

        var controller = new HomeController(mock.Object);

        // Act
        var listViewModel = controller.Index().ViewData.Model as ProductsListViewModel;
        var result = listViewModel?.Products;

        // Assert
        var prodArray = result?.ToArray() ?? Array.Empty<Product>();
        Assert.True(prodArray.Length == 2);
        Assert.Equal("P1", prodArray[0].Name);
        Assert.Equal("P2", prodArray[1].Name);
    }

    [Fact]
    public void Can_Paginate()
    {
        // Arrange
        var mock = new Mock<IStoreRepository>();
        mock.Setup(m => m.Products).Returns(new Product[]
            {
                new() { ProductId = 1, Name = "P1" },
                new() { ProductId = 2, Name = "P2" },
                new() { ProductId = 3, Name = "P3" },
                new() { ProductId = 4, Name = "P4" },
                new() { ProductId = 5, Name = "P5" }
            }
            .AsQueryable());

        var controller = new HomeController(mock.Object);
        controller.PageSize = 3;

        // Act
        var listViewModel = controller.Index(2)
            .ViewData.Model as ProductsListViewModel;
        var result = listViewModel?.Products;

        // Assert
        var prodArray = result?.ToArray();
        Assert.True(prodArray?.Length == 2);
        Assert.Equal("P4", prodArray?[0].Name);
        Assert.Equal("P5", prodArray?[1].Name);
    }

    [Fact]
    public void Can_Send_Pagination_View_Model()
    {
        // Arrange
        var mock = new Mock<IStoreRepository>();
        mock.Setup(m => m.Products).Returns(
            new Product[]
            {
                new() { ProductId = 1, Name = "P1" },
                new() { ProductId = 2, Name = "P2" },
                new() { ProductId = 3, Name = "P3" },
                new() { ProductId = 4, Name = "P4" },
                new() { ProductId = 5, Name = "P5" }
            }.AsQueryable());

        // Arrange
        var controller = new HomeController(mock.Object)
        {
            PageSize = 3
        };

        // Act
        var result = controller
            .Index(2)
            .ViewData.Model as ProductsListViewModel ?? new ProductsListViewModel();

        // Assert
        var pageInfo = result.PagingInfo;
        Assert.Equal(2, pageInfo.CurrentPage);
        Assert.Equal(3, pageInfo.ItemsPerPage);
        Assert.Equal(5, pageInfo.TotalItems);
        Assert.Equal(2, pageInfo.TotalPages);
    }
}