---
title: Is it safe to download files from a shady website?
slug: malicious-file
date: 2022-01-30
lastmod: 2022-01-30
---

Trusting people on the internet can be difficult. Especially when they tempt us
with things we want. It's important to understand the basics of trust online,
and determine for yourself what risks are worth taking. You should use all the tools
available to help you make an informed decision, and weigh it against how much
you need the offered good. 

<!--more-->

A friend of mine asked the following question in a chat room today:
```
Friend: How do I determine if a video file is malicious?
Friend: Put another way, is there a way to download a video file from a shady
        website and then make sure you only get the video file?
```

I felt obliged to give a detailed answer, but wanted the wording to come out
right, and to save my answer for future reference.

The short answer is **no** -- you can never be sure that all you're getting is
the video file.

If you've already labelled the site as sketchy/shady, the trust is gone, and you
should show caution just entering the site, since there are a plethora of ways
to damage your PC. *The internet is not a safe place. Especially if you let
random people execute javascript on your PC*[^1]

[^1]: There are vulnerabilities in pure HTML like iframe viruses, tracking
  pixels et.c. but these are too technical for the audience of this piece.

However, we can choose to peel this union almost indefinitely. If we trust the
site (read: already opened it), the first barrier has ultimately been broken,
we must try to salvage the remains of our technical dignity. At this point,
if the site was malicious (and it's creators properly skilled, but let's always
assume that they are), you've nothing to fear anymore - your PC is
thoroughly compromised.[^2] 

[^2]: Again a grain of salt. Depending on your browser, operation system and
  antivirus software, you may have been protected from the website's malicious
  code.

Whatever service the website may offer, both free and paid[^3], be it easy wins,
[Sildenafil](https://en.wikipedia.org/wiki/Sildenafil), world-class pornography
or audio and video content, there's seldom such thing as a free lunch. Let's
split these websites into two categories: **altruistic** and **egocentric**.

[^3]: Though paid services are often trusted more, they can be just as
  malicious. >>I am an Egyptian Prince -- please wire \$200, and you will inherit
  \$1.000.000<<, >>Buy this iPhone for \$999, and we promise never to charge
you anything ever again.<<

# The egocentric website service

This is a website that offers a service (or the illusion of one) in exchange for
your personal information, your money, your well-being or some other good that
you'd prefer not to lose. There's some bias on which sites are in this category.
This is a selection of services I consider egocentric:

- Shoving advertisements in someones face[^4],
- Stealing, knowingly (terms of service, privacy policy et.c.) and unknowingly,
  personal information from your users.
- Running unnecessary or malicious (with or without intent) code in the visitors
  browser
- Being misleading or drowning the user in information in malice (like the
  really long contracts you're expected to read in a tiny window when signing up
  for an account)

[^4]: I don't mind advertisement payed content, but it should be very clear
  about it, and you should preferably be able to pay to opt-out of the
  advertisements.

# The altruistic website service

This is a website that offers a service to improve the well-being of others,
with no ill intentions or hidden fees. This service may be behind a paywall
depending on your bias. Finding examples is left as an exercise for the reader.

# About that video file...

Downloading a file from a website, altruistic or egocentric, must  be done with
caution. The file may not be the original file that the author intended to share
(replaced on the server), or it may be altered on the way to your PC (man in the
middle attack)[^4]. Even if the file is the original it may still contain
something malicious.

[^4]: These can, as far as we now, be mitigated using valid SSL certificates, if
  you trust the certificate authority and the encryption algorithm. Ask your
grandmother, which encryption algorithm she trusts the most.

*In theory[^5],* if you don't open/execute this file, it won't be able to harm
you PC. This is why so much money is funneled into antivirus software (Avast
revenue is \$893 million. NortonLifeLock \$2.5 billion.) When the file reaches
your computer, anti virus software will, if installed, look for a bunch of
**known** malicious patterns in the file, and flag it if any of these exists.
Some even go as far as removing it without asking, and denying your PC from ever
running the file.

Remember our talk about altruistic and egocentrical websites? I'll let you
determine for yourself, which category [Virustotal](https://www.virustotal.com)
falls into. It's a service that will scan a file or a URL for you with multiple
anti virus tools to determine if any of them find anything.

If you've come this far, and the file hasn't been flagged as malicious yet (and
you're not interested in reverse engineering it to determine ill-intent), your
best bet is to weigh up pros and cons, and if the pros outweigh the cons,
execute/open the file and share your findings with the world.

[^5]: And disregarding some edge cases like vulnerabilities in your file system,
  antivirus, thumbnail generation, et.c.
