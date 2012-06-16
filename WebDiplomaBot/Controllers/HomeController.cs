using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDiplomaBot.Models;

namespace WebDiplomaBot.Controllers
{
    public class HomeController : Controller
    {
        private DiplomaContext db = new DiplomaContext();

        public ActionResult Index()
        {

            ViewBag.Message = "Build your Diploma!";

            ViewBag.SelectedInstructor = new SelectList(db.Instructors.Select(i => i.FullName));
            ViewBag.SelectedCourse = new SelectList(db.Courses.Select(c => c.CourseName));            

            return View();        
        }

        public String ReplaceHelper(int startIndex, int endIndex, String diplomaMessage, String replacement)
        {
            return diplomaMessage.Substring(0, startIndex) + replacement + diplomaMessage.Substring(endIndex + 1, diplomaMessage.Length - endIndex - 1);
        }

        [HttpPost]
        public String Generate(String camperName, String courseName, String instructorName, String projectName, String personalizedMessage)
        {
            String diplomaMessage = "[camper],\n\t[intro_sentence] [project_sentence] [inspire_sentence] [personalized_message][end_sentence] \n\n\t\t\t\t-[instructor]";
            Random r = new Random();
            //Search string for template phrase
            while (true)
            {
                int startIndex = -1;
                int endIndex = -1;
                for (int i = 0; i < diplomaMessage.Length; i++)
                {
                    if (startIndex == -1 && diplomaMessage[i] == '[')
                        startIndex = i;
                    if (startIndex != -1 && diplomaMessage[i] == ']')
                    {
                        endIndex = i;
                        String templatePhrase = diplomaMessage.Substring(startIndex+1, endIndex - startIndex-1);
                        if (templatePhrase == "camper")
                        {
                            diplomaMessage = ReplaceHelper(startIndex, endIndex, diplomaMessage, camperName);
                        }
                        else if (templatePhrase == "class")
                        {
                            diplomaMessage = ReplaceHelper(startIndex, endIndex, diplomaMessage, courseName);
                        }
                        else if (templatePhrase == "instructor")
                        {
                            diplomaMessage = ReplaceHelper(startIndex, endIndex, diplomaMessage, instructorName);
                        }
                        else if (templatePhrase == "project")
                        {
                            diplomaMessage = ReplaceHelper(startIndex, endIndex, diplomaMessage, projectName);
                        }
                        else if (templatePhrase == "personalized_message")
                        {
                            if(personalizedMessage == "")
                                diplomaMessage = ReplaceHelper(startIndex, endIndex, diplomaMessage, personalizedMessage);
                            else
                                diplomaMessage = ReplaceHelper(startIndex, endIndex, diplomaMessage, personalizedMessage+" ");
                        }
                        else
                        {
                            List<String> replacements = db.Templates.Where(t => t.Target == templatePhrase).Select(t => t.Replacement).ToList();
                            if(replacements.Count > 0)
                                diplomaMessage = ReplaceHelper(startIndex, endIndex, diplomaMessage, replacements[r.Next(0,replacements.Count)]);
                            else
                                diplomaMessage = ReplaceHelper(startIndex, endIndex, diplomaMessage, "");

                        }
                        break;
                    }
                }
                if (startIndex == -1 || endIndex == -1)
                    return diplomaMessage;
            }
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
