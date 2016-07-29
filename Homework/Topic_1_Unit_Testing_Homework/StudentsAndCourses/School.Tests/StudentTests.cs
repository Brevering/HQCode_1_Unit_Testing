namespace School.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class StudentTests
    {
        private Student validTestStudent = new Student("Ivan", "Ivanov");

        [Test]        
        public void ArgumentExceptionShouldBeThrownIfFirstNameIsNull()
        {
            Assert.That(() => new Student(null, "Ivanov"), Throws.TypeOf<ArgumentException>());
        }

        [Test]        
        public void ArgumentExceptionShouldBeThrownIfFirstNameIsEmpty()
        {
            Assert.That(() => new Student(string.Empty, "Ivanov"), Throws.TypeOf<ArgumentException>());

        }

        [Test]   
        public void ArgumentExceptionShouldBeThrownIfLastNameIsNull()
        {
            Assert.That(() => new Student("Ivan", null), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void ArgumentExceptionShouldBeThrownIfLastNameIsEmpty()
        {
            Assert.That(() => new Student("Ivan", string.Empty), Throws.TypeOf<ArgumentException>());

        }

        [Test]
        public void StudentNameShouldBeCorrectWhenValidArgumentsArePassed()
        {
            Student testStudent = this.validTestStudent;
            Assert.AreEqual("Ivan Ivanov", testStudent.Name);
        }

        [Test]
        public void StudentShouldBeCreatedWithExpectedPropertiesWhenValidArgumentsArePassed()
        {
            Student testStudent = validTestStudent;
            Assert.AreEqual("Ivan", testStudent.FirstName);
            Assert.AreEqual("Ivanov", testStudent.LastName);
            Assert.AreEqual(0, testStudent.Courses.Count);
            Assert.IsTrue(10000 <= testStudent.UniqueNumber && testStudent.UniqueNumber <= 99999);
        }

        [Test]
        public void StudentUniqueNumberMustBeDifferentForAllDifferentInstances()
        {
            int testStudentsCount = 100;
            int[] uniqueStudentNumbers = new int[testStudentsCount];
            for (int i = 0; i < testStudentsCount; i++)
            {
                Student testStudent = new Student("Ivan", "Ivanov");
                uniqueStudentNumbers[i] = testStudent.UniqueNumber;
            }

            CollectionAssert.AllItemsAreUnique(uniqueStudentNumbers);
        }

        [Test]
        public void WhenStudentSignsACourseTheCourseShouldAppearInCoursesListAndStudentInCoursesStudentList()
        {
            Student testStudent = this.validTestStudent;
            Course testCourse = new Course("TestCourse");
            testStudent.SignCourse(testCourse);
            Assert.IsTrue(testStudent.Courses.Contains(testCourse));
            Assert.IsTrue(testCourse.StudentsList.Contains(testStudent));
        }

        [Test]
        public void WhenStudentUnsignsACourseTheCourseShouldBeRemovedFromTheCoursesListAndTheStudentFromTheCourseStudentList()
        {
            Student testStudent = this.validTestStudent;
            Course testCourse = new Course("TestCourse");
            testStudent.SignCourse(testCourse);
            testStudent.UnsignCourse(testCourse);
            Assert.IsFalse(testStudent.Courses.Contains(testCourse));
            Assert.IsFalse(testCourse.StudentsList.Contains(testStudent));
        }

        [Test]
        public void ShouldThrowAnArgumentNullExceptionWhenNullIsPassedToTheSignCourseMethod()
        {
            Student testStudent = validTestStudent;
            Assert.That(() => testStudent.SignCourse(null), Throws.TypeOf<ArgumentNullException>());            
        }

        [Test]       
        public void ShouldThrowAnArgumentNullExceptionWhenNullIsPassedToTheUnsignCourseMethod()
        {
            Student testStudent = validTestStudent;
            Assert.That(() => testStudent.UnsignCourse(null), Throws.TypeOf<ArgumentNullException>());            
        }
    }
}
