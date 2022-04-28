using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebAppMenu.Models;

namespace WebAppMenu.Controllers
{
    public class HomeController : Controller
    {
        MenuContext db;
        public HomeController(MenuContext context)
        {
            this.db = context;
            if(db.Table_Access.Count() == 0)
            {
                Table_Access menu1 = new Table_Access { Code = "code1", MenuName = "MenuName 1", ParentId = null, Status = 0 };
                Table_Access menu2 = new Table_Access { Code = "code2", MenuName = "MenuName 2", ParentId = null, Status = 0 };
                Table_Access menu3 = new Table_Access { Code = "code3", MenuName = "MenuName 3", ParentId = null, Status = 0 };
                Table_Access menu4 = new Table_Access { Code = "code4", MenuName = "MenuName 2.1", ParentId = 2, Status = 1 };
                Table_Access menu5 = new Table_Access { Code = "code5", MenuName = "MenuName 2.2", ParentId = 2, Status = 1 };
                Table_Access menu6 = new Table_Access { Code = "code6", MenuName = "MenuName 2.3", ParentId = 2, Status = 1 };
                Table_Access menu7 = new Table_Access { Code = "code7", MenuName = "MenuName 3.1", ParentId = 3, Status = 1 };

                db.Table_Access.AddRange(menu1, menu2, menu3, menu4, menu5, menu6, menu7);
                db.SaveChanges();
            }
        }


        public IActionResult Index()
        {
            ViewBag.MenuLevel1 = db.Table_Access.ToList();
            //ViewBag.MenuLevel1 = db.Table_Access.Where(menu => menu.ParentId == null).ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.MenuLevel1 = db.Table_Access.ToList();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ChangeTable()
        {
            ViewBag.MenuLevel1 = db.Table_Access.ToList();
            return View();
        }
        public IActionResult Create()
        {
            ViewBag.MenuLevel1 = db.Table_Access.ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Table_Access element)
        {
            db.Table_Access.Add(element);
            await db.SaveChangesAsync();
            return RedirectToAction("ChangeTable");
        }
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.MenuLevel1 = db.Table_Access.ToList();
            if (id != null)
            {
                Table_Access element = await db.Table_Access.FirstOrDefaultAsync(p => p.Id == id);
                if (element != null)
                    return View(element);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Table_Access element)
        {
            db.Table_Access.Update(element);
            await db.SaveChangesAsync();
            return RedirectToAction("ChangeTable");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            ViewBag.MenuLevel1 = db.Table_Access.ToList();
            if (id != null)
            {
                Table_Access element = await db.Table_Access.FirstOrDefaultAsync(p => p.Id == id);
                if (element != null)
                    return View(element);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Table_Access element = await db.Table_Access.FirstOrDefaultAsync(p => p.Id == id);
                if (element != null)
                {
                    db.Table_Access.Remove(element);
                    await db.SaveChangesAsync();
                    return RedirectToAction("ChangeTable");
                }
            }
            return NotFound();
        }
        public async Task<IActionResult> ShowName(int? id)
        {
            ViewBag.MenuLevel1 = db.Table_Access.ToList();
            if (id != null)
            {
                Table_Access element = await db.Table_Access.FirstOrDefaultAsync(p => p.Id == id);
                if (element != null)
                    return View(element);
            }
            return NotFound();
        }
    }
}
