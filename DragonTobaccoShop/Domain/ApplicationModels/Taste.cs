using Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Domain.ApplicationModels
{
    public class Taste : ITasteModel<Guid>
    {
        public virtual Guid ID { get; set; }
        public virtual string Name { get; set; }

        public virtual ICollection<TobaccosTastes> Tobaccos { get; set; }
    }
}