using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using TombRaider.API.PoznanApiRepresentations;
using TombRaider.Client.Core;

namespace TombRaider.API.Providers.GraveProvider
{
    public class MockedGraveProvider : IGraveProvider
    {
        public List<Grave> FindGraves(Grave template)
        {
            throw new NotImplementedException();
        }

        public Grave GetGraveById(int id)
        {
            string filePath = HttpContext.Current.Server.MapPath("~/Resources/MockedResponses/mocked_poznan_api_multiple_graves_response.json");
 
            var jsonString = File.ReadAllText(filePath);
            var feature = JsonConvert.DeserializeObject<PoznanApiGravesRepresentation>(jsonString).Features.First();
            var grave = Mapper.Map<Grave>(feature);

            return grave;
        }
    }
}