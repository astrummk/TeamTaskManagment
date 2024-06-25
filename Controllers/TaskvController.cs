using Microsoft.AspNetCore.Mvc;
using TeamTaskManagment.Models;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TeamTaskManagment.Controllers
{
    public class TaskvController : Controller
    {
        public string taskName = "", taskDueDate = "", category = "", status = "", selCategory = "0", selStatus = "0", taskDescription = "", taskID = "";

        public IActionResult Index(string a, Guid id)
        {
            //initiali
            Init();

            switch (a)
            {
                case "a":
                    ViewBag.But = "AddNew";
                    break;

                case "e":
                    ViewBag.But = "Edit";
                    ViewData["fdat"] = GetDetails(id);
                    break;

                case "d":
                    ViewBag.But = "Delete";
                    ViewData["fdat"] = GetDetails(id);
                    break;

                default:
                    break;
            }

            return View();
        }

        private List<Taskd> GetDetails(Guid id)
        {
            using (var context = new TeamTaskManDbContext())
            {
                var taskdDetail = context.Taskds
                    .Where(s => s.TaskId == id)
                    .ToList();

                return taskdDetail;
            }
        }

        public IActionResult Edit()
        {
            GetPost();

            using (var context = new TeamTaskManDbContext())
            {
                var taskToUpdate = context.Taskds.Single(t => t.TaskId.ToString() == taskID);

                if (taskToUpdate != null)
                {
                    taskToUpdate.TaskName = taskName;
                    taskToUpdate.TaskDueDate = Convert.ToDateTime(taskDueDate);
                    taskToUpdate.CategoryId = Convert.ToInt32(selCategory);
                    taskToUpdate.StatusId = Convert.ToInt32(selStatus);
                    taskToUpdate.TaskDescription = taskDescription;

                    context.SaveChanges();
                }
            }

            return RedirectToAction("Index", "Home");
        }

        
        public IActionResult Delete()
        {
            GetPost();
            using (var context = new TeamTaskManDbContext())
            {
                var taskToUpdate = context.Taskds.Single(t => t.TaskId.ToString() == taskID);

                if (taskToUpdate != null)
                {

                    context.Taskds.Remove(taskToUpdate);

                    context.SaveChanges();
                }

            }
                return RedirectToAction("Index", "Home");
        }

        public IActionResult AddNew()
        {
            Init();
            GetPost();
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
            return RedirectToAction("Index", "Home");
        }

        private void Init()
        {
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
        }

        public void GetPost()
        {
            
            if (Request.Method == "POST")
            {
                taskName = HttpContext.Request.Form["txtTaskName"].ToString();
                taskDueDate = HttpContext.Request.Form["datTaskDueDate"].ToString();

                selCategory = HttpContext.Request.Form["selCategory"].ToString();
                selStatus = HttpContext.Request.Form["selStatus"].ToString();

                taskDescription = HttpContext.Request.Form["txtTaskDescription"].ToString();

                taskID = HttpContext.Request.Form["tGu"].ToString();
                
            }
        }

        public static string DateFormat(DateTime date)
        {
            //DateTimeFormatInfo format = new DateTimeFormatInfo();
            //format.ShortDatePattern = "yyyy-MM-dd";
            //format.DateSeparator = "-";
            //DateTime date2 = date;
            //DateTime shortDate = Convert.ToDateTime(date2, format);

            //return shortDate.ToString();

            string m;
            if (date.Month.ToString().Length == 1)
            {
                m = "0" + date.Month.ToString();
            }
            else
            {
                m = date.Month.ToString();
            }
            string d;
            if (date.Day.ToString().Length == 1)
            {
                d = "0" + date.Day.ToString();
            }
            else
            {
                d = date.Day.ToString();
            }

            return date.Year.ToString() + "-" + m + "-" + d;

        }

    }
}
