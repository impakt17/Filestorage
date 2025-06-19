using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileStorageApi.Models;

public class FileEntity
{
    public int Id { get; set; }

    [Required]
    public string FileName { get; set; } = string.Empty;

    [Required]
    public byte[] Content { get; set; } = Array.Empty<byte>();

    [ForeignKey("Folder")]
    public int FolderId { get; set; }

    public Folder? Folder { get; set; }
}

