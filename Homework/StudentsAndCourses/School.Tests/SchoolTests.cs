namespace School.Tests
{
    using System;
    using NUnit.Framework;

    [TestFixture]
    public class SchoolTests
    {        

        [TestCase (9999)]
        [TestCase (100000)]
        public void School_ShouldThrowArgumentOutOfRangeException_IfUniqueStudentNumberIsLessThan10000OrGreaterThan99999(int nbr)
        {
            Assert.That(() => School.UniqueNumber = nbr, Throws.TypeOf<ArgumentOutOfRangeException>());
        }


        [Test]
        public void SchoolShouldReturnCorrectUniqueIdWhenItIsSetCorrectly()
        {
            School.UniqueNumber = 10000;
            Assert.AreEqual(10000, School.UniqueNumber, "Unique number should be set correctly when valid");
        }
    }
}
