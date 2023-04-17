---
title: Controlling a remote MPD server
date: 2021-06-30
---

I've written about my music setup on multiple occasions, and was
pleasantly surprised by the ease of which I could control my remote MPD
server today.

I've been running MPD on my personal computer for close to six years
now. As I was working on my office laptop today, I wanted to skip a
song, but had no easy access to my personal computer. Luckily, this was
easily solved by directing my office laptop MPD client (`vimpc`) to my
personal computer.
<!--more-->
```
$ export MPD_Host=lambdacomplex
$ export MPD_PORT=6600
```
