using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FileStorageApi.Data;
using FileStorageApi.Models;

namespace FileStorageApi.Controllers;

[ApiController]
[Route("api/files")]
public class FileController : ControllerBase
{
    private readonly AppDbContext _context;

    public FileController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("{folderId}")]
    public async Task<IActionResult> UploadFile(int folderId, [FromForm] IFormFile file)
    {
        var folder = await _context.Folders.FindAsync(folderId);
        if (folder == null)
            return NotFound("Folder not found.");

        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream);

        var fileEntity = new FileEntity
        {
            FileName = file.FileName,
            Content = memoryStream.ToArray(),
            FolderId = folderId
        };

        _context.Files.Add(fileEntity);
        await _context.SaveChangesAsync();

        return Ok(fileEntity);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFile(int id)
    {
        var file = await _context.Files.FindAsync(id);
        if (file == null)
            return NotFound();

        _context.Files.Remove(file);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> DownloadFile(int id)
    {
        var file = await _context.Files.FindAsync(id);
        if (file == null)
            return NotFound();

        return File(file.Content, "application/octet-stream", file.FileName);
    }
}

