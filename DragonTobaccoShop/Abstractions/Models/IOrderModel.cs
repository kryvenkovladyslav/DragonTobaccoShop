namespace Abstractions.Models
{
    public interface IOrderModel
    {
        public Guid ID { get; set; }
        public string Status { get; set; }
        public decimal TototalPrice { get; set; }
    }
}