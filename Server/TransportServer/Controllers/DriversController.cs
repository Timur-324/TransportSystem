using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportServer.Data;
using TransportServer.Models;
using TransportServer.Services;

[ApiController]
[Route("api/drivers")]
public class DriversController : ControllerBase
{
    private readonly DriverService _service;

    public DriversController(DriverService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await _service.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Driver driver)
    {
        await _service.AddAsync(driver);
        return CreatedAtAction(nameof(Get), new { id = driver.Id }, driver);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}