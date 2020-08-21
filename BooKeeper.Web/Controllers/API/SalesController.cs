namespace BooKeeper.Web.Controllers.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BooKeeper.Web.Data;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class SaleController : Controller
    {
        private readonly ISaleRepository saleRepository;

        public SaleController(ISaleRepository saleRepository)
        {
            this.saleRepository = saleRepository;
        }

        [HttpGet]
        public IActionResult GetSales()
        {
            return Ok(saleRepository.GetSalesAsync(User.Identity.Name));
        }
    }
}
