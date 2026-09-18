using System.Diagnostics;
using System.Reflection;

namespace Goldsmith.TestUtils;

public static class PrettyPrint
{
    private static int indent;

    public static int Indent
    {
        get => indent;
        set => indent = Math.Max(0, value);
    }

    public static bool EnableGreen { get; set; } = true;

    public static void Red(string? message) => WriteLine(message, ConsoleColor.Black, ConsoleColor.Red);
    public static void Yellow(string? message) => WriteLine(message, ConsoleColor.Black, ConsoleColor.Yellow);

    public static void Green(string? message, bool force = false)
    {
        if (EnableGreen || force) WriteLine(message, ConsoleColor.DarkGreen, null);
    }

    public static void Normal(string? message) => WriteLine(message);

    private static void WriteLine(string? message, ConsoleColor? fg, ConsoleColor? bg)
    {
        if (string.IsNullOrEmpty(message)) return;
        for (int i = 0; i < Indent; ++i)
        {
            Console.Write("    ");
        }

        if (Console.IsOutputRedirected)
        {
            Console.WriteLine(message);
            return;
        }

        if (fg is not null) Console.ForegroundColor = fg.Value;
        if (bg is not null) Console.BackgroundColor = bg.Value;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    private static void WriteLine(string? message)
    {
        if (string.IsNullOrEmpty(message)) return;
        for (int i = 0; i < Indent; ++i)
        {
            Console.Write("    ");
        }

        Console.WriteLine(message);
    }

    public static void Print(this Exception ex)
    {
        StackTrace trace = new StackTrace(ex, true);
        StackFrame? frame = null;
        StackFrame? prevFrame = null;
        for (int i = 0; i < trace.FrameCount; ++i)
        {
            MethodBase? meth = trace.GetFrame(i)?.GetMethod();
            Type? type = meth?.DeclaringType;
            if (meth?.GetCustomAttribute<TestMethod>() != null) frame = trace.GetFrame(i);
            if (prevFrame == null && meth?.GetCustomAttribute<TestMethod>() == null &&
                meth?.DeclaringType?.FullName?.StartsWith("System.") == false && type != typeof(Assert) &&
                type != typeof(TestRunner) && (meth?.GetParameters().Length < 1 ||
                                               meth?.GetParameters()[0].ParameterType != typeof(Assert)))
            {
                prevFrame = trace.GetFrame(i);
            }
        }

        PrettyPrint.Red($"{ex.GetType().Name}: {ex.Message}");
        PrettyPrint.Indent++;

        if (frame != null)
        {
            PrettyPrint.Yellow(
                $"Test method: {frame.GetMethod()?.DeclaringType?.FullName}.{frame.GetMethod()?.Name}() " +
                $"({frame.GetFileName()}:{frame.GetFileLineNumber()}:{frame.GetFileColumnNumber()})");
        }

        if (prevFrame != null)
        {
            PrettyPrint.Yellow(
                $"Origin: {prevFrame.GetMethod()?.DeclaringType?.FullName}.{prevFrame.GetMethod()?.Name}() " +
                $"({prevFrame.GetFileName()}:{prevFrame.GetFileLineNumber()}:{prevFrame.GetFileColumnNumber()})");
        }

        PrettyPrint.Indent--;
    }
}