namespace BooKeeper.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using BooKeeper.Web.Data;
    using BooKeeper.Web.Data.Entities;
    using BooKeeper.Web.Helpers;
    using Microsoft.AspNetCore.Authorization;

    [Authorize]
    public class SalesController : Controller
    {
        private readonly ISaleRepository saleRepository;
        private readonly IUserHelper userHelper;

        public SalesController(ISaleRepository saleRepository, IUserHelper userHelper)
        {
            this.saleRepository = saleRepository;
            this.userHelper = userHelper;
        }

        // GET: Sales
        public IActionResult Index()
        {
            return View(saleRepository.GetAll());
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await saleRepository.GetByIdAsync(id.Value);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // GET: Sales/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Sale sale)
        {
            if (ModelState.IsValid)
            {
                sale.User = await this.userHelper.GetUserByEmailAsync(this.User.Identity.Name);
                await saleRepository.CreateAsync(sale);
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }

        // GET: Sales/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sale = await saleRepository.GetByIdAsync(id.Value);
            if (sale == null)
            {
                return NotFound();
            }
            return View(sale);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Sale sale)
        {
            if (id != sale.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await saleRepository.UpdateAsync(sale);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await SaleExists(sale.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }

        // GET: Sales/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var sale = await saleRepository.GetByIdAsync(id.Value);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sale = await saleRepository.GetByIdAsync(id);
            await saleRepository.DeleteAsync(sale);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SaleExists(int id)
        {
            return await saleRepository.ExistAsync(id);
        }
    }
}
