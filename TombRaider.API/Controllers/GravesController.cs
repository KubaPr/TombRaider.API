using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using TombRaider.API.Core;
using TombRaider.API.PoznanApiRepresentations;
using TombRaider.API.Providers.GraveProvider;

namespace TombRaider.API.Controllers
{
    //[Authorize]
    public class GravesController : ApiController
    {
        private IGraveProvider _graveProvider;

        public GravesController(IGraveProvider graveProvider)
        {
            _graveProvider = graveProvider;
        }

        // GET api/graves/get/{id}
        public JToken Get(int id)
        {
            //Single grave is also a collection
            var gravesCollection = _graveProvider.GetGraveById(id);
            dynamic collectionWrapper = new{ graves = gravesCollection };
            var serializedGraves = JsonConvert.SerializeObject(collectionWrapper);
            return JToken.Parse(serializedGraves);
        }

        [AcceptVerbs("GET")]
        // GET api/graves/FindGraves
        public JToken FindGraves(string name = null, string surname = null)
        {
            var template = new Grave { Name = name, Surname = surname };
            var gravesCollection = _graveProvider.FindGraves(template);
            dynamic collectionWrapper = new { graves = gravesCollection };
            var serializedGraves = JsonConvert.SerializeObject(collectionWrapper);
            return JToken.Parse(serializedGraves);
        }
    }
}
