using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CalculatorOPG.Models {
    public class OperatorsViewModel {

        [Required(ErrorMessage = "Vælg en operation")]
        public string? SelectedOperator { get; set; }

        public IEnumerable<SelectListItem>? Operators { get; set; }

        public double? OperandOne { get; set; }

        public double? OperandTwo { get; set; }

        public string? Result { get; set; }
    }
}