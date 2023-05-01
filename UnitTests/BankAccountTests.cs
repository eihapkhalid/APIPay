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
    }
}
