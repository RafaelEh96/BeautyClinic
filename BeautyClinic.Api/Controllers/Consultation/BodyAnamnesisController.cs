using BeautyClinic.Core.DTOs.Consultation;
using BeautyClinic.Core.Exceptions;
using BeautyClinic.Core.Interfaces.Consulation;
using Microsoft.AspNetCore.Mvc;

namespace BeautyClinic.Api.Controllers.Consultation;

[ApiController]
[Route("api/v1/[controller]")]
public class BodyAnamnesisController(IBodyAnamnesisService service) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetBodyAnamnesisById(Guid id)
    {
        try
        {
            var result = await service.GetBodyAnamnesisByIdAsync(id);
            return Ok(result);
        }
        catch (ResourceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateBodyAnamnesis(BodyAnamnesisDto dto)
    {
        if (dto is null) return BadRequest();
        var result = await service.CreateBodyAnamnesis(dto);
        return CreatedAtAction(nameof(GetBodyAnamnesisById), new { id = result.Id }, result);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateBodyAnamnesis(Guid id, BodyAnamnesisDto dto)
    {
        try
        {
            var bodyAnamnesis = await service.GetBodyAnamnesisByIdAsync(id);
            bodyAnamnesis = await service.UpdateBodyAnamnesisAsync(bodyAnamnesis);
            return Ok(bodyAnamnesis);
        }
        catch (ResourceNotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}