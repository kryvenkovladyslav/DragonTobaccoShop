using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class Taste : ITasteModel<Guid>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}