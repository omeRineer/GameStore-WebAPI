using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleClaimsController : ControllerBase
    {
        private readonly IUserRoleClaimService _userRoleClaimService;

        public UserRoleClaimsController(IUserRoleClaimService userRoleClaimService)
        {
            _userRoleClaimService = userRoleClaimService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userRoleClaimService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{userRoleClaimId}")]
        public IActionResult GetById(int userRoleClaimId)
        {
            var result = _userRoleClaimService.GetById(userRoleClaimId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(UserRoleClaim userRoleClaim)
        {
            var result = _userRoleClaimService.Add(userRoleClaim);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("delete/{userRoleClaimId}")]
        public IActionResult Delete(int userRoleClaimId)
        {
            var result = _userRoleClaimService.Delete(userRoleClaimId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(UserRoleClaim userRoleClaim)
        {
            var result = _userRoleClaimService.Update(userRoleClaim);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
