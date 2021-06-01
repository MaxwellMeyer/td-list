using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace ToDoList.Controllers
{
  [Authorize]
  public class ItemsController : Controller
  {
    private readonly ToDoListContext _db;
    private readonly UserManager<ApplicationUser> _userManager;


    public ItemsController(UserManager<ApplicationUser> userManager, ToDoListContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Items.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }
    public ActionResult Details(int id)
    {
      var thisItem = _db.Items
     .Include(item => item.JoinEntities)
     .ThenInclude(join => join.Category)
     .FirstOrDefault(item => item.ItemId == id);
      return View(thisItem);
    }

    //     public ActionResult Edit(int id)
    //     {
    //       var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    //       ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
    //       return View(thisItem);
    //     }
    //     [HttpPost]
    //     public ActionResult Edit(Item item)
    //     {
    //       _db.Entry(item).State = EntityState.Modified;
    //       _db.SaveChanges();
    //       return RedirectToAction("Index");
    //     }
    //     public ActionResult Delete(int id)
    //     {
    //       var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    //       return View(thisItem);
    //     }

    //     [HttpPost, ActionName("Delete")]
    //     public ActionResult DeleteConfirmed(int id)
    //     {
    //       var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
    //       _db.Items.Remove(thisItem);
    //       _db.SaveChanges();
    //       return RedirectToAction("Index");
    //     }
  }
}