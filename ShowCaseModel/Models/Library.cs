using EFCore_DBLibrary;
using EFCore_DBModels.Library;
using Microsoft.EntityFrameworkCore;
using ShowCaseModel.DataTypes.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCaseModel.Models
{
    public class Library : ILibrary
    {
        private readonly DBFactory dBFactory;
        
        public Library()
        {
            dBFactory = new DBFactory();
        }

        public Library(DbContextOptions<ShowCaseDbContext> options)
        {
            dBFactory = new DBFactory(options);
        }

        public void AddAuthor(LibraryAuthor libraryAuthor)
        {
            var database = dBFactory.GetDbContext();
            Author author = new Author { Biography = libraryAuthor.Biography, Name = libraryAuthor.Name };
            database.Authors.Add(author);
            database.SaveChanges();
            libraryAuthor.Id = author.Id;
        }

        public LibraryAuthor GetAuthor(int Id)
        {
            var database = dBFactory.GetDbContext();
            var author = database.Authors.FirstOrDefault(x => x.Id == Id);
            if (author == null)
            {
                return null;
            }
            else
            {
                return new LibraryAuthor { Biography = author.Biography, Id = author.Id, Name = author.Name };
            }
        }
    }
}
