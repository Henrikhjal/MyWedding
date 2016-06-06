using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyWedding;
using MyWedding.Controllers;
using MyWedding.Repository;
using MyWedding.Models;
using Moq;

namespace MyWedding.Tests.Controllers
{
    [TestClass]
    public class MyWeddingTest
    {
        // Unit tests will be created.
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

            // assert
            Message[] MessageArray = result.ToArray();
            Assert.IsTrue(MessageArray.Length == 2);
            Assert.AreEqual(MessageArray[0].Name, "Name1");
            Assert.AreEqual(MessageArray[1].Name, "Name2");
        }

        public void CanReserveWishListItem()
        {
            // arrange

            // act

            // assert
        }
    }
}

