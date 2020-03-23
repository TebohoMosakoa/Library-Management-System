using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models.Branch;
using LibraryData;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BranchController : Controller
    {
        private IBranch _branch;
        public BranchController(IBranch branch)
        {
            _branch = branch;
        }

        public IActionResult Index()
        {
            var branches = _branch.GetAll().Select(branch => new BranchDetailModel
            {
                id = branch.ID,
                Name = branch.Name,
                isOpen = _branch.IsBranchOpen(branch.ID),
                NumberOfAssets = _branch.GetAssets(branch.ID).Count(),
                NumberOfMembers = _branch.GetMembers(branch.ID).Count()
            });
            var model = new BranchIndexModel()
            {
                Branches = branches
            };
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var branch = _branch.Get(id);
            var model = new BranchDetailModel
            {
                id = branch.ID,
                Name = branch.Name,
                Address = branch.Address,
                Telephone = branch.Telephone,
                OpenDate = branch.OpenDate.ToString("yyyy-MM-dd"),
                NumberOfAssets = _branch.GetAssets(id).Count(),
                NumberOfMembers = _branch.GetMembers(id).Count(),
                TotalAssetValue = _branch.GetAssets(id).Sum(a=>a.Cost),
                ImageUrl = branch.ImageUrl,
                HoursOpen = _branch.GetBranchHours(id)
            };
            return View(model);
        }
    }
}