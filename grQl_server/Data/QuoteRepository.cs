using System.Collections.Generic;
using QuoteOfTheDay.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace QuoteOfTheDay.Data
{
    public class QuoteRepository
    {
        private readonly QuoteOfTheDayDbContext _dbContext;

        // orginal avec dB public QuoteRepository(QuoteOfTheDayDbContext dbContext)       {
        // orginal avec dB     _dbContext = dbContext;
        // orginal avec dB }
        // orginal avec dB 

        private static List<Category> categories = new List<Category>
        {
            new Category(){ Id = 0, Name = "Eis" },
            new Category(){ Id = 1, Name = "Sauerkraut" },
            new Category(){ Id = 2, Name = "Apfel" },
        };

        private static List<Quote> quotes = new List<Quote>
        {
            new Quote (){Id=0, Author = "Andrea", CategoryId = 0},
            new Quote (){Id=1, Author = "Susi", CategoryId = 1},
            new Quote (){Id=2, Author = "Leon", CategoryId = 2},
        };


        public IEnumerable<Quote> GetAll()
        {
            // return _dbContext.Quotes.Include(q => q.Category);
            return quotes;
        }

        public Quote GetById(int id)
        {
            // return _dbContext.Quotes.Include( q => q.Category) .SingleOrDefault(c => c.Id == id);
            return quotes[id];
        }

        public Quote AddQuote(Quote quote)
        {
            //  _dbContext.Add<Quote>(quote);
            //  _dbContext.SaveChanges();
            //  _dbContext.Entry(quote)           .Reference(q => q.Category)         .Load();
            Random rnd = new Random();
            quote.Id = rnd.Next(10, 90000);
            quote.Author = quote.Author + "__" + quote.Id.ToString();
            quotes.Add(quote);
            return quote;
        }

        public Quote UpdateQuote(Quote quote)  // funktioniert nicht ohne DB
        {
            //    _dbContext.Attach(quote);
            //    _dbContext.Entry(quote).State = EntityState.Modified;
            //    _dbContext.SaveChanges();
            //    _dbContext  .Entry(quote)     .Reference(q => q.Category)           .Load();
            int id = quote.Id;
            quote.Author = quote.Author + "__" + id.ToString();
            quotes[id].Author = quote.Author;

            // return quote;
            return quotes[id];
        }

        public void DeleteQuote(int id) // works
        {
            //var quote = GetById(id);
            //_dbContext.Remove(quote);
            //_dbContext.SaveChanges(); 
            quotes.Remove(quotes[id]);
        }   

        public IEnumerable<Category> GetCategories()
        {
            // return _dbContext.Categories;
            return categories;
        }
    }
}
