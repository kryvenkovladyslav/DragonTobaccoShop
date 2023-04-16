namespace Abstractions.Models
{
    public interface IReviewModel
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public int Evaluation { get; set; }
    }
}