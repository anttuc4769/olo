using Microsoft.AspNetCore.Mvc;
using olo.Models;
using olo.Services;


namespace olo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("WordWrap/{word}/{length}")]
        public WordWrapModel TestWordWrap(string word, int length)
        {
            try
            {
                return TextService.WordWrap(word, length);
            }
            catch (Exception exception)
            {
                return new WordWrapModel() { IsError = true, Msg = exception.Message };
            }
        }
    }
}
