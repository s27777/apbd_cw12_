using WebApplication2.Models;

namespace WebApplication2.Services;

public interface IDbService
{
    Task<List<Trip>> GetTrips();
    Task<bool> DeleteClientAsync(int idClient);
}