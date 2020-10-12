using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IplanRio.Domain.Entities;
using IplanRio.Infrastructure.Data.Context;
using IplanRio.Application.Interfaces;
using AutoMapper;
using IplanRio.Application.DTO;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IplanRio.Web.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IShoppingAppService _shoppingAppService;

        public ShoppingController(IMapper mapper, 
            IShoppingAppService shoppingAppService)
        {
            _mapper = mapper;
            _shoppingAppService = shoppingAppService;
        }

        // GET: Shopping
        public async Task<IActionResult> Index()
        {
            var shopping = _shoppingAppService.Get();
            var shoppingDTO = _mapper.Map<List<ShoppingDTO>>(shopping);

            return View(shoppingDTO);
        }

        // GET: Shopping/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopping = _shoppingAppService.GetById(id);

            if (shopping == null)
            {
                return NotFound();
            }

            var shoppingDTO = _mapper.Map<ShoppingDTO>(shopping);

            return View(shoppingDTO);
        }

        // GET: Shopping/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shopping/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ShoppingDTO shoppingDTO)
        {
            if (ModelState.IsValid)
            {
                var shopping = _mapper.Map<Shopping>(shoppingDTO);

                _shoppingAppService.Insert(shopping);
                _shoppingAppService.Commit();

                return RedirectToAction(nameof(Index));
            }

            return View(shoppingDTO);
        }

        // GET: Shopping/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopping = _shoppingAppService.GetById(id);

            if (shopping == null)
            {
                return NotFound();
            }

            var shoppingDTO = _mapper.Map<ShoppingDTO>(shopping);

            return View(shoppingDTO);
        }

        // POST: Shopping/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ShoppingDTO shoppingDTO)
        {
            if (id != shoppingDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var shopping = _mapper.Map<Shopping>(shoppingDTO);

                    _shoppingAppService.Update(shopping);
                    _shoppingAppService.Commit();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingExists(shoppingDTO.Id))
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

            return View(shoppingDTO);
        }

        // GET: Shopping/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shopping = _shoppingAppService.GetById(id);

            if (shopping == null)
            {
                return NotFound();
            }

            var shoppingDTO = _mapper.Map<ShoppingDTO>(shopping);

            return View(shoppingDTO);
        }

        // POST: Shopping/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shopping = _shoppingAppService.GetById(id);

            _shoppingAppService.Delete(shopping);
            _shoppingAppService.Commit();

            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingExists(int id)
        {
            return _shoppingAppService.Get().Any(e => e.Id == id);
        }
    }
}
