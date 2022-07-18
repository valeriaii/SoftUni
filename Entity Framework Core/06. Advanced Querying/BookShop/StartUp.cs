namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var context = new BookShopContext();
            // DbInitializer.ResetDatabase(db);
             string command = Console.ReadLine();
            ////2. Age Restriction

            //Console.WriteLine(GetBooksByAgeRestriction(context,command));

            ////3. Golden Books
            //Console.WriteLine(GetGoldenBooks(context));

            ////4. Golden Books
            //Console.WriteLine(GetBooksByPrice(context));

            //5. Not Released In
            //Console.WriteLine(GetBooksNotReleasedIn(context,int.Parse(command)));

            ////6. Book Titles by Category
            //Console.WriteLine(GetBooksByCategory(context, command));

            ////07. Released Before Date
            //Console.WriteLine(GetBooksReleasedBefore(context, command));

            ////08. Author Search
            //Console.WriteLine(GetAuthorNamesEndingIn(context, command));

            ////09. Book Search
            //Console.WriteLine(GetBookTitlesContaining(context, command));

            ////10. Book Search by Author
            //Console.WriteLine(GetBooksByAuthor(context, command));

            ////11. Count Books
            //Console.WriteLine(CountBooks(context,int.Parse(command)));

            ////12. Total Book Copies
            //Console.WriteLine(CountCopiesByAuthor(context));

            ////13. Profit by Category
            //Console.WriteLine(GetTotalProfitByCategory(context));

            ////14. Most Recent Books
            //Console.WriteLine(GetMostRecentBooks(context));




        }
        //2. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder result = new StringBuilder();

            AgeRestriction ageRestriction;
            bool isParsed = Enum.TryParse<AgeRestriction>(command, true, out ageRestriction);

            if (!isParsed)
            {
                return String.Empty;

            }

            string[] bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return String.Join(Environment.NewLine, bookTitles);

        }

        //3. Golden Books
        public static string GetGoldenBooks(BookShopContext context) 
        {

            var bookTitles = context.Books
                .Where(b => b.EditionType == EditionType.Gold &&
                            b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();
            return String.Join(Environment.NewLine, bookTitles);


        }

        //4. GetBooksByPrice

        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();

            var books = context.Books
                .Where(b => b.Price > 40m)
                .Select(b => new { b.Title, b.Price })
                .OrderByDescending(b => b.Price)
                .ToArray();

            foreach (var b in books)
            {
                result.AppendLine($"{b.Title} - ${b.Price:f2}");
            }

            return result.ToString().TrimEnd();
        }

        //5. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year) 
        {
            var bookTitles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            return String.Join(Environment.NewLine, bookTitles);
        }

        //6. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
           
            string[] categories = input.ToLower().Split().ToArray();

            string[] bookTitles = context.Books
                .Where(b => b.BookCategories
                    .Select(bc => bc.Category.Name.ToLower())
                    .Intersect(categories)
                    .Any())
                .Select(b => b.Title)
                .OrderBy(t => t)
                .ToArray();

            return String.Join(Environment.NewLine, bookTitles);

        }
        //07. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder result = new StringBuilder();

            DateTime givenDate = DateTime.ParseExact(date, "dd-MM-yyyy",null);


            var books = context.Books
                .Where(b => DateTime.Compare(b.ReleaseDate.Value, givenDate) < 0)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToArray();

            foreach (var b in books)
            {
                result.AppendLine($"{b.Title} - {b.EditionType} - ${b.Price:f2}");
            }

            return result.ToString().TrimEnd();
        }
        //8. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                
                .ToArray()
                .OrderBy(a => a.FullName);

            foreach (var a in authors)
            {
                result.AppendLine(a.FullName);
            }

            return result.ToString().TrimEnd();
        }
        //9. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            string[] books = context.Books
                .Where(b => b.Title.ToLower().Contains(input))
                .Select(b => b.Title)
                .OrderBy(t=>t)
                .ToArray();

            return String.Join(Environment.NewLine, books);
        }
        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder result = new StringBuilder();
            var authors = context.Authors
                .Where(a => a.LastName.StartsWith(input))
                .Select(a => new
                {
                    a.Books,
                    FullName = $"{a.FirstName} {a.LastName}"
                })
                .ToArray();

            foreach (var a in authors)
            {

                foreach (var b in a.Books.OrderBy(b=>b.BookId))
                {
                    result.AppendLine($"{b.Title} ({a.FullName})");
                }

            }

            return result.ToString().TrimEnd();
        }
        //11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
           
            return context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

        }
        //12.Total Book Copies 
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();
            var authors = context.Authors
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}",
                    NumberOfBooks = a.Books
                                     .Select(b => b.Copies)
                                     .Sum()
                })
                .OrderByDescending(a=>a.NumberOfBooks)
                .ToArray();

            foreach (var a in authors)
            {
                result.AppendLine($"{a.FullName} - {a.NumberOfBooks}");
            }

            return result.ToString().TrimEnd();
        }
        //13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();
            var profitByCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    TotalProfit = c.CategoryBooks
                                .Select(cb => cb.Book.Price * cb.Book.Copies)
                                .Sum()
                })
                 .OrderByDescending(c => c.TotalProfit)
                .ThenBy(c => c.Name)
                .ToArray();

            foreach (var c in profitByCategory)
            {
                result.AppendLine($"{c.Name} ${c.TotalProfit:f2}");
            }

            return result.ToString().TrimEnd();
        }

        //14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder result = new StringBuilder();
            var recentBooksPerCategory = context.Categories
                .Select(c => new
                {
                    c.Name,
                    RecentBooks = c.CategoryBooks
                            .Select(cb => cb.Book)
                            .OrderByDescending(b => b.ReleaseDate)
                            .Take(3)
                })
                .OrderBy(c => c.Name)
                .ToArray();

            foreach (var c in recentBooksPerCategory)
            {
                result.AppendLine($"--{c.Name}");

                foreach (var b in c.RecentBooks)
                {
                    result.AppendLine($"{b.Title} ({b.ReleaseDate.Value.Year})");
                }
            }
            return result.ToString().TrimEnd();
        }

        public static int IncreasePrices(BookShopContext context)
        {
            var books = context.Books
                .Where(b => b.ReleaseDate != null && b.ReleaseDate.Value.Year < 2010)
                .ToArray();

            foreach (var book in books)
            {
                book.Price += 5;
            }

            return context.SaveChanges();
        }
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                    .Where(b => b.Copies < 4200)
                    .ToArray();

            var removedBooks = books.Length;

            context.Books.RemoveRange(books);
            context.SaveChanges();

            return removedBooks;
        }

    }
}
