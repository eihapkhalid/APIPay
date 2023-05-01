using Moq;
using APIPay.ApiControllers;
using Bl;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Domains;
using static Bl.IBusinessLayer;

namespace UnitTests
{
    public class BankAccountTests
    {

        #region dependency injection region
        private readonly BankAccounsController _controller;
        private readonly Mock<IBusinessLayer<TbBankAccount>> _mockBankAccountBusinessLayer;

        public BankAccountTests()
        {
            _mockBankAccountBusinessLayer = new Mock<IBusinessLayer<TbBankAccount>>();
            _controller = new BankAccounsController
                (
                    _mockBankAccountBusinessLayer.Object
                );
        }
        #endregion

        [TestMethod]
        #region GetAllBankAccounts
        public void GetAllBankAccounts_ReturnsListOfBankAccounts()
        {
            // Arrange
            var expectedBankAccounts = new List<TbBankAccount>
                    {
                        new TbBankAccount {  UserId = 1, AccountNumber = "1234567891011121344", BankName="bank1", BranchNumber="Sudan", Balance =(decimal)200.25, CurrentState = 1 },
                        new TbBankAccount {  UserId = 1, AccountNumber = "9867510531011121344", BankName="bank2", BranchNumber="Saudi", Balance =(decimal)10.25F, CurrentState = 1 }
                    };
            _mockBankAccountBusinessLayer.Setup(b => b.GetAll()).Returns(expectedBankAccounts);
            // Act
            var result = _controller.Get();

            // Assert
            Assert.AreEqual(expectedBankAccounts, result);
        }
        #endregion

        [TestMethod]
        #region GetBankAccountById
        public void GetBankAccountById_ReturnsUser()
        {
            // Arrange
            var userId = 1;
            var expectedBankAccount = new TbBankAccount { UserId = 1, AccountNumber = "1234567891011121344", BankName = "bank1", BranchNumber = "Sudan", Balance = (decimal)200.25, CurrentState = 1 };
            _mockBankAccountBusinessLayer.Setup(b => b.GetById(userId)).Returns(expectedBankAccount);

            // Act
            var result = _controller.Get(userId);

            // Assert
            Assert.AreEqual(expectedBankAccount, result);
        }
        #endregion
    }
}
