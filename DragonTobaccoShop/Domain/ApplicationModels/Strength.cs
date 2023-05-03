using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Strength : IStengthModel<Guid>
    {
        public Guid ID { get; set; }
        public string Kind { get; set; }
        
        public ICollection<Tobacco> Tobaccos { get; set; }
    }
}