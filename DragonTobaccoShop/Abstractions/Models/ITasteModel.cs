namespace Abstractions.Models
{
    public interface ITasteModel<TKey> where TKey : struct
    {
        public TKey ID { get; set; }
        public string Name { get; set; }
    }
}