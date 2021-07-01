using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore.DataProcessor.Dto.Export
{
    public class GenreViewModel
    {
        public int Id { get; set; }

        public string Genre { get; set; }

        public IEnumerable<GameViewModel> MyProperty { get; set; }
    }
}
