﻿using Concurrency.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Concurrency.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> List()
        {
            return View(await _context.Products.ToListAsync());
        }

        public async Task<IActionResult> Update(int id)
        {
            var  product = await _context.Products.FindAsync(id);

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(List));
        }


    }
}
