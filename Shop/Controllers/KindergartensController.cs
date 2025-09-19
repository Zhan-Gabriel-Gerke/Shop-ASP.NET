using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Shop.Core.Dto.Kindergarten;
using Shop.Core.ServiceInterface.Kindergarten;
using Shop.Data.Kindergarten;
using Shop.Models.Kindergarten;

namespace Shop.Controllers
{
    public class KindergartensController : Controller
    {

        private readonly KindergartenContext _context;
        private readonly IKindergartensServices _kindergartenServices;

        public KindergartensController
            (
                KindergartenContext context,
                IKindergartensServices kindergartenServices
            )
        {
            _context = context;
            _kindergartenServices = kindergartenServices;
        }

        public IActionResult Index()
        {
            var result = _context.Kindergartens
                .Select(x => new KindergartenIndexViewModel
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    ChildrenCount = x.ChildrenCount,
                    KindergartenName = x.KindergartenName,
                    TeacherName = x.TeacherName

                });
            return View(result);
        }
        [HttpGet]
        public IActionResult Create()
        {
            KindergartenCreateUpdateViewModel result = new();

            return View("CreateUpdate", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(KindergartenCreateUpdateViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                TeacherName = vm.TeacherName,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt
            };

            var result = await _kindergartenServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var kindergarten = await _kindergartenServices.DetailAsync(id);
            if (kindergarten == null)
            {
                return NotFound();
            }
            var vm = new KindergartenDeleteViewModel();

            vm.Id = kindergarten.Id;
            vm.GroupName = kindergarten.GroupName;
            vm.ChildrenCount = kindergarten.ChildrenCount;
            vm.KindergartenName = kindergarten.KindergartenName;
            vm.TeacherName = kindergarten.TeacherName;
            vm.CreatedAt = kindergarten.CreatedAt;
            vm.UpdatedAt = kindergarten.UpdatedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var deleted = await _kindergartenServices.Delete(id);

            if (deleted == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var spaceship = await _kindergartenServices.DetailAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var vm = new KindergartenCreateUpdateViewModel();

            vm.Id = spaceship.Id;
            vm.GroupName = spaceship.GroupName;
            vm.ChildrenCount = spaceship.ChildrenCount;
            vm.KindergartenName = spaceship.KindergartenName;
            vm.TeacherName = spaceship.TeacherName;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.UpdatedAt = spaceship.UpdatedAt;

            return View("CreateUpdate", vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(KindergartenDetailViewModel vm)
        {
            var dto = new KindergartenDto()
            {
                Id = vm.Id,
                GroupName = vm.GroupName,
                ChildrenCount = vm.ChildrenCount,
                KindergartenName = vm.KindergartenName,
                TeacherName = vm.TeacherName,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt
            };
            var result = await _kindergartenServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index), vm);
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var spaceship = await _kindergartenServices.DetailAsync(id);
            if (spaceship == null)
            {
                return NotFound();
            }
            var vm = new KindergartenDetailViewModel();

            vm.Id = spaceship.Id;
            vm.GroupName = spaceship.GroupName;
            vm.ChildrenCount = spaceship.ChildrenCount;
            vm.KindergartenName = spaceship.KindergartenName;
            vm.TeacherName = spaceship.TeacherName;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.UpdatedAt = spaceship.UpdatedAt;

            return View(vm);
        }
    }
}
