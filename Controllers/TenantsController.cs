using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rent_A_House.BusinessLayer;
using Rent_A_House_MVC.Models;

namespace Rent_A_House_MVC.Controllers
{
    [Authorize]
    //Tenants econtroller with Authorisation.
    public class TenantsController : Controller
    {
        private readonly Rent_A_House_MVCContext _context;

        public TenantsController(Rent_A_House_MVCContext context)
        {
            _context = context;
        }

        // GET: Tenants
        //Gets all tenants using a linq query.
        public IActionResult Index()
        {
            return View( (from tenant in _context.Tenant select tenant).ToList());
        }

        // GET: Tenants/Details/5
        //Gets Tenant details using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant =  _context.Tenant
                .FirstOrDefault(m => m.Id == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // GET: Tenants/Create
        //Gets the create form .
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tenants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds  a tenant to database.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,ContactNumber")] Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tenant);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(tenant);
        }

        // GET: Tenants/Edit/5
        //Gets  a tenant for update. using a linq query.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant = (from tenants in _context.Tenant
                          where tenants.Id == id
                          select tenants).FirstOrDefault();
            if (tenant == null)
            {
                return NotFound();
            }
            return View(tenant);
        }

        // POST: Tenants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates a  tenant.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,ContactNumber")] Tenant tenant)
        {
            if (id != tenant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tenant);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TenantExists(tenant.Id))
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
            return View(tenant);
        }

        // GET: Tenants/Delete/5
        //Gets a tenant for delete uses a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tenant =  _context.Tenant
                .FirstOrDefault(m => m.Id == id);
            if (tenant == null)
            {
                return NotFound();
            }

            return View(tenant);
        }

        // POST: Tenants/Delete/5.
        //Delete the tenant uses a linq query to select the tenant
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            
            var tenant = (from tenants in _context.Tenant
                          where tenants.Id == id
                          select tenants).FirstOrDefault();
            _context.Tenant.Remove(tenant);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks for the tenant using lamda.
        private bool TenantExists(int id)
        {
            return _context.Tenant.Any(e => e.Id == id);
        }
    }
}
