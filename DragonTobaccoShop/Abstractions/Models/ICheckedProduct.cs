namespace Abstractions.Models
{
    public interface ICheckedProduct<TKey> where TKey : struct
    {
        public TKey ID { get; set; }
    }
}