using CaartingService.API.Entities;

namespace CaartingService.API.Data.Interfaces
{
    public interface ICartingRepository
    {
        Task<Cart> GetCartInfo(string cartId);
        Task AddItem(Cart cart);
        Task DeleteItem(string cartId, int itemId);
    }
}
