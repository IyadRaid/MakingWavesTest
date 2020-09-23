using MakingWavesTest.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingWavesTest.Service.Color
{
    public interface IColorService
    {
        List<GroupedColorsViewModel> GroupedColors(); 
    }
}
