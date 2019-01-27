
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace MVC_Simple_Calculator.Models.Service
{
    public interface ICalculate<T> 
    {
        [Required(ErrorMessage ="Данное поле обязательно для заполнения")]
        [DisplayName("Операция")]
        char Operation_symbol { get; }
        [DisplayName("Результат")]
        T Result { get; set; }
        [DisplayName("Первое значение")]
        T A_number { get; set; }
        [DisplayName("Второе значение")]
        T B_number { get; set; }
        T ResultOperation(T first_number, T last_number);
        T ResultOperation();
    }
}
