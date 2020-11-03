using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PesquisaEOrdenacao.Sort
{
    public static class SortWithVectors
    {

        public static int[] BubbleSort(this int[] list)
        {
            bool invertido;
            do
            {
                invertido = false;
                for (int i = 1; i < list.Length; i++)
                {
                    if (list[i - 1] > list[i])
                    {
                        var aux = list[i - 1];
                        list[i - 1] = list[i];
                        list[i] = aux;

                        invertido = true;
                    }
                }

            } while (invertido);
            return list;
        }
        public static int[] InsertionSort(this int[] list)
        {
            for (int i = 1; i < list.Length; i++)
            {
                int j = i;
                while (j > 0 && list[j - 1] > list[j])
                {
                    var aux = list[j];
                    list[j] = list[j - 1];
                    list[j - 1] = aux;
                    j--;
                }
            }
            return list;
        }

        public static int[] MergeSort(int[] vet, int indiceInicial, int indiceFinal)
        {
            if (indiceInicial < indiceFinal)
            {
                int meioDoVetor = (indiceInicial + indiceFinal) / 2;
                MergeSort(vet, indiceInicial, meioDoVetor);
                MergeSort(vet, meioDoVetor + 1, indiceFinal);
                Intercala(vet, indiceInicial, meioDoVetor, indiceFinal);
            }
            return vet;
        }
        private static void Intercala(int[] vet, int indiceInicial, int meioDoVetor, int indiceFinal)
        {
            int[] novoVetor = new int[vet.Length];

            int i, j;
            for (i = indiceInicial; i <= meioDoVetor; i++)
            {
                novoVetor[i] = vet[i];
            }
            for (j = meioDoVetor + 1; j <= indiceFinal; j++)
            {
                novoVetor[indiceFinal + meioDoVetor + 1 - j] = vet[j];
            }
            i = indiceInicial;
            j = indiceFinal;

            for (int k = indiceInicial; k <= indiceFinal; k++)
            {
                if (novoVetor[i] <= novoVetor[j])
                {
                    vet[k] = novoVetor[i];
                    i++;
                }
                else
                {
                    vet[k] = novoVetor[j];
                    j--;
                }
            }
        }


        public static int[] SelectionSort(int[] list)
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                var minimo = i;
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[j] < list[minimo])
                    {
                        minimo = j;
                    }
                }
                var temp = list[i];
                list[i] = list[minimo];
                list[minimo] = temp;
            }
            return list;
        }

        public static int[] QuickSort(int[] vet, int inicio, int fim)
        {
            if (inicio < fim)
            {
                var meio = Particionar(vet, inicio, fim);
                QuickSort(vet, inicio, meio - 1);
                QuickSort(vet, meio + 1, fim);
            }
            return vet;
        }

        private static int Particionar(int[] vet, int inicio, int fim)
        {
            var i = inicio + 1;
            var j = fim;
            int aux;

            while (i <= j)
            {
                if (vet[i] < vet[inicio])
                {
                    i++;
                }
                else
                {
                    if (vet[j] > vet[inicio])
                    {
                        j--;
                    }
                    else
                    {
                        aux = vet[i];
                        vet[i] = vet[j];
                        vet[j] = aux;
                        i++;
                        j--;
                    }
                }
            }

            aux = vet[inicio];
            vet[inicio] = vet[j];
            vet[j] = aux;
            return j;
        }

        public static int[] HeapSort(int[] vet, int tamanho)
        {
            CriaHeap(vet, tamanho);
            var fim = tamanho - 1;
            while (fim > 0)
            {
                Troca(vet, 0, fim);
                fim -= 1;
                ArrumaHeap(vet, 0, fim);
            }
            return vet;
        }

        private static void ArrumaHeap(int[] vet, int inicio, int fim)
        {
            var raiz = inicio;
            while (raiz * 2 + 1 <= fim)
            {
                var filho = raiz * 2 + 1;
                var trocar = raiz;
                if (vet[trocar] < vet[filho])
                {
                    trocar = filho;
                }

                if (filho + 1 <= fim && vet[trocar] < vet[filho + 1])
                {
                    trocar = filho + 1;
                }

                if (trocar == raiz)
                {

                    break;
                }
                else
                {
                    Troca(vet, raiz, trocar);
                    raiz = trocar;
                }
            }
        }

        private static void Troca(int[] vet, int i, int j)
        {
            var temp = vet[j];
            vet[j] = vet[i];
            vet[i] = temp;
        }

        private static void CriaHeap(int[] vet, int tamanho)
        {
            var inicio = (tamanho - 2) / 2;
            while (inicio >= 0)
            {
                ArrumaHeap(vet, inicio, tamanho - 1);
                inicio -= 1;
            }
        }
    }
}

