//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Articles
//{
//    class Article
//    {
//        private string title_;
//        private string content_;
//        private string author_;
//        public string Title { get => title_; set => title_ = value; }
//        public string Content { get => content_; set => content_ = value; }

//        public string Author { get => author_; set => author_ = value; }


//        public Article(string title, string content, string author)
//        {
//            this.Title = title;
//            this.Content = content;
//            this.Author = author;
//        }
//        public void Edit(string content) => this.Content = content;


//        public void ChangeAuthor(string author) => this.Author = author;


//        public void Rename(string title) => this.Title = title;


//        public override string ToString()
//        {
//            return this.Title + " - " + this.Content + ": " + this.Author;
//        }
//    }
//}
