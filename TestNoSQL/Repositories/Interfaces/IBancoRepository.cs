using Test.Models;

namespace TestNoSQL.Repositories.Interfaces;

public interface IBancoRepository
{
    Task<IEnumerable<Banco>> GetAllAsync();
    Task<Banco> GetByIdAsync(string id);
    Task AddAsync(Banco banco);
    Task UpdateAsync(string id, Banco banco);
    Task DeleteAsync(string id);
}