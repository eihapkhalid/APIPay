using Moq;
using APIPay.ApiControllers;
using Bl;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Domains;
using static Bl.IBusinessLayer;

namespace UnitTests
{
    [TestClass]
    public class UsersTests
    {
        #region dependency injection region
        private readonly UsersController _controller;
        private readonly Mock<IBusinessLayer<TbUser>> _mockUsersBusinessLayer;
        
        public UsersTests()
        {
            _mockUsersBusinessLayer = new Mock<IBusinessLayer<TbUser>>();
            _controller = new UsersController
                (
                    _mockUsersBusinessLayer.Object
                );
        }
        #endregion

        [TestMethod]
        #region GetAllUsers
        public void GetAllUsers_ReturnsListOfUsers()
        {
            // Arrange
            var expectedUsers = new List<TbUser>
                    {
                        new TbUser { UserId = 1, UserName = "User1", Password="123", Email="eihap@gmail.com", CurrentState = 1 },
                        new TbUser { UserId = 2, UserName = "User2", Password="777", Email="omerf@gmail.com", CurrentState = 1 }
                    };
            _mockUsersBusinessLayer.Setup(b => b.GetAll()).Returns(expectedUsers);
            // Act
            var result = _controller.Get();

            // Assert
            Assert.AreEqual(expectedUsers, result);
        }
        #endregion

        [TestMethod]
        #region GetUserById
        public void GetUserById_ReturnsUser()
        {
            // Arrange
            var userId = 1;
            var expectedUser = new TbUser { UserId = userId, UserName = "User1", Password = "123", Email = "eihap@gmail.com", CurrentState = 1 };
            _mockUsersBusinessLayer.Setup(b => b.GetById(userId)).Returns(expectedUser);

            // Act
            var result = _controller.Get(userId);

            // Assert
            Assert.AreEqual(expectedUser, result);
        }
        #endregion

        [TestMethod]
        #region AddsNewUser
        public void Post_AddsNewUser()
        {
            // Arrange
            var newUser = new TbUser { UserId = 1, UserName = "User1", Password = "123", Email = "eihap@gmail.com", CurrentState = 1 };

            // Act
            _controller.Post(newUser);

            // Assert
            _mockUsersBusinessLayer.Verify(b => b.Save(newUser), Times.Once);
        }
        #endregion

    }
}
