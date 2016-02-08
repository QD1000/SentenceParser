using System;
using System.Collections;

namespace SentenceParser.Helper
{

        /// <summary>
        /// Extension method to sort collection of IComparable  Object using Bubble sort
        /// </summary>
        public static class ListExtension
        {
            /// <summary>
            /// Sorts the IList of IComparable objects using Bubble Sort. 
            /// </summary>
            /// <param name="listToSort"></param>
            public static void BubbleSort(this IList listToSort)
            {
                for (int i = listToSort.Count - 1; i >= 0; i--)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        object o1 = listToSort[j - 1];
                        object o2 = listToSort[j];

                    if (o1 == null)
                        throw new NullReferenceException(Constants.LIST_ELEMENT_NULL_MESSAGE);

                    if (!(o1 is IComparable))
                        throw new InvalidCastException(Constants.LIST_ELEMENT_NOT_ICOMPARABLE_MESSAGE);

                    if (((IComparable)o1).CompareTo(o2) > 0)
                        {
                            listToSort.Remove(o1);
                            listToSort.Insert(j, o1);
                        }
                    }
                }
            }
        }
    
}
