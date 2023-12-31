using API_Estacionamento.Data;
using API_Estacionamento.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace API_Estacionamento.Controllers;
[ApiController]
[Route("[controller]")]
public class CarroController : ControllerBase
{
    private EstacionamentoDbContext _dbContext;
    public CarroController(EstacionamentoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Carro carro)
    {
        if(_dbContext is null) return BadRequest();
        await _dbContext.AddAsync(carro);
        await _dbContext.SaveChangesAsync();
        return Created("",carro);
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Carro>>> Listar()
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Carro is null) return BadRequest();
        return await _dbContext.Carro.ToListAsync();
    }

    [HttpGet]
    [Route("buscar/{placa}")]
    public async Task<ActionResult<Carro>> Buscar(string placa)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Carro is null) return BadRequest();
        var carroTemp = await _dbContext.Carro.FindAsync(placa);
        if(carroTemp is null) return BadRequest();
        return carroTemp;
    }

    [HttpPut()]
    [Route("alterar")]
    public async Task<ActionResult> Alterar(Carro carro)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Carro is null) return BadRequest();
        var carroTemp = await _dbContext.Carro.FindAsync(carro.Placa);
        if(carroTemp is null) return BadRequest();
        carroTemp.ModeloId = carro.ModeloId;
        carroTemp.Descricao = carro.Descricao;
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

    [HttpDelete()]
    [Route("excluir/{placa}")]
    public async Task<ActionResult> Excluir(string placa)
    {
        if(_dbContext is null) return BadRequest();
        if(_dbContext.Carro is null) return BadRequest();
        var carroTemp = await _dbContext.Carro.FindAsync(placa);
        if(carroTemp is null) return BadRequest();
        _dbContext.Remove(carroTemp);
        await _dbContext.SaveChangesAsync();
        return Ok();
    }

}
