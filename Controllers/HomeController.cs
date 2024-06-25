using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TeamTaskManagment.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TeamTaskManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
        public IActionResult Index()
        {
            using (var context = new TeamTaskManDbContext())
            {
                List<Taskd> taskdLokal = new List<Taskd>();

                var taskdLokal2 = context.Taskds.ToList();

                taskdLokal = taskdLokal2;
                ViewData["Poracka"] = taskdLokal;

            }
                return View();
        }

        //[Route("")]
        [Route("Home/Taskv/{a?}")]
        public IActionResult Taskv(string a)
        {
            string taskName = "", taskDueDate = "", category = "", status = "", selCategory="", selStatus="", taskDescription="";
           
            //initiali
            using (var context = new TeamTaskManDbContext())
            {
                List<Category> catLokal = new List<Category>();
                var catLokal2 = context.Categories.ToList();
                catLokal = catLokal2;
                ViewData["cat"] = catLokal;


                List<Status> statLokal = new List<Status>();
                var statLokal2 = context.Statuses.ToList();
                statLokal = statLokal2;
                ViewData["sta"] = statLokal;

            }

            //if (Request.Method == "POST")
            //{
            //    taskName = HttpContext.Request.Form["txtTaskName"].ToString();
            //    taskDueDate = HttpContext.Request.Form["datTaskDueDate"].ToString();

            //    selCategory = HttpContext.Request.Form["selCategory"].ToString();
            //    selStatus = HttpContext.Request.Form["selStatus"].ToString();

            //    taskDescription = HttpContext.Request.Form["txtTaskDescription"].ToString();

            //    using (var context = new TeamTaskManDbContext())
            //    {
            //        var tsk1 = new Taskd() { 
            //            TaskName = taskName, 
            //            TaskDueDate = Convert.ToDateTime(taskDueDate), 
            //            CategoryId = Convert.ToInt32(selCategory),
            //            StatusId = Convert.ToInt32(selStatus),
            //            TaskDescription = taskDescription
            //        };
            //        context.Taskds.Add(tsk1);
            //        context.SaveChanges();
            //    }
            //}

            switch (a)
            {
                case "e":
                    //Edit

                    //string taskName, taskDueDate;
                    ////gud = HttpContext.Request.Form["txtGuid"].ToString();
                    //taskName = HttpContext.Request.Form["txtTaskName"].ToString();
                    //taskDueDate = HttpContext.Request.Form["taskDueDate"].ToString();

                   
                    ViewBag.But = "Edit";
                    break;
                case "d":
                    //using (var context = new TeamTaskManDbContext())
                    //{
                    //    var tsk1 = new Taskd() { TaskName = "1st Grade" };
                    //    context.Taskds.Add(tsk1);
                    //    context.SaveChanges();
                    //}
                    ViewBag.But = "Delete";
                    break;

                case "n":
                    

                    break;

                default:
                    ViewBag.But = "Add New";
                    break;
            }



            return View();
        }

        public IActionResult Taskv()
        {
            string taskName = "", taskDueDate = "", category = "", status = "", selCategory = "", selStatus = "", taskDescription = "";

            //initiali
            using (var context = new TeamTaskManDbContext())
            {
                List<Category> catLokal = new List<Category>();
                var catLokal2 = context.Categories.ToList();
                catLokal = catLokal2;
                ViewData["cat"] = catLokal;


                List<Status> statLokal = new List<Status>();
                var statLokal2 = context.Statuses.ToList();
                statLokal = statLokal2;
                ViewData["sta"] = statLokal;

            }

            if (Request.Method == "POST")
            {
                taskName = HttpContext.Request.Form["txtTaskName"].ToString();
                taskDueDate = HttpContext.Request.Form["datTaskDueDate"].ToString();

                selCategory = HttpContext.Request.Form["selCategory"].ToString();
                selStatus = HttpContext.Request.Form["selStatus"].ToString();

                taskDescription = HttpContext.Request.Form["txtTaskDescription"].ToString();

                using (var context = new TeamTaskManDbContext())
                {
                    var tsk1 = new Taskd()
                    {
                        TaskName = taskName,
                        TaskDueDate = Convert.ToDateTime(taskDueDate),
                        CategoryId = Convert.ToInt32(selCategory),
                        StatusId = Convert.ToInt32(selStatus),
                        TaskDescription = taskDescription
                    };
                    context.Taskds.Add(tsk1);
                    context.SaveChanges();
                }
            }

            //switch (a)
            //{
            //    case "e":
            //        //Edit

            //        //string taskName, taskDueDate;
            //        ////gud = HttpContext.Request.Form["txtGuid"].ToString();
            //        //taskName = HttpContext.Request.Form["txtTaskName"].ToString();
            //        //taskDueDate = HttpContext.Request.Form["taskDueDate"].ToString();


            //        ViewBag.But = "Edit";
            //        break;
            //    case "d":
            //        using (var context = new TeamTaskManDbContext())
            //        {
            //            var tsk1 = new Taskd() { TaskName = "1st Grade" };
            //            context.Taskds.Add(tsk1);
            //            context.SaveChanges();
            //        }
            //        ViewBag.But = "Delete";
            //        break;

            //    case "n":


            //        break;

            //    default:
            //        ViewBag.But = "Add New";
            //        break;
            //}



            return View();
        }

       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
