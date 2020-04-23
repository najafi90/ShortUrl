using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortUrl.Entities.Models;
using ShortUrl.Services.Interfaces;

namespace ShortUrl.UrlConvertorApi.Controllers
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

        [HttpGet]
        public async Task<IActionResult> Get(string shortUrl)
        {
            var response = await Task.Run(() => _urlService.GetMainAddress(shortUrl));
            if (string.IsNullOrEmpty(response))
            {
                return NotFound();
            }
            else
            {
                await Task.Run(() => _urlService.SubmitUrlView(shortUrl));
                return Redirect(response);
            }
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<Url>> GetInfo(string shortUrl)
        {
            var response = await Task.Run(() => _urlService.GetByShortAddress(shortUrl));
            if (response == null)
            {
                return NotFound();
            }
            else
            {
                
                return response;
            }
        }


    }
}