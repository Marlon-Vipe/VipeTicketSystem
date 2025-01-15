using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using VipeSystem.Models;

namespace VipeSystem.Controllers
{
    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets
                            .Include(t => t.AssignedToNavigation)// Relación con Usuarios
                            .Include(t => t.CategoryIdNavigation)  // Relación con Categorías.
                            .ToList();

            return View(tickets);
        }

        // GET: Tickets/Details/
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.Users = new SelectList(db.Users, "Id_User", "Name");
            ViewBag.Categories = new SelectList(db.Categories, "Id_Category", "Name");
            return View();
        }

        // POST: Tickets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Ticket,Title,Description,Status,Priority,CreatedBy,AssignedTo,CategoryId,CreatedAt,UpdatedAt")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                var userExists = db.Users.Any(u => u.Id_User == ticket.CreatedBy);
                if (!userExists)
                {
                    ModelState.AddModelError("CreatedBy", "El usuario creador seleccionado no existe.");
                    ViewBag.Users = new SelectList(db.Users, "Id_User", "Name");
                    ViewBag.Categories = new SelectList(db.Categories, "Id_Category", "Name");
                    return View(ticket);
                }

                ticket.CreatedAt = DateTime.Now;
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Users = new SelectList(db.Users, "Id_User", "Name");
            ViewBag.Categories = new SelectList(db.Categories, "Id_Category", "Name");
            return View(ticket);
        }
        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }

            ViewBag.Users = new SelectList(db.Users, "Id_User", "Name", ticket.CreatedBy);
            ViewBag.Categories = new SelectList(db.Categories, "Id_Category", "Name", ticket.CategoryId);

            return View(ticket);
        }

        // POST: Tickets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Ticket,Title,Description,Status,Priority,CreatedBy,AssignedTo,CategoryId")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                // Verificar si el usuario creador existe
                var userExists = db.Users.Any(u => u.Id_User == ticket.CreatedBy);
                if (!userExists)
                {
                    ModelState.AddModelError("CreatedBy", "El usuario creador seleccionado no existe.");
                    ViewBag.Users = new SelectList(db.Users, "Id_User", "Name", ticket.CreatedBy);
                    ViewBag.Categories = new SelectList(db.Categories, "Id_Category", "Name", ticket.CategoryId);
                    return View(ticket);
                }

                // Obtener el ticket original
                var originalTicket = db.Tickets.Find(ticket.Id_Ticket);

                if (originalTicket != null)
                {
                    // No modificar CreatedAt, mantener el valor original
                    ticket.CreatedAt = originalTicket.CreatedAt;

                    // Solo actualizar UpdatedAt
                    ticket.UpdatedAt = DateTime.Now;

                    // Reasignar el ticket y actualizar el estado solo para las propiedades modificadas
                    db.Entry(originalTicket).CurrentValues.SetValues(ticket);

                    // Guardar los cambios
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            ViewBag.Users = new SelectList(db.Users, "Id_User", "Name", ticket.CreatedBy);
            ViewBag.Categories = new SelectList(db.Categories, "Id_Category", "Name", ticket.CategoryId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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