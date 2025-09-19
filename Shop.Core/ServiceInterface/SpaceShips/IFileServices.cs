using Shop.Core.Domain.SpaceShips;
using Shop.Core.Dto.SpaceShips;

namespace Shop.Core.ServiceInterface.SpaceShips
{
    public interface IFileServices
    {
        void FilesToApi(SpaceShipDto dto, SpaceShip spaceShip);
    }
}
