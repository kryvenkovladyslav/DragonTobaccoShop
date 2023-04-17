namespace Abstractions.Models
{
    public interface IStengthModel<TKey> where TKey : struct
    {
        public TKey ID { get; set; }
        public string Kind { get; set; }
    }
}