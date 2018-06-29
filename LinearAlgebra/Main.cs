using Linalg;
using System;
using System.Diagnostics;

class MatrixDemo
{
    public static void Main()
    {
        VectorDemo();
        Console.ReadLine();
        SafeMatrixDemo();
        Console.ReadLine();
        ParallelUnsafeMatrixDemo();
        Console.ReadLine();
    }

    private static void VectorDemo()
    {
        Console.WriteLine("-------VECTOR DEMO-------");
        Vector A = Utils.RandomVector(5, 9, 9);
        Vector B = Utils.RandomVector(5, 9, 9);

        Console.WriteLine("A:");
        Console.WriteLine(A);
        Console.WriteLine();
        Console.WriteLine("B:");
        Console.WriteLine(B);
        Console.WriteLine();

        Console.WriteLine("A + B:");
        Console.WriteLine(A + B);
        Console.WriteLine();

        Console.WriteLine("A - B:");
        Console.WriteLine(A - B);
        Console.WriteLine();

        Console.WriteLine("A * B (dot product):");
        Console.WriteLine(A * B);
        Console.WriteLine();

        Rational scalar = Utils.RandomRational(9, 9);
        Console.WriteLine($"A * {scalar}:");
        Console.WriteLine(A * scalar);
        Console.WriteLine();
        Console.WriteLine($"B * {scalar}:");
        Console.WriteLine(B * scalar);
        Console.WriteLine();
        Console.WriteLine($"A / {scalar}:");
        Console.WriteLine(A / scalar);
        Console.WriteLine();
        Console.WriteLine($"B /* {scalar}:");
        Console.WriteLine(B / scalar);
        Console.WriteLine();

        Console.WriteLine("A normalized:");
        Console.WriteLine(A.Normalize());
        Console.WriteLine();
        Console.WriteLine("B normalized:");
        Console.WriteLine(B.Normalize());
        Console.WriteLine();

        Console.WriteLine("Length of A:");
        Console.WriteLine(A.Norm());
        Console.WriteLine();
        Console.WriteLine("Length of B:");
        Console.WriteLine(B.Norm());
        Console.WriteLine();
    }

    private static void SafeMatrixDemo()
    {
        Console.WriteLine("-------MATRIX OF COMPLEX NUMBERS DEMO-------");
        SafeMatrix<Complex> A = Utils.RandomMatrix(3, 3, Utils.RandomComplex);
        SafeMatrix<Complex> B = Utils.RandomMatrix(3, 3, Utils.RandomComplex);

        Console.WriteLine("A:");
        Console.WriteLine(A);
        Console.WriteLine();
        Console.WriteLine("B:");
        Console.WriteLine(B);
        Console.WriteLine();

        Console.WriteLine("A + B:");
        Console.WriteLine(A + B);
        Console.WriteLine();

        Console.WriteLine("A - B:");
        Console.WriteLine(A - B);
        Console.WriteLine();

        Console.WriteLine("A * B:");
        Console.WriteLine(A * B);
        Console.WriteLine();

        Complex scalar = Utils.RandomComplex(9, 9);
        Console.WriteLine($"A * {scalar}:");
        Console.WriteLine(A * scalar);
        Console.WriteLine();
        Console.WriteLine($"B * {scalar}:");
        Console.WriteLine(B * scalar);
        Console.WriteLine();

        Console.WriteLine("A transpose:");
        Console.WriteLine(A.Transpose());
        Console.WriteLine();
        Console.WriteLine("B transpose:");
        Console.WriteLine(B.Transpose());
        Console.WriteLine();
    }

    public static void ParallelUnsafeMatrixDemo()
    {
        Console.WriteLine("-------PARALLEL MATRIX MULTIPLICATION DEMO-------");
        ParallelMatrixMultiplicator multiplicator = new ParallelMatrixMultiplicator();

        UnsafeMatrix<long> A = Utils.RandomMatrix(500, 750);
        UnsafeMatrix<long> B = Utils.RandomMatrix(750, 500);

        Console.WriteLine("Multiplying two matrices of {0}x{1} and {2}x{3}", A.Rows, A.Columns, B.Rows, B.Columns);

        Stopwatch stopWatch = new Stopwatch();

        Console.WriteLine("Starting parallel...");
        stopWatch.Start();
        UnsafeMatrix<long> parallelResult = multiplicator.Multiply(A, B, 250);
        stopWatch.Stop();
        Console.WriteLine($"Parallel: {stopWatch.Elapsed}");

        stopWatch.Restart();

        Console.WriteLine("Starting serial...");
        stopWatch.Start();
        UnsafeMatrix<long> serialResult = A * B;
        stopWatch.Stop();
        Console.WriteLine($"Serial: {stopWatch.Elapsed}");

        Console.WriteLine($"Verify results are equal: {parallelResult == serialResult}");
    }
}
