using System;
using System.Reflection;
using System.Text;
using System.Linq;

using SimpleConsoleSnake.Core;
using SimpleConsoleSnake.GameObjects;
using SimpleConsoleSnake.GameObjects.Levels;

namespace SimpleConsoleSnake
{
    class StartUp
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.CursorVisible = false;
            Console.SetBufferSize(60, 19);
            Console.SetCursorPosition(18, 7);
            Console.WriteLine("Select level difficulty");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("Press (E for Easy), (M for Meduim) or (H for Hard)");

            string levelChar = ChooseLevel();

            Type levelType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(Level).IsAssignableFrom(t) && typeof(Level) != t)
                .FirstOrDefault(t => t.Name.StartsWith(levelChar));

            Console.Clear();
            Level level = Activator.CreateInstance(levelType) as Level;


            Engine engine = new Engine(new Snake(2, 1, level));
            engine.Run();
        }

        private static string ChooseLevel()
        {
            string levelChar = string.Empty;
            ConsoleKeyInfo userInput = Console.ReadKey();
            if (userInput.KeyChar == 'e')
            {
                levelChar = "Easy";
            }
            else if (userInput.KeyChar == 'm')
            {
                levelChar = "Medium";
            }
            else if(userInput.KeyChar == 'h')
            {
                levelChar = "Hard";
            }

            return levelChar;
        }
    }
}
