using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault bankVault;
        [SetUp]
        public void Setup()
        {
            this.item = new Item("Martin", "asd");
            this.bankVault = new BankVault();
        }

        [Test]
        public void TestItem()
        {
            Item item = new Item("asd", "1");
            Assert.AreEqual("asd", item.Owner);
            Assert.AreEqual("1", item.ItemId);
        }
        [Test]
        public void TestBank1()
        {
            this.bankVault = new BankVault();
            Assert.IsNotNull(bankVault);
        }
        [Test]
        public void TestBank2()
        {
            this.bankVault = new BankVault();
            Assert.AreEqual(12, bankVault.VaultCells.Count);
        }
        [Test]
        public void TestAddItem1()
        {
            this.bankVault = new BankVault();
            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.AddItem("123", this.item);

            });
        }
        [Test]
        public void TestAddItem2()
        {
            this.bankVault = new BankVault();
            bankVault.AddItem("B2", this.item);

            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.AddItem("B2", this.item);
            });

        }
        [Test]
        public void TestAddItem3()
        {
            this.bankVault = new BankVault();
            Item item = new Item("q", "123");
            Item item2 = new Item("re", "123");
            bankVault.AddItem("B2", item);
            Assert.Throws<InvalidOperationException>(() =>
            {
                bankVault.AddItem("B1", item2);
            });

        }
        [Test]
        public void TestAddItem4()
        {
            this.bankVault = new BankVault();
            Item item = new Item("q", "123");
            Item item2 = new Item("re", "78");
            bankVault.AddItem("B2", item);
            bankVault.AddItem("B1", item2);
            Assert.AreEqual(item.ItemId, bankVault.VaultCells["B2"].ItemId);

        }
        [Test]
        public void TestRemoveItem1()
        {
            this.bankVault = new BankVault();
            Item item = new Item("q", "123");
            Item item2 = new Item("re", "78");
            bankVault.AddItem("B2", item);

            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.RemoveItem("12312312", item);
            });

        }
        [Test]
        public void TestRemoveItem2()
        {
            this.bankVault = new BankVault();
            Item item = new Item("q", "123");
            Item item2 = new Item("re", "78");
            bankVault.AddItem("B2", item);

            Assert.Throws<ArgumentException>(() =>
            {
                bankVault.RemoveItem("B2", item2);
            });

        }
        [Test]
        public void TestRemoveItem3()
        {
            this.bankVault = new BankVault();
            Item item = new Item("q", "123");
            Item item2 = new Item("re", "78");
            bankVault.AddItem("B2", item);


            bankVault.RemoveItem("B2", item);

            Assert.AreEqual(null, bankVault.VaultCells["B2"]);

        }

    }
}