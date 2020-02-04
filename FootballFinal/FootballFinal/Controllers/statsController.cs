using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FootballFinal.Models
{
    public class statsController : Controller
    {
        private PlayersEntities db = new PlayersEntities();

        // GET: stats
        public ActionResult Index()
        {
            var stats = db.stats.Include(s => s.player);
            return View(stats.ToList());
        }

        // GET: stats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stat stat = db.stats.Find(id);
            if (stat == null)
            {
                return HttpNotFound();
            }
            return View(stat);
        }

        // GET: stats/Create
        public ActionResult Create()
        {
            ViewBag.Player_playerId = new SelectList(db.players, "playerId", "fName");
            return View();
        }

        // POST: stats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "pointsScored,gamesPlayed,Player_playerId,rushingTDs,rushingYDs,fumblesLost,receptions,receivingTDs,receivingYDs,passingYDs,passingINTs,passingTDs,Year,Week,statsID")] stat stat)
        {
            if (ModelState.IsValid)
            {
                db.stats.Add(stat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Player_playerId = new SelectList(db.players, "playerId", "fName", stat.Player_playerId);
            return View(stat);
        }

        // GET: stats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stat stat = db.stats.Find(id);
            if (stat == null)
            {
                return HttpNotFound();
            }
            ViewBag.Player_playerId = new SelectList(db.players, "playerId", "fName", stat.Player_playerId);
            return View(stat);
        }

        // POST: stats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "pointsScored,gamesPlayed,Player_playerId,rushingTDs,rushingYDs,fumblesLost,receptions,receivingTDs,receivingYDs,passingYDs,passingINTs,passingTDs,Year,Week,statsID")] stat stat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Player_playerId = new SelectList(db.players, "playerId", "fName", stat.Player_playerId);
            return View(stat);
        }

        // GET: stats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            stat stat = db.stats.Find(id);
            if (stat == null)
            {
                return HttpNotFound();
            }
            return View(stat);
        }

        // POST: stats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            stat stat = db.stats.Find(id);
            db.stats.Remove(stat);
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
