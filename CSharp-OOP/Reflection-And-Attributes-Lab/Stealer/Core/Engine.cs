using Stealer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stealer.Core
{
  public class Engine
    {
        public void Run()
        {
            Spy spy = new Spy();
            string resut = spy.CollectGettesAndSetters("Stealer.Hacker");
            Console.WriteLine(resut);
        }
    }
}
