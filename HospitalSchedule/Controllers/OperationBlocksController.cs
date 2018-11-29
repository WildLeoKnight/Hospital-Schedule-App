﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HospitalSchedule.Models;

namespace HospitalSchedule.Controllers
{
    [RequireHttps]
    public class OperationBlocksController : Controller
    {
        private readonly HospitalScheduleDbContext _context;

        public OperationBlocksController(HospitalScheduleDbContext context)
        {
            _context = context;
        }

        // GET: OperationBlocks
        public async Task<IActionResult> Index()
        {
            return View(await _context.OperationBlock.ToListAsync());
        }

        // GET: OperationBlocks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operationBlock = await _context.OperationBlock
                .FirstOrDefaultAsync(m => m.OperationBlockId == id);
            if (operationBlock == null)
            {
                return NotFound();
            }

            return View(operationBlock);
        }

        // GET: OperationBlocks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OperationBlocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OperationBlockId,BlockName,TypeOfShift")] OperationBlock operationBlock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(operationBlock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(operationBlock);
        }

        // GET: OperationBlocks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operationBlock = await _context.OperationBlock.FindAsync(id);
            if (operationBlock == null)
            {
                return NotFound();
            }
            return View(operationBlock);
        }

        // POST: OperationBlocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OperationBlockId,BlockName,TypeOfShift")] OperationBlock operationBlock)
        {
            if (id != operationBlock.OperationBlockId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(operationBlock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperationBlockExists(operationBlock.OperationBlockId))
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
            return View(operationBlock);
        }

        // GET: OperationBlocks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operationBlock = await _context.OperationBlock
                .FirstOrDefaultAsync(m => m.OperationBlockId == id);
            if (operationBlock == null)
            {
                return NotFound();
            }

            return View(operationBlock);
        }

        // POST: OperationBlocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operationBlock = await _context.OperationBlock.FindAsync(id);
            _context.OperationBlock.Remove(operationBlock);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OperationBlockExists(int id)
        {
            return _context.OperationBlock.Any(e => e.OperationBlockId == id);
        }
    }
}
