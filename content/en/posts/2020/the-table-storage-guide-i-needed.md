---
title: The Table Storage Guide I Needed
date: 2020-02-28
lastmod: 2021-03-21
draft: true
---

When I started using Azure Table Storage, I was confounded by the lack of
documentation and examples online. I rolled my own framework for my companys
use-case, and we used that framework for more than a year.

When implementing a class that went into the table storage, I'd define two
entities, our working domain model, and a table storage model. We'd then define
an interface called `IToTableEntity`.

```{.csharp}
public interface IToTableEntity<T>
{
    T ToTableEntity();
}
```

This was quite extensive, and required our domain model to
define how it would be stored in our storage abstraction.
I can smell it through my computer monitor.

There are two more sensible approaches to handle this:

# Create a storage abstraction class for each model class

For each class in our domain model, we coul define a
ClassStorer, that handles the table logic and the conversion
of the object. This way, the mapping from domain model to
table model is done once, and in the relevant class. It still
seems cluttered.

# Create conversion extension methods

This gives the user more freedom but also more
responsibility. In the namespace of your table storage logic,
define a sub-namespace ModelConversionExtensions, and handle
the conversions in there

```{.csharp}
public static class TodoConversionExtensions
{
    public static TodoTableEntity ToTableEntity(this Todo t)
    {
        return new TodoTableEntity()
        {
            PartitionKey = "TODO"
            , Message = t.Message
            , Priority = t.Priority
            , Context = t.Context
            , Tags = JsonDeserialize(t.Tags)
        };
    }
    public static Todo ToTodo(this TodoTableEntity te)
    {
        return new Todo(te.Message
            , te.Priority
            , te.Context
            , JsonSerialize<List<Tag>>(te.Tags)
    }
}
```
