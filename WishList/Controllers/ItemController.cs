using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public IActionResult Index()
        {
            return View("Index", _context.Items.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Create");
        }

        public IActionResult Delete(int Id)
        {
            _context.Items.Find(Id);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
