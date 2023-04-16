namespace Abstractions.Models
{
    public interface ITobaccoModel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Leaf { get; set; }
        public string Package { get; set; }
        public string Slicing { get; set; }
        public string Country { get; set; }
        public bool IsSmoky { get; set; }
        public bool IsMixed { get; set; }
        public bool IsMint { get; set; }
        public bool IsSweet { get; set; }
        public bool IsIced { get; set; }
    }
}