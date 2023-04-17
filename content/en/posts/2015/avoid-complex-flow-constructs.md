---
date: 2015-11-25
lastmod: 2019-04-28
title: Avoid complex flow constructs
---

If
==

`If` is one of the major flow constructs in most languages. There are plenty of
cases where `if` statements are completely justified, but there are also a lot
of places, where they're unnecessary. Consider the following:

```C#
namespace UsingIfs
{
    public interface IDrink
    {
        string Name { get; }
        List<Ingredient> Ingredients { get; }
        float Price { get; }
    }

    public class OrangeJuice : IDrink
    {
        public string Name => "Orange juice";
        public List<Ingredient> Ingredients
            => new List() { Ingredient.Oranges };
        public float Price { get; }
        public OrangeJuice(float price) => Price = price;
    }

    public class AppleJuice : IDrink
    {
        public string Name => "Apple juice";
        public List<Ingredient> Ingredients
            => new List() { Ingredient.Apples };
        public float Price { get; }
        public OrangeJuice(float price) => Price = price;
    }
    public class Water : IDrink
    {
        public string Name => nameof(Water);
        public List<Ingredient> Ingredients
            => Ingredient.None;
        public float Price { get; }
        public Water(float price) => Price = price;
    }

    public class DrinkAnalyzer
    {
        public Weight DetermineSugarContent(IDrink drink)
        {
            if(drink is AppleJuice)
                return Weight.FromGrams(11);
            if(drink is OrangeJuice)
                return Weight.FromGrams(9);
            if(drink is Water)
                return Weight.FromGrams(0);

            throw new NotImplementedException("Drink not supported in {0}"
                        , nameof(DrinkAnalyzer));
        }
    }
}
```

The `DrinkAnalyzer` is lying. It's blatantly saying that
```{.haskell}
DetermineSugarContent :: IDrink -> Weight
```
But the `DetermineSugarContent`
doesn't cover all elements in it's domain (`IDrink`). There are multiple ways to
solve this.

An alternative implementation of the `DrinkAnalyzer` without the `if`s:
```c#
public class DrinkAnalyzer2
{
    public Weight DetermineSugarContent(AppleJuice j) => Weight.FromGrams(11);
    public Weight DetermineSugarContent(OrangeJuice j) => Weight.FromGrams(9);
    public Weight DetermineSugarContent(Water j) => Weight.FromGrams(0);
}
```

If we stop for a moment, and rethink our domain logic, we can ask ourselves: "Is
the sugar content a part of a drink?". If the answer is yes, we must incorporate
this in our `IDrink` interface.
```c#
    public interface IDrink2
    {
        string Name { get; }
        List<Ingredient> Ingredients { get; }
        float Price { get; }
        Weight SugarContent { get; }
    }
```

In all cases the `DrinkAnalyzer` is tightly coupled with the various IDrink
implementations.

Goto
====

Go to statements are "considered harmful", as popularized by Dijkstra
in the 1960s. The compiler has a hard time optimizing gotos, and it's
difficult to argue about the correctness of logic using go tos. The most
common place to see go tos in high-level languages is breaking out of
nested loops. Consider the following *crude* example:[^1]
```c#
private static ValueInAllRows(Matrix<T> v, T value)
{
    foreach (Row<T> r in v.Rows)
    {
        foreach (Entry<T> e in r)
        {
            if (e.Value == value)
            {
                goto NextRow;
            }
        }
        goto Fail;

        NextRow:
        continue;
    }

    return true;

    Fail:
    return false;
}
```
This can easily be refactored to functions:
```c#
private static bool ValueInRow(Row<T> row, T Value)
{
    foreach (Entry<T> e in r)
    {
        if (e.Value == value)
            return true;
    }
}

private static bool ValueInAllRows(Matrix<T> v, T value)
{
    foreach (Row<T> r in v.Rows)
    {
        if (!ValueInRow(value))
            return false;
    }
    return true;
}
```
Recursion
=========

Many people using recursion come from functional languages. In functional
languages tail-recursive functions can be optimized to run as optimally as
loops. This is because we can optimize the stack allocation for tail-recursive
functions, and thus reduce the spatial complexity of the function.

In object-oriented languages recursive functions usually aren't optimized.
Recursive functions usually lead to a bunch of stack allocations, that can be
avoided by using loops. Consider the following function for calculating a
Fibonacci number:

```C#
public static int Fib(int n, int a = 0, int b = 1)
{
    return n switch
    {
        0 => a,
        1 => b,
        _ => Fib(n - 1, b, a + b)
    };
}
```
This function runs in `O(n)` time and has a spatial complexity of `O(n)`. If
tail-recursive optimization was used, this would have a spacial complexity of
`O(1)`.

Now consider another implementation using a `for`-loop:

```C#
public static int Fibonacci(int n)
{
    int a = 0;
    int b = 1;
    for (int i = 0; i < n; i++)
    {
        (a, b) = (b, a+b);
    }
    return a;
}
```
This function also runs in `O(n)` time, but has a spatial complexity of just
`O(1)`.

[^1]: I had to go to great lengths to write this.
