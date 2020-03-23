using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
    public class NewsPaper : LibraryAsset
    {
        [Required]
        public int Issue { get; set; }
    }
}
