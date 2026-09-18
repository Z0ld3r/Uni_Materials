using System.Collections.Specialized;
using System.Reflection;

namespace Goldsmith.TestUtils; // you might want to rename this

public static class AssertExtensions
{
    public static void Catch<TEx>(this Assert ass, Action action, string? message = null) where TEx : Exception
    {
        try
        {
            action.Invoke();
        }
        catch (NullReferenceException) // these are mostly exceptions thrown on missing checks so let's exclude them
        {
            throw;
        }
        catch (ArgumentOutOfRangeException)
        {
            throw;
        }
        catch (IndexOutOfRangeException)
        {
            throw;
        }
        catch (TEx)
        {
            return;
        }
        catch (Exception e)
        {
            Assert.Fail($"Unexpected exception (wanted {typeof(TEx).FullName}): {e}");
        }

        Assert.Fail(message ?? $"No {typeof(TEx).FullName} or derivative thrown.");
    }

    public static void CollectionEquals<T>(this Assert ass, ICollection<T> expected, ICollection<T> actual,
        bool ignoreOrder = false)
    {
        if (expected.Count != actual.Count)
            Assert.Fail(
                $"Element counts do not match, expected: [{string.Join(", ", expected)}], actual: [{string.Join(", ", actual)}]");
        if (!ignoreOrder)
        {
            Assert.IsTrue(expected.SequenceEqual(actual), $"Elements do not match, expected: [{string.Join(", ", expected)}], actual: [{string.Join(", ", actual)}]", "");
        }
        Assert.IsTrue(new HashSet<T>(expected).SetEquals(actual), $"Elements do not match, expected: [{string.Join(", ", expected)}], actual: [{string.Join(", ", actual)}]", "");
    }

    public static PropertyInfo HasProperty<T>(this Assert ass, string propName, bool hasPublicGetter, bool hasPublicSetter, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance, string? message = null)
    {
        return ass.HasProperty(typeof(T), propName, hasPublicGetter, hasPublicSetter, bindingFlags, message);
    }
    
    public static PropertyInfo HasProperty(this Assert ass, Type type, string propName, bool hasPublicGetter, bool hasPublicSetter, BindingFlags bindingFlags = BindingFlags.Public | BindingFlags.Instance, string? message = null)
    {
        PropertyInfo? prop =
            type.GetProperty(propName, bindingFlags);
        Assert.IsNotNull(prop, $"{propName} should exist as a property on {type.FullName}");
        Assert.AreEqual(hasPublicGetter, prop!.GetMethod?.IsPublic ?? false, message ?? $"{propName} getter {(hasPublicGetter ? "should" : "should not")} be public", message ?? $"{propName} getter {(hasPublicGetter ? "is" : "is not")} public");
        Assert.AreEqual(hasPublicSetter, prop.SetMethod?.IsPublic ?? false, message ?? $"{propName} setter {(hasPublicSetter ? "should" : "should not")} be public", message ?? $"{propName} setter {(hasPublicSetter ? "is" : "is not")} public");
        return prop;
    }
    
    public static MethodInfo HasMethod<T>(this Assert ass, string methodName, BindingFlags bindingFlags = BindingFlags.Default, string? fail = null, string? success = null)
    {
        MethodInfo? meth =
            typeof(T).GetMethod(methodName, bindingFlags);
        Assert.IsNotNull(meth, fail ?? $"{methodName} missing", success ?? fail ?? $"{methodName} exists");
        return meth!;
    }
    
    public static void IsSubtypeOf(this Assert ass, Type baseType, Type? type)
    {
        Assert.IsNotNull(type, "Type is null!", "");

        if (baseType.IsInterface)
        {
            Assert.IsTrue(type!.GetInterfaces().Contains(baseType),
                $"Type {type.FullName} must implement {baseType.FullName}!", $"Type {type.FullName} implements {baseType.FullName}");
        }
        else
        {
            Type? curr = type;
            while (curr is not null)
            {
                if (curr.BaseType == baseType)
                {
                    return;
                }

                curr = curr.BaseType;
                PrettyPrint.Green($"Type {type!.FullName} is a descendant of {baseType.FullName}");
            }
            Assert.Fail($"Type {type!.FullName} must be a descendant of {baseType.FullName}!");
        }
    }
    
    public static void IsSubtypeOf<T>(this Assert ass, Type? type)
    {
        ass.IsSubtypeOf(typeof(T), type);
    }

    public static void IsSingleton(this Assert ass, Type type)
    {
        Assert.AreEqual(0, type.GetConstructors().Length, $"Singleton {type.FullName} has public constructors", "");
        object obj = type.GetSingletonInstance();
        Assert.AreSame(obj, type.GetSingletonInstance(), "Singleton instance doesn't match", "");
    }
    
    public static void IsSingleton<T>(this Assert ass)
    {
        ass.IsSingleton(typeof(T));
    }

    public static void HasNoPublicFields(this Assert ass, Type type)
    {
        Assert.AreEqual(0, type.GetFields().Length, $"{type.FullName} has public fields", $"{type.FullName} has no public fields");
    }
    
    public static void HasNoPublicFields<T>(this Assert ass)
    {
        ass.HasNoPublicFields(typeof(T));
    }
}
