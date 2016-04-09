using Newtonsoft.Json.Linq;
using System.IO;
using System.Web;
using System.Web.Http;

namespace TombRaider.API.Controllers
{
    //[Authorize]
    public class GravesController : ApiController
    {
        // GET api/graves/5
        public JToken Get(int id)
        {            
            string filePath = HttpContext.Current.Server.MapPath("~/Resources/MockedResponses/mock_graves_response.json");
            return JObject.Parse(File.ReadAllText(filePath));
        }
    }
}
