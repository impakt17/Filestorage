// using Microsoft.EntityFrameworkCore;
// using FileStorageApi.Models;

using Microsoft.EntityFrameworkCore;
using FileStorageApi.Models;

namespace FileStorageApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Folder> Folders => Set<Folder>();
    public DbSet<FileEntity> Files => Set<FileEntity>();
}
