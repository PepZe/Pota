using System;
using System.Collections.Generic;
using System.Text;
using PesquisaEOrdenacao.Lists;
using PesquisaEOrdenacao.Model;

namespace PesquisaEOrdenacao.Sort
{
    public static class SortWithLinkedList
    {
        public static DoublyLinkedList BubbleSort(this DoublyLinkedList list)
        {
            bool invertido;
            do
            {
                var element = list.GetElement(1);

                invertido = false;
                for (int i = 1; i < list.Length(); i++)
                {
                    if (element.Previous.Element > element.Element)
                    {
                        var aux = element.Previous.Element;
                        element.Previous.Element = element.Element;
                        element.Element = aux;

                        invertido = true;
                    }
                    element = element.Next;
                }

            } while (invertido);
            return list;
        }

        public static DoublyLinkedList InsertionSort(this DoublyLinkedList list)
        {
            var auxElement = list.GetElement(0);

            for (int i = 0; i < list.Length(); i++)
            {
                var element = auxElement;
                int j = i;
                while (j > 0 && element.Previous.Element > element.Element)
                {
                    var aux = element.Element;
                    element.Element = element.Previous.Element;
                    element.Previous.Element = aux;

                    element = element.Previous;
                    j--;
                }
                auxElement = auxElement.Next;
            }
            return list;
        }

        public static LinkedList SelectionSort(LinkedList list)
        {
            for (Celula i = list.GetElement(0); i != null; i = i.Next)
            {
                var minimo = i;
                for (Celula j = i.Next; j != null; j = j.Next)
                {
                    if (j.Element < minimo.Element)
                    {
                        minimo = j;
                    }
                }
                var temp = i.Element;
                i.Element = minimo.Element;
                minimo.Element = temp;
            }
            return list;
        }
    }
}
