using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyValidationSample.Infra
{
    public class CustomValidator:ValidationAttribute
    {
        public Type? DbContextType { get; set; }
        public Type? DataType { get; set; }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(DbContextType != null && DataType!= null)
            {
                DbContext dbContext = validationContext.GetRequiredService(DbContextType) as DbContext;
                if (dbContext!=null && dbContext.Find(DataType,value)==null)
                {
                    return new ValidationResult(ErrorMessage ?? $"There is no object with primery key {value}");
                }
            }
            return base.IsValid(value, validationContext);
        }
    }
}
