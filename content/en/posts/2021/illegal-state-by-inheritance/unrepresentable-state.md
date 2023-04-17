---
title: Making bad states unrepresentable
date: 2020-06-20
lastmod: 2020-06-20
draft: true
---

> If you wish to make an apple pie from scratch, you must first invent the
> universe. -- Carl Sagan, Cosmos

When doing functional programming in F# and Haskell, we can ensure
irrepresentable state by modelling with types. This is more difficult in
object-oriented languages like C#.

Let's create a model of a university student:
```csharp
public class Student
{
    public int ID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string PasswordHash { get; set; }
    public List<Book> BorrowedBooks {get; set;}
}

public class Book
{
    public string Title { get; set; }
    public List<string> Authors { get; set; }
}
```

Let's assess some of the issues with this class.

1. All users of this class must remember to set all fields.
2. All users must known how to validate data before instantiating the
   class.
3. During the flow of the program, it is difficult to know, if the
   validated fields are changed (and if these changes are valid).
4. Primitive type obsession.
5. The types are lying.

The `ID` property says that it's an integer, but that's not true. An id
can only be a positive integer. The `FirstName` and `LastName` properties
are not just strings; `"<p> dire straits 25 - </p>"` is a string, but it
is not a name[^1]. The same goes for the `Email` property. So let's
describe a student with types that aren't lying.

[^1]: This obviously depends on your definition on the term name. I do not
  expect a university student to have such a name.

```csharp
public class Student2
{
    public PositiveInt ID { get; }
    public Name Name { get; }

    public DateTime DateOfBirth { get; }
    public Password Password { get; }

    public ContactInformation ContactInfo { get; }
    public IReadOnlyList<Book> BorrowedBooks { get; }
    public Student2(PositiveInt id
                    , Name name
                    , Password pw
                    , DateTime dob
                    , ContactInformation contactInfo
                    , IReadOnlyList<Book> books)
    {
        ID = id;
        Name = name;
        Password = pw;
        DateOfBirth = dob;
        ContactInfo = contactInfo;
        BorrowedBooks = books;
    }
}

public class ContactInfomation
{
    public EmailAddress Email { get; }
    public MailAddress Address { get; }
}

public class MailAddress
{
}

public class EmailAddress
{
    public string Name { get; }
    public string Domain { get; }
    public override ToString() => Name + "@" + Domain + "." + TLD;
    public EmailAddress(string email)
    {
        var em = email.SplitAt('@');
        var name = em[0];
        var domain = em[1];

    }
}

public class ParseResult<T> where T : class
{
    T? Result { get; }
    IReadOnlyList<ParseErrors> Errors { get; }
    bool IsValid => Result is object;
    bool HasErrors => Errors.Count > 0;

    public ParseResult<T>(T? result, NotEmptyCollection<ParseErrors> errors)
    {
        Errors = errors;
        Result = result;
    }

    public ParseResult<T>(T result)
    {
        if(result is null)
            throw new ArgumentNullException(nameof(result), "Result cannot be null");
        Result = result;
    }

    public ParseResult<T>(NotEmptyCollection<ParseErrors> errors)
    {
        if(errors is null)
            throw new ArgumentNullException(nameof(errors), "Errors cannot be null");
        Errors = errors;
    }
}

public class NotEmptyCollection<T> : IReadOnlyCollection<T>
{
    public NotEmptyCollection(T head, params T[] tail)
    {
        if (head == null)
            throw new ArgumentNullException(nameof(head));

        this.Head = head;
        this.Tail = tail;
    }

    public T Head { get; }

    public IReadOnlyCollection<T> Tail { get; }

    public int Count { get => this.Tail.Count + 1; }

    public IEnumerator<T> GetEnumerator()
    {
        yield return this.Head;
        foreach (var item in this.Tail)
            yield return item;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

public interface Parser<T>
{
    ParseResult<T> Parse(string s);
}
public class EmailAddressParser : Parser<EmailAddress>
{
    public ParseResult<EmailAddress> Parse(string email);
}

public class Password
{
    // Enum type. Omitted for brevity
    public HashAlgorithm Algorithm { get; }
    public string PasswordHash { get; }
}

public class Name
{
    public string FirstName { get; }
    public string LastName { get; }
    public override string ToString() => LastName + ", " + FirstName;
}

public class Book
{
    public string Title { get; }
    public IEnumerable<Name> Authors { get; }
}

public struct PositiveInt
{
    public int Num { get; }
    public IDValue(int num) => num < 0
        ? throw new ArgumentOutOfRangeException(nameof(digit), "Number can't be negative.")
        : Num = num;
    public static implicit operator int(PositiveInt d) => d.Num;
}
```
