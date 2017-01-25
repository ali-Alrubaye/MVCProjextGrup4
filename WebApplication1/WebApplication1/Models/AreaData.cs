using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class AreaData
    {

        public AreaData()
        {
            AreaApartmentM = new HashSet<ApartmentData>();
        }

        public Guid Id { get; set; }
        public string AreaName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ApartmentData> AreaApartmentM { get; set; }
    }
}
