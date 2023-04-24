using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class Strength : IStengthModel<Guid>
    {
        public Guid ID { get; set; }
        public string Kind { get; set; }
    }
}