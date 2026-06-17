using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportServer.Data;
using TransportServer.Models;
using TransportServer.Services;

[ApiController]
[Route("api/repairs")]
public class RepairsController : ControllerBase
{
    private readonly RepairService _service;

    public RepairsController(RepairService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Repair repair)
    {
        await _service.AddRepairAsync(repair);
        return CreatedAtAction(nameof(Get), new { id = repair.Id }, repair);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteRepairAsync(id);
        return NoContent();
    }
}