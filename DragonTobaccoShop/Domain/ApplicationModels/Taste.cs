using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Taste : ITasteModel<Guid>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public ICollection<TobaccosTastes> Tobaccos { get; set; }
    }
}