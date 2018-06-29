using LinAlg;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Linalg
{
    public class ParallelMatrixMultiplicator
    {
        public UnsafeMatrix<T> Multiply<T>(UnsafeMatrix<T> a, UnsafeMatrix<T> b, int blockSize) 
        {
            if (!a.CanMultiplyWith(b))
                throw new ArgumentException();

            int ar = a.Rows;
            int ac = a.Columns;
            int br = b.Rows;
            int bc = b.Columns;

            if (ar % blockSize != 0 || ac % blockSize != 0 || 
                br % blockSize != 0 || bc % blockSize != 0)
                throw new IndexOutOfRangeException();

            UnsafeMatrix<T> result = new UnsafeMatrix<T>(new T[ar, bc]);

            int processCount = (ar * bc) / (blockSize * blockSize);
            int blocksPerProcess = ac / blockSize; 
            int multiplicationsPerBlock = bc / blockSize;

            Thread[] threads = new Thread[processCount];

            for (int i = 0; i < processCount; i++)
            {
                UnsafeMatrix<T>[] blocksA = new UnsafeMatrix<T>[blocksPerProcess];
                UnsafeMatrix<T>[] blocksB = new UnsafeMatrix<T>[blocksPerProcess];

                int row = (i / multiplicationsPerBlock) * blockSize;
                int col = (i % multiplicationsPerBlock) * blockSize;

                for (int j = 0; j < blocksPerProcess; j++)
                {
                    blocksA[j] = a.GetBlock(row, j * blockSize, blockSize, blockSize);
                    blocksB[j] = b.GetBlock(j * blockSize, col, blockSize, blockSize);
                }

                threads[i] = new Thread(() => Multiply(result, blocksA, blocksB, row, col, blockSize));
                threads[i].Start();
            }

            foreach (Thread t in threads)
               t.Join();

            return result;
        }

        private static void Multiply<T>(
            UnsafeMatrix<T> result,
            UnsafeMatrix<T>[] blocksA,
            UnsafeMatrix<T>[] blocksB, 
            int row,
            int col,
            int size)
        {
            Debug.Assert(blocksA.Length == blocksB.Length);

            UnsafeMatrix<T> sumOfProducts = null;

            for (int k = 0; k < blocksA.Length; k++)
            {
                UnsafeMatrix<T> toAdd = blocksA[k].Mul(blocksB[k]);
                sumOfProducts = sumOfProducts == null ? toAdd : sumOfProducts + toAdd;
            }

            result.SetBlock(row, col, sumOfProducts);
        }
    }
}
