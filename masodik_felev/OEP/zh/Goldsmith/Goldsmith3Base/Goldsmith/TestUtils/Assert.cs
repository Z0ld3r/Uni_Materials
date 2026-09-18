using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Goldsmith.TestUtils;

public class Assert
{
    private static Assert? ass = null;
    public static Assert That => ass ??= new Assert();

    private Assert() { }

    [DoesNotReturn]
    public static void Fail() => throw new AssertFailedException();
    
    [DoesNotReturn]
    public static void Fail(string message) => throw new AssertFailedException(message);

    public static void IsFalse(bool value, string fail, string? success = null)
    {
        if (value) Assert.Fail(fail);
        PrettyPrint.Green(success ?? fail);
    }
    public static void IsFalse(bool value) => Assert.IsFalse(value, "Value should be false");

    public static void IsTrue(bool value, string fail, string? success = null) => Assert.IsFalse(!value, fail, success);
    public static void IsTrue(bool value) => Assert.IsTrue(value, "Value should be true");

    public static void IsNotNull<T>(T? obj, string fail, string? success = null) => Assert.IsTrue(obj is not null, fail, success);
    public static void IsNotNull<T>(T? obj) => Assert.IsNotNull(obj, "Value should not be null");

    public static void AreEqual<T>(T expected, T actual, string fail, string? success = null) => Assert.IsTrue(Object.Equals(expected, actual), fail, success);
    public static void AreEqual<T>(T expected, T actual) => Assert.AreEqual(expected, actual,
        $"Values should be equal, expected {expected} and got {actual}");
    
    public static void AreSame<T>(T expected, T actual, string fail, string? success = null) => Assert.IsTrue(Object.ReferenceEquals(expected, actual), fail, success);
    public static void AreSame<T>(T expected, T actual) => Assert.AreSame(expected, actual,
        $"Values should be the same reference, expected {expected} and got {actual}");

    public static T ThrowsException<T>(Action action, string? fail = null, string? success = null) where T : Exception
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            Assert.AreEqual(typeof(T), ex.GetType(), fail ?? $"Expected {typeof(T).FullName} to be thrown but got {ex.GetType().FullName}");
            PrettyPrint.Green(success ?? $"Correctly threw {typeof(T).FullName}.");
            return (T)ex;
        }
        Assert.Fail(fail ?? $"Expected {typeof(T).FullName} to be thrown but got nothing");
        return null!;
    }
}