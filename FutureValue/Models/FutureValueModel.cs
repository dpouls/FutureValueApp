using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace FutureValue.Models
{
    public class FutureValueModel
    {
        //Makes this input required
        [Required(ErrorMessage ="Please enter a monthly investment")]
        //specifies the range and gives an error if not met
        [Range(1,500, ErrorMessage ="Monthly investment amount must be between 1 and 500")]
        //public property for MonthlyInvestment
        public decimal? MonthlyInvestment { get; set; }
        //Makes this input required
        [Required(ErrorMessage = "Please enter a yearly interest rate")]
        //specifies the range and gives an error if not met
        [Range(.1, 10, ErrorMessage = "Yearly interest rate must be between .1 and 10.0")]
        //public property for Yearly Interest Rate
        public decimal? YearlyInterestRate { get; set; }
        //Makes this input required
        [Required(ErrorMessage = "Please enter the number of years")]
        //specifies the range and gives an error if not met
        [Range(1, 50, ErrorMessage = "Number of years must be between 1 and 50.")]
        //public property for Years
        public int? Years { get; set; }
        /// <summary>
        /// Takes property values and calculates the future value.
        /// </summary>
        /// <returns></returns>
        public decimal? CalculateFutureValue()
        {
            //nullable value months is years times 12
            int? months = Years * 12;
            //nullable value monthlyInterestRate is the yearly interest rate divided by 1200
            decimal? monthlyInterestRate = YearlyInterestRate / 12 / 100;
            //nullable value for future value starts at 0 but will be changed later
            decimal? futureValue = 0;
            //for loop to add to the future value the monthly investment and the accruing interest
            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + MonthlyInvestment) + (1 + monthlyInterestRate);
            }
            //returns future value.
            return futureValue;
        }
    }
}
