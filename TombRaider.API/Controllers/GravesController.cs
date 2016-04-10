using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using TombRaider.API.PoznanApiRepresentations;
using TombRaider.API.Providers.GraveProvider;
using TombRaider.Client.Core;

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

        // GET api/graves/5
        public JToken Get(int id)
        {            
            var graves = new List<Grave> { _graveProvider.GetGraveById(id) };
            var serializedGrave = JsonConvert.SerializeObject(graves);
            return JToken.Parse(serializedGrave);
        }

        [AcceptVerbs("GET")]
        public JToken FindGraves(int id)
        {
            throw new NotImplementedException();
        }
    }
}
