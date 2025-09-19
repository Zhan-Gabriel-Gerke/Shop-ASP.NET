using Shop.Core.Domain.SpaceShips;
using Shop.Core.Dto.Kindergarten;
using Shop.Core.Dto.SpaceShips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.ServiceInterface.SpaceShips
{
    public interface IFileServices
    {
        void FilesToApi(SpaceShipDto dto, SpaceShip spaceShip);
    }
}
