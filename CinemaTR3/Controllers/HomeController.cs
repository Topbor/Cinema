using CinemaTR3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace CinemaTR3.Controllers
{
    public class HomeController : Controller
    {
        CinemaContext db = new CinemaContext();
        public ActionResult Index()
        {
            TempData.Keep();
            var Films = db.Films.Include(p => p.Category);
            return View(Films.ToList());
        }
        public ActionResult Film(int id)
        {
            TempData.Keep();
            var Film = db.Films.Include(p => p.Category).Where(x => x.Id == id);
            var Sessions = db.Sessions.Where(x => x.FilmId == id);
            ViewBag.sessions = Sessions;
            return View(Film.ToList());
        }
        public ActionResult Categories()
        {
            TempData.Keep();
            var Cat = db.Categories;
            return View(Cat.ToList());
        }
        public ActionResult Category(int id)
        {
            TempData.Keep();
            var Cat = db.Categories.Where(x => x.Id == id);
            var Films = db.Films.Where(x => x.CategoryId == id);
            ViewBag.films = Films;
            return View(Cat.ToList());
        }
        public ActionResult Halls()
        {
            TempData.Keep();
            var hall = db.Halls;
            return View(hall.ToList());
        }


        public ActionResult Checkout()
        {
            TempData.Keep();
            return View();
        }
        public ActionResult Hall(int id)
        {
            TempData.Keep();
            var Hall = db.Halls.Where(x => x.Id == id);
            var Places = db.Places.Where(x => x.HallId == id);
            ViewBag.Places = Places;
            return View(Hall.ToList());
        }
        [HttpGet]
        public ActionResult BuyForm()
        {
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public ActionResult BuyForm(string Name, string Surname, string Phone, int Total)
        {
            TempData.Keep();

            if (Name == "" || Surname == "" || Phone == "")
            {
                return View("BuyErr");
            }
            else
            {
                Order o = new Order();
                o.Name = Name;
                o.Surname = Surname;
                o.Phone = Phone;
                o.Price = Total;
                o.Status = 1;
                o.Date = DateTime.Now;
                db.Orders.Add(o);
                db.SaveChanges();
                int ordId = 0;
                var ord = db.Orders.OrderByDescending(x => x.Id).Take(1);

                foreach (var s in ord)
                {
                    ordId = s.Id;
                }
                foreach (var p in TempData["Card"] as List<CinemaTR3.Models.Card>)
                {
                    Pivot piv = new Pivot();
                    piv.TicketId = p.TicketId;
                    piv.OrderId = ordId;
                    db.Pivots.Add(piv);
                    var ticket = db.Tickets.Where(x => x.Id == p.TicketId).SingleOrDefault();
                    ticket.Status = 0;
                }
                db.SaveChanges();
                TempData.Clear();
                return View("BuyGood");
            }
        }
        public ActionResult DelFromCard(int id)
        {
            TempData.Keep();
            List<Card> li2 = TempData["Card"] as List<Card>;
            Card c = li2.Where(x => x.TicketId == id).SingleOrDefault();
            li2.Remove(c);
            int total = 0;
            foreach (var t in li2)
            {
                total += t.price;
            }
            TempData["Total"] = total;
            TempData.Keep();
            return RedirectToAction("Checkout");
        }
        [HttpGet]
        public ActionResult Sess(int id)
        {
            TempData.Keep();
            var Ses = db.Sessions.Include(p => p.Film).Include(p => p.Hall).Where(x => x.Id == id);
            //var Hall = db.Halls.Where(x => x.Id == Ses.);
            var Tickets = db.Tickets.Include(p => p.Place).Where(x => x.SessionId == id);
            ViewBag.tickets = Tickets;
            return View(Ses.ToList());
        }
        List<Card> li = new List<Card>();
        public int Sum = 0;
        [HttpPost]
        public ActionResult Sess(int TicketId, int SessionId, int PlaceId)
        {
            Sum = 0;
            TempData.Keep();
            var ticket = db.Tickets.Where(x => x.Id == TicketId).SingleOrDefault();
            var session = db.Sessions.Where(x => x.Id == SessionId).SingleOrDefault();
            var place = db.Places.Where(x => x.Id == PlaceId).SingleOrDefault();
            var film = db.Films.Where(x => x.Id == session.FilmId).SingleOrDefault();
            Card c = new Card();
            c.TicketId = ticket.Id;
            c.Place = place.Number;
            c.Session = film.Title;
            c.price = ticket.Price;
            if (TempData["Card"] == null)
            {
                li.Add(c);
                TempData["Card"] = li;
            }
            else
            {
                List<Card> li2 = TempData["Card"] as List<Card>;
                li2.Add(c);
                TempData["Card"] = li2;
            }
            if (TempData["Card"] != null)
            {
                foreach (var p in TempData["Card"] as List<CinemaTR3.Models.Card>)
                {
                    Sum += p.price;
                }
            }
            TempData["Total"] = Sum;
            TempData.Keep();
            ViewBag.sesId = session.Id;
            return View("AddToCard");
        }
        [HttpGet]
        public ActionResult Login()
        {
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public ActionResult Login(string login, string password)
        {
            TempData.Keep();
            try
            {
                var Users = db.Users.Where(x => x.Login == login);
                foreach (var user in Users)
                {
                    if (password == user.Password || password == null)
                    {
                        ViewBag.User = user;
                        return View("LoginGood");
                        //return true;
                    }
                    else
                    { 
                        return View("LoginErr1");
                        //return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return View("LoginErr2");
                //return true;
            }
            return View("LoginErr3");
            //return false;
        }
        [HttpGet]
        public ActionResult Registration()
        {
            TempData.Keep();
            return View();
        }
        [HttpPost]
        public ActionResult Registration(User user)
        {
            TempData.Keep();
            var codes = db.Codes;
            int count = 0;
            try
            {
                if (user.Name == null || user.Surname == null ||
                user.Login == null || user.Password == null || user.Code == null)
                {
                    return View("RegistrErr1");
                }
                else
                {
                    if (user.Code != null)
                    {
                        foreach (var code in codes)
                        {
                            if (user.Code == code.Cod)
                            {
                                count = 1;
                                db.Users.Add(user);
                            }
                        }
                        db.SaveChanges();
                        if (count == 1)
                        {
                            return View("RegistrDone");
                        }
                        else
                        {
                            return View("RegistrErr2");
                        }
                    }
                    return View("RegistrErr3");
                }

            }
            catch (Exception ex)
            {

                return View("RegistrErr3");
            }
        }
    }
}