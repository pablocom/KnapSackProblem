using System;

namespace KnapSackProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = new[]
            {
                new Item(5, 2),
                new Item(10, 5),
                new Item(16, 7),
                new Item(18, 3),
                new Item(10, 4),
                new Item(80, 31),
                new Item(3, 1)
            };
            var capacity = 43;

            var result = KnapSack(capacity, items);
            Console.WriteLine(result);
        }

        private static int KnapSack(int capacity, Item[] items)
        {
            var itemsCount = items.Length;
            var k = new int[itemsCount + 1, capacity + 1];

            for (int i = 0; i <= itemsCount; ++i)
            {
                for (int w = 0; w <= capacity; ++w)
                {
                    if (i == 0 || w == 0)
                        k[i, w] = 0;
                    else if (items[i - 1].Weight <= w) 
                        k[i, w] = Math.Max(items[i - 1].Value + k[i - 1, w - items[i - 1].Weight], k[i - 1, w]);
                    else
                        k[i, w] = k[i - 1, w];
                }
            }

            PrintMatrix(k);
            return k[itemsCount, capacity];
        }

        private static void PrintMatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.Write(Environment.NewLine);
            }
        }

        private class Item
        {
            public int Value { get; }
            public int Weight { get; }

            public Item(int value, int weight)
            {
                Value = value;
                Weight = weight;
            }
        }
    }
}
