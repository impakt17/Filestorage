using Microsoft.AspNetCore.Mvc;
using FileStorageApi.Data;
using FileStorageApi.Models;

namespace FileStorageApi.Controllers;

[ApiController]
[Route("api/folders")]
public class FolderController : ControllerBase
{
    private readonly AppDbContext _context;

    public FolderController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFolder([FromBody] Folder folder)
    {
        _context.Folders.Add(folder);
        await _context.SaveChangesAsync();
        return Ok(folder);
    }
}
