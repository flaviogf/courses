a = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h']

print(a)
print(a[:4])
print(a[-4:])
print(a[3:-3])

assert a[:4] == a[0:4]

assert a[5:] == a[5:len(a)]

a[3:5] = 'X', 'X'

print(a)

print(a[2:-2])
