using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakingWavesTest.Models.DataModels
{
    public class ColorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string Pantone_Value { get; set; }
    }
}