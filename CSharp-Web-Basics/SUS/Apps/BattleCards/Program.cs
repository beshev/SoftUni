using SUS.MvcFramework;
using System.Threading.Tasks;

namespace BattleCards
{
    public static class Program
    {
        public static async Task Main()
        {
            await Host.CreateHostAsync(new Startup());
        }
    }
}
