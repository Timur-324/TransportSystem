using TransportServer.Models;
using TransportServer.Data; 
using Microsoft.EntityFrameworkCore;

public class TransportService
{
    private readonly AppDbContext _context;

    public TransportService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Transport>> GetAllAsync()
        => await _context.Transports.ToListAsync();

    public async Task AddAsync(Transport transport)
    {
        _context.Transports.Add(transport);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Transports.FindAsync(id);
        if (entity != null)
        {
            _context.Transports.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}