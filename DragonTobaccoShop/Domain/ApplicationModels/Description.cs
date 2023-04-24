using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class Description : IDesctiptionModel<Guid>
    {
        public Guid ID { get; set; }
        public string Path { get; set; }
    }
}