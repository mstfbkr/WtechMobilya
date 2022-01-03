using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Mobilya.Api.Helpers.FilterUtility;

namespace Mobilya.Api.Helpers
{
    public class FilterParams
    {

        public string ColumnName { get; set; } = string.Empty;
        public string FilterValue { get; set; } = string.Empty;
        public FilterOptions FilterOptions { get; set; } = FilterOptions.Contains;
    }
}
