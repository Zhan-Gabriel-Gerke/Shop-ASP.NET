using Microsoft.AspNetCore.Mvc;
using Shop.Models.Kindergarten;
using Shop.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Shop.Core.ServiceInterface;
using Shop.Core.Dto;

namespace Shop.Controllers
{
    public class KindergartenController : Controller
    {

        private readonly ShopContextKindergarten _context;
        private readonly IKindergartenServices _kindergartenServices;

    }
}
