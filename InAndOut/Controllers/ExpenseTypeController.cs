using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
    public class ExpenseTypeController : Controller
    {
        private readonly ApplicationDBContext _db;

        public ExpenseTypeController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<ExpenseType> expenseTypeList = _db.ExpenseType;
            return View(expenseTypeList);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ExpenseType expType)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseType.Add(expType);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(expType);
        }

        //GET: Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ExpenseType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //POST: Delete
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.ExpenseType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.ExpenseType.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        //GET: Update
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.ExpenseType.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        //POST: Update
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ExpenseType exp)
        {
            if (ModelState.IsValid)
            {
                _db.ExpenseType.Update(exp);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
                return View(exp);
        }
    }
}
