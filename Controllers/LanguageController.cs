using System.Linq;
using Microsoft.AspNetCore.Mvc;
using translatorapp.DomainLayer.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        ITranslatorLogic _translatorLogic;

        public LanguageController(ITranslatorLogic translatorLogic)
        {
            _translatorLogic = translatorLogic;
        }

        // GET api/language/getlanguages
        [HttpGet]
        [Route("getlanguages")]
        public ActionResult<string> GetLanguages()
        { 
            var languages = _translatorLogic.GetLanguages();
            var entries = languages.Select(d => string.Format("\"{0}\": \"{1}\"", d.LanguageCode, string.Join(",", d.Language)));      
            var jsonEntries = "{" + string.Join(", ", entries) + "}";
            return (jsonEntries);
        }
    }
}
