using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartingService.API.Tests
{
   
    [TestClass]
    public class CartingServiceTests : TestBase
    {
        [TestMethod]
        public async Task GetCartInfo()
        {
            var cart = await cartingController.GetCartInfo("34fdgf43232");

            Assert.IsNotNull(cart);
        }

        [TestMethod]
        public async Task GetItems()
        {
            var items = await cartingController.GetCartInfoV2("34fdgf43232");
            
            Assert.IsNotNull(items);
        }

    }
}
