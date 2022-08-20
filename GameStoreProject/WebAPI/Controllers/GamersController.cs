using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamersController : ControllerBase
    {
        private readonly IGamerService _gamerService;

        public GamersController(IGamerService gamerService)
        {
            _gamerService = gamerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _gamerService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{gamerId}")]
        public IActionResult GetById(int gamerId)
        {
            var result = _gamerService.GetById(gamerId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(Gamer gamer)
        {
            var result = _gamerService.Add(gamer);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("delete/{gamerId}")]
        public IActionResult Delete(int gamerId)
        {
            var result = _gamerService.Delete(gamerId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Gamer gamer)
        {
            var result = _gamerService.Update(gamer);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
