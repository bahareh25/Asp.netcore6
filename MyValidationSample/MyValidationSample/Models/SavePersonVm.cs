using Microsoft.AspNetCore.Mvc;
using MyValidationSample.Infra;
using System.ComponentModel.DataAnnotations;

namespace MyValidationSample.Models
{
    public class SavePersonVm
    {
        [Remote("CheckName", "Person",ErrorMessage ="نام کاربری قبلا ذخیره شده است")]
        public string UserName { get; set; }
        [StringLength(20,MinimumLength =2)]
        public string FirstName { get; set; }
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }
        [StringLength(20, MinimumLength = 8)]
        public string Password { get; set; }
        [StringLength(20, MinimumLength = 8)]
        [Compare("Password")]
        public string RepeatPassword { get; set; }

        [EmailAddress(ErrorMessage ="یک ایمیل صحیح وارد کنید")]
        public string Email { get; set; }
    }
    public class EditPersonVm
    {
        [CustomValidator(DbContextType =typeof(ValidationDbContex),DataType =typeof(Person),ErrorMessage ="شخصی با این شناسه وجود ندارد")]
        public int Id { get; set; }
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }
        
    }
}
