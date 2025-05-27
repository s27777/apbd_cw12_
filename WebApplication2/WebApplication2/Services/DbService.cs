using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Services;

public class DbService
{
    private readonly MasterContext _dbContext;

    public DbService(MasterContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Trip>> GetTrips()
    {
        return await _dbContext.Trips
            .OrderByDescending(d => d.DateFrom)
            .ToListAsync();
    }
}