---
title: Handling a music library in 2017
date: 2017-01-12
---

The concept having a music collection has changed drastically since I was a kid.
I was raised with CD collections (and from these ripped mp3 collections). These
were very common, and there were certain CDs that everybody had in their
collection.

When I was studying, I found the process of selecting and moving music to my
cellphone was tedious. Further more, the software for managing music and
playlists on my cellphone was subpar. Instead I'd pick out ~the~ 3-5 CDs that I
wanted to listen to that day, and bring them and my discman. This solution
worked well although carrying CDs around isn't always practical.

Today, nobody owns CD's anymore, and most people don't own the music they listen
to, but stream it from various providers. The ease and flexibility of this
solution is very attractive. This solution has some cons for me:

- I'm often (most of the time) offline.
- I have an intricate way of labeling and creating playlists.
- Music streaming providers don't have all the music I like.
- Streaming an album multiple times will amount to a bunch of network traffic.

Take "A Rush of Blood to the Head", my favorite Coldplay album, as an example.
I've listened to this entire album twelve or fifteen times this year. The album
takes up 127 MB of storage when compressed in a zip file. This amounts to
1905 MB = 1.9 GB. According to
[Emerge](https://www.emergeinteractive.com/insights/detail/does-irresponsible-web-development-contribute-to-global-warming/),
one GB of data produces 3kg of CO2. Thus my listening to Coldplay produces
almost 6kg of CO2. And that's not even counting the power used by my laptop or
my speakers.

My original solution to this, was the same as it was twenty years ago. I have a
folder on my PC called <code>music</code> indexed by authors and then by albums.
That's all fine and dandy.

But say I'm at work, and want to listen to one of my CD's. That's no problem, I
just copy my music folder to my work laptop. This has several issues:

- I don't want my personal music collection on a laptop I do not own,
- my music collection is large (&gt;50 GB), and
- I would have to update it, if I bought a new album.

~~As of now, I have my entire music collection on a portable SSD harddrive, and a
backup on my file server. To ensure the least possible amount of data usage, I
use an `rsync` command, that only copies new files to the directory, instead of
blindly copying and overwriting every single file.~~

~~This way I get the portability of moving all of my albums around weighing close
to nothing, and but still have to remember my drive to be able to listen to
music.~~

**Update:** I now use `syncthing` to synchronize my music between all my
workstations. The downside to this is, that I have to reserve 50GB on each of my
machines for music. Since I'm not using the 500 GB SSD for anything else, this
doesn't really matter for now.

Not everything is perfect.
