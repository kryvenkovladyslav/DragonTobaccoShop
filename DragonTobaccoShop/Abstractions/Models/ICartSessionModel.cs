namespace Abstractions.Models
{
    public interface ICartSessionModel<TKey> where TKey : struct
    {
        public TKey ID { get; set; }
    }
}