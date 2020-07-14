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

    public class SaleDetailsController : Controller
    {
        //TODO: Change contructor for use IRepository
        private readonly ISaleDetailRepository saleDetailRepository;

        public SaleDetailsController(ISaleDetailRepository saleDetailRepository)
        {
            this.saleDetailRepository = saleDetailRepository;
        }

        // GET: SaleDetails
        public IActionResult Index()
        {
            return View(saleDetailRepository.GetAll());
        }

        // GET: SaleDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetail = await saleDetailRepository.GetByIdAsync(id.Value);
            if (saleDetail == null)
            {
                return NotFound();
            }

            return View(saleDetail);
        }

        // GET: SaleDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SaleDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SaleDetail saleDetail)
        {
            if (ModelState.IsValid)
            {
                await this.saleDetailRepository.CreateAsync(saleDetail);
                return RedirectToAction(nameof(Index));
            }
            return View(saleDetail);
        }

        // GET: SaleDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetail = await this.saleDetailRepository.GetByIdAsync(id.Value);
            if (saleDetail == null)
            {
                return NotFound();
            }
            return View(saleDetail);
        }

        // POST: SaleDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SaleDetail saleDetail)
        {
            if (id != saleDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await this.saleDetailRepository.UpdateAsync(saleDetail);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (! await SaleDetailExists(saleDetail.Id))
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
            return View(saleDetail);
        }

        // GET: SaleDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var saleDetail = await this.saleDetailRepository.GetByIdAsync(id.Value);
            if (saleDetail == null)
            {
                return NotFound();
            }

            return View(saleDetail);
        }

        // POST: SaleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var saleDetail = await this.saleDetailRepository.GetByIdAsync(id);
            await this.saleDetailRepository.DeleteAsync(saleDetail);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> SaleDetailExists(int id)
        {
            return await saleDetailRepository.ExistAsync(id);
        }
    }
}
