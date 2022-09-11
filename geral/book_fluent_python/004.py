#!/bin/env python

if __name__ == '__main__':
    symbols = '$¢£¥€¤'

    codes = [ord(symbol) for symbol in symbols]

    print(codes)
