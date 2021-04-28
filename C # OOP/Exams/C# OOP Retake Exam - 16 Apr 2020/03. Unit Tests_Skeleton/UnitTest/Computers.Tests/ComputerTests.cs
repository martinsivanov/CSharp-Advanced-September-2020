namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        Part part;
        [SetUp]
        public void Setup()
        {
            this.part = new Part("Martin", 5);
        }

        [Test]
        public void TestPartConstructorShouldWorkCorrectly()
        {
            var part = new Part("asd", 5);

            Assert.AreEqual("asd", part.Name);
            Assert.AreEqual(5, part.Price);
        }
        [Test]
        public void TestIfComputerConstroctorWorksCorrectly()
        {
            Computer computer = new Computer("Martin");
            Assert.AreEqual("Martin", computer.Name);
        }
        [Test]
        public void ShouldComputerConstroctorThrownExceptionForNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = new Computer(null);
            });
        }
        [Test]
        public void ShouldComputerConstructorThrowExceptionforWhiteSpace()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = new Computer(" ");
            });
        }
        [Test]
        public void ShouldCountParts()
        {
            Computer computer = new Computer("Martin");
            Assert.AreEqual(0, computer.Parts.Count);
        }
        [Test]
        public void ShouldGetTotalPrice()
        {
            Computer computer = new Computer("Martin");
            computer.AddPart(this.part);
            computer.AddPart(new Part("asd",5));
            Assert.AreEqual(10, computer.TotalPrice);
        }
        [Test]
        public void TestAddPartShouldWork()
        {
            Computer computer = new Computer("Martin");
            computer.AddPart(this.part);
            Assert.AreEqual(1, computer.Parts.Count);
        }
        [Test]
        public void AddPartShouldThrowException()
        {
            Computer computer = new Computer("Martin");
            Part part = null;

            Assert.Throws<InvalidOperationException>(() =>
            {
                computer.AddPart(part);
            });
        }
        [Test]
        public void RemovePartShouldWork()
        {
            Computer computer = new Computer("Martin");
            computer.AddPart(this.part);
            computer.RemovePart(this.part);
            Assert.AreEqual(0, computer.Parts.Count);
        }
        [Test]
        public void RemovePart()
        {
            Computer computer = new Computer("Martin");
            computer.AddPart(this.part);
            Part part = new Part("asdasdas", 12312);
            Assert.AreEqual(false, computer.RemovePart(part));
        }
        [Test]
        public void GetPartShouldWork()
        {
            Computer computer = new Computer("Martin");
            computer.AddPart(this.part);
            Part expected = computer.GetPart("Martin");
            Assert.AreEqual(expected,this.part);

        }
        [Test]
        public void GetPartShouldReturnNull()
        {
            Computer computer = new Computer("Martin");
            Part part = new Part("asd",5);
            computer.AddPart(part);
           Part actual =  computer.GetPart("ertert");
            Assert.AreEqual(null, actual);
        }
    }
}