using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface IMember
    {
        Member Get(int id);
        IEnumerable<Member> GetAll();
        void Add(Member newMember);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int memberId);
        IEnumerable<Hold> GetHolds(int memberId);
        IEnumerable<CheckOut> GetCheckOuts(int memberId);
    }
}
