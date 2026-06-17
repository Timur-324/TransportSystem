using TransportServer.Models;
using TransportServer.Data;
using Microsoft.EntityFrameworkCore;

public class DriverService
{
    private readonly AppDbContext _context;

    public DriverService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Driver>> GetAllAsync()
        => await _context.Drivers.ToListAsync();

    public async Task AddAsync(Driver driver)
    {
        _context.Drivers.Add(driver);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Drivers.FindAsync(id);
        if (entity != null)
        {
            _context.Drivers.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}