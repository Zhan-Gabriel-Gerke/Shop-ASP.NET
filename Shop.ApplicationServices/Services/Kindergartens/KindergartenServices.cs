using Microsoft.EntityFrameworkCore;
using Shop.Core.Dto.Kindergarten;
using Shop.Core.ServiceInterface.Kindergarten;
using Shop.Data.Kindergarten;

namespace Shop.ApplicationServices.Services.Kindergarten
{
    public class KindergartenServices : IKindergartensServices
    {
        private readonly KindergartenContext _context;

        public KindergartenServices(KindergartenContext context)
        {
            _context = context;
        }

        public async Task<Shop.Core.Domain.Kindergartens.Kindergarten> Create(KindergartenDto dto)
        {
            Shop.Core.Domain.Kindergartens.Kindergarten kindergarten = new Shop.Core.Domain.Kindergartens.Kindergarten();

            kindergarten.Id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.TeacherName = dto.TeacherName;
            kindergarten.CreatedAt = DateTime.Now;
            kindergarten.UpdatedAt = DateTime.Now;

            await _context.Kindergartens.AddAsync(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

        public async Task<Shop.Core.Domain.Kindergartens.Kindergarten> DetailAsync(Guid id)
        {
            var result = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);
            return result;
        }

        public async Task<Shop.Core.Domain.Kindergartens.Kindergarten> Delete(Guid id)
        {
            //you need to do that by yourself
            var kindergarten = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);
            _context.Kindergartens.Remove(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

        public async Task<Shop.Core.Domain.Kindergartens.Kindergarten> Update(KindergartenDto dto)
        {
            Shop.Core.Domain.Kindergartens.Kindergarten domain = new();

            domain.Id = dto.Id;
            domain.GroupName = dto.GroupName;
            domain.ChildrenCount = dto.ChildrenCount;
            domain.KindergartenName = dto.KindergartenName;
            domain.TeacherName = dto.TeacherName;
            domain.CreatedAt = dto.CreatedAt;
            domain.UpdatedAt = DateTime.Now;

            _context.Kindergartens.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
        }
    }
}