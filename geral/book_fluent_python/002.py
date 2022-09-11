#!/bin/env python

import math


class Vector:
    def __init__(self, x, y):
        self.x = x
        self.y = y

    def __repr__(self):
        return f'Vector({self.x!r}, {self.y!r})'

    def __bool__(self):
        return bool(abs(self))

    def __abs__(self):
        return math.hypot(self.x, self.y)

    def __add__(self, other):
        x = self.x + other.x
        y = self.y + other.y
        return Vector(x, y)

    def __mul__(self, scalar):
        return Vector(self.x * scalar, self.y * scalar)


if __name__ == '__main__':
    v1 = Vector(2, 4)
    print(v1)

    v2 = Vector(2, 1)
    print(v2)

    print(v1 + v2)

    v3 = Vector(3, 5)
    print(abs(v3))

    v4 = Vector(0, 12)
    print(v4 * 3)

    v5 = Vector(3, 5)
    print(not not v5)
