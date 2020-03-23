using Library.Models.Member;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    public class MemberController : Controller
    {
        public IMember _member;
        public MemberController(IMember member)
        {
            _member = member;
        }

        public IActionResult Index()
        {
            var allMembers = _member.GetAll();

            var memberModels = allMembers.Select(m => new MemberDetailModel
            {
                Id = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                LibraryCardId = m.LibraryCard.Id,
                OverdueFees = m.LibraryCard.Fees,
                HomeLibrary = m.HonmeLibraryBranch.Name

            }).ToList();
            var model = new MemberIndexModel()
            {
                Members = memberModels
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var member = _member.Get(id);
            var model = new MemberDetailModel
            {
                LastName = member.LastName,
                FirstName = member.FirstName,
                Address = member.Address,
                HomeLibrary = member.HonmeLibraryBranch.Name,
                MemberSince = member.LibraryCard.Created,
                OverdueFees = member.LibraryCard.Fees,
                LibraryCardId = member.LibraryCard.Id,
                Telephone = member.PhoneNumber,
                AssetsCheckedOut = _member.GetCheckOuts(id).ToList() ?? new List<CheckOut>(),
                CheckoutHistory = _member.GetCheckoutHistory(id),
                Holds = _member.GetHolds(id)
            };
            return View(model);
        }
    }
}
