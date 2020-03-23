using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryServices
{
    public class BranchService : IBranch
    {
        private LibraryContext _context;
        public BranchService(LibraryContext context)
        {
            _context = context;
        }
        public void Add(LibraryBranch newBranch)
        {
            _context.Add(newBranch);
            _context.SaveChanges();
        }

        public LibraryBranch Get(int branchId)
        {
            return GetAll().FirstOrDefault(b => b.ID == branchId);
        }

        public IEnumerable<LibraryBranch> GetAll()
        {
            return _context.LibraryBranches
                .Include(b => b.Members)
                .Include(b => b.LibraryAssets);
        }

        public IEnumerable<LibraryAsset> GetAssets(int branchId)
        {
            return _context.LibraryBranches
                .Include(b => b.LibraryAssets)
                .FirstOrDefault(b => b.ID == branchId)
                .LibraryAssets;
        }

        public IEnumerable<string> GetBranchHours(int branchId)
        {
            var hours = _context.BranchHours.Where(h => h.Branch.ID == branchId);

            return DataHelpers.HumanizeBusinessHours(hours);
        }

        public IEnumerable<Member> GetMembers(int branchId)
        {
            return _context.LibraryBranches
                .Include(b => b.Members)
                .FirstOrDefault(b => b.ID == branchId)
                .Members;
        }

        public bool IsBranchOpen(int branchId)
        {
            return true;
        }
    }
}
