using Microsoft.AspNetCore.Mvc;
using Test.Models;
using TestNoSQL.Repositories.Interfaces;

namespace TestNoSQL.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BancoController: ControllerBase
{
    private readonly IBancoRepository _bancoRepository;
    
    public BancoController(IBancoRepository bancoRepository)
    {
        _bancoRepository = bancoRepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var bancos = await _bancoRepository.GetAllAsync();
        return Ok(bancos);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var banco = await _bancoRepository.GetByIdAsync(id);
        return Ok(banco);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Banco banco)
    {
        if (banco.Id != null)
        {
            banco.Id = null;
        }
        await _bancoRepository.AddAsync(banco);
        return Ok("Banco creado con exito");
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, [FromBody] Banco banco)
    {
        await _bancoRepository.UpdateAsync(id, banco);
        return Ok("Banco actualizado con exito");
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _bancoRepository.DeleteAsync(id);
        return Ok("Banco eliminado con exito");
    }
    
}