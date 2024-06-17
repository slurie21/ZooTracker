using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooTracker.Models.Entity
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [Required, NotNull]
        public string Street1 { get; set; }
        [AllowNull]
        public string? Street2 { get; set; }
        [Required, NotNull]
        public string City {  get; set; }
        [Required, NotNull]
        public string State { get; set; }
        public string Zip { get; set; }

        #region Navigation Properties

        #endregion
    }
}
