using Domain.Errors;

namespace Domain.Errors;

public static class DomainError
{
    public static class General
    {
        public static string ValueIsRequired(string fieldName)
            => $"Поле {fieldName} не может быть пустым!";
        
        public static string InvalidMinLenght(string fieldName, int minLenght) 
            => $"Поле {fieldName} должно быть не менее {minLenght} символов!";
        
        public static string InvalidMaxLenght(string fieldName, int maxLenght) 
            => $"Поле {fieldName} должно быть не более {maxLenght} символов!";

        public static string ValueIsInvalid(string fieldName)
            => $"Поле {fieldName} имеет некорректные данные!";
    }

    public static class Password
    {
        public static string NotConfirmed = "Пароли не совпадают!";
    }
}