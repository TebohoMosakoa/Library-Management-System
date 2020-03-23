using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public class LibraryBranch
    {
        public int ID { get; set; }
        
        [Required]
        [StringLength(30, ErrorMessage =" Limit Name To 30 Characters.")]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Telephone { get; set; }
        public string Description { get; set; }
        public DateTime OpenDate { get; set; }

        public virtual IEnumerable<Member> Members { get; set; }
        public virtual IEnumerable<LibraryAsset> LibraryAssets { get; set; }
        public string ImageUrl { get; set; }
    }
}
