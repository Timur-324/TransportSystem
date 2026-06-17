using TransportServer.Models;
using TransportServer.Data; 
using Microsoft.EntityFrameworkCore;

namespace TransportServer.Services;

public class RepairService
{
    private readonly AppDbContext _context;

    public RepairService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Repair>> GetAllAsync()
    {
        return await _context.Repairs.ToListAsync();
    }

    public async Task<Repair?> GetByIdAsync(int id)
    {
        return await _context.Repairs.FindAsync(id);
    }

    public async Task AddRepairAsync(Repair repair)
    {
        repair.Date = DateTime.UtcNow;
    
        _context.Repairs.Add(repair);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteRepairAsync(int id)
    {
        var entity = await _context.Repairs.FindAsync(id);
        if (entity != null)
        {
            _context.Repairs.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}