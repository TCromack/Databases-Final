using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FootballFinal.Models;

namespace FootballFinal.Controllers
{
    public class V_PlayersWithStatsController : Controller
    {
        private PlayersEntities db = new PlayersEntities();

        // GET: V_PlayersWithStats
        //public ActionResult Index()
        //{
        //    return View(db.V_PlayersWithStats.ToList());
        //}
        public ActionResult Index()
        {
            List<player> players = db.players.ToList();
            List<stat> stats = db.stats.ToList();
            var joinResults = from p in players
                              join s in stats
       on p.playerId equals s.Player_playerId
                              select new V_PlayersWithStats
                              {

                                  position = p.position,
                                  fName = p.fName,
                                  lastName = p.lastName,
                                  team = p.team,
                                  pointsScored = s.pointsScored,
                                  passingTDs = s.passingTDs,
                                  passingYDs = s.passingYDs,
                                  passingINTs = s.passingINTs,
                                  rushingTDs = s.rushingTDs,
                                  rushingYDs = s.rushingYDs,
                                  receivingTDs = s.receivingTDs,
                                  receivingYDs = s.receivingYDs,
                                  receptions = s.receptions,
                                  fumblesLost = s.fumblesLost,
                                  Year = s.Year



                              };
            return View(joinResults);
        }


        // GET: V_PlayersWithStats/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_PlayersWithStats v_PlayersWithStats = db.V_PlayersWithStats.Find(id);
            if (v_PlayersWithStats == null)
            {
                return HttpNotFound();
            }
            return View(v_PlayersWithStats);
        }

        // GET: V_PlayersWithStats/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: V_PlayersWithStats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "position,lastName,fName,team,pointsScored,passingTDs,passingYDs,passingINTs,rushingTDs,rushingYDs,receivingTDs,receivingYDs,receptions,fumblesLost,gamesPlayed")] V_PlayersWithStats v_PlayersWithStats)
        {
            if (ModelState.IsValid)
            {
                db.V_PlayersWithStats.Add(v_PlayersWithStats);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(v_PlayersWithStats);
        }

        // GET: V_PlayersWithStats/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_PlayersWithStats v_PlayersWithStats = db.V_PlayersWithStats.Find(id);
            if (v_PlayersWithStats == null)
            {
                return HttpNotFound();
            }
            return View(v_PlayersWithStats);
        }

        // POST: V_PlayersWithStats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "position,lastName,fName,team,pointsScored,passingTDs,passingYDs,passingINTs,rushingTDs,rushingYDs,receivingTDs,receivingYDs,receptions,fumblesLost,gamesPlayed")] V_PlayersWithStats v_PlayersWithStats)
        {
            if (ModelState.IsValid)
            {
                db.Entry(v_PlayersWithStats).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(v_PlayersWithStats);
        }

        // GET: V_PlayersWithStats/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            V_PlayersWithStats v_PlayersWithStats = db.V_PlayersWithStats.Find(id);
            if (v_PlayersWithStats == null)
            {
                return HttpNotFound();
            }
            return View(v_PlayersWithStats);
        }

        // POST: V_PlayersWithStats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            V_PlayersWithStats v_PlayersWithStats = db.V_PlayersWithStats.Find(id);
            db.V_PlayersWithStats.Remove(v_PlayersWithStats);
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
