using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class CheckedProduct : ICheckedProduct<Guid>
    {
        public Guid ID { get; set; }
    }
}