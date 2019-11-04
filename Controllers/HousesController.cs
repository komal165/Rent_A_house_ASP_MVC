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
    //House controller with authorization.
    public class HousesController : Controller
    {
        private readonly Rent_A_House_MVCContext _context;

        public HousesController(Rent_A_House_MVCContext context)
        {
            _context = context;
        }

        // GET: Houses
        //Gets all the houses using a linq query
        public IActionResult Index()
        {
            var rent_A_House_MVCContext = _context.House.Include(h => h.HouseOwner);
            return View(rent_A_House_MVCContext.ToList());
        }

        // GET: Houses/Details/5
        //Gets the details of the house using lamda.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house =  _context.House
                .Include(h => h.HouseOwner)
                .FirstOrDefault(m => m.Id == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // GET: Houses/Create
        //Gets the create house form.
        public IActionResult Create()
        {
            ViewData["HouseOwnerId"] = new SelectList(_context.Set<HouseOwner>(), "Id", "HouseOwnerRegistrationId");
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates the house 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,HouseOwnerId,HouseAddress")] House house)
        {
            if (ModelState.IsValid)
            {
                _context.Add(house);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewData["HouseOwnerId"] = new SelectList(_context.Set<HouseOwner>(), "Id", "Id", house.HouseOwnerId);
            return View(house);
        }

        // GET: Houses/Edit/5
        //Gets the query for update. uses a linq query to select the house.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = (from houses in _context.House
                         where houses.Id == id
                         select houses).FirstOrDefault();
            if (house == null)
            {
                return NotFound();
            }
            ViewData["HouseOwnerId"] = new SelectList(_context.Set<HouseOwner>(), "Id", "HouseOwnerRegistrationId", house.HouseOwnerId);
            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the linq house.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,HouseOwnerId,HouseAddress")] House house)
        {
            if (id != house.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(house);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HouseExists(house.Id))
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
            ViewData["HouseOwnerId"] = new SelectList(_context.Set<HouseOwner>(), "Id", "Id", house.HouseOwnerId);
            return View(house);
        }

        // GET: Houses/Delete/5
        //Gets the house for delete using a lamda query.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var house = _context.House
                .Include(h => h.HouseOwner)
                .FirstOrDefault(m => m.Id == id);
            if (house == null)
            {
                return NotFound();
            }

            return View(house);
        }

        // POST: Houses/Delete/5
        //Deletes the house uses a linq query to select the house.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var house = (from houses in _context.House
                         where houses.Id == id
                         select houses).FirstOrDefault();
            _context.House.Remove(house);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Checks the house owner exists.
        private bool HouseExists(int id)
        {
            return _context.House.Any(e => e.Id == id);
        }
    }
}
