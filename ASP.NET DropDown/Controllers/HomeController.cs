using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP.NET_DropDown.Models;
using CalculatorOPG.Models;

public class HomeController : Controller {
    [HttpGet]
    public IActionResult Index() {
        var model = new OperatorsViewModel {
            Operators = GetOperators()
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Index(OperatorsViewModel model) {
        model.Operators = GetOperators();
        ModelState.Remove(nameof(model.Result));

        if (!ModelState.IsValid) {
            return View(model);
        }

        if (model.SelectedOperator == "/" || model.SelectedOperator == "%" && model.OperandTwo == 0) {
            model.Result = "man må ikke sætte 0 som nævner";
            return View(model);
        }

        switch (model.SelectedOperator) {
            case "+": model.Result = (model.OperandOne + model.OperandTwo).ToString(); break;
            case "-": model.Result = (model.OperandOne - model.OperandTwo).ToString(); break;
            case "*": model.Result = (model.OperandOne * model.OperandTwo).ToString(); break;
            case "/": model.Result = (model.OperandOne / model.OperandTwo).ToString(); break;
            case "%": model.Result = (model.OperandOne % model.OperandTwo).ToString(); break;
        }
        return View(model);
    }


    private IEnumerable<SelectListItem> GetOperators() {
        return new List<SelectListItem> {
            new SelectListItem { Value = "+", Text = "+" },
            new SelectListItem { Value = "-", Text = "-" },
            new SelectListItem { Value = "*", Text = "*" },
            new SelectListItem { Value = "/", Text = "/" },
            new SelectListItem { Value = "%", Text = "%" }
        };
    }
}