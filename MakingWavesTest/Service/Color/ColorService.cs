using MakingWavesTest.Models.DataModels;
using MakingWavesTest.Models.ViewModels;
using MakingWavesTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MakingWavesTest.Service.Color
{
    public class ColorService : IColorService
    {
        private readonly IColorRepository _colorRepository;

        public ColorService(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public List<GroupedColorsViewModel> GroupedColors()
        {
            List<GroupedColorsViewModel> colorsGrouped = new List<GroupedColorsViewModel>();

            try
            {
                var colors = _colorRepository.GetAllColorsAsync().Result;
                if (colors == null || colors.Count == 0)
                    return null;
                colors.ForEach(c =>
                {
                    int indexToTake = c.Pantone_Value.IndexOf('-');
                    var pantomeToDivisible = new string(c.Pantone_Value.Take(indexToTake).ToArray());

                    int.TryParse(pantomeToDivisible.ToString(), out int pantoneValueToDivisible);

                    if (pantoneValueToDivisible % 3 == 0)
                        colorsGrouped.Add(MapColorValues(c, 1));
                    else if (pantoneValueToDivisible % 2 == 0)
                        colorsGrouped.Add(MapColorValues(c, 2));
                    else
                        colorsGrouped.Add(MapColorValues(c, 3));
                });
                return colorsGrouped;
            }
            catch(Exception e)
            {
                return null; 
            }



            
        }

        public GroupedColorsViewModel MapColorValues(ColorDto colorDto, int group)
        {
            var color = new GroupedColorsViewModel
            {
                Color = colorDto.Color,
                group = group,
                Id = colorDto.Id,
                Name = colorDto.Name,
                Pantone_Value = colorDto.Pantone_Value,
                Year = colorDto.Year
            };

            return color;
        }
    }
}