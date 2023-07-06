using System;

namespace WebAPI.Models.DataTransferObjects.Manufacturer
{
    public sealed class ManufacturerDTO<TKey> where TKey : IEquatable<TKey>
    {
        public TKey ID { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}