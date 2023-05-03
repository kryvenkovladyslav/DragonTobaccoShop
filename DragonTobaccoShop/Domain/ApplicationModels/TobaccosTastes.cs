using System;

namespace Domain.ApplicationModels
{
    public sealed class TobaccosTastes
    {
        public Guid TobaccoID { get; set; }
        public Guid TasteID { get; set; }

        public Tobacco Tobacco { get; set; }
        public Taste Taste { get; set; }
    }
}