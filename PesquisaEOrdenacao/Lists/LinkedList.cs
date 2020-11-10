using PesquisaEOrdenacao.Model;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace PesquisaEOrdenacao.Lists
{
    public class LinkedList
    {
        public Celula First = null;
        public Celula Last;
        private int _totalElements = 0;

        public void AddBeginning(int elemento)
        {
            var nova = new Celula(elemento, First);
            First = nova;

            if (_totalElements == 0)
            {
                Last = First;
            }

            _totalElements++;
        }

        public void Add(int elemento)
        {
            if (_totalElements == 0)
            {
                AddBeginning(elemento);
            }
            else
            {
                var nova = new Celula(elemento, null);
                Last.Next = nova;
                Last = nova;
                _totalElements++;
            }
        }


        public void Add(int index, int element)
        {
            if (index == 0)
            {
                AddBeginning(element);
            }
            else if (index == _totalElements)
            {
                Add(element);
            }
            else
            {
                var previous = GetElement(index - 1);
                var newElement = new Celula(element, previous.Next);
                previous.Next = newElement;
                _totalElements++;
            }
        }

        public bool ElementExist(int index) => index >= 0 && index <= _totalElements;

        public Celula GetElement(int index)
        {
            if (!ElementExist(index))
            {
                throw new ArgumentException("element was not found");
            }
            var atual = First;
            for (int i = 0; i < index; i++)
            {
                atual = atual.Next;
            }
            return atual;
        }

        public int Get(int index)
        {
            return GetElement(index).Element;
        }

        public void RemoveFirst()
        {
            if (_totalElements == 0)
            {
                throw new ArgumentException("Empty list");
            }
            First = First.Next;
            _totalElements--;

            if (_totalElements == 0)
            {
                Last = null;
            }
        }

        public int Length() => _totalElements;

        public override string ToString()
        {
            if (_totalElements == 0)
            {
                return "";
            }
            var current = First;

            string result = "" + current.Element;
            current = current.Next;

            for (int i = 1; i < _totalElements; i++)
            {
                result += ", " + current.Element;
                current = current.Next;
            }

            return result;
        }
    }
}
