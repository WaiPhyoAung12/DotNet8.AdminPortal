using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPortal.Models.DataGrid
{
    public class DataGridResponseModel<T>
    {
        public IEnumerable<T>? Datalist { get; set; }
        public List<DataGridColumns> Columns { get; set; }
    }
    public class DataGridColumns
    {
        public string? PropertyName { get; set; }
        public string? Title { get; set; }
    }
}
