using PesquisaEOrdenacao.Lists;
using PesquisaEOrdenacao.Sort;
using System;
using System.Text;

namespace PesquisaEOrdenacao
{
    class Program
    {
        static void Main(string[] args)
        {

            var linked = new LinkedList();
            linked.Add(7);
            linked.Add(5);
            linked.Add(2);
            linked.Add(6);
            linked.Add(9);
            linked.Add(4);

            var l = SortWithLinkedList.SelectionSort(linked);
            Console.WriteLine(l);

            //var vet = new int[] { 7, 5, 2, 6, 9, 4 };
            //var r = Class1.QuickSort(vet, 0, vet.Length - 1);
            //foreach (var item in r)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
