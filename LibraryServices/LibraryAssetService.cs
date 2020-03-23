using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryServices
{
    public class LibraryAssetService : ILibraryAsset
    {
        private LibraryContext _context;

        public LibraryAssetService(LibraryContext context)
        {
            _context = context;
        }
        public void add(LibraryAsset newAsset)
        {
            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAsset> GetAll()
        {
            return _context.LibraryAssets.Include(asset => asset.Status).Include(asset => asset.Location);
        }

        public string GetAuthorOrDirector(int id)
        {
            var isBook = _context.LibraryAssets
                .OfType<Book>().Any(a => a.Id == id);
            var isVideo = _context.LibraryAssets
                .OfType<Video>().Any(v => v.Id == id);

            return isBook ?
                _context.Books.FirstOrDefault(book => book.Id == id).Author :
                _context.Videos.FirstOrDefault(v => v.Id == id).Director
            ?? "Unknown";
        }

        public LibraryAsset GetById(int id)
        {
            return GetAll().FirstOrDefault(asset => asset.Id == id);
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return GetById(id).Location;
        }

        public string GetDeweyIndex(int id)
        {
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books.FirstOrDefault(book => book.Id == id).DeweyIndex;
            }
            else return "";
        }

        public string GetIsbn(int id)
        {
            if (_context.Books.Any(book => book.Id == id))
            {
                return _context.Books.FirstOrDefault(book => book.Id == id).ISBN;
            }
            else return "";
        }

        public int GetIssue(int id)
        {
            if (_context.Magazines.Any(magazine => magazine.Id == id))
            {
                return _context.Magazines.FirstOrDefault(magazine => magazine.Id == id).Issue;
            }
            else if (_context.NewsPapers.Any(newsPaper => newsPaper.Id == id))
            {
                return _context.NewsPapers.FirstOrDefault(newsPaper => newsPaper.Id == id).Issue;
            }
            else return 0;
        }

        public string GetTitle(int id)
        {
            return _context.LibraryAssets.FirstOrDefault(a => a.Id == id).Title;
        }

        public string GetType(int id)
        {
            var book = _context.LibraryAssets.OfType<Book>().Where(b => b.Id == id);

            return book.Any() ? "Book" : "Video";
        }
    }
}
