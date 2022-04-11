using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using olo.Services;


namespace olo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("WordWrap/{word}/{length}")]
        public List<string> TestWordWrap(string word, int length)
        {
            return TextService.WordWrap(word, length);
        }
    }
}
