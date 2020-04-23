using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.Services.Interfaces;

namespace ShortUrl.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private IUrlService _urlService;
        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(string url)
        {
            string shortUrl = await ValidShortUrlGeneratorAsync();
            var createResponse = await Task.Run(() => _urlService.CreateShortUrl(new Entities.Models.Url
            {
                MainUrlAddress = url,
                ShortAddress = shortUrl
            }));
            if (createResponse == false)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "مشکلی در سمت سرور رخ داده لطفا دوباره تلاش کنید");
            }
            return Ok(shortUrl);
        }

        private async Task<string> ValidShortUrlGeneratorAsync()
        {
            Random r = new Random();
            do
            {
                int firstNumber = r.Next(100, 9999);
                int secondNumber = r.Next(100, 9999);
                string validAddress = string.Format("{0}{1}", firstNumber, secondNumber);
                var isValidAddress = await Task.Run(() => _urlService.ShortAddressIsValid(validAddress));
                if (isValidAddress == true)
                {
                    return validAddress;
                }

            } while (true);
        }
    }
}