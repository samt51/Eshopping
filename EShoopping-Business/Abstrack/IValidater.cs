using System;
namespace EShoopping_Business.Abstrack
{
    public interface IValidater<T>
    {

       string ErrorMessage { get; set; }
        bool Validate(T entity);
    }
}
