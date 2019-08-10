using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        // GET api/language/getlanguages
        [HttpGet]
        [Route("getlanguages")]
        public ActionResult<string> GetLanguages()
        { 
            //TO-DO: Add Unity Container for Loosely Coupled Code.
            var instance = new translatorapp.DomainLayer.TranslatorLogic();
            var languages = instance.GetLanguages();
            //TO-DO: Add Unity Container for Loosely Coupled Code.

            var entries = languages.Select(d => string.Format("\"{0}\": \"{1}\"", d.LanguageCode, string.Join(",", d.Language)));      
            var jsonEntries = "{" + string.Join(", ", entries) + "}";
            return (jsonEntries);
        }
    }
}
