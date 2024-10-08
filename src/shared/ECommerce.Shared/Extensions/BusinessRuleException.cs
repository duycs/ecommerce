using ECommerce.Shared.Exceptions;
using System;

namespace ECommerce.Shared.Extensions
{
    public class BusinessRuleException : Exception
    {
        public BusinessRule Rule { get; private set; }

        public object ReferenceData { get; private set; }

        public BusinessRuleException(int violatedRuleCode)
            : base(BusinessRule.GetErrorMessage(violatedRuleCode))
        {
            Rule = BusinessRule.GetRule(violatedRuleCode);
        }

        public BusinessRuleException(BusinessRule rule)
            : base(rule.Message)
        {
            Rule = rule;
        }

        public BusinessRuleException(BusinessRule rule, object referenceData)
            : base(rule.Message)
        {
            Rule = rule;
            ReferenceData = referenceData;
        }
    }
}
