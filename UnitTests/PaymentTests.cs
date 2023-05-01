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
    }
}
