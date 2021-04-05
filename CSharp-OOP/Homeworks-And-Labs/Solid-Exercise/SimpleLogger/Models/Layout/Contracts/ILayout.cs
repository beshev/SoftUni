using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleLogger.Layout.Contracts
{
    public interface ILayout
    {
        public string Format { get; }
    }
}
