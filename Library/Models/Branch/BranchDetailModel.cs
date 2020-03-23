using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Branch
{
    public class BranchDetailModel
    {
        public int id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string OpenDate { get; set; }
        public string Telephone { get; set; }
        public bool isOpen { get; set; }
        public string Desciption { get; set; }
        public int NumberOfMembers { get; set; }
        public int NumberOfAssets { get; set; }
        public decimal TotalAssetValue { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<string> HoursOpen { get; set; }
    }
}
