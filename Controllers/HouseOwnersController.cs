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
    //House owner controller with authorization.
    [Authorize]
    public class HouseOwnersController : Controller
    {
        private readonly Rent_A_House_MVCContext _context;

        public HouseOwnersController(Rent_A_House_MVCContext context)
        {
            _context = context;
        }

        // GET: HouseOwners
        //Get all house owners using a linq query
        public IActionResult Index()
        {
            return View((from houseOwners in _context.HouseOwner
                        select houseOwners).ToList());
        }

        // GET: HouseOwners/Details/5
        //Gets the details of a house owner using a lamda query.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseOwner = _context.HouseOwner
                .FirstOrDefault(m => m.Id == id);
            if (houseOwner == null)
            {
                return NotFound();
            }

            return View(houseOwner);
        }

        // GET: HouseOwners/Create
        //Gets the form for create House owner.
        public IActionResult Create()
        {
            return View();
        }

        // POST: HouseOwners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Adds a house owner.
        public IActionResult Create([Bind("Id,Name,ContactNumber")] HouseOwner houseOwner)
        {
            if (ModelState.IsValid)
            {
                _context.Add(houseOwner);
                 _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(houseOwner);
        }

        // GET: HouseOwners/Edit/5
        //Gets the house owner for update uses a linq query to select the house owner.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseOwner = (from houseOwners in _context.HouseOwner
                              where houseOwners.Id == id
                              select houseOwners).FirstOrDefault();
            if (houseOwner == null)
            {
                return NotFound();
            }
            return View(houseOwner);
        }

        // POST: HouseOwners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the house owner.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,ContactNumber")] HouseOwner houseOwner)
        {
            if (id != houseOwner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(houseOwner);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseOwnerExists(houseOwner.Id))
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
            return View(houseOwner);
        }

        // GET: HouseOwners/Delete/5
        //Gets the house owner for delete uses a lamda query for delete.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var houseOwner =  _context.HouseOwner
                .FirstOrDefault(m => m.Id == id);
            if (houseOwner == null)
            {
                return NotFound();
            }

            return View(houseOwner);
        }

        // POST: HouseOwners/Delete/5
        //Delete the house owner uses a linq query to select the house owner.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var houseOwner = (from houseOwners in _context.HouseOwner
                              where houseOwners.Id == id
                              select houseOwners).FirstOrDefault();
            _context.HouseOwner.Remove(houseOwner);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the existance of house owner using a lamda
        private bool HouseOwnerExists(int id)
        {
            return _context.HouseOwner.Any(e => e.Id == id);
        }
    }
}
