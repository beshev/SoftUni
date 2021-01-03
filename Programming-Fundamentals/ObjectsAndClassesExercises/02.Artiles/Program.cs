using System;

namespace _02.Artiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] article = Console.ReadLine().Split(", ");
            Article newArticle = new Article(article[0], article[1], article[2]);
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                if (command[0] == "Edit")
                {
                    newArticle.EditContent(command[1]);
                }
                else if (command[0] == "ChangeAuthor")
                {
                    newArticle.ChangeAuthor(command[1]);
                }
                else if (command[0] == "Rename")
                {
                    newArticle.RenameTitle(command[1]);
                }
            }
            Console.WriteLine(newArticle.ToString());
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

        public void EditContent(string currentContent)
        {
            Content = currentContent;
        }

        public void ChangeAuthor(string currentAuthor)
        {
            Author = currentAuthor;
        }

        public void RenameTitle(string currentTitle)
        {
            Title = currentTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
