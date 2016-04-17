using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TombRaider.API.PoznanApiRepresentations;
using TombRaider.API.Core;

namespace TombRaider.API.Providers.GraveProvider
{
    public class MockedGraveProvider : IGraveProvider
    {
        private readonly string filePath = HttpContext.Current.Server.MapPath("~/Resources/MockedResponses/mocked_poznan_api_multiple_graves_response.json");

        public List<Grave> FindGraves(Grave template)
        {
            var graves = new List<Grave>();

            GetFeaturesFromFile().ForEach(f => graves.Add(Mapper.Map<Grave>(f)));
     
            return graves;
        }

        public Grave GetGraveById(int id)
        {
            var feature = GetFeaturesFromFile().First();

            return Mapper.Map<Grave>(feature);
        }

        private List<Feature> GetFeaturesFromFile()
        {
            var jsonString = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<PoznanApiResponseRepresentation>(jsonString).Features;
        }
    }
}