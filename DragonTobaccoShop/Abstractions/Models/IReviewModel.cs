namespace Abstractions.Models
{
    public interface IReviewModel<TKey> where TKey : struct
    {
        public TKey ID { get; set; }
        public string Text { get; set; }
        public int Evaluation { get; set; }
    }
}