using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class FormHousingData
    {
        public FormHousingData()
        {
            this.FormHousingApartmentM = new HashSet<ApartmentData>();
        }
        public Guid Id { get; set; }
        public string FormOfHousing { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ApartmentData> FormHousingApartmentM { get; set; }
    }
}
