using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryServices
{
    public class MemberService : IMember
    {
        private LibraryContext _context;
        public MemberService(LibraryContext context)
        {
            _context = context;
        }
        public void Add(Member newMember)
        {
            _context.Add(newMember);
            _context.SaveChanges();
        }

        public Member Get(int id)
        {
            return GetAll().FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Member> GetAll()
        {
            return _context.Members
                .Include(m => m.LibraryCard)
                .Include(m => m.HonmeLibraryBranch);
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int memberId)
        {
            var cardId = Get(memberId).LibraryCard.Id;

            return _context.CheckoutHistories
                .Include(c => c.LibraryCard)
                .Include(c => c.LibraryAsset)
                .Where(c => c.LibraryCard.Id == cardId)
                .OrderByDescending(c => c.CheckedOut);
        }

        public IEnumerable<CheckOut> GetCheckOuts(int memberId)
        {
            var cardId = Get(memberId).LibraryCard.Id;

            return _context.CheckOuts
                .Include(c => c.LibraryCard)
                .Include(c => c.LibraryAsset)
                .Where(c => c.LibraryCard.Id == cardId);
        }

        public IEnumerable<Hold> GetHolds(int memberId)
        {
            var cardId = Get(memberId).LibraryCard.Id;

            return _context.Holds
                .Include(c => c.LibraryCard)
                .Include(c => c.LibraryAsset)
                .Where(c => c.LibraryCard.Id == cardId)
                .OrderByDescending(c => c.HoldPlaced); ;
        }
    }
}
