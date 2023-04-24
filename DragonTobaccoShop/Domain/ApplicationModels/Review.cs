using Abstractions.Models;
using System;

namespace Domain.ApplicationModels
{
    public class Review : IReviewModel<Guid>
    {
        public Guid ID { get; set; }
        public string Text { get; set; }
        public int Evaluation { get; set; }
    }
}