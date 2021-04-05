using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Articles2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] article = Console.ReadLine().Split(", ");
                Article newArticle = new Article(article[0], article[1], article[2]);
                articles.Add(newArticle);
            }
            string sortByCriteria = Console.ReadLine();
            if (sortByCriteria == "title")
            {
                foreach (var title in articles.OrderBy(x => x.Title))
                {
                    Console.WriteLine(title.ToString());
                }
            }
            else if (sortByCriteria == "content")
            {
                foreach (var title in articles.OrderBy(x => x.Content))
                {
                    Console.WriteLine(title.ToString());
                }
            }
            else
            {
                foreach (var title in articles.OrderBy(x => x.Author))
                {
                    Console.WriteLine(title.ToString());
                }
            }
        }
    }

    public class Article
    {
        public Article(string Title, string Content, string Author)
        {
            this.Title = Title;
            this.Content = Content;
            this.Author = Author;
        }
        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
