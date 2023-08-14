using Application.VSCoverage;
using Microsoft.AspNetCore.Mvc;
using sureApp.domain.CoverageEntity;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoverageController : ControllerBase
    {
        private readonly ICoverageServices _coverageServices;
        public CoverageController(ICoverageServices services) {
            _coverageServices = services;
        }

        [HttpPost] public async Task<IActionResult> Post([FromBody] CoverageRequest request)
        {
            //No hago validaciones a nivel de api de forma esaustiva por tiempo
            var value = new Coverage() {
                Name = request.Name, 
                Availability = request.Availability,
                MaximunCoverageValue=request.MaximunCoverageValue };
            var result =  await _coverageServices.CreateAsync(value);
            return Ok(result);
        }
    }
}
