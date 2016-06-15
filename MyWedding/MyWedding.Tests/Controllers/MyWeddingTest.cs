using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWedding.Controllers;
using MyWedding.Repository;
using MyWedding.Models;
using Moq;
using System.Web;

namespace MyWedding.Tests.Controllers
{
    [TestClass]
    public class MyWeddingTest
    {
        [TestMethod]
        public void Can_Add_Private_Message()
        {
            // arrange
            Mock<IMyWeddingRepository> mock = new Mock<IMyWeddingRepository>();

            mock.Setup(m => m.Messages).Returns(new Message[]{
                new Message { Name = "Name1", MessageText = "ett meddelande", Public = false },
                new Message { Name = "Name2", MessageText = "ett till meddelande", Public = false }
                });

            MessagesController controller = new MessagesController(mock.Object);

            // act
            IEnumerable<Message> result = (IEnumerable<Message>)controller.ShowMessages().Model;

            //// assert
            Message[] MessageArray = result.ToArray();
            Assert.IsTrue(MessageArray.Length == 2);
            Assert.AreEqual(MessageArray[0].Name, "Name1");
            Assert.AreEqual(MessageArray[0].MessageText, "ett meddelande");
            Assert.AreEqual(MessageArray[1].Name, "Name2");
            Assert.AreEqual(MessageArray[1].MessageText, "ett till meddelande");
        }


        [TestMethod]
        public void ReturnsWishlistView()
        {
            // arrange
            Mock<IMyWeddingRepository> mock = new Mock<IMyWeddingRepository>();

            mock.Setup(m => m.WishlistItems).Returns(new WishlistItem[]{
                new WishlistItem{ Id=1, Name= "Item1", Details = "Item1 details", Price  = 100, Quantity=3, Reserved=1 },
                new WishlistItem{ Id=2, Name= "Item2", Details = "Item2 details", Price  = 200, Quantity=4, Reserved=0 },
                new WishlistItem{ Id=3,  Name= "Item3", Details = "Item3 details", Price  = 300, Quantity=2, Reserved=2 }
                });

            
            //WishlistController controller = new WishlistController(mock.Object);
            //var result = controller.Wishlist() as ViewResult;
            //Assert.AreEqual("fooview", result.ViewName);
        }

        [TestMethod]
        public void Can_Reserve_Item_In_Wishlist()
        {
            // arrange
            Mock<IMyWeddingRepository> mock = new Mock<IMyWeddingRepository>();

            mock.Setup(m => m.WishlistItems).Returns(new WishlistItem[]{
                new WishlistItem{ Id=1, Name= "Item1", Details = "Item1 details", Price  = 100, Quantity=3, Reserved=1 },
                new WishlistItem{ Id=2, Name= "Item2", Details = "Item2 details", Price  = 200, Quantity=4, Reserved=0 },
                new WishlistItem{ Id=3,  Name= "Item3", Details = "Item3 details", Price  = 300, Quantity=2, Reserved=2 }
                });


            WishlistController controller = new WishlistController(mock.Object);



            // act

            // assert
        }
    }
}

