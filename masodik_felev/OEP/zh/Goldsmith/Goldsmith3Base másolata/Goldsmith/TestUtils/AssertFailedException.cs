namespace Goldsmith.TestUtils;

public class AssertFailedException : Exception
{
    public AssertFailedException() : base("Assertion failed.") {}
    public AssertFailedException(string message) : base(message) {}
}