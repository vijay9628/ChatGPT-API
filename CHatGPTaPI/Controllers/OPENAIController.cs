using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Completions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHatGPTaPI.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class OPENAIController : ControllerBase
    {
        [HttpPost]
        [Route("chatgpt")]
         public IActionResult GetResult(string data)
        {
            string apikey = "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";
            string resultdata = string.Empty;
            var openAI = new OpenAIAPI(apikey);
            CompletionRequest completion = new CompletionRequest();
            completion.Prompt = data;
            completion.Model = OpenAI_API.Models.Model.DavinciText;
            completion.MaxTokens = 4000;
            var result = openAI.Completions.CreateCompletionsAsync(completion);
            if(result != null)
            {
                foreach(var item in result.Result.Completions)
                {
                    resultdata = item.Text;
                }
                return Ok(resultdata);
            }
            else
            {
                return BadRequest("not found");
            }

         }

    }
}
