using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles2._0
{
    class Article
    {
        private string title_;
        private string content_;
        private string author_;
        public string Title { get => title_; set => title_ = value; }
        public string Content { get => content_; set => content_ = value; }
        public string Author { get => author_; set => author_ = value; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Program
    {
        public static void Main(string[] args)
        {

            int numOfArticles = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < numOfArticles; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string title = input[0];
                string content = input[1];
                string author = input[2];
                Article article = new Article(title, content, author);
                articles.Add(article);

            }

            string orderCriteria = Console.ReadLine();
            switch (orderCriteria)
            {
                case "title":
                    articles = articles.OrderBy(X => X.Title).ToList();
                    break;
                case "content":
                    articles = articles.OrderBy(X => X.Content).ToList();
                    break;
                case "author":
                    articles = articles.OrderBy(X => X.Author).ToList();
                    break;
            }
            Console.WriteLine(string.Join(Environment.NewLine,articles ));
        }
    }
}
