using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Core.Domain.Kindergarten
{
    [Table("FileToApiKindergarten")]
    public class FileToApiKindergarten
    {
        public Guid Id { get; set; }
        public string? ExistingFilePath { get; set; }
        public Guid? KindergartenId { get; set; }
        
    }
}
