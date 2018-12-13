import rpy2.robject as robject

x = input('X = ')
y = input('Y = ')

robject.r("source('path\\to\\Script.R')")
robject.r(f"my.f({x}, {y})")