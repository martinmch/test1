---
title: "Re: Styling external links"
date: 2023-03-03
---

# DESCRIPTION

I came across an article on [styling external links] by Jake Bauer. In the
article he details a CSS trick to append an arrow to all external links.

This can be accomplished using the semantic HTML attribute `rel`
and a simple attribute selector in CSS
```html
<style> a[rel=external]::after { content: "^"; } </style>
<a rel=external href="https://www.paritybit.ca/">ParityBit</a>
```

# EXAMPLES

<style> a[rel=external]::after { content: "^"; } </style>
<a rel=external href="https://www.paritybit.ca/">ParityBit</a>

[styling external links]:
    https://www.paritybit.ca/blog/styling-external-links.html
