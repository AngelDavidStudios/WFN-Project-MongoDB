using MongoDB.Driver;
using Test.Models;
using TestNoSQL.Repositories.Interfaces;

namespace TestNoSQL.Repositories;

public class BancoRepository: IBancoRepository
{
    private readonly IMongoCollection<Banco> _BancoCollection;
    
    public BancoRepository(IMongoDatabase database)
    {
        _BancoCollection = database.GetCollection<Banco>(nameof(Banco));
    }
    
    public async Task<IEnumerable<Banco>> GetAllAsync()
    {
        return await _BancoCollection.Find(banco => true).ToListAsync();
    }
    
    public async Task<Banco> GetByIdAsync(string id)
    {
        return await _BancoCollection.Find(banco => banco.Id == id).FirstOrDefaultAsync();
    }
    
    public async Task AddAsync(Banco banco)
    {
        await _BancoCollection.InsertOneAsync(banco);
    }
    
    public async Task UpdateAsync(string id, Banco banco)
    {
        await _BancoCollection.ReplaceOneAsync(banco => banco.Id == id, banco);
    }
    
    public async Task DeleteAsync(string id)
    {
        await _BancoCollection.DeleteOneAsync(banco => banco.Id == id);
    }
}