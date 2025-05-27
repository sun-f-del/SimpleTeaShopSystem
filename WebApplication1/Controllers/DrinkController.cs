using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DrinkController : Controller
    {
        drinkshopEntities2 db = new drinkshopEntities2();
        // GET: Drink
        public ActionResult Index()
        {
            List<drinkSelete_Result> drink = db.drinkSelete("").ToList();
            return View(drink);
        }
        [HttpPost]
        // GET: Drink/Details/5
        public ActionResult Index(string id)
        {
            List<drinkSelete_Result> drink = db.drinkSelete(id).ToList();
            return View(drink);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        // GET: Drink/Create
        public ActionResult Create(drink drink)
        {
            if (drink.deinkname == "")
            {
                return View();
            }

            List<drink>  drinkselect1 = db.drinks.ToList();
            if (drinkselect1.FirstOrDefault().ToString() == "")
            {
                drink.drinkid = 1;
            }
            else
            {
                drink.drinkid = drinkselect1.Last().drinkid + 1;
            }
           
            db.drinkInsert(drink.drinkid, drink.deinkname, drink.istoppings, drink.toppingsname, drink.sugerlevel, drink.icelevel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            drink drinkselect = db.drinks.Where(m => m.drinkid == id).FirstOrDefault();
            drinkSelete_Result drinkselectoutput = new drinkSelete_Result();
            drinkselectoutput.drinkid = drinkselect.drinkid;
            drinkselectoutput.deinkname = drinkselect.deinkname;
            drinkselectoutput.istoppings = drinkselect.istoppings;
            drinkselectoutput.toppingsname = drinkselect.toppingsname;
            drinkselectoutput.sugerlevel = drinkselect.sugerlevel;
            drinkselectoutput.icelevel = drinkselect.icelevel;
            return View(drinkselectoutput);
        }
        [HttpPost]
        // GET: Drink/Edit/5
        public ActionResult Edit(drink drink)
        {
            db.drinkEdit(drink.drinkid, drink.istoppings, drink.toppingsname, drink.sugerlevel, drink.icelevel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        [HttpPost]
        // GET: Drink/Delete/5
        public ActionResult Delete(int id)
        {
            db.drinkDelete(id);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
