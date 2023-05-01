using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class ClsUsersTests
    {
        #region dependency injection region
        private readonly UsersController _controller;
        private readonly Mock<IBusinessLayer<TbUser>> _mockUsersBusinessLayer;
        
        public ClsUsersTests()
        {
            _mockUsersBusinessLayer = new Mock<IBusinessLayer<TbUser>>();
            _controller = new UsersController
                (
                    _mockUsersBusinessLayer.Object
                );
        }
        #endregion


    }
}
