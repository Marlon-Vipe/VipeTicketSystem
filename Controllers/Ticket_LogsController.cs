﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VipeSystem.Models;

namespace VipeSystem.Controllers
{
    public class Ticket_LogsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TicketLogs
        public ActionResult Index()
        {
            return View(db.TicketLogs.ToList());
        }

        // GET: TicketLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket_Log ticketLog = db.TicketLogs.Find(id);
            if (ticketLog == null)
            {
                return HttpNotFound();
            }
            return View(ticketLog);
        }

        // GET: TicketLogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Ticket_Log,TicketId,ChangedBy,Field,OldValue,NewValue,ChangedAt")] Ticket_Log ticketLog)
        {
            if (ModelState.IsValid)
            {
                db.TicketLogs.Add(ticketLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ticketLog);
        }

        // GET: TicketLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket_Log ticketLog = db.TicketLogs.Find(id);
            if (ticketLog == null)
            {
                return HttpNotFound();
            }
            return View(ticketLog);
        }

        // POST: TicketLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Ticket_Log,TicketId,ChangedBy,Field,OldValue,NewValue,ChangedAt")] Ticket_Log ticketLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticketLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ticketLog);
        }

        // GET: TicketLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket_Log ticketLog = db.TicketLogs.Find(id);
            if (ticketLog == null)
            {
                return HttpNotFound();
            }
            return View(ticketLog);
        }

        // POST: TicketLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket_Log ticketLog = db.TicketLogs.Find(id);
            db.TicketLogs.Remove(ticketLog);
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
