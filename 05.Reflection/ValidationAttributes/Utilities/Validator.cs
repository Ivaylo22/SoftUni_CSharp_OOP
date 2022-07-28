﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ValidationAttributes.Utilities
{
    public static class Validator 
    {
        public static bool IsValid(object obj)
        {

            Type objType = obj.GetType();
            PropertyInfo[] properties = objType
                .GetProperties()
                .Where(pi => pi.CustomAttributes.Any(a => a.AttributeType.BaseType == typeof(MyValidationAttribute)))
                .ToArray();

            foreach (PropertyInfo propertyInfo in properties)
            {
                object propValue = propertyInfo.GetValue(obj);

                foreach (CustomAttributeData customAttributeData in propertyInfo.CustomAttributes)
                {
                    Type customAtributeType = customAttributeData.AttributeType;
                    object attributeInstance = propertyInfo
                        .GetCustomAttribute(customAtributeType);

                    MethodInfo validationMethod = customAtributeType
                        .GetMethods()
                        .First(m => m.Name == "IsValid");
                    bool result = (bool)validationMethod.Invoke(attributeInstance, new object[] { propValue });
                    if (!result) 
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
