using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace Goldsmith.TestUtils;

public class TestRunner
{
    private Type[] testClasses;
    public int TestCount { get; private set; }
    public int TestsSucceeded { get; private set; }

    public TestRunner()
    {
        testClasses = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.GetCustomAttribute<TestCase>() is not null)
            .OrderBy(t => t.GetCustomAttribute<TestCase>()!.Index).ToArray();
        TestCount = 0;
        TestsSucceeded = 0;
    }

    public void Run()
    {
        PrettyPrint.Indent++;
        try
        {
            foreach (Type type in testClasses)
            {
                object? obj = Activator.CreateInstance(type);
                if (obj is null) throw new Exception($"Could not create test class {type.FullName}");
                MethodInfo[] methods = type.GetMethods().Where(t => t.GetCustomAttribute<TestMethod>() is not null)
                    .OrderBy(t => t.GetCustomAttribute<TestMethod>()!.Index).ToArray();
                PrettyPrint.Normal(obj!.ToString());
                PrettyPrint.Indent++;
                try
                {
                    foreach (MethodInfo meth in methods)
                    {
                        PrettyPrint.Normal(meth.GetCustomAttribute<TestMethod>()!.Description ?? meth.Name);
                        PrettyPrint.Indent++;
                        TestCount++;
                        try
                        {
                            meth.Invoke(obj, []);
                            TestsSucceeded++;
                        }
                        catch (TargetInvocationException ex)
                        {
                            Exception e = ex;
                            while (e is TargetInvocationException tex) e = tex.InnerException ?? tex;
                            e.Print();
                        }
                        catch (Exception ex)
                        {
                            ex.Print();
                        }
                        finally
                        {
                            PrettyPrint.Indent--;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Print();
                }
                finally
                {
                    PrettyPrint.Indent--;
                }
            }
        }
        catch (Exception ex)
        {
            ex.Print();
        }
        finally
        {
            PrettyPrint.Indent--;
        }

        if (TestCount == TestsSucceeded && !Console.IsOutputRedirected && PrettyPrint.EnableGreen)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            using var s = new GZipStream(new MemoryStream(Convert.FromBase64String(new string ("""
                NNNOSv5n3o6UBFzc5ZQm66haL8/1J1n3
                UkRqTPCQLfYorTBufaudFlWDaj8hxfl7pVYFrHj8wKYqaLlkoUQSOr493+6iSqQGEbgaeya0qtYC
                2KHuwdZSlkUdiJoL9fz/Is7+hz+JCe+ue3y1UP9b6TqX76JRtz2MBKrueALjkwlY6San7tz/3iA1
                ch9PzIizpJ/nmkbBUAKR/XF7FQ8iH/2ys6faGBwPYX8A77/f3/dETFyHXwbihbOu51Fij5f656gP
                AcN0+XRDpQ0BQItpIE2QXPDNHVyqOa2m2CNj/AfCjGcNHB+FLxPDYC531lil5CWfNbDrlOIpYQuD
                7ckrs2NL/YjXBXKUXLoRu6WE3fZJ10gwNEyHwMSeTw0FbB5hqHfJIJJ+6EAalz/5+npZmwCkonVH
                dKSK/F4k9813YgPduvtdudQxqNk88VbjRKRC3KVQtHfo9FMeNDUr05vou1TquW2NNt2AYzRPVf4U
                """.ToCharArray().Select(s => (char)(( s >= 97 && s <= 122 ) ? ( (s + 13 > 122 ) ? s - 13 : s + 13) : ( s >= 65 && s <= 90 ? (s + 13 > 90 ? s - 13 : s + 13) : s ))).Reverse().ToArray() ))), CompressionMode.Decompress);
            using var s2 = new MemoryStream();
            s.CopyTo(s2);
            Console.Write(Encoding.UTF8.GetString(s2.ToArray()));
            Console.ResetColor();
        }
    }
}

[AttributeUsage(AttributeTargets.Class)]
public class TestCase(int index = int.MaxValue) : Attribute
{
    public int Index => index;
}

[AttributeUsage(AttributeTargets.Method)]
public class TestMethod(int index = int.MaxValue) : Attribute
{
    public int Index => index;
    public string? Description { get; init; }
}
