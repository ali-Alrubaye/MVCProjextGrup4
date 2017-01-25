using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class SizeData
    {
        public SizeData()
        {
            SizeApartmentM = new HashSet<ApartmentData>();
        }
        [Key]
        public Guid SizeId { get; set; }
        public string SizekName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ApartmentData> SizeApartmentM { get; set; }
    }
}
