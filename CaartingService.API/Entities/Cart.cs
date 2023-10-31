namespace CaartingService.API.Entities
{
    public class Cart
    {
        public Cart()
        {
            this.CartItems = new List<Item>();
        }
        public string CartId { get; set; }
        public Item Item { get; set; }

        public List<Item> CartItems { get; set; }
    }
}
