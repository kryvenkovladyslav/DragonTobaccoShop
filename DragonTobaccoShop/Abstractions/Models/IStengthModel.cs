using Abstractions.Common;

namespace Abstractions.Models
{
    public interface IStengthModel<TKey> where TKey : struct
    {
        public TKey ID { get; set; }
        public StrengthKind Kind { get; set; }
    }
}