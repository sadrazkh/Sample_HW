using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleHW.Entities;
using SampleHW.Exceptions;

namespace SampleHW;
public class University
{
    public List<Student> Students { get; set; }
    public List<Course> Courses { get; set; }

    public bool AddStudent(Student student)
    {
        var lastId = Students
            .OrderBy(x => x.StudentId)
            .Select(s => s.StudentId)
            .LastOrDefault(defaultValue: 1);

        if (student.StudentId + 1 == lastId)
        {
            Students.Add(student);
            return true;
        }

        throw new DuplicateKeyException();
    }
    public bool AddStudent(string firstName, string lastName)
    {
        var lastId = Students
            .OrderBy(x => x.StudentId)
            .Select(s => s.StudentId)
            .LastOrDefault(defaultValue: 1);


        var student = new Student()
        {
            StudentId = lastId += 1,
            FirstName = firstName,
            LastName = lastName,
            Grades = new List<double>(),
        };

        Students.Add(student);
        return true;
    }


    public bool AddCourseToStudent(int studentId, int courseId, double grade)
    {
        var course = Courses.FirstOrDefault(c => c.CourseId == courseId, defaultValue: null);

        if (course == null)
        {
            throw new IdNotFoundException();
        }

        // Todo check and validations

        var student = Students.FirstOrDefault(c => c.StudentId == studentId);

        if (student.Courses.Any(c => c.CourseId == courseId))
        {
            student.Courses.Where(c => c.CourseId == courseId).First().Grade = grade;
        }
        else
        {
            student.Courses.Add(course);
            student.Courses.Where(c => c.CourseId == courseId).First().Grade = grade;
        }

        return true;
    }


}

