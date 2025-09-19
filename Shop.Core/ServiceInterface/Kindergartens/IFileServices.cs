using Shop.Core.Domain.Kindergarten;
using Shop.Core.Dto.Kindergarten;
using Shop.Core.Domain.Kindergartens;

namespace Shop.Core.ServiceInterface.Kindergarten
{
    public interface IFileServices
    {
        void FilesToApi(KindergartenDto dto, Shop.Core.Domain.Kindergartens.Kindergarten kindergarten);
    }
}
