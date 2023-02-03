// See https://aka.ms/new-console-template for more information

// Console.WriteLine("Hello, World!");

int GetMaxSquares(int a, int b)
{
    var min = a > b ? b : a;
    var max = a > b ? a : b;

    while (true)
    {
        if (max % min == 0)
        {
            return min;
        }

        var rem = max % min;
        max = min;
        min = rem;
    }
}

Console.WriteLine(GetMaxSquares(6, 3));
Console.WriteLine(GetMaxSquares(5, 5));
Console.WriteLine(GetMaxSquares(9, 6));
Console.WriteLine(GetMaxSquares(9, 5));
Console.WriteLine(GetMaxSquares(10, 6));


// min = a > b ? b : a
// max = a > b ? a : b 
//
// while
// if max % min == 0
// return min
//
// rem = max % min
// max = min
// min = rem 