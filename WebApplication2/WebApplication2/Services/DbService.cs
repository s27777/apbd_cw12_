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

    public async Task<bool> DeleteClientAsync(int idClient)
    {
        var client = await _dbContext.Clients.FindAsync(idClient);
        if (client == null)
        {
            throw new KeyNotFoundException("");
        }

        bool tripsAssigned = await _dbContext.ClientTrips.AnyAsync(trip => trip.IdClient == idClient);

        if (tripsAssigned)
        {
            throw new Exception("Client is assigned to trips");
        }

        _dbContext.Clients.Remove(client);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}