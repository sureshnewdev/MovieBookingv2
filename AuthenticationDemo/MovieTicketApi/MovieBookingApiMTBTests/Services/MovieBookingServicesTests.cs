using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodieApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace FoodieApi.Services.Tests
{
    [TestClass()]
    public class MovieBookingServicesTests
    {
        Mock<MovieBookingServices> moservices;

        [TestInitialize]
        public void Setup()
        {
             
        }

     

        [TestMethod()]
        public void MovieBookingServicesTest()
        {
            Assert.AreEqual(1, 1);

        }

        [TestMethod()]
        public void GetMovieTicketsTest()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        public void InsertMovieTicketTest()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Assert.AreEqual(1, 1);
        }

         
    }
}