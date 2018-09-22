using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ASP_Net_Rest.Controllers
{
  [Route("api/[controller]")]
  public class CalculatorController : Controller
  {
    // GET api/Calculator/5/5
    [HttpGet("{firstNumber}/{secondNumber}")]
    public IActionResult Sum(string firstnumber, string secondnumber)
    {
      if (IsNumeric(firstnumber) && IsNumeric(secondnumber))
      {
        var sum = ConvertToDecimal(firstnumber) + ConvertToDecimal(secondnumber);
        return Ok(sum.ToString());
      }

      return BadRequest("Invalid Input");
    }

    private decimal ConvertToDecimal(string number)
    {
      decimal decimalValue;
      if (decimal.TryParse(number, out decimalValue))
        return decimalValue;
      return default(decimal);

      throw new NotImplementedException();
    }

    private bool IsNumeric(string numberSting)
    {
      double number;

      return double.TryParse(numberSting, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out number);
    }
  }
}
