using APBD_ex6.Data;
using APBD_ex6.DTOs;
using APBD_ex6.Entities;
using Microsoft.EntityFrameworkCore;

namespace APBD_ex6.Services;

public class PCsService : IPCsService
{
    private readonly AppDbContext _context;

    public PCsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<PCResponseDto>> GetAllPCsAsync()
    {
        return await _context.PCs
            .Select(pc => new PCResponseDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock
            })
            .ToListAsync();
    }
    
    public async Task<PCWithComponentsResponseDto?> GetPCWithComponentsAsync(int id)
    {
        return await _context.PCs
            .Where(pc => pc.Id == id)
            .Select(pc => new PCWithComponentsResponseDto
            {
                Id = pc.Id,
                Name = pc.Name,
                Weight = pc.Weight,
                Warranty = pc.Warranty,
                CreatedAt = pc.CreatedAt,
                Stock = pc.Stock,
                Components = pc.PCComponents.Select(pcc => new PCComponentDto
                {
                    Amount = pcc.Amount,
                    Component = new ComponentDto
                    {
                        Code = pcc.Component.Code,
                        Name = pcc.Component.Name,
                        Description = pcc.Component.Description,
                        Manufacturer = new ManufacturerDto
                        {
                            Id = pcc.Component.ComponentManufacturer.Id,
                            Abbreviation = pcc.Component.ComponentManufacturer.Abbreviation,
                            FullName = pcc.Component.ComponentManufacturer.FullName,
                            FoundationDate = pcc.Component.ComponentManufacturer.FoundationDate
                        },
                        Type = new TypeDto
                        {
                            Id = pcc.Component.ComponentType.Id,
                            Abbreviation = pcc.Component.ComponentType.Abbreviation,
                            Name = pcc.Component.ComponentType.Name
                        }
                    }
                }).ToList()
            })
            .FirstOrDefaultAsync();
    }
    
    public async Task<PCResponseDto> AddPCAsync(CreatePcDto dto)
    {
        var pc = new PC
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        await _context.PCs.AddAsync(pc);
        await _context.SaveChangesAsync();

        return new PCResponseDto { Id = pc.Id, Name = pc.Name, Weight = pc.Weight, Warranty = pc.Warranty, CreatedAt = pc.CreatedAt, Stock = pc.Stock };
    }

    public async Task<PCResponseDto?> UpdatePCAsync(int id, CreatePcDto dto)
    {
        var pc = await _context.PCs.FirstOrDefaultAsync(x => x.Id == id);
        if (pc == null) return null;

        // Aktualizacja właściwości
        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await _context.SaveChangesAsync();

        return new PCResponseDto { Id = pc.Id, Name = pc.Name, Weight = pc.Weight, Warranty = pc.Warranty, CreatedAt = pc.CreatedAt, Stock = pc.Stock };
    }

    public async Task<bool> DeletePCAsync(int id)
    {
        var pc = await _context.PCs.FirstOrDefaultAsync(x => x.Id == id);
        if (pc == null) return false;

        _context.PCs.Remove(pc);
        await _context.SaveChangesAsync();
        
        return true;
    }
}