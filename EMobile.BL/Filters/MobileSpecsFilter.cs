using System;
using System.Collections.Generic;
using System.Text;

namespace EMobile.BL.Filters
{
    public class MobileSpecsFilter
    {
        public MobileSpecsFilter()
        {
            PageSize = 50;
        }
        public decimal? FromPrice{ get; set; }
        public decimal? ToPrice { get; set; }
        public string? Model { get; set; }
        public string? Company { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
