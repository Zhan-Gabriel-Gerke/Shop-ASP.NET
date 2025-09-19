using System.ComponentModel.DataAnnotations.Schema;

namespace Shop.Core.Domain.SpaceShips
{
    [Table("FileToApiSpaceShip")]
    public class FileToApiSpaceShip
    {
        public Guid Id { get; set; }
        public string? ExistingFilePath { get; set; }
        public Guid? SpaceShipId { get; set; }
        
    }
}
