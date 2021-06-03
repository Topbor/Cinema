using CinemaTR3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CinemaTR3.Controllers
{
    public class AdminController : Controller
    {
        CinemaContext db = new CinemaContext();
        public ActionResult Index()
        {

            var Films = db.Films.Include(p => p.Category);
            return View(Films.ToList());
        }

        public ActionResult Film(int id)
        {
            var Film = db.Films.Include(p => p.Category).Where(x => x.Id == id);
            var Sessions = db.Sessions.Where(x => x.FilmId == id);
            ViewBag.sessions = Sessions;
            return View(Film.ToList());
        }
        [HttpGet]
        public ActionResult FilmAdd()
        {
            var Cat = db.Categories;
            ViewBag.Categories = Cat;
            return View();
        }
        [HttpPost]
        public ActionResult FilmAdd(Film film)
        {
            if (film.Cast == "" || film.Title == "" || film.Studio == "" || film.ShortDesc == "" || film.LongDesc == "" || film.Language == "" ||
                film.Img == "" || film.Director == "" || film.ChoronoHours > 23 || film.ChoronoHours < 0 || film.ChoronoMinutes > 59 || film.ChoronoMinutes < 0
                || film.StartDate < DateTime.Today || film.FinishDate < DateTime.Today)
            {
                return View("AddFilmErr");
            }
            else
            {
                db.Films.Add(film);
                db.SaveChanges();
                return View("AddFilmDone");
            }

        }
        [HttpGet]
        public ActionResult FilmEdit(int id)
        {
            var Film = db.Films.Include(p => p.Category).Where(x => x.Id == id);
            var Cat = db.Categories;
            ViewBag.Categories = Cat;
            ViewBag.Film = Film;
            return View();
        }
        [HttpPost]
        public ActionResult FilmEdit(Film film)
        {
            if (film.Cast == "" || film.Title == "" || film.Studio == "" || film.ShortDesc == "" || film.LongDesc == "" || film.Language == "" ||
                film.Img == "" || film.Director == "" || film.ChoronoHours > 23 || film.ChoronoHours < 0 || film.ChoronoMinutes > 59 || film.ChoronoMinutes < 0
                || film.StartDate < DateTime.Today || film.FinishDate < DateTime.Today)
            {
                return View("FilmEditErr");
            }
            else
            {
                var Film = db.Films.Include(p => p.Category).Where(x => x.Id == film.Id);
                foreach (var f in Film)
                {
                    f.Director = film.Director;
                    f.Cast = film.Cast;
                    f.ChoronoHours = film.ChoronoHours;
                    f.ChoronoMinutes = film.ChoronoMinutes;
                    f.FinishDate = film.FinishDate;
                    f.Img = film.Img;
                    f.Language = film.Language;
                    f.LongDesc = film.LongDesc;
                    f.ShortDesc = film.ShortDesc;
                    f.Studio = film.Studio;
                    f.Title = film.Title;
                }
                db.SaveChanges();
                return View("EditFilmDone");
            }

        }
        public ActionResult ChangeStatus(int id)
        {
            try {
                var Ord = db.Orders.Where(x => x.Id == id).FirstOrDefault();
                Ord.Status = 0;
                db.SaveChanges();
                return View();
            }
            catch{
                return View();
            }
            
        }
        public ActionResult Orders()
        {
            var Pivots = db.Pivots.Include(p => p.Order).Include(p => p.Ticket);
            var Ord = db.Orders;
            ViewBag.Pivots = Pivots;
            ViewBag.Ord = Ord;
            return View();
        }
        public ActionResult FilmDel(int id)
        {
            var Film = db.Films.Include(p => p.Category).Where(x => x.Id == id);
            foreach (var film in Film)
            {
                film.ShowStaus = 0;
            }
            db.SaveChanges();
            return View("FilmDel");
        }
        public ActionResult SessionAll()
        {
            var Sess = db.Sessions.Include(p => p.Film).Include(p => p.Hall).Where(x => x.DateTime >= DateTime.Now);
            ViewBag.Sess = Sess;
            return View();
        }

        [HttpGet]
        public ActionResult SessionAdd()
        {
            var Films = db.Films;
            ViewBag.Films = Films;
            var Halls = db.Halls;
            ViewBag.Halls = Halls;
            return View();
        }
        [HttpPost]
        public ActionResult SessionAdd(Session session, int price)
        {
            if (session.DateTime < DateTime.Now)
            {
                //return false;
                return View("AddSessErr1");
            }
            else if (session.HallId == null || session.FilmId == null)
            {
                //return false;
                return View("AddSessErr2");
            }
            else
            {
                try
                {
                    db.Sessions.Add(session);
                    db.SaveChanges();
                }
                catch
                {
                    return View("AddSessErr2");
                }
                int sesId = 0;
                var ses = db.Sessions.OrderByDescending(x => x.Id).Take(1);
                foreach (var s in ses)
                {
                    sesId = s.Id;
                }
                var places = db.Places.Where(x => x.HallId == session.HallId);
                foreach (var pl in places)
                {
                    Ticket tik = new Ticket();
                    tik.SessionId = sesId;
                    tik.PlaceId = pl.Id;
                    tik.Price = price;
                    tik.Status = 1;
                    db.Tickets.Add(tik);
                }

                db.SaveChanges();
                //return true;
                return View("AddSessDone");
            }

        }
        public ActionResult SessDel(int id)
        {
            var ses = db.Sessions.Where(x => x.Id == id);
            foreach (var s in ses)
            {
                s.ShowStatus = 0;
            }
            db.SaveChanges();
            return View();
        }
        public ActionResult Categories()
        {
            var Cat = db.Categories;
            return View(Cat.ToList());
        }
        public ActionResult Category(int id)
        {
            var Cat = db.Categories.Where(x => x.Id == id);
            var Films = db.Films.Where(x => x.CategoryId == id);
            ViewBag.films = Films;
            return View(Cat.ToList());
        }
        public ActionResult Halls()
        {
            var hall = db.Halls;
            return View(hall.ToList());
        }
        public ActionResult LogOut()
        {
            return View();
        }

        public ActionResult Hall(int id)
        {
            var Hall = db.Halls.Where(x => x.Id == id);
            var Places = db.Places.Where(x => x.HallId == id);
            ViewBag.Places = Places;
            return View(Hall.ToList());
        }
        public ActionResult Sess(int id)
        {
            var Ses = db.Sessions.Include(p => p.Film).Include(p => p.Hall).Where(x => x.Id == id);
            //var Hall = db.Halls.Where(x => x.Id == Ses.);
            var Tickets = db.Tickets.Include(p => p.Place).Where(x => x.SessionId == id);
            ViewBag.tickets = Tickets;
            return View(Ses.ToList());
        }
    }
}