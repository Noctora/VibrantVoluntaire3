using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using VibrantVoluntaire3.Data;
using VibrantVoluntaire3.Models;
using VibrantVoluntaire3.Services;

namespace VibrantVoluntaire3.Controllers
{
   // [SessionState(SessionStateBehavior.Default)]
    public class VibrantController : Controller
    {
        // GET: Vibrant
        public ActionResult Index()
        {
            List<EventM> events = new List<EventM>();

            ////ngo.Add(new NGOAcc(111, "asda", "adas", "dasdsa", "dasdasd", "dasdasd", "dasdsa", "dqawewq", "dqawedwq", "1/1/2001", "dqwewq"));

            EventDAO eventDAO = new EventDAO();

            events = eventDAO.FetchAll();
            TempData.Keep();
            return View("Index", events);
            
            //return View();
        }

        [HttpPost]
        public ActionResult Index(UserAcc obj)
        {
            //store the session from user input and display into the view if session is enabled.    
            //Session["Name"] = obj.usernameId;
            //TempData["Name"] = obj.username;
             //TempData["ID"] = 1000;
            //ViewData["ViewDataName"] = obj.username;
            //ViewData["ViewDataID"] = obj.usernameId;
            TempData.Keep();
            return View();

        }

        public ActionResult Index2()
        {
            List<EventM> events = new List<EventM>();

            ////ngo.Add(new NGOAcc(111, "asda", "adas", "dasdsa", "dasdasd", "dasdasd", "dasdsa", "dqawewq", "dqawedwq", "1/1/2001", "dqwewq"));

            EventDAO eventDAO = new EventDAO();

            events = eventDAO.FetchAll();
            TempData.Keep();
            return View("Index2", events);
           
        }



        public ActionResult EventList()
        {
            List<EventM> events = new List<EventM>();

            //ngo.Add(new NGOAcc(111, "asda", "adas", "dasdsa", "dasdasd", "dasdasd", "dasdsa", "dqawewq", "dqawedwq", "1/1/2001", "dqwewq"));

            EventDAO eventDAO = new EventDAO();

            events = eventDAO.FetchAll();
            TempData.Keep();
            return View("EventList", events);
        }

        

        public ActionResult Login()
        {
            TempData.Keep();
            return View("Login");
        }

        public ActionResult LoginCheck(UserAcc userAcc)
        {
            //return "Result: Username = " +userAcc.username;
            SecurityService securityService = new SecurityService();
            Boolean success = securityService.Authenticate(userAcc);

            UserDAO userDAO = new UserDAO();
            UserAcc users = userDAO.AssignUser(userAcc);



            //UserDAO userDAO = new UserDAO();
            //int x = userDAO.FetchOneName(userAcc.username);

            //int x = securityService.StoreId(userAcc);
            //TempData["ID"] = 1000;
            ViewData["ViewDataID"] = userAcc.usernameId;
            TempData["Name"] = userAcc.username;


            if (success)
            {
                //ViewData["ViewDataName"] = userAcc.username;



                //int x = userAcc.usernameId;
                //Session["ViewDataID"] = x;
                TempData["ID"] = users.usernameId;
                TempData.Keep();
                return View("LoginSuccess", users);
            }
            else
            {
                TempData.Keep();
                return View("LoginFailure");
                
            }
        }

        public ActionResult Signup()
        {
            UserAcc users = new UserAcc();
            TempData.Keep();
            return View("Signup", users);
        }

        public ActionResult SignupCheck()
        {
            TempData.Keep();
            return View("SignupSuccess");
        }

        public ActionResult CreateUser()
        {
            UserAcc users = new UserAcc();
            TempData.Keep();
            return View("UserForm", users);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            UserAcc _uobj = Session["userInfo"] as UserAcc;
            TempData.Keep();
            return View();
            //return View("About", userAcc);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            // Session["Name"] = Convert.ToString(userAcc.usernameId);
            //string name = TempData["Name"].ToString();
            // int height = Convert.ToInt32(TempData["ID"]);
            //string abc = ViewData["ViewDataName"].ToString();
            //int ViewDataHeight = Convert.ToInt32(TempData["ViewDataID"]);

            TempData.Keep();
            return View();
        }


        public ActionResult NGO()
        {
            List<NGOAcc> ngo = new List<NGOAcc>();

            //ngo.Add(new NGOAcc(111, "asda", "adas", "dasdsa", "dasdasd", "dasdasd", "dasdsa", "dqawewq", "dqawedwq", "1/1/2001", "dqwewq"));

            NGODAO ngoDAO = new NGODAO();

            ngo = ngoDAO.FetchAll();

            TempData.Keep();
            return View("NGO", ngo);
        }

        public ActionResult NGODetails(int id)
        {
            NGODAO ngoDAO = new NGODAO();
            NGOAcc ngo = ngoDAO.FetchOne(id);

            TempData.Keep();
            return View("NGODetails", ngo);
        }

        public ActionResult UserDetails()
        {
            //string abc = ViewData["ViewDataName"].ToString();
            //int ViewDataHeight = Convert.ToInt32(TempData["ViewDataID"]);
            UserDAO userDAO = new UserDAO();
            //UserAcc users = userDAO.FetchOne(1000);

            //if (Session["ViewDataID"] != null)
            //{
            //    //Retrieving UserName from Session
            //    //lblWelcome.Text = "Welcome : " + Session["UserName"];

            //    UserAcc users = userDAO.FetchOne(Convert.ToInt32(TempData["ViewDataID"]));
            //    return View("UserDetails", users);

            //}
            //else
            //{
            //    return View("About");
            //    //Do Something else
            //}

            //string name; 
            int x;

            if (TempData.ContainsKey("ID"))
            {
               // name = TempData["ID"] as string;
                //x = Convert.ToInt32(name);

                x = (int)TempData["ID"];

                UserAcc users = userDAO.FetchOne(x);
                TempData.Keep();
                return View("UserDetails", users);
            }
            else
            {
                TempData.Keep();
                return View("About");
            }
                

           

            


            
            


            // return View("UserDetails", users);
        }

        public ActionResult EditUser(int id)
        {
            UserDAO userDAO = new UserDAO();
            UserAcc users = userDAO.FetchOne(id);
            TempData.Keep();
            return View("UserForm", users);
        }

        [HttpPost]
        public ActionResult ProcessUser(UserAcc userAcc)
        {
            //save to the db.
            UserDAO userDAO = new UserDAO();

            userDAO.CreateOrUpdate(userAcc);
            TempData.Keep();
            return View("UserDetails", userAcc);
        }

        public ActionResult CreateEvent(UserAcc userAcc)
        {
            EventM events = new EventM();
            events.usernameId = userAcc.usernameId;
            TempData.Keep();
            return View("EventForm", events);
        }

        [HttpPost]
        public ActionResult ProcessEvent(EventM eventM)
        {
            //save to the db.
            EventDAO eventDAO = new EventDAO();

            eventDAO.Create(eventM);
            //UserAcc users = new UserAcc();


            List<EventM> listevent = new List<EventM>();
            listevent = eventDAO.FetchAll();

            TempData.Keep();

            return View("Index", listevent);
        }

        public ActionResult EventDetails(int id)
        {
            EventDAO eventDAO = new EventDAO();
            EventM events = eventDAO.FetchOne(id);
            TempData.Keep();
            return View("EventDetails", events);
        }

    }
}