using Microsoft.AspNetCore.Mvc;
using Shop.Models.Kindergarten;
using Shop.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Shop.Core.ServiceInterface;
using Shop.Core.Dto;
using Shop.Core.ServiceInterface.Kindergarten;

namespace Shop.Controllers
{
    public class KindergartenController : Controller
    {

        private readonly ShopContextKindergarten _context;
        private readonly IKindergartenServices _kindergartenServices;

        public KindergartenController
            (
                ShopContextKindergarten context,
                IKindergartenServices kindergartenServices
            )
        {
            _context = context;
            _kindergartenServices = kindergartenServices;
        }
    }
}
