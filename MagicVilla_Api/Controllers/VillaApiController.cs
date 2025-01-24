using MagicVilla_Api.Models;
using MagicVilla_Api.Models.DTOS;
using MagicVilla_Api.Models.SeedData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace MagicVilla_Api.Controllers
{
    [Route("api/VillaApi")]
    [ApiController]
    public class VillaApiController : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<VillaDto> GetVilla()
        {
            return Ok(VillaList.VillaLists);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDto> GetByIdVilla(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            var villa = VillaList.VillaLists.FirstOrDefault(f => f.VillaId == id);
            if (villa == null)
            {
                return NotFound();
            }
            return Ok(villa);
        }

        [HttpPost]
        public ActionResult CreateVilla(VillaDto createVillaDto)
        {
            createVillaDto.VillaId =
                VillaList.VillaLists.OrderByDescending(f => f.VillaId).FirstOrDefault().VillaId + 1;


            return CreatedAtRoute("GetByIdVilla", new { createVillaDto.VillaId }, createVillaDto);
        }
    }
}
