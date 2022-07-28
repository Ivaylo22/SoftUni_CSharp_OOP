using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes.Utilities
{

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool IsValid(object obj)
        {
            if (obj is string str)
            { 
                return !string.IsNullOrEmpty(str);
            }
            return obj != null;
        }
    }
}
