using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TransportServer.Data;
using TransportServer.Models;
using TransportServer.Services;

[ApiController]
[Route("api/transports")]
public class TransportsController : ControllerBase
{
    private readonly TransportService _service;

    public TransportsController(TransportService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
        => Ok(await _service.GetAllAsync());

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Transport transport)
    {
        await _service.AddAsync(transport);
        return CreatedAtAction(nameof(Get), new { id = transport.Id }, transport);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}