using CaartingService.API.Controllers;
using CaartingService.API.Data.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartingService.API.Tests
{
    public class TestBase
    {
        public CartingController cartingController;

        public TestBase()
        {
            var loggerMock = new Mock<ILogger<CartingController>>();
            var catalogRepoMock = new Mock<ICartingRepository>();

            cartingController = new CartingController(catalogRepoMock.Object, loggerMock.Object);
        }
    }
}
