using System.Reflection;

namespace Goldsmith.TestUtils; // you might want to rename this

public static class GrossHack
{
    // no gross hacks here, sorry
	// they have gone missing in the time the tests were created

    public static (bool Found, Jewelry Jewelry) SearchForJewelryNice(this Workshop w, int id) =>
        w.TranslateBoolXType<Workshop, Jewelry>("SearchForJewelry",
            AllowedSignatures.BothOutParam | AllowedSignatures.OutParamNullable | AllowedSignatures.ReturnBoolOutParam |
            AllowedSignatures.ReturnNullable | AllowedSignatures.ReturnTuple,
            BindingFlags.Public | BindingFlags.Instance,
            [typeof(int)], [id]);
    
    public static (bool, TReturn) TranslateBoolXType<TObject, TReturn>(this TObject obj, string methodName, AllowedSignatures allowedSignatures, BindingFlags bindingFlags, Type[] argTypes, params object?[] paramList)
    {
        Type[] realArgTypes = argTypes.ToArray();
        MethodInfo? method = typeof(TObject).GetMethod(methodName, bindingFlags, realArgTypes);
        if ((allowedSignatures & AllowedSignatures.ReturnNullable) != 0 && method != null && method.ReturnType == typeof(TReturn))
        {
            TReturn? retval = (TReturn?)method.Invoke(obj, paramList);
            return (retval != null, retval!);
        } 
        if ((allowedSignatures & AllowedSignatures.ReturnTuple) != 0 && method != null)
        {
            if (method.ReturnType == typeof(ValueTuple<bool, TReturn>))
            {
                return (ValueTuple<bool, TReturn>)method.Invoke(obj, paramList)!;
            }
            if (method.ReturnType == typeof(Tuple<bool, TReturn>))
            {
                return ((Tuple<bool, TReturn>)method.Invoke(obj, paramList)!).ToValueTuple();
            }
        }
        
        realArgTypes = argTypes.Concat(new[] { typeof(TReturn).MakeByRefType() }).ToArray();
        method = typeof(TObject).GetMethod(methodName, bindingFlags, realArgTypes);
        if ((allowedSignatures & AllowedSignatures.OutParamNullable) != 0 && method != null && method.ReturnType == typeof(void))
        {
            object?[] realParamList = paramList.Concat(new object?[] { null }).ToArray();
            method.Invoke(obj, realParamList);
            return (realParamList[^1] != null, (TReturn)realParamList[^1]!);
        }

        realArgTypes = argTypes.Concat(new[] { typeof(TReturn).MakeByRefType() }).ToArray();
        method = typeof(TObject).GetMethod(methodName, bindingFlags, realArgTypes);
        if ((allowedSignatures & AllowedSignatures.ReturnBoolOutParam) != 0 && method != null && method.ReturnType == typeof(bool))
        {
            object?[] realParamList = paramList.Concat(new object?[] { null }).ToArray();
            bool result = (bool)method.Invoke(obj, realParamList)!;
            return (result, (TReturn)realParamList[^1]!);
        }
        
        realArgTypes = argTypes.Concat(new[] { typeof(bool).MakeByRefType(), typeof(TReturn).MakeByRefType() }).ToArray();
        method = typeof(TObject).GetMethod(methodName, bindingFlags, realArgTypes);
        if ((allowedSignatures & AllowedSignatures.BothOutParam) != 0 && method != null && method.ReturnType == typeof(void))
        {
            object?[] realParamList = paramList.Concat(new object?[] { false, null }).ToArray();
            method.Invoke(obj, realParamList);
            return ((bool)realParamList[^2]!, (TReturn)realParamList[^1]!);
        }
        
        throw new NotSupportedException("Unknown calling convention");
    }

    public static object GetSingletonInstance(this Type type)
    {
        PropertyInfo? prop = type.GetProperties(BindingFlags.Static | BindingFlags.Public)
            .FirstOrDefault(prop => prop?.PropertyType == type, null);
        if (prop != null)
        {
            object? value = prop.GetValue(null);
            if (value == null) throw new InvalidOperationException($"Property {prop.Name} of type {type.FullName} returned null");
            return value;
        }
        MethodInfo? meth = type.GetMethods(BindingFlags.Static | BindingFlags.Public)
            .FirstOrDefault(method => method?.ReturnType == type, null);
        if (meth != null)
        {
            object? value = meth.Invoke(null, null);
            if(value == null) throw new InvalidOperationException($"Method {meth.Name} of type {type.FullName} returned null");
            return value;
        }
        throw new NotSupportedException($"Could not find singleton instance property or method on type {type.FullName}");
    }

    [Flags]
    public enum AllowedSignatures
    {
        ReturnNullable = 1 << 0,
        OutParamNullable = 1 << 1,
        ReturnBoolOutParam = 1 << 2,
        BothOutParam = 1 << 3,
        ReturnTuple = 1 << 4,
    }
}
