using KarthikTechBlog.Restaurant.API.ViewModel.Create;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KarthikTechBlog.Restaurant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {

        [HttpPost("SHA256Hash")]
        public async Task<IActionResult> GetSHA256Hash([FromBody] EncodeInput model)
        {
            string requestBody = await new StreamReader(Request.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string stringToHash = model?.InputString;

            string hashedString = string.Empty;

            if (string.IsNullOrEmpty(stringToHash))
            {
                return BadRequest("This HTTP triggered function executed successfully. Pass a stringToHash in the request body to get SHA256 hash response.");
            }

            using (SHA256 hash = SHA256.Create())
            {
                var gg = Encoding.UTF8.GetBytes(stringToHash);
                var dd = hash.ComputeHash(gg);

                hashedString = Convert.ToBase64String(hash.ComputeHash(Encoding.UTF8.GetBytes(stringToHash)));
            }

            string responseMessage = $"your hashed string is => {hashedString}";


            return new OkObjectResult(responseMessage);
        }
    }
}
