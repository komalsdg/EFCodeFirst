using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst.Data;
using EFCodeFirst.Models;

namespace EFCodeFirst.Controllers
{
    public class ProjectController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: Project
        public ActionResult Index()
        {
            var projects = db.Projects.Include(p => p.Client);
            return View(projects.ToList());
        }
        
        // GET: Project/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName");
            return View();
        }

        // POST: Project/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectID,ClientID,ProjectName,ProjectDescription,ProjectType,ProjectTypes")] Project project)
        {
            project.ProjectType = project.projectTypes.ToString();

            if (ModelState.IsValid)
            {
                db.Projects.Add(project);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", project.ClientID);
            return View(project);
        }

        // GET: Project/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", project.ClientID);
            project.projectTypes = (ProjectTypes)Enum.Parse(typeof(ProjectTypes), project.ProjectType);
            return View(project);
        }

        // POST: Project/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectID,ClientID,ProjectName,ProjectDescription,ProjectType,ProjectTypes")] Project project)
        {
            project.ProjectType = project.projectTypes.ToString();

            if (ModelState.IsValid)
            {
                db.Entry(project).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.Clients, "ClientID", "ClientName", project.ClientID);
            return View(project);
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return RedirectToAction("Index");
            }
            db.Projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}