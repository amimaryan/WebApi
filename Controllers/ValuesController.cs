using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> GetDomainLogic(int id)
        {
            var instance = new translatorapp.DomainLayer.TranslatorLogic();
         
            var languages = instance.GetLanguages();

            // var entries = languages.Select(d =>
            //  string.Format("\"{0}\": {1}", d.LanguageCode, string.Join(",", d.Language)));
            
            // var jsonEntries = "langs:{" + string.Join(",", entries) + "}";

            var entries = languages.Select(d =>
             string.Format("{0}: \"{1}\"", d.LanguageCode, string.Join(",", d.Language)));
            
            var jsonEntries = "{" + string.Join(", ", entries) + "}";

          //  var jsonTest = JsonConvert.SerializeObject(languages);
            return new JsonResult(jsonEntries);
         //   return JsonConvert.SerializeObject(languages, Formatting.None, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.None, ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
           // return "value";
        }

        // GET api/values/5
        // [HttpGet("{id}")]
        // public ActionResult<string> Get(int id)
        // {
        //     // var instance = new translatorapp.DomainLayer.TranslatorLogic();
        //     // return instance.GetNumber();
        //     return "value";
        // }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
