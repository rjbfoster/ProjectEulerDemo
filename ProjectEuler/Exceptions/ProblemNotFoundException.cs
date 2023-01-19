
public class ProblemNotFoundException : Exception
{
    public ProblemNotFoundException()
    {
    }

    public ProblemNotFoundException(string message)
        : base(message)
    {
    }

    public ProblemNotFoundException(string message, Exception inner)
        : base(message, inner)
    {
    }
}