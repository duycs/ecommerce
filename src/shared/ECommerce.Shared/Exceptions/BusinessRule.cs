using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Shared.Exceptions
{
    public class BusinessRule
    {
        public static List<BusinessRule> All = new List<BusinessRule>();

        public int Code { get; private set; }

        public string Message { get; private set; }

        public static BusinessRule RegisterRule(int code, string message)
        {
            BusinessRule businessRule = All.FirstOrDefault((BusinessRule t) => t.Code == code);
            if (businessRule == null)
            {
                businessRule = new BusinessRule(code, message);
                All.Add(businessRule);
            }

            return businessRule;
        }

        public static string GetErrorMessage(int code)
        {
            return All.FirstOrDefault((BusinessRule t) => t.Code == code)?.Message;
        }

        public static BusinessRule GetRule(int code)
        {
            return All.FirstOrDefault((BusinessRule t) => t.Code == code);
        }

        public BusinessRule(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
