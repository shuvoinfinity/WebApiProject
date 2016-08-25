using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Learning.Data;
using Learning.Data.Entities;


namespace Learning.Web.Controllers
{
    public class CoursesController : ApiController
    {
        public List<Course> Get()
        {
            ILearningRepository repository = new LearningRepository(new LearningContext());

            return repository.GetAllCourses().ToList();
        }

        public Course GetCourse(int id)
        {
            ILearningRepository repository = new LearningRepository(new LearningContext());

            return repository.GetCourse(id);
        }
    }
}
