namespace Abstractions.Models
{
    public interface ITaste<TKey> where TKey : struct
    {
        public TKey ID { get; set; }
        public string Name { get; set; }
    }
}