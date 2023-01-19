namespace ProjectEuler.Problems;

internal partial class Problem
{
    public string Title { get; set; }
    public Delegate Exercise { get; set; }
    public Problem(string title, Delegate exercise)
    {
        Title = title;
        Exercise = exercise;
    }

    public static void Write(string heading, string text)
    {
        // Neatly split long strings into roughly 80 character lines. This is primarily used
        //  to display the exercise and solution on execution of each problem method.
        var words = text.Split(' ');
        var lines = words.Skip(1).Aggregate(words.Take(1).ToList(), (l, w) =>
        {
            if (l.Last().Length + w.Length >= 80)
            {
                l.Add(w);
            }
            else
            {
                l[l.Count - 1] += " " + w;
            }
            return l;
        });
        for (int i = 0; i < lines.Count; i++)
        {
            if (i == 0)
            {
                Console.WriteLine("{0,-10}{1,-20}", heading, lines[i]);
                continue;
            }
            Console.WriteLine("{0,-10}{1,-20}", "", lines[i]);
        }
        Console.WriteLine();
    }
    public static void ShowProblems()
    {
        foreach (var option in AllProblems)
        {
            Console.WriteLine($"{option.Key}\t {option.Value.Title}");
        }
        Console.WriteLine();
    }

    public static void GetProblem(int index)
    {
        if (!AllProblems.TryGetValue(index, out _))
        {
            // Key not found. Throw custom exception.
            throw new ProblemNotFoundException($"Error extracting problem {index} - unable to locate problem. Please try again.");
        }

        Console.WriteLine("* * *\n");
        Write($"Problem {index}: ", AllProblems[index].Title);
        AllProblems[index].Exercise.DynamicInvoke();
        Console.WriteLine("* * *\n");
    }

    public static readonly Dictionary<int, Problem> AllProblems = new()
    {
        /* Dictionary of available problems. The main purpose of instantiating a Problem() class
           here is to provide a means by which multiple values (and in particular the delegate) can
           be indexed with a single key. */

        { 1, new Problem("Multiples of 3 or 5", Problem_1) },
        { 2, new Problem("Even Fibonacci numbers", Problem_2) },
        { 3, new Problem("Largest prime factor", Problem_3) }
    };
        
}