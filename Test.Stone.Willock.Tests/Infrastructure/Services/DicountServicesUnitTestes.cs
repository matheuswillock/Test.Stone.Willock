using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Stone.Willock.Infrastructure.Services;

namespace Test.Stone.Willock.Tests.Infrastructure.Services
{
    public class DicountServicesUnitTestes
    {
        private readonly DiscountsServices _discountsServices;

        public DicountServicesUnitTestes()
        {
            _discountsServices = new DiscountsServices();
        }

        [Theory]
        [InlineData(1000, 75)]
        [InlineData(2000, 180)]
        [InlineData(3000, 360)]
        [InlineData(4000, 560)]
        [InlineData(7000, 980)]
        public void InssDiscount_ShouldCalculateCorrectly(decimal grossSalary, decimal expected)
        {
            var result = _discountsServices.InssDiscount(grossSalary);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1000, 0)]
        [InlineData(2000, 150)]
        [InlineData(3000, 450)]
        [InlineData(4000, 900)]
        [InlineData(7000, 1925)]
        public void IncomeTaxDiscount_ShouldCalculateCorrectly(decimal grossSalary, decimal expected)
        {
            var result = _discountsServices.IncomeTaxDiscount(grossSalary);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void HealthPlan_ShouldReturn10()
        {
            var result = _discountsServices.HealthPlan();
            Assert.Equal(10, result);
        }

        [Fact]
        public void DentalPlan_ShouldReturn5()
        {
            var result = _discountsServices.DentalPlan();
            Assert.Equal(5, result);
        }

        [Theory]
        [InlineData(1000, 0)]
        [InlineData(2000, 120)]
        public void TransportVoucher_ShouldCalculateCorrectly(decimal grossSalary, decimal expected)
        {
            var result = _discountsServices.TransportVoucher(grossSalary);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(1000, 80)]
        [InlineData(2000, 160)]
        public void FgtsDiscount_ShouldCalculateCorrectly(decimal grossSalary, decimal expected)
        {
            var result = _discountsServices.FgtsDiscount(grossSalary);
            Assert.Equal(expected, result);
        }
    }
}
