namespace Abstractions.Models
{
    public interface IDesctiptionModel<TKey> where TKey : struct
    {
        public TKey ID { get; set; }
        public string Path { get; set; }
    }
}