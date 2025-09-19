using Shop.Core.Domain.Kindergartens;
using Shop.Core.Dto.Kindergarten;

namespace Shop.Core.ServiceInterface.Kindergarten
{
    public interface IKindergartensServices
    {
        Task<Shop.Core.Domain.Kindergartens.Kindergarten> Create(KindergartenDto dto);
        Task<Shop.Core.Domain.Kindergartens.Kindergarten> DetailAsync(Guid id);
        Task<Shop.Core.Domain.Kindergartens.Kindergarten> Delete(Guid id);
        Task<Shop.Core.Domain.Kindergartens.Kindergarten> Update(KindergartenDto dto);
    }
}