using Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpeechEntry.Controllers
{
    [Route("api/[controller]")]
    public class SilkController : Controller
    {
        [HttpPost]
        public async Task<JsonResult> Post([FromBody]byte[] audioSource, [FromQuery]string locale = "zh-cn", [FromQuery]bool withIntent = true)
        {

            await Task.Delay(0);
            return null;
        }

        [HttpGet("{id}")]
        public async Task<ResponeModel> Get(string id)
        {
            await Task.Delay(100);
            return new ResponeModel
            {
                Text = "test",
                intentions = "test01"
            };
        }
    }
}
