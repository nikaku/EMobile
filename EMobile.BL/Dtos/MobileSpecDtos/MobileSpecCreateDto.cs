using System;
using System.Collections.Generic;
using System.Text;

namespace EMobile.BL.Dtos.MobileSpecDtos
{
    public class MobileSpecCreateDto
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public decimal Size { get; set; }
        public decimal Weight { get; set; }
        public string Resolution { get; set; }
        public string Processor { get; set; }
        public int Memory { get; set; }
        public int Ram { get; set; }
        public string OS { get; set; }
        public decimal Price { get; set; }
        public string Base64Image { get; set; }
        public string Base64Video { get; set; }
    }
}
