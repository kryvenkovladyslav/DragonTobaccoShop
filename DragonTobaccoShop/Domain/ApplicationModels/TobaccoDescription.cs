using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class TobaccoDescription : IDesctiptionModel<Guid>
    {
        public virtual Guid ID { get; set; }
        public virtual string Path { get; set; }

        public virtual Guid TobaccoID { get; set; }
        public virtual Tobacco Tobacco { get; set; }
    }
}