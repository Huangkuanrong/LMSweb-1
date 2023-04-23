﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LMSweb.Models;
using LMSweb.ViewModel;
using System.Security.Claims;

namespace LMSweb.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class TeacherController : Controller
    {
        private LMSmodel db = new LMSmodel();

        public ActionResult Home()
        {
            ClaimsIdentity claims = (ClaimsIdentity)User.Identity; //取得Identity
            var claimData = claims.Claims.Where(x => x.Type == "UID").FirstOrDefault();   //抓出當初記載Claims陣列中的TID
            var tid = claimData.Value; //取值(因為只有一筆)
            var courses = db.Courses.Where(c => c.TID == tid);
            return View(courses.ToList());
        }

        public ActionResult CourseCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CourseCreate(CourseCreateViewModel courseViewModel)
        {
            ClaimsIdentity claims = (ClaimsIdentity)User.Identity; //取得Identity
            var claimData = claims.Claims.Where(x => x.Type == "UID").FirstOrDefault();   //抓出當初記載Claims陣列中的TID
            var tid = claimData.Value; //取值(因為只有一筆)

            if(ModelState.IsValid)
            {
                Course course = new Course
                {
                    TID = tid,
                    CreateTime = DateTime.Now.ToString(),
                    CID = $"C{DateTime.Now.ToString("yyMMddHHmmss")}",
                    CName = courseViewModel.Name,
                    TestType = courseViewModel.TestType,
                    // 以下欄位要根據TestType來決定其值，或是要刪除這兩個欄位
                    IsAddMetacognition = false,
                    IsAddPeerAssessmemt = false
                };
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Home");
            }
            return View(courseViewModel);
        }

        public ActionResult CourseEdit(string cid)
        {
            if (cid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(cid);
            if (course == null)
            {
                return HttpNotFound();
            }

            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CourseEdit([Bind(Include = "CID,TID,CourseName, IsAddMetacognition, IsAddPeerAssessmemt")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Home");
            }
            return View(course);
        }

        public ActionResult CourseDelete(string cid)
        {
            if (cid == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(cid);
            if (course == null)
            {
                return HttpNotFound();
            }

            return View(course);
        }

        [HttpPost, ActionName("CourseDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult CourseDeleteConfirmed(string cid)
        {
            Course course = db.Courses.Find(cid);
            db.Courses.Remove(course);
            var mission = db.Missions.Where(m => m.CID == cid);
            var learningBehavior = db.LearnB.Where(l => l.CID == cid);
            var teacherA = db.TeacherA.Where(ta => ta.CID == cid);
            var group = db.Groups.Where(g => g.CID == cid);
            var kp = db.KnowledgePoints.Where(k => k.CID == cid);
            var peerA = db.PeerA.Where(p => p.CID == cid);
            var question = db.Questions.Where(q => q.mission.CID == cid);
            var option = db.Options.Where(o => o.Question.CID == cid);
            var student = db.Students.Where(s => s.CID == cid);
            var response = db.Responses.Where(r => r.Student.CID == cid);
            var stuDraw = db.StudentDraws.Where(sd => sd.CID == cid);
            var stuCode = db.StudentCodes.Where(sc => sc.CID == cid);
            var ger = db.GroupERs.Where(gr => gr.CID == cid);
            var eresponse = db.EvalutionResponse.Where(er => er.CID == cid);

            db.Missions.RemoveRange(mission);
            db.LearnB.RemoveRange(learningBehavior);
            db.TeacherA.RemoveRange(teacherA);
            db.Groups.RemoveRange(group);
            db.KnowledgePoints.RemoveRange(kp);
            db.PeerA.RemoveRange(peerA);
            db.Questions.RemoveRange(question);
            db.Responses.RemoveRange(response);
            db.Students.RemoveRange(student);
            db.Options.RemoveRange(option);
            db.StudentDraws.RemoveRange(stuDraw);
            db.StudentCodes.RemoveRange(stuCode);
            db.GroupERs.RemoveRange(ger);
            db.EvalutionResponse.RemoveRange(eresponse);
            db.SaveChanges();

            return RedirectToAction("Home", "Teacher", null);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult TeacherChat(string mid, string cid)
        {
            var gmodel = new GroupViewModel();
            gmodel.MID = mid;
            var mis = db.Missions.Find(mid);

            ClaimsIdentity claims = (ClaimsIdentity)User.Identity; //取得Identity
            var claimData = claims.Claims.Where(x => x.Type == "UID").FirstOrDefault();   //抓出當初記載Claims陣列中的SID
            var tid = claimData.Value;            
            var mname = db.Missions.Find(mid).MName;
            var cname = db.Courses.Find(cid).CName;
           
            gmodel.CID = cid;
            gmodel.CName = cname;
            gmodel.Groups = db.Groups.Where(g => g.CID == cid).ToList(); 
            gmodel.MName = mname;

            return View(gmodel);
        }

        public ActionResult StuChat(int gid ,string cid, string mid)
        {
            MissionViewModel model = new MissionViewModel();
            var mission = db.Missions.Find(mid);
            var mname = db.Missions.Find(mid).MName;
            var gname = db.Groups.Find(gid).GName;
            model.CID = cid;
            model.MID = mid;
            model.GID = gid;
            model.GName = gname;
            model.MName = mname;

            return View(model);
        }
    }
}
