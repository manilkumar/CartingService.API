using CaartingService.API.Data.Interfaces;
using CaartingService.API.Entities;
using CaartingService.API.Models;
using Microsoft.EntityFrameworkCore;

namespace CaartingService.API.Data.Repositories
{
    public class CartingRepository : ICartingRepository
    {
        public CartingDBContext _context;

        public CartingRepository(CartingDBContext context)
        {
            _context = context;
        }

        public async Task<Cart> GetCartInfo(string cartId)
        {
            var items = await _context.Items.Where(i => i.CartId == cartId).ToListAsync();

            return new Cart() { CartId = cartId, CartItems = items };
        }
        public async Task AddItem(Cart cart)
        {
            cart.Item.CartId = cart.CartId;
            await _context.Items.AddAsync(cart.Item);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteItem(string cartId, int itemId)
        {
            var item = await _context.Items.Where(i => i.CartId == cartId && i.Id == itemId).FirstOrDefaultAsync();

            if (item != null)
            {
                _context.Items.Remove(item);
            }
        }

    }
}
