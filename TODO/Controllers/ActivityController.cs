using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TODO.Models;

namespace TODO.Controllers
{
    public class ActivityController : Controller
    {
        // global instance of the activity database table
        private ActivityContext db = new ActivityContext();

        // Controller for the index view
        public ActionResult Index()
        {
            return View(db.Activities.ToList());
        }

        // Controller for the details view
        public ActionResult Details(int id = 0)
        {
            Activities activities = db.Activities.Find(id);
            if (activities == null)
            {
                return HttpNotFound();
            }
            return View(activities);
        }

        // Get request for the create view
        public ActionResult Create()
        {
            return View();
        }

        // Post request for creating a new activity into the activity table
        [HttpPost]

        // Validation for the new activity
        [ValidateAntiForgeryToken]
        public ActionResult Create(Activities activities)
        {
            // determine if all form validation passed before adding to the database table
            if (ModelState.IsValid)
            {
                db.Activities.Add(activities);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // return user back to the form to correct validation errors
            return View(activities);
        }

        // Get request for the edit view by activity's id
        public ActionResult Edit(int id = 0)
        {
            Activities activities = db.Activities.Find(id);
            if (activities == null)
            {
                return HttpNotFound();
            }
            // return user back to the form to correct validation errors
            return View(activities);
        }


        // Post request for Saving a particular activity to the database table
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Activities activities)
        {
            // Check the changes against the model before writing to the database table
            if (ModelState.IsValid)
            {
                db.Entry(activities).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // return user back to the form to correct validation errors
            return View(activities);
        }

        // Get the delete view by activity ID
        public ActionResult Delete(int id = 0)
        {
            Activities activities = db.Activities.Find(id);
            // Ensure that the activity is present in the Database table
            if (activities == null)
            {
                return HttpNotFound();
            }
            
            return View(activities);
        }

        // Confirm that the user wants to delete from database table
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        // Posts the delete action and redirects user to index view
        public ActionResult DeleteConfirmed(int id)
        {
            Activities activities = db.Activities.Find(id);
            db.Activities.Remove(activities);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
