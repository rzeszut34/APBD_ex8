using APBD_ex6.DTOs;

namespace APBD_ex6.Services;

public interface IPCsService
{
    Task<IEnumerable<PCResponseDto>> GetAllPCsAsync();
    Task<PCWithComponentsResponseDto?> GetPCWithComponentsAsync(int id);
    Task<PCResponseDto> AddPCAsync(CreatePcDto dto);
    Task<PCResponseDto?> UpdatePCAsync(int id, CreatePcDto dto);
    Task<bool> DeletePCAsync(int id);
}