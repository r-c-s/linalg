## Linear Algebra in C#

This is a math library I created to learn C#. It showcases OOP, generics, partial classes, operator overloading, the dynamic keyword, LINQ, threads, and unit testing.

The top level classes in this library are AbstractMatrix, Rational, Complex, Vector, and the Arithmetical interface that defines +-*/ operations.

There are two implementations of AbstractMatrix: a generic SafeMatrix whose type parameter is restricted to objects implementing Arithmetical, and the UnsafeMatrix which is also generic but has no restrictions on the type. It accomplishes the mathematical operations by using the dynamic keyword.

Rationals are simply fractions consisting of a nominator and a denominator (long).

Complex is a number consisting of a real and an imaginary part. I used composition here and made real and imaginary of type Rational. 

Both Rational and Complex implement the Arithmetical interface so they can be used with the SafeMatrix.

A Vector consists of Rational objects. Although I could have created a SafeVector and UnsafeVector, I did not, since that concept is already displayed in the matrices.

Matrices can be multiplied in parallel, which is implemented by ParallelMatrixMultiplicator. See below for the results. Not as fast as my C++ version!

This was intended as an exercise for learning C#, and as such, it is not meant to be performant. :)


##Sample Output

```
-------VECTOR DEMO-------
A:
[-7/4, 4/5, 7/8, -2/7, 1]

B:
[-3/2, -3/4, -4, -4/7, 1/2]

A + B:
[-13/4, 1/20, -25/8, -6/7, 3/2]

A - B:
[-1/4, 31/20, 39/8, 2/7, 1/2]

A * B (dot product):
-1591/1960

A * 2/5:
[-7/10, 8/25, 7/20, -4/35, 2/5]

B * 2/5:
[-3/5, -3/10, -8/5, -8/35, 1/5]

A / 2/5:
[-35/8, 2, 35/16, -5/7, 5/2]

B /* 2/5:
[-15/4, -15/8, -10, -10/7, 5/4]

A normalized:
[-490/659, 224/659, 245/659, -80/659, 280/659]

B normalized:
[-14/41, -7/41, -112/123, -16/123, 14/123]

Length of A:
659/280

Length of B:
123/28


-------MATRIX OF COMPLEX NUMBERS DEMO-------
A:
   -1+5i    5/8+2i   -2+6/5i
  3/5-5i  1/5-9/8i  1/4+1/6i
1/6+7/3i   -1+4/5i    3/5-6i

B:
4/7-2i    -1-1/4i  5/6-5/6i
5/3-6i  -1/2+8/7i    -9/2-i
  -3+i      -1+5i   -3-4/7i

A + B:
    -3/7+3i    -3/8+7/4i  -7/6+11/30i
  34/15-11i  -3/10+1/56i   -17/4-5/6i
-17/6+10/3i     -2+29/5i  -12/5-46/7i

A - B:
 -11/7+7i     13/8+9/4i  -17/6+61/30i
 -16/15+i  7/10-127/56i     19/4+7/6i
19/6+4/3i        -21/5i    18/5-38/7i

A * B:
 22907/840-487/420i    -487/112-2273/140i  15467/1680-1983/280i
-1784/105-2067/280i  -367/210+11297/1680i   -1777/280-751/1680i
     254/21+404/15i   12349/420+1423/280i    181/84+21247/1260i

A * -2/5+5/6i:
   -113/30-17/6i  -23/12-67/240i     -1/5-161/75i
    589/150+5/2i  343/400+37/60i  -43/180+17/120i
-181/90-143/180i  -4/15-173/150i    119/25+29/10i

B * -2/5+5/6i:
151/105+134/105i     73/120-11/15i     13/36+37/36i
    13/3+341/90i  -79/105-367/420i     79/30-67/20i
    11/30-29/10i     -113/30-17/6i  176/105-159/70i

A transpose:
  -1+5i    3/5-5i  1/6+7/3i
 5/8+2i  1/5-9/8i   -1+4/5i
-2+6/5i  1/4+1/6i    3/5-6i

B transpose:
  4/7-2i     5/3-6i     -3+i
 -1-1/4i  -1/2+8/7i    -1+5i
5/6-5/6i     -9/2-i  -3-4/7i


-------PARALLEL MATRIX MULTIPLICATION DEMO-------
Multiplying two matrices of 500x750 and 750x500
Starting parallel...
Parallel: 00:00:22.8715471
Starting serial...
Serial: 00:00:44.7796338
Verify results are equal: True
```