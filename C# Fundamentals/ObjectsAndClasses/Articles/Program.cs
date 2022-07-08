using System;

namespace Articles
{
    class Program
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
            public void Edit(string content) => Content = content;


            public void ChangeAuthor(string author) => Author = author;


            public void Rename(string title) => Title = title;


            public override string ToString()
            {
                return $"{ Title} - {Content}: { Author}";
            }
        }
        static void Main(string[] args)
        {

            string[] inputArr = Console.ReadLine().Split(", ");


            Article article = new Article(
                inputArr[0],
                inputArr[1],
                inputArr[2]);

            int numOfCommands = int.Parse(Console.ReadLine());


            for (int i = 0; i < numOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                string mainCmd = command[0];
                string argument = command[1];
                switch (mainCmd)
                {
                    case "Edit":

                        article.Edit(argument);
                        break;

                    case "ChangeAuthor":

                        article.ChangeAuthor(argument);
                        break;

                    case "Rename":

                        article.Rename(argument);
                        break;

                }
            }
            Console.WriteLine(article);

        }
    }
}
