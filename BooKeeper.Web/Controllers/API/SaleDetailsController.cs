namespace BooKeeper.Web.Controllers.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BooKeeper.Web.Data;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[Controller]")]
    public class SaleDetailsController : Controller
    {
        private readonly ISaleDetailRepository saleDetailRepository;

        public SaleDetailsController(ISaleDetailRepository saleDetailRepository)
        {
            this.saleDetailRepository = saleDetailRepository;
        }

        [HttpGet]
        public IActionResult GetSaleDetails()
        {
            return Ok(saleDetailRepository.GetAllWithSaleAndBooks());
        }
    }
}
