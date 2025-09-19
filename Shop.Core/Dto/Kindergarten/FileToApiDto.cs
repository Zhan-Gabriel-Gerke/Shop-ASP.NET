using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Dto.Kindergarten
{
    public class FileToApiDto
    {
        public Guid? Id { get; set; }
        public string? ExistingFilePath { get; set; }
        public Guid? SpaceShipId { get; set; }
    }
}
