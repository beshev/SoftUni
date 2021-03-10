using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy.Models.Contracts
{
    interface IRemovable : IAddable
    {
        public string Remove();
    }
}
