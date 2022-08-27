#!/bin/env python

suffix = input('suffix: ')

if suffix == '.htm':
    content = 'text/html'
elif suffix == '.jpg':
    content = 'image/jpeg'
elif suffix == '.png':
    content = 'image/png'
else:
    raise RuntimeError(f'Unknow content type {suffix!r}')

print(content)
