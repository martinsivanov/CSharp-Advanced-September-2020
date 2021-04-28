using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        Computer computer;
        [SetUp]
        public void Setup()
        {
            computer = new Computer("asd", "qwe", 50);
        }

        [Test]
        [TestCase(null,null,0)]
        [TestCase("qwe","asd",0)]
        [TestCase("gh",null,0)]
        [TestCase(null,"5",-6)]
        public void TestIfComputerConstructorWorksCorrect(string manuf,string model,decimal price)
        {
            var comp = new Computer(manuf, model, price);

            Assert.AreEqual(manuf, comp.Manufacturer);
            Assert.AreEqual(model, comp.Model);
            Assert.AreEqual(price, comp.Price);

        }
        [Test]
        public void TestComputerManagerConstructorIfWorks()
        {
            ComputerManager computerManager = new ComputerManager();
            Assert.AreEqual(0, computerManager.Count);
        }
        [Test]
        public void TestAddComputerMethodWorksCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();

            computerManager.AddComputer(this.computer);
            Assert.AreEqual(1, computerManager.Count);
        }
        [Test]
        public void TestAddoComputerMEthodWithNull()
        {
            ComputerManager computerManager = new ComputerManager();
            Computer computer = null;
            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.AddComputer(computer); // TODO:
            });
        }
        [Test]
        public void TestAddComputerMethodWithSameComputer()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);
            Computer computer = new Computer("asd", "qwe", 3);

            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.AddComputer(computer);

            });
        }
        [Test]
        public void TestRemoveMethodWorksCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            computerManager.RemoveComputer("asd","qwe");

            Assert.AreEqual(0, computerManager.Count);
        }

        [Test]
        public void TestRemoveComputerMethodExceptions()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentException>(() =>
            {
                computerManager.RemoveComputer("123", "4124");
            });
        }
        [Test]
        public void TestRemoveComputerMethodExceptionsWithNull()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.RemoveComputer(null, null);
            });
        }
        [Test]
        public void TestRemoveComputerMethodExceptionsWthNull()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.RemoveComputer("asd", null);
            });
        }
        [Test]
        public void TestRemoveComputerMesdExceptionsWithNull()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentNullException>(() =>
            {
                computerManager.RemoveComputer(null, "a65");
            });
        }
        [Test]
        public void TestRemoveComputerMethodThrowException()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);
            Assert.Throws<ArgumentException>(() => 
            {
                computerManager.RemoveComputer("gh", "lj");
            });
        }
        [Test]
        public void TestGetComputerWorksCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);
            Computer computer = computerManager.GetComputer("asd", "qwe");
            Assert.AreEqual("asd", computer.Manufacturer);
            Assert.AreEqual("qwe", computer.Model);
        }
        [Test]
        public void TestGetComputerThrowException()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);

            Assert.Throws<ArgumentException>(() =>
            {
                Computer computer = computerManager.GetComputer("123", "321");
            });

        }
        [Test]
        public void TestGetComputerThrowExceptionforNullManufactor()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);
            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = computerManager.GetComputer(null, "321");
            });
        }

        [Test]
        public void TestGetComputerThrowExceptionforNullModel()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);
            Assert.Throws<ArgumentNullException>(() =>
            {
                Computer computer = computerManager.GetComputer("asd", null);
            });
        }
        [Test]
        public void TestGetComputersByManufacturerWorksCorrectly()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);
            var list = computerManager.GetComputersByManufacturer("asd").ToList();
            Assert.AreEqual(1, list.Count);
        }
        [Test]
        public void TestGetComputersByManufacturerThrowsException()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);
            Assert.Throws<ArgumentNullException>(() =>
            {
                var list = computerManager.GetComputersByManufacturer(null);
            });
        }
        [Test]
        public void TestCollectionIReadOnly()
        {
            ComputerManager computerManager = new ComputerManager();
            computerManager.AddComputer(this.computer);
          int expection =   computerManager.Computers.Count;
            Assert.AreEqual(expection, 1);
        }
      
    }
}