using PesquisaEOrdenacao.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PesquisaEOrdenacao.Lists
{
    public class DoublyLinkedList
    {
        public Celula First = null;
        public Celula Last;
        private int _totalElements = 0;

        public void AddBeginning(int element)
        {
            var newElement = new Celula(element);

            if (_totalElements == 0)
            {
                First = newElement;
                Last = newElement;
            }
            else
            {
                First.Previous = newElement;
                First = newElement;
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
                var newElement = new Celula(elemento, null);
                Last.Next = newElement;
                newElement.Previous = Last;
                Last = newElement;
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
                var nextElement = previous.Next;

                var newElement = new Celula(element, previous.Next)
                {
                    Previous = previous
                };

                previous.Next = newElement;
                nextElement.Previous = newElement;
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

        public void RemoveLast()
        {
            if (_totalElements == 1)
            {
                RemoveFirst();
            }
            else
            {
                var penult = Last.Previous;
                penult.Next = null;
                Last = penult;
                _totalElements--;
            }
        }

        public void Remove(int index)
        {
            if (index < 0 || index > _totalElements)
            {
                throw new ArgumentException("Invalid index");
            }
            else if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == _totalElements)
            {
                RemoveLast();
            }
            else
            {
                var previous = GetElement(index - 1);
                var current = previous.Next;
                var next = current.Next;

                previous.Next = next;
                next.Previous = previous;

                _totalElements--;
            }
        }

        public bool Contains(int element)
        {
            var current = First;

            while (current != null)
            {
                if (current.Element == element)
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public int Length() => _totalElements;

        public override string ToString()
        {
            if (_totalElements == 0)
            {
                return "";
            }
            var atual = First;

            string result = "" + atual.Element;
            atual = atual.Next;

            for (int i = 1; i < _totalElements; i++)
            {
                result += ", " + atual.Element;
                atual = atual.Next;
            }

            return result;
        }
    }
}
