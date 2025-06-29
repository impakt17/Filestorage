 using Microsoft.AspNetCore.Mvc;
 using FileStorageApi.Data;
 using FileStorageApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FileStorageApi.Controllers;

// [ApiController]
// [Route("api/folders")]
// public class FolderController : ControllerBase
// {
//     private readonly AppDbContext _context;

//     public FolderController(AppDbContext context)
//     {
//         _context = context;
//     }

//     [HttpPost]
//     public async Task<IActionResult> CreateFolder([FromBody] Folder folder)
//     {
//         _context.Folders.Add(folder);
//         await _context.SaveChangesAsync();
//         return Ok(folder);
//     }
// }

[ApiController]
[Route("api/[controller]")]
public class FoldersController : ControllerBase
{
    private readonly AppDbContext _context;

    public FoldersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> CreateFolder([FromBody] Folder folder)
    {
        _context.Folders.Add(folder);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetFolderById), new { id = folder.Id }, folder);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFolderById(int id)
    {
        var folder = await _context.Folders
            .Include(f => f.Files)
            .FirstOrDefaultAsync(f => f.Id == id);

        if (folder == null) return NotFound();

        return Ok(folder);
    }
}

