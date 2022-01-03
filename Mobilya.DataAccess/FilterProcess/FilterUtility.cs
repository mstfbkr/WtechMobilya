using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobilya.Api.Helpers
{
    public class FilterUtility
    {
        public enum FilterOptions
        {
                StarsWith=1,
                EndsWith,
                Contains,
                DoesNotContain,
                IUsEmpty,
                IsNoEmpty,
                IsGreaterThan,
                IsGreaterThanEqualTo,
                IsLessThan,
                IsLessThanOrEqualTo,
                IsEqualTo,
                IsNotEqualTo
        }
    }
}
