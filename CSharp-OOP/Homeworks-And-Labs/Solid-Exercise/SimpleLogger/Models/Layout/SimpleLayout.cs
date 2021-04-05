using SimpleLogger.Layout.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLogger.Layout
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
