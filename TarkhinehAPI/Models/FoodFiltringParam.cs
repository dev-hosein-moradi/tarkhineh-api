using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TarkhinehAPI.Models
{
    public class FoodFiltringParam
    {
        public string? Reagion { get; set; }

        public string? Type { get; set; }

        public string? SortBy { get; set; }

        public FoodFiltringParam()
        {
            Reagion = "";
            Type = "";
            SortBy = "";
        }
    }
}
