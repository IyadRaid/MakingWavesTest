using MakingWavesTest.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MakingWavesTest.Repository
{
    public interface IColorRepository
    {
        Task<List<ColorDto>> GetAllColorsAsync(); 
    }
}