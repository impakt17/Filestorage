using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FileStorageApi.Models;

public class Folder
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public List<FileEntity> Files { get; set; } = new();
}
