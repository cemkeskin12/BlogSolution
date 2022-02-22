using CKBlog.TestWeb.Controllers;
using CKBlog.TestWeb.Entities;
using CKBlog.TestWeb.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CKBlog.Test
{
    public class ArticleTest
    {
        [Fact]
        public async void Test_GET_AllReservations()
        {
            // Arrange
            var mockRepo = new Mock<IArticleService>();
            await mockRepo.Setup(repo => repo.GetArticlesAsync()).Returns();
            var controller = new HomeController(mockRepo.Object);

            // Act
            var result = controller.Index();

            // Assert
            var model = Assert.IsAssignableFrom<IEnumerable<Article>>(result);
            Assert.Equal("asd", model.ToString());
        }

    }
}
