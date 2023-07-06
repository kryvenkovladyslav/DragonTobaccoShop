using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class ProductModel<TKey> where TKey : IEquatable<TKey>
    {
        public virtual TKey ID { get; set; }
        public virtual decimal Price { get; set; }
        public virtual bool IsAvailable { get; set; }
        public virtual int Discount { get; set; }
        public virtual string ImagePath { get; set; }
    }
}