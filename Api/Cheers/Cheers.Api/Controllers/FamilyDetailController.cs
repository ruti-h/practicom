using Microsoft.AspNetCore.Mvc;
using Cheers.Core.DTOs;
using Cheers.Core.IServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace Cheers.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FamilyDetailController : ControllerBase
    {
        private readonly IServiceFamiltDetail _familyDetailService;
        private readonly IMapper _mapper; // הוסף את ה-IMapper

        public FamilyDetailController(IServiceFamiltDetail familyDetailService, IMapper mapper) // הוסף את ה-mapper לקונסטרוקטור
        {
            _familyDetailService = familyDetailService;
            _mapper = mapper; // אתחול של ה-mapper
        }

        // GET: api/familydetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FamilyDetailDTOs>>> Get()
        {
            var familyDetails = await _familyDetailService.GetListOfFamilyDetailsAsync();
            var familyDetailsDto = _mapper.Map<IEnumerable<FamilyDetailDTOs>>(familyDetails); // מיפוי כאן
            return Ok(familyDetailsDto);
        }

        // GET api/familydetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FamilyDetailDTOs>> Get(int id)
        {
            var familyDetail = await _familyDetailService.GetFamilyDetailsByIdAsync(id);
            if (familyDetail == null)
            {
                return NotFound();
            }
            var familyDetailDto = _mapper.Map<FamilyDetailDTOs>(familyDetail); // מיפוי כאן
            return Ok(familyDetailDto);
        }

        // POST api/familydetail
        [HttpPost]
        public async Task<ActionResult<FamilyDetailDTOs>> Post([FromBody] FamilyDetailDTOs familyDetailsDto)
        {
            var addedFamilyDetail = await _familyDetailService.AddFamilyDetailsAsync(familyDetailsDto);
            return CreatedAtAction(nameof(Get), new { id = addedFamilyDetail.Id }, addedFamilyDetail);
        }

        // PUT api/familydetail/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] FamilyDetailDTOs familyDetailsDto)
        {
            var updatedFamilyDetail = await _familyDetailService.UpdateFamilyDetailsAsync(id, familyDetailsDto);
            if (updatedFamilyDetail == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/familדydetail/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deletedFamilyDetail = await _familyDetailService.DeleteFamilyDetailsAsync(id);
            if (deletedFamilyDetail == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
