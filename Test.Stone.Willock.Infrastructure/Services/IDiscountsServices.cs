using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Stone.Willock.Infrastructure.Services
{
    public interface IDiscountsServices
    {
        decimal InssDiscount(decimal grossSalary);
        decimal IncomeTaxDiscount(decimal grossSalary);
        decimal HealthPlan();
        decimal DentalPlan();
        decimal TransportVoucher(decimal grossSalary);
        decimal FgtsDiscount(decimal grossSalary);
    }
}
