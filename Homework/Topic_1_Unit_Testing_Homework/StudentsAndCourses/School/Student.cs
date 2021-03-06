﻿namespace School
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private string firstName;

        private string lastName;

        private readonly int uniqueNumber;

        private ICollection<Course> courses;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.uniqueNumber = School.UniqueNumber++;
            this.courses = new List<Course>();
        }

        public ICollection<Course> Courses => new List<Course>(this.courses);
       
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student's first name cannot be null or empty");
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student's last name cannot be null or empty");
                }
                this.lastName = value;
            }
        }

        public string Name => this.FirstName + ' ' + this.LastName;

        public int UniqueNumber => this.uniqueNumber;

        public void SignCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course cannot be null");
            }

            this.courses.Add(course);
            if (!course.StudentsList.Contains(this))
            {
                course.AddStudent(this);
            }
        }
       
        public void UnsignCourse(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException("Course cannot be null");
            }

            this.courses.Remove(course);
            if (course.StudentsList.Contains(this))
            {
                course.RemoveStudent(this);
            }
        }
    }
}
