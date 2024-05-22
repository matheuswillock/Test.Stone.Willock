using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Stone.Willock.Infrastructure.Services
{
    public class DiscountsServices : IDiscountsServices
    {
        public decimal InssDiscount(decimal grossSalary)
        {
            if (grossSalary < 1045)
            {
                return grossSalary * 0.075m;
            }
            else if (grossSalary >= 1045 && grossSalary < (decimal)2089.60)
            {
                return grossSalary * 0.09m;
            }
            else if (grossSalary >= (decimal)2089.60 && grossSalary < (decimal)3134.40)
            {
                return grossSalary * 0.12m;
            }
            else if (grossSalary >= (decimal)3134.41 && grossSalary < (decimal)6101.06)
            {
                return grossSalary * 0.14m;
            }
            else
            {
                return grossSalary * 0.14m;
            }
        }

        public decimal IncomeTaxDiscount(decimal grossSalary)
        {
            if (grossSalary < (decimal)1903.98)
            {
                return 0;
            }
            else if (grossSalary >= (decimal)1903.98 && grossSalary < (decimal)2826.65)
            {
                return grossSalary * 0.075m;
            }
            else if (grossSalary >= (decimal)2826.66 && grossSalary < (decimal)3751.06)
            {
                return grossSalary * 0.15m;
            }
            else if (grossSalary >= (decimal)3751.06 && grossSalary < (decimal)4664.68)
            {
                return grossSalary * 0.225m;
            }
            else
            {
                return grossSalary * 0.275m;
            }
        }

        public decimal HealthPlan() => 10;

        public decimal DentalPlan() => 5;

        public decimal TransportVoucher(decimal grossSalary) => grossSalary >= 1500 ? grossSalary * 0.06m : 0;

        public decimal FgtsDiscount(decimal grossSalary) => grossSalary * 0.08m;
    }
}
