using System.ComponentModel.DataAnnotations;

namespace NMT_Counter.Models;
public enum SubjectsViewModel
{
    [Display(Name = "Українська мова")]
    Ukrainian,
    [Display(Name = "Математика")]
    Math,
    [Display(Name = "Історія України")]
    History,
    [Display(Name = "Англійська мова")]
    English,
    [Display(Name = "Фізика")]
    Physics,
    [Display(Name = "Біологія")]
    Biology,
    [Display(Name = "Хімія")]
    Chemistry
}
