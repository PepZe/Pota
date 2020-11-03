using PesquisaEOrdenacao.Enum;
using PesquisaEOrdenacao.Lists;
using PesquisaEOrdenacao.Sort;
using System;
using System.Data;
using System.Text;
using System.Linq;
using PesquisaEOrdenacao.Model;
using PesquisaEOrdenacao.Manipulator;
using PesquisaEOrdenacao.StyleSheet;
using OfficeOpenXml;

namespace PesquisaEOrdenacao
{
    class Program
    {
        private static int[] _width = new int[] { 35, 35};
        static void Main(string[] args)
        {
            var linked = new DoublyLinkedList();
            Random rnd = new Random();
            for (int i = 0; i < 100000; i++)
            {
                linked.Add(rnd.Next());
            }

            var watch = System.Diagnostics.Stopwatch.StartNew();
            var insertion = SortWithLinkedList.InsertionSort(linked);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            var report = new ReportSortModel[1];
            report[0] = new ReportSortModel()
            {
                Sort = "Insertion Sort",
                Time = elapsedMs
            };

            GeneratReport(report);

            //var vet = new int[] { 7, 5, 2, 6, 9, 4 };
            //var r = HeapSort(vet, vet.Length);
            //foreach (var item in r)
            //{
            //    Console.WriteLine(item);
            //}

        }

        public static void GeneratReport(ReportSortModel[] reports)
        {
            var reportModelProperties = new string[] { ReportSortSettings.Name.ToString(), ReportSortSettings.Time.ToString() };
            var columnSettings = new HeaderColumnSettings[reportModelProperties.Length];

            for (int i = 0; i < columnSettings.Length; i++)
            {
                columnSettings[i].MaxWidth = _width[i];
                columnSettings[i].ColumnNumber = i + 1;
                columnSettings[i].ColumnValue = reportModelProperties[i];
            }
            var xlsx = new XlsxManipulator(new XlsxStyles());
            xlsx.GenerateReport(reports.ToList(), "../../../Report", columnSettings, new ExcelRange[columnSettings.Length]);
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
