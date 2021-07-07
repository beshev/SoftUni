using System;
using System.Collections.Generic;
using System.Text;

namespace SoftJail.DataProcessor.ImportDto
{
    public class DepartmentDto
    {
        public string Name { get; set; }

        public ICollection<CellDto> Cells { get; set; }
    }
}
