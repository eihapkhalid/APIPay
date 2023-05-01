using Domains;
using Moq;
using APIPay.ApiControllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Bl.IBusinessLayer;

namespace UnitTests
{
    public class PaymentTests
    {
        #region dependency injection region
        private readonly PaymentsController _controller;
        private readonly Mock<IBusinessLayer<TbPayment>> _mockPaymentsBusinessLayer;

        public PaymentTests()
        {
            _mockPaymentsBusinessLayer = new Mock<IBusinessLayer<TbPayment>>();
            _controller = new PaymentsController
                (
                    _mockPaymentsBusinessLayer.Object
                );
        }
        #endregion

        [TestMethod]
        #region GetAllPayments
        public void GetAllPayments_ReturnsListOfPayments()
        {
            // Arrange
            var expectedPayments = new List<TbPayment>
                    {
                        new TbPayment { PaymentId = 1, TransactionNumber = "User1", Currency="SDG", Amount = (decimal)700.5, CurrentState = 1 },
                        new TbPayment { PaymentId = 2, TransactionNumber = "User2", Currency="AUE", Amount = (decimal)50.05, CurrentState = 1 }
                    };
            _mockPaymentsBusinessLayer.Setup(b => b.GetAll()).Returns(expectedPayments);
            // Act
            var result = _controller.Get();

            // Assert
            Assert.AreEqual(expectedPayments, result);
        }
        #endregion

        [TestMethod]
        #region GetPaymentById
        public void GetPaymentById_ReturnsPayment()
        {
            // Arrange
            var PaymentId = 1;
            var expectedPayments = new TbPayment { PaymentId = 1, TransactionNumber = "User1", Currency = "SDG", Amount = (decimal)700.5, CurrentState = 1 };
            _mockPaymentsBusinessLayer.Setup(b => b.GetById(PaymentId)).Returns(expectedPayments);

            // Act
            var result = _controller.Get(PaymentId);

            // Assert
            Assert.AreEqual(expectedPayments, result);
        }
        #endregion

    }
}
