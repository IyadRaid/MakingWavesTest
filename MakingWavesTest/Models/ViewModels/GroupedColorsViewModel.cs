using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakingWavesTest.Models.ViewModels
{
    public class GroupedColorsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public string Pantone_Value { get; set; }
        public int group { get; set; }

    }
}