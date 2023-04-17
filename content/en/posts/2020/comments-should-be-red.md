---
title: The misunderstood concept of code comments
date: 2020-08-11
---

Code comments shouldn't be syntax highlighted as faded grey, or other hard to
see colors. They should be red as a wildfire, and you shouldn't have that many
of them. Comments should explain the why, never the what. Explaining the why
is creating a breadcrumb trail through the code to allow easy reading.
Explaining the what is just dumbing down the code and increases the risk of
comment rot.

The pinnacle of good code is for it to be self-documenting *in other's eyes*,
but during the ascencion, we'll have to leave a breadcrumb trail for
developers who daringly follow us. 

<!--more-->

In programming courses, students are usually taught to be lavish with comments.
It is of the utmost importance, that they comment every single line of code, to
show that they understand, what they've done. Well, here's the knockout. The guy
they found on fiverr&reg; can comment the code as well. 

The code is just an implementation of a solution to a problem. The solution
should be thoroughly described in a report on the problem. This takes care of
"what" the code is doing, and brings us to the real purpose of comments. Why
the code is implemented the way it is.

Comments must be well-written, terse[^1] and not laconic[^2] or verbose.
Comments are used to explain why the code is as it is, not what the code does.
Consider these examples based on the `display` function from
`openbsd-src/ls.c`:

[^1]: Terse (adjective): neatly or effectively concise. 
[^2]: Laconic (adjective): concise to the point of seeming rude or mysterious.

```
/*
 * Displays a list of all files in directory
 */
static void
display(FTSENT *p, FTSENT *list) { ... }

```
This is so concise that it borders to be incorrect. The reader will have
gained close to nothing from reading the comment, that he would've not gotten
from reading the function signature. In which case there's no reason to have a
comment. Now consider (the actual comment at the time of writing):
```
/*
 * Display() takes a linked list of FTSENT structures and passes the list
 * along with any other necessary information to the print function.  P
 * points to the parent directory of the display list.
 */
static void
display(FTSENT *p, FTSENT *list) { ... }
```
Effectively concise telling just enough to understand the function, without
having to delve into the code. The perfect abstraction.
```
/*
 * Given a list of FTSENT, display will magically print it out and include
 * all the necessary information. This is done by iterating through the list
 * and branching on FTSENT type (directory or file). If it's a directory,
 * we need to handle fts_level, and fts_accpath, while these aren't necessary
 * for regular files.
 */
static void
display(FTSENT *p, FTSENT *list) { ... }
```
This comment is verbose and goes in depth with implementation details. The
abstraction level is too low. There's no reason to explain control flow at
this level. This is better described in the body of the function *if
necessary*. 
