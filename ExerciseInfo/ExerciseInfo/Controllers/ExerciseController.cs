using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExerciseInfo.Models;
using System.Web.Script.Serialization;
using ExerciseInfo.Common;
using System.Text.RegularExpressions;
using System.IdentityModel.Protocols.WSTrust;

namespace ExerciseInfo.Controllers
{
    public class ExerciseController : Controller
    {
        public static List<ExerciseModal> exer = new List<ExerciseModal>
        {
            new ExerciseModal
            {
                ExerciseName = "Dancing",
                DateTime = new DateTime(1998, 01, 01),
                Duration = 2
            },
            new ExerciseModal
            {
               
                ExerciseName = "Singing",
                DateTime = new DateTime(1940, 10, 01),
                Duration = 120
            },
            new ExerciseModal
            {
                ExerciseName = "Jogging",
                DateTime = new DateTime(1942, 10, 01),
                Duration = 12
            },
            new ExerciseModal
            {
               
                ExerciseName = "Pushup",
                DateTime = new DateTime(2002, 10, 01),
                Duration = 45
            },
            new ExerciseModal
            {
               
                ExerciseName = "Plank",
                DateTime = new DateTime(2004, 02, 05),
                Duration = 10
            },
            new ExerciseModal
            {
                
                ExerciseName = "Cardio",
                DateTime = new DateTime(2003, 11, 21),
                Duration = 45
            },
            new ExerciseModal
            {
               
                ExerciseName = "Swimming",
                DateTime = new DateTime(2015, 12, 18),
                Duration = 20
            },
            new ExerciseModal
            {
               
                ExerciseName = "Glute Bridge",
                DateTime = new DateTime(2012, 10, 06),
                Duration = 20
            },
            new ExerciseModal
            {
               
                ExerciseName = "Spider Lunge",
                DateTime = new DateTime(2011, 02, 11),
                Duration = 60
            },
            new ExerciseModal
            {
               
                ExerciseName = "Plank Tap",
                DateTime = new DateTime(2011, 02, 11),
                Duration = 25
            },

            new ExerciseModal
            {
               
                ExerciseName = " Squat",
                DateTime = new DateTime(2016, 09, 22),
                Duration = 55
            },

            new ExerciseModal
            {
               
                ExerciseName = " Side Lunge",
                DateTime = new DateTime(2016, 08, 24),
                Duration = 55
            }
        };

        // GET: Exercise
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            DateTime Current = DateTime.Now;

            var list = exer.Where(x => x.DateTime < Current.Date)
                            .OrderByDescending(x => x.DateTime).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Insert(ExerciseModal ex)
        {

           if (ModelState.IsValid)
            {
                bool sameRecord = exer.Any(x => x.DateTime == ex.DateTime 
                                            && x.ExerciseName == ex.ExerciseName);

                if (sameRecord)
                {

                    return Json(new
                    {
                        Success = false,
                        Result = false, ex,
                        Message = "Cannot Add Same Exercise Name Twice in one day"
                    });
                   
                }

                var obj = ex;
                exer.Add(obj);
                return Json(exer, JsonRequestBehavior.AllowGet);

            }
           return Json(new
           {
               Success = false,
               Result =false, ex,
               Message = "Please !!! Enter valid data",
               
           });
            
        }
       [HttpGet]
        public ActionResult SearchRecord(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IList<ExerciseModal> searchresult = exer.Where(obj => obj.ExerciseName.Contains(name)).ToList();
                return Json(searchresult, JsonRequestBehavior.AllowGet);
            }
            
            var list = exer.ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}
