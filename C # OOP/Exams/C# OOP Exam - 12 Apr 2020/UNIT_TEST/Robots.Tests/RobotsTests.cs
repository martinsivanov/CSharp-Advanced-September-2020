namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        [Test]
        [TestCase(null, 0)]
        [TestCase(null, null)]
        [TestCase("martin", 12)]
        public void TestRobotConstructor(string name, int maxBattery)
        {
            Robot robot = new Robot(name, maxBattery);

            Assert.AreEqual(name, robot.Name);
            Assert.AreEqual(maxBattery, robot.MaximumBattery);
            Assert.AreEqual(maxBattery, robot.Battery);
        }
        [Test]
        [TestCase(0)]
        [TestCase(5)]
        public void ShouldRobotManagerWorksCorrectly(int capacity)
        {
            Robot robot = new Robot("asd", 5);
            RobotManager robotManager = new RobotManager(capacity);
            Assert.AreEqual(capacity, robotManager.Capacity);
        }
        
        [Test]
        public void RobotManagerCapacityShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                RobotManager robotManager = new RobotManager(-5);
            });
        }
        [Test]
        public void RobotManager()
        {
            Robot robot = new Robot("asd", 5);
            RobotManager robotManager = new RobotManager(2);
            Assert.AreEqual(0, robotManager.Count);
        }
        [Test]
        [TestCase("marti", 1)]
        [TestCase("mrti", 2)]
        [TestCase("mati", 3)]
        public void TestAddMethotShouldWork(string name, int maxBattery)
        {
            Robot robot = new Robot(name, maxBattery);
            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robot);
            Assert.AreEqual(1, robotManager.Count);
        }
      
        [Test]
        public void TestAddMethodSholdThrowInvalidOperationException()
        {
            Robot robot = new Robot("martin", 5);
            RobotManager robotManager = new RobotManager(5);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot);
            });
        }
        [Test]
        public void TestAddMethodSholdThrowInvalidOperationExceptionForFullCapacity()
        {
            Robot robot = new Robot("mrtin", 5);
            RobotManager robotManager = new RobotManager(0);
           
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Add(robot);
            });
        }
        [Test]
        public void TestRemoveMethodWorkCorrect()
        {
            Robot robot = new Robot("mrtin", 5);
            RobotManager robotManager = new RobotManager(2);
            robotManager.Add(robot);
            string robotToRemove = "mrtin";
            robotManager.Remove(robotToRemove);
            Assert.AreEqual(0, robotManager.Count);
        }
        [Test]
        public void TestRemoveMethodThrowException()
        {
            Robot robot = new Robot("mrtin", 5);
            RobotManager robotManager = new RobotManager(6);
            robotManager.Add(robot);
            string robotToRemove = "polina";
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Remove(robotToRemove);

            });
        }
        [Test]
        public void TestWorkMethodCorrectly()
        {
            Robot robot = new Robot("mrtin", 10);
            RobotManager robotManager = new RobotManager(6);
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "kopane", 5);
            Assert.AreEqual(5, robot.Battery);
        }
        [Test]
        public void TestWorkMethodNotExistThrowException()
        {
            Robot robot = new Robot("mrtin", 5);
            RobotManager robotManager = new RobotManager(6);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work("nqma me", "kopane", 2);
            });
        }
        [Test]
        public void TestWorkMethodLowBatteryThrowException()
        {
            Robot robot = new Robot("mrtin", 5);
            RobotManager robotManager = new RobotManager(6);
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Work(robot.Name, "kopane", 200);
            });
        }
      
        [Test]
        public void TestChargeMethodThrowException()
        {
            Robot robot = new Robot("mrtin", 5);
            RobotManager robotManager = new RobotManager(6);
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() =>
            {
                robotManager.Charge("nqma me");
            });
         
        }
        [Test]
        public void TestChargeMethodWorksCorrectly()
        {
            Robot robot = new Robot("mrtin", 10);
            RobotManager robotManager = new RobotManager(6);
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "job", 5);
            robotManager.Charge("mrtin");
            Assert.AreEqual(10, robot.Battery);
        }

    }
}
