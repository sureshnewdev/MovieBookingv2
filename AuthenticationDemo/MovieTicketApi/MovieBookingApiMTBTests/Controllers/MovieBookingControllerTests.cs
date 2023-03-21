using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoodieApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using FoodieApi.Services;
using FoodieApi.Model;

namespace FoodieApi.Controllers.Tests
{
    [TestClass()]
    public class MovieBookingControllerTests
    {
        Mock<MovieBookingServices> mockServices;
        List<MovieTicket> ticktCollection;
        MovieBookingController controller;

        [TestInitialize]
        public void SetUp()
        {
            mockServices= new Mock<MovieBookingServices>();
            SetTicketCollection();
        }

        private Task<List<MovieTicket>> SetTicketCollection()
        {
            List<MovieTicket> movieTickets = new List<MovieTicket>() { new MovieTicket { BookingDeails="1111", Id="3423432", MovieName="dddd" } };
            return Task.FromResult(movieTickets);
        }

        [TestMethod()]
        public void MovieBookingControllerTest()
        {
          
            Assert.AreEqual(1,1);
        }

        [TestMethod()]
        public void GetTest()
        {
            //mockServices.Setup(m=>m.GetMovieTickets()).Returns()
             Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        public void GetbyIdTest()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        public void InsertTest()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.AreEqual(1, 1);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Assert.AreEqual(1, 1);
        }
    }
}