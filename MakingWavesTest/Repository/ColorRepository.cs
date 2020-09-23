using MakingWavesTest.Models.DataModels;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;

namespace MakingWavesTest.Repository
{
    public class ColorRepository : IColorRepository
    {
        public async Task<List<ColorDto>> GetAllColorsAsync()
        {
            List<ColorDto> colors = new List<ColorDto>();

            var baseUrl = System.Configuration.ConfigurationManager.AppSettings["ColorApi"];
            var pageSize = 10;
            var page = 1;
            bool dataHasValues = true;

            while (dataHasValues)
            {

                HttpClient client = new HttpClient();

                try
                {
                    var response = client.GetAsync(baseUrl + "per_page=" + pageSize + "&page=" + page)
                                       .ConfigureAwait(false).GetAwaiter().GetResult();
                    
                    page++;
                    var conteent = await response.Content.ReadAsStringAsync();
                    
                    JObject jsconContent = JObject.Parse(conteent);

                    if (jsconContent["data"].HasValues == false)
                        dataHasValues = false;
                    else
                    {
                        var data = from p in jsconContent["data"]
                                   select p;

                        data.ForEach(c =>
                        {
                            var color = new ColorDto()
                            {
                                Id = (int)c["id"],
                                Color = (string)c["color"],
                                Name = (string)c["name"],
                                Pantone_Value = (string) c["pantone_value"],
                                Year = (int)c["year"]
                            };
                            colors.Add(color);
                        });

                    }
                }
                catch (Exception e)
                {
                    return null; 
                }
                finally
                {
                    client.Dispose();
                }


            }

            return colors;

        }
    }
}