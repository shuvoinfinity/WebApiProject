using Learning.Data.Entities;
using System;
using System.Linq;

namespace Learning.Data
{
    class LearningRepository : ILearningRepository
    {
        private LearningContext _ctx;

        public LearningRepository(LearningContext ctx)
        {
            _ctx = ctx;
        }

        public bool CourseExists(int courseId)
        {
            return _ctx.Courses.Any(c => c.Id == courseId);
        }

        public bool DeleteCourse(int id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteStudent(int id)
        {
            throw new NotImplementedException();
        }

        public int EnrollStudentInCourse(int studentId, int courseId, Enrollment enrollment)
        {
            try
            {
                if (_ctx.Enrollments.Any(e => e.Course.Id == courseId && e.Student.Id == studentId))
                {
                    return 2;
                }

                _ctx.Database.ExecuteSqlCommand("INSERT INTO Enrollments VALUES (@p0, @p1, @p2)",
                    enrollment.EnrollmentDate, courseId.ToString(), studentId.ToString());

                return 1;
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbex)
            {
                foreach (var eve in dbex.EntityValidationErrors)
                {
                    string line = string.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        line = string.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);

                    }
                }
                return 0;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public IQueryable<Course> GetAllCourses()
        {
            return _ctx.Courses
                .Include("CourseSubject")
                .Include("CourseTutor")
                .AsQueryable();
        }

        public IQueryable<Student> GetAllStudentsSummary()
        {
            return _ctx.Students.AsQueryable();
        }

        public IQueryable<Student> GetAllStudentsWithEntrollments()
        {
            return _ctx.Students
                .Include("Enrollments")
                .Include("Enrollments.Course")
                .Include("Enrollments.Course.CourseSubject")
                .Include("Enrollments.Course.CourseTutor")
                .AsQueryable();
        }

        public IQueryable<Subject> GetAllSubjects()
        {
            return _ctx.Subjects.AsQueryable();
        }

        public Course GetCourse(int courseId, bool includeEnrollments = true)
        {
            if (includeEnrollments)
            {
                return _ctx.Courses
                    .Include("Enrollments")
                    .Include("CourseSubjects")
                    .Include("CourseTutor")
                    .Where(c => c.Id == courseId)
                    .SingleOrDefault();
            }
            else
            {
                return _ctx.Courses
                       .Include("CourseSubject")
                       .Include("CourseTutor")
                       .Where(c => c.Id == courseId)
                       .SingleOrDefault();
            }
        }

        public IQueryable<Course> GetCoursesBySubject(int subjectId)
        {
            return _ctx.Courses
                .Include("CourseSubject")
                .Include("CourseTutor")
                .Where(c => c.CourseSubject.Id == subjectId)
                .AsQueryable();
        }

        public IQueryable<Student> GetEnrolledStudentsInCourse(int courseId)
        {
            return _ctx.Students
                    .Include("Enrollments")
                    .Where(c => c.Enrollments.Any(s => s.Course.Id == courseId))
                    .AsQueryable();

        }

        public Student GetStudent(string userName)
        {
            var student = _ctx.Students
                           .Include("Enrollments")
                           .Where(s => s.UserName == userName)
                           .SingleOrDefault();

            return student;
        }

        public Student GetStudentEnrollments(string userName)
        {
            var student = _ctx.Students
                           .Include("Enrollments")
                           .Include("Enrollments.Course")
                           .Include("Enrollments.Course.CourseSubject")
                           .Include("Enrollments.Course.CourseTutor")
                           .Where(s => s.UserName == userName)
                           .SingleOrDefault();

            return student;
        }

        public Subject GetSubject(int subjectId)
        {
            return _ctx.Subjects.Find(subjectId);
        }

        public Tutor GetTutor(int tutorId)
        {
            return _ctx.Tutors.Find(tutorId);
        }

        public bool Insert(Course course)
        {
            throw new NotImplementedException();
        }

        public bool insert(Student student)
        {
            throw new NotImplementedException();
        }

        public bool LoginStudent(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool SaveAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Course originalCourse, Course updatedCourse)
        {
            throw new NotImplementedException();
        }

        public bool Update(Student originalStudent, Student updatedStudent)
        {
            throw new NotImplementedException();
        }

        IQueryable<Student> ILearningRepository.GetAllSubjects()
        {
            throw new NotImplementedException();
        }
    }
}
