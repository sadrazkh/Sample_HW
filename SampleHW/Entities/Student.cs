using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleHW.Entities;

public class Student
{
    public int StudentId { get; set; }
    public string FirstName { private get; set; }
    public string LastName { private get; set; }

    public string FullName => $"{FirstName} {LastName}";

    public List<Course> Courses { get; set; }
}

