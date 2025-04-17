using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using URL_ShortenerApi.Data.DTOs;
using URL_ShortenerApi.Data.Services.Interfaces;

namespace URL_ShortenerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortUrlController : ControllerBase
    {
        private readonly IShortUrlService _shortUrlService;
        public ShortUrlController(IShortUrlService shortUrlService)
        {
            _shortUrlService = shortUrlService;
        }
        [HttpPost("LongToShort")]
        public async Task<IActionResult> LongToShort([FromBody]ShortenUrlRequestDTO model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new { ShortUrl = _shortUrlService.LongToShort(model.Url) });
                }
                return BadRequest(ModelState);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { Message = $"Something went wrong , {ex.Message}" });
            }
        }
        [HttpGet("ShortToLong/{shortCode}")]
        public async Task<IActionResult> ShortToLong(string shortCode)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(new { OriginalUrl = _shortUrlService.ShortToLong(shortCode) });
                }
                return BadRequest(ModelState);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Something went wrong , {ex.Message}" });
            }
        }
    }
}
