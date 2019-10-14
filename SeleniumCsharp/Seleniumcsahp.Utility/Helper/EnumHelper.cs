using Microsoft.VisualBasic;
using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

public class EnumHelper
{

    public static string GetEnumDescription(System.Enum enumType, string value)
    {
        System.Type _enumType = enumType.GetType();
        if (_enumType == null)
        {
            throw new Exception("Type '" + enumType.ToString() + "' not found");
        }
        
        return GetEnumDescription(_enumType.GetField(value.ToString()));
    }

    public static string GetEnumDescription(System.Type enumType, string value)
    {
        System.Type _enumType = enumType;
        if (_enumType == null)
        {
            throw new Exception("Type '" + enumType.ToString() + "' not found");
        }

        return GetEnumDescription(_enumType.GetField(value.ToString()));
    }

    public static string GetEnumDescription(System.Enum value)
    {
        Assembly _Assembly = System.Reflection.Assembly.GetExecutingAssembly();

        System.Type _enumType = _Assembly.GetType(_Assembly.GetName().Name + "." + value.GetType().Name);
        if (_enumType == null)
        {
            throw new Exception("Type '" + value.ToString() + "' not found");
        }

        return GetEnumDescription(_enumType.GetField(value.ToString()));
    }

    public static string GetEnumDescription(System.Reflection.FieldInfo field)
    {

        // Get the array of description attributes applied (there will be 0 or 1)  
        object[] descriptions = null;
        descriptions = field.GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);

        // If there was a description, return it  
        if (descriptions.Length > 0)
        {
            return ((System.ComponentModel.DescriptionAttribute)descriptions[0]).Description;
        }

        // Otherwise return the field's name  
        return field.Name;
    }

}
