namespace School.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class CourseTests
    {        

        [Test]        
        public void CourseShouldThrowAnArgumentExceptionIfTitleIsNull()
        {
            Assert.That(() => new Course(null), Throws.TypeOf<ArgumentException>());           
        }

        [Test]
        public void CourseShouldThrowAnArgumentExceptionIfTitleIsEmpty()
        {
            Assert.That(() => new Course(string.Empty), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void CourseListOfStudentsAndStudentListOfCoursesShouldBeUpdatedProperlyWhenANewStudentIsAdded()
        {
            Course testCourse = new Course("TestCourse");
            Student testStudent = new Student("Ivan", "Ivanov");
            testCourse.AddStudent(testStudent);

            Assert.IsTrue(testCourse.StudentsList.Contains(testStudent));
            Assert.IsTrue(testStudent.Courses.Contains(testCourse));
        }

        [Test]
        public void CourseListOfStudentsAndStudentListOfCoursesShouldBeUpdatedProperlyWhenAStudentIsRemoved()
        {
            Course testCourse = new Course("TestCourse");
            Student testStudent = new Student("Ivan", "Ivanov");
            testCourse.AddStudent(testStudent);
            testCourse.RemoveStudent(testStudent);

            Assert.IsFalse(testCourse.StudentsList.Contains(testStudent));
            Assert.IsFalse(testStudent.Courses.Contains(testCourse));
        }

        [Test]
        public void CourseTitleShouldBeSetCorrectlyWhenValidArgumentIsPassed()
        {
            Course testCourse = new Course("Valid Title");
            Assert.AreEqual("Valid Title", testCourse.Title);
        }

        [Test]        
        public void CourseShouldThrowAnApplicationExceptionWhenNumberOfSignedStudentsExceedsTheLimit()
        {
            Course testCourse = new Course("TestCourse");
            for (int i = 0; i < 29; i++)
            {
                Student testStudent = new Student("Ivan", "Ivanov");
                testCourse.AddStudent(testStudent);
            }
            Student lastStudent = new Student("Causes", "Exception");
            
            Assert.That(() => testCourse.AddStudent(lastStudent), Throws.TypeOf<ApplicationException>());
        }

        [Test]        
        public void CourseShouldThrowAnApplicationExceptionWhenTheSameStudentIsAddedMoreThanOnce()
        {
            Course testCourse = new Course("TestCourse");
            Student testStudent = new Student("Ivan", "Ivanov");
            testCourse.AddStudent(testStudent);

            Assert.That(() => testCourse.AddStudent(testStudent), Throws.TypeOf<ApplicationException>());
            
        }

        [Test]        
        public void ShouldThrowAnArgumentNullExceptionWhenNullIsPassedToAddStudentMethod()
        {
            Course testCourse = new Course("TestCourse");
            Assert.That(() => testCourse.AddStudent(null), Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void ShouldThrowAnArgumentNullExceptionWhenNullIsPassedToRemoveStudentMethod()
        {
            Course testCourse = new Course("TestCourse");
            Assert.That(() => testCourse.RemoveStudent(null), Throws.TypeOf<ArgumentNullException>());
        }
    }
}
