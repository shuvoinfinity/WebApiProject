﻿using Learning.Data.Entities;
using System.Linq;

namespace Learning.Data
{
    public interface ILearningRepository
    {
        IQueryable<Subject> GetAllSubjects();
        Subject GetSubject(int subjectId);

        IQueryable<Course> GetCoursesBySubject(int subjectId);

        IQueryable<Course> GetAllCourses();
        Course GetCourse(int courseId, bool includeEnrollments = true);
        bool CourseExists(int courseId);

        IQueryable<Student> GetAllStudentsWithEntrollments();
        IQueryable<Student> GetAllStudentsSummary();

        IQueryable<Student> GetEnrolledStudentsInCourse(int courseId);
        Student GetStudentEnrollments(string userName);
        Student GetStudent(string userName);

        Tutor GetTutor(int tutorId);

        bool LoginStudent(string userName, string password);

        bool insert(Student student);
        bool Update(Student originalStudent, Student updatedStudent);
        bool DeleteStudent(int id);

        int EnrollStudentInCourse(int studentId, int courseId, Enrollment enrollment);

        bool Insert(Course course);
        bool Update(Course originalCourse, Course updatedCourse);
        bool DeleteCourse(int id);

        bool SaveAll();
    }
}
