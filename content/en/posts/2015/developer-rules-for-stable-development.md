---
title: Rules for developing code
date: 2015-11-25
lastmod: 2020-09-24
---

Some of these are inspired by
[The Power of 10 Rules](https://en.wikipedia.org/wiki/The_Power_of_10:_Rules_for_Developing_Safety-Critical_Code)
by Gerard J. Holzmann.

- Avoid complex flow constructs, such as goto and recursion.
  [Read more.](../avoid-complex-flow-constructs)

- All loops must have fixed bounds. This prevents runaway
  code.

- Avoid heap memory allocation

- Restrict classes to a single printed page

- Restrict the scope of data to the smallest possible

- Abstain from using void (except at entry-point) in functions. A function is
  never void. All functions perform a transformation. Methods that
  mutate state should return void.

- Aim for immutable data structures

- Compile with all possible warnings; all warnings should be addressed before
  release of the software.

- Minimize control flow complexity and "area under ifs", favoring consistent
  execution paths and times over "optimally" avoiding unnecessary work.

- Data dominates. If you've chosen the right data structures and organized
  things well, the algorithms will almost always be self-evident.

- Data structures, not algorithms, are central to programming.

- Use good descriptive names

- Exceptions are for exceptional cases

- Cover all cases in your domain model

- The best performance improvement is the transition from the nonworking state
  to the working state.

- Spend more time on the right abstraction

- Make a domain model beforehand

- Exceptions should be used in exceptional (unrecoverable) cases.

- Understand design patterns. Known when to use design patterns.

- Abstractions often present themselves as duplicate code.

- Stay below 80 characters.

- Stay below 72 characters.

- Avoid leaky abstractions. Who's responsible when it fails?

- Sometimes (a -> b -> c) can be written as (a -> c), or ((a -> b)
  -> c) or (a -> (b -> c)).

- Design with optionals or design without. Not both. A class can't have
  "either-or" field.

- A function should never accept a bool argument. Be precatious about bool. Bool
  is a type that should only be used in conditionals.

- Mutable data structures are inherently not thread-safe. Immutable data
  structures are inherently thread-safe.

- Use small scopes.

- Have a single source of truth
