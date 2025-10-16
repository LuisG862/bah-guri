using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bubble_Sort
{
    public class BubbleSortOrder
    {
        public static T[] Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) < 0) //Inversor da string, < 0 fica na forma decrescente e > 0 fica de forma crescente

                    {
                        Swap(array, j, j + 1);
                    }
                }
            }

            return array;
        }

        public static void Swap<T>(T[] array, int first, int second)
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}

