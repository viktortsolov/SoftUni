using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddItemShouldThrowArgumentExceptionWhenCellKeyIsInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Item item = new Item("Viki", "1234");
                BankVault bankVault = new BankVault();

                bankVault.AddItem("A5", item);
            });
        }
        [Test]
        public void AddItemShouldThrowArgumentExceptionWhenCellIsTaken()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Item item = new Item("Viki", "1234");
                BankVault bankVault = new BankVault();

                bankVault.AddItem("A1", item);
                bankVault.AddItem("A1", item);
            });
        }
        [Test]
        public void AddItemShouldThrowInvalidOperationExceptionWhenItemIsAlreadyAtCell()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Item item = new Item("Viki", "1234");
                BankVault bankVault = new BankVault();

                bankVault.AddItem("A1", item);
                bankVault.AddItem("A2", item);
            });
        }
        [Test]
        public void AddItemShouldWork()
        {
            Item item = new Item("Viki", "1234");
            BankVault bankVault = new BankVault();

            var actualResult = bankVault.AddItem("A1", item);
            var expectedResult = $"Item:{item.ItemId} saved successfully!";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void RemoveItemShouldThrowArgumentExceptionWhenCellKeyIsInvalid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Item item = new Item("Viki", "1234");
                BankVault bankVault = new BankVault();

                bankVault.RemoveItem("A5", item);
            });
        }
        [Test]
        public void RemoveItemShouldThrowArgumentExceptionWhenItemDoesntExist()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Item item = new Item("Viki", "1234");
                BankVault bankVault = new BankVault();

                bankVault.RemoveItem("A1", item);
            });
        }
        [Test]
        public void RemoveItemShouldWork()
        {
            Item item = new Item("Viki", "1234");
            BankVault bankVault = new BankVault();

            bankVault.AddItem("A1", item);

            var actualResult = bankVault.RemoveItem("A1", item);
            var expectedResult = $"Remove item:{item.ItemId} successfully!";

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}