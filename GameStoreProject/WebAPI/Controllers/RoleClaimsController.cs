using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleClaimsController : ControllerBase
    {
        private readonly IRoleClaimService _roleClaimService;

        public RoleClaimsController(IRoleClaimService roleClaimService)
        {
            _roleClaimService = roleClaimService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _roleClaimService.GetAll();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("{roleClaimId}")]
        public IActionResult GetById(int roleClaimId)
        {
            var result = _roleClaimService.GetById(roleClaimId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add(RoleClaim roleClaim)
        {
            var result = _roleClaimService.Add(roleClaim);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("delete/{roleClaimId}")]
        public IActionResult Delete(int roleClaimId)
        {
            var result = _roleClaimService.Delete(roleClaimId);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public IActionResult Update(RoleClaim roleClaim)
        {
            var result = _roleClaimService.Update(roleClaim);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
