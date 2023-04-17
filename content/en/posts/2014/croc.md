---
title: Using croc for running multiple git hooks
date: 2014-08-29
---

I needed the opportunity to run several checks in one git hook. To accomplish
this, I wrote `croc`[^1]. It's a very simple and crude script with some pretty
printing. It's very useful for running checks as git hooks.

To use the dispatcher, symlink it to the desired git hook stage, and create a
corresponding directory. Symlink or move any existing scripts into the
dispatcher directory. Git hook will trigger the dispatcher, triggering any
scripts not marked as `.skip` in the dispatcher directory.

[^1]: It was a crocodile that swallowed the hand of Captain Hook.
