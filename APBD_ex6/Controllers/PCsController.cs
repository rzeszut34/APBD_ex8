using APBD_ex6.Services;
using APBD_ex6.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace APBD_ex6.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PCsController : ControllerBase
{
    private readonly IPCsService _pcsService;

    public PCsController(IPCsService pcsService)
    {
        _pcsService = pcsService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllPcs()
    {
        var result = await _pcsService.GetAllPCsAsync();
        return Ok(result);
    }
    
    [HttpGet("{id}/components")]
    public async Task<IActionResult> GetPCWithComponents(int id)
    {
        var result = await _pcsService.GetPCWithComponentsAsync(id);
        
        if (result == null)
        {
            return NotFound($"PC with id {id} does not exist.");
        }
        
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPC(CreatePcDto dto)
    {
        var result = await _pcsService.AddPCAsync(dto);
        return Created($"api/PCs/{result.Id}", result); 
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePC(int id, CreatePcDto dto)
    {
        var result = await _pcsService.UpdatePCAsync(id, dto);
        
        if (result == null)
            return NotFound($"PC with id {id} does not exist.");
            
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePC(int id)
    {
        var success = await _pcsService.DeletePCAsync(id);
        
        if (!success)
            return NotFound($"PC with id {id} does not exist.");
            
        return NoContent();
    }
}