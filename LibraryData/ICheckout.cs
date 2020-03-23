using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface ICheckout
    {
        IEnumerable<CheckOut> GetAll();
        CheckOut Get(int id);
        void Add(CheckOut newCheckout);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);
        void PlaceHold(int assetId, int libraryCardId);
        void CheckoutItem(int id, int libraryCardId);
        void CheckInItem(int id);
        CheckOut GetLatestCheckout(int id);
        int GetNumberOfCopies(int id);
        bool IsCheckedOut(int id);

        string GetCurrentHoldMember(int id);
        string GetCurrentHoldPlaced(int id);
        string GetCurrentMember(int id);
        IEnumerable<Hold> GetCurrentHolds(int id);

        void MarkLost(int id);
        void MarkFound(int id);
    }
}
