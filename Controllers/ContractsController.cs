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
    //Contracts  contoller with Authentication
    public class ContractsController : Controller
    {
        private readonly Rent_A_House_MVCContext _context;

        public ContractsController(Rent_A_House_MVCContext context)
        {
            _context = context;
        }

        //Gets all the contrats using a lamda query
        // GET: Contracts
        public IActionResult Index()
        {
            var rent_A_House_MVCContext = _context.Contract.Include(c => c.House).Include(c => c.Tenant);
            return View(rent_A_House_MVCContext.ToList());
        }

        // GET: Contracts/Details/5
        //Gets the details of a contract .Uses a lamda query to get the contract.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract =  _context.Contract
                .Include(c => c.House)
                .Include(c => c.Tenant)
                .FirstOrDefault(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contracts/Create
        //Gets the create form for contracts.
        public IActionResult Create()
        {
            ViewData["HouseId"] = new SelectList(_context.Set<House>(), "Id", "HouseAddress");
            ViewData["TenantId"] = new SelectList(_context.Set<Tenant>(), "Id", "TenantRegistrationId");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Adds a contract 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,HouseId,TenantId,RentPerWeek")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contract);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseId"] = new SelectList(_context.Set<House>(), "Id", "Id", contract.HouseId);
            ViewData["TenantId"] = new SelectList(_context.Set<Tenant>(), "Id", "Id", contract.TenantId);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        //Gets a contract for update uses a  linq query to select the contract
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = (from contracts in _context.Contract
                            where contracts.Id == id
                            select contracts).FirstOrDefault();
            if (contract == null)
            {
                return NotFound();
            }
            ViewData["HouseId"] = new SelectList(_context.Set<House>(), "Id", "HouseAddress", contract.HouseId);
            ViewData["TenantId"] = new SelectList(_context.Set<Tenant>(), "Id", "TenantRegistrationId", contract.TenantId);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the contract.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,HouseId,TenantId,RentPerWeek")] Contract contract)
        {
            if (id != contract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.Id))
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
            ViewData["HouseId"] = new SelectList(_context.Set<House>(), "Id", "Id", contract.HouseId);
            ViewData["TenantId"] = new SelectList(_context.Set<Tenant>(), "Id", "Id", contract.TenantId);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        //Gets the contract for delete.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract =  _context.Contract
                .Include(c => c.House)
                .Include(c => c.Tenant)
                .FirstOrDefault(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracts/Delet
        //Deletes the contract uses a linq query to get the contract.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var contract = (from contracts in _context.Contract
                            where contracts.Id == id
                            select contracts).FirstOrDefault();
            _context.Contract.Remove(contract);
           _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        //Checks the contract exists using lamda.

        private bool ContractExists(int id)
        {
            return _context.Contract.Any(e => e.Id == id);
        }
    }
}
