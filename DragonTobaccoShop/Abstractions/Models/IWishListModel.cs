namespace Abstractions.Models
{
    public interface IWishListModel<TKey> where TKey : struct
    {
        public TKey ID { get; set; }
    }
}