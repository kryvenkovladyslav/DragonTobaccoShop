using System;

namespace Domain.ApplicationModels
{
    public class TobaccosTastes
    {
        public virtual Guid TobaccoID { get; set; }
        public virtual Guid TasteID { get; set; }

        public virtual Tobacco Tobacco { get; set; }
        public virtual Taste Taste { get; set; }
    }
}