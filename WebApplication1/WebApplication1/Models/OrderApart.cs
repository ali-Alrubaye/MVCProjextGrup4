using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class OrderApart
    {
        public OrderApart()
        {
            //this.o = new HashSet<o>();
        }

        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public  Guid Id { get; set; }
        public  string Name { get; set; }
        public  Guid? UserId { get; set; }
        public  DateTime? OrderDate { get; set; }
        public  DateTime? RequiredDate { get; set; }
        public  DateTime? InFlytDate { get; set; }
        public decimal Ytakvm { get; set; }
        public double Price { get; set; }
        public string OrderName { get; set; }
        public string OrderAddress { get; set; }
        public string OrderCity { get; set; }
        public string OrderRegion { get; set; }
        public string OrderPostalCode { get; set; }
        public string OrderCountry { get; set; }
        public int RowVersion { get; set; }
        public UserData UserData { get; set; }
        //public virtual ICollection<o> o { get; set; }
    }
}