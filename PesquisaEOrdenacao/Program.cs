using PesquisaEOrdenacao.Enum;
using PesquisaEOrdenacao.Lists;
using PesquisaEOrdenacao.Sort;
using System;
using PesquisaEOrdenacao.Model;
using PesquisaEOrdenacao.Manipulator;
using PesquisaEOrdenacao.StyleSheet;
using OfficeOpenXml;
using System.Diagnostics;

namespace PesquisaEOrdenacao
{
    class Program
    {
        private static int[] _width = new int[] { 35, 35, 35, 35 };
        static void Main(string[] args)
        {
            var length = new int[] { 100, 1000, 10000, 100000 };
            var report = new System.Collections.Generic.List<ReportSortModel>();

            GenerateReportInsertionSort(length, report);
            GenerateReportBubbleSort(length, report);
            GenerateReportSelectionSort(length, report);
            GenerateReportMergeSort(length, report);

            GeneratReport(report);

        }

        private static void GenerateReportMergeSort(int[] length, System.Collections.Generic.List<ReportSortModel> report)
        {
            for (int i = 0; i < length.Length; i++)
            {
                var vet = new int[length[i]];
                var linked = new LinkedList();

                SetVectorAndList(length[i], linked, vet);

                var watch = Stopwatch.StartNew();
                SortWithVectors.MergeSort(vet, 0, vet.Length - 1);
                watch.Stop();
                var elapsedMsVector = watch.ElapsedMilliseconds;

                report.Add(new ReportSortModel()
                {
                    Sort = "Merge",
                    Time = elapsedMsVector,
                    Length = length[i],
                    ordenation = OrdenationType.Vector
                });
            }
        }

        private static void GenerateReportSelectionSort(int[] length, System.Collections.Generic.List<ReportSortModel> report)
        {
            for (int i = 0; i < length.Length; i++)
            {
                var vet = new int[length[i]];
                var linked = new LinkedList();

                SetVectorAndList(length[i], linked, vet);

                var watch = Stopwatch.StartNew();
                SortWithLinkedList.SelectionSort(linked);
                watch.Stop();
                var elapsedMsList = watch.ElapsedMilliseconds;

                watch = Stopwatch.StartNew();
                SortWithVectors.SelectionSort(vet);
                watch.Stop();
                var elapsedMsVector = watch.ElapsedMilliseconds;

                report.Add(new ReportSortModel()
                {
                    Sort = "Selection",
                    Time = elapsedMsList,
                    Length = length[i],
                    ordenation = OrdenationType.List
                });
                report.Add(new ReportSortModel()
                {
                    Sort = "Selection",
                    Time = elapsedMsVector,
                    Length = length[i],
                    ordenation = OrdenationType.Vector
                });
            }
        }

        private static void GenerateReportBubbleSort(int[] length, System.Collections.Generic.List<ReportSortModel> report)
        {
            for (int i = 0; i < length.Length; i++)
            {
                var vet = new int[length[i]];
                var linked = new DoublyLinkedList();

                SetVectorAndList(length[i], linked, vet);

                var watch = Stopwatch.StartNew();
                SortWithLinkedList.BubbleSort(linked);
                watch.Stop();
                var elapsedMsList = watch.ElapsedMilliseconds;

                watch = Stopwatch.StartNew();
                SortWithVectors.BubbleSort(vet);
                watch.Stop();
                var elapsedMsVector = watch.ElapsedMilliseconds;

                report.Add(new ReportSortModel()
                {
                    Sort = "Bubble",
                    Time = elapsedMsList,
                    Length = length[i],
                    ordenation = OrdenationType.List
                });
                report.Add(new ReportSortModel()
                {
                    Sort = "Bubble",
                    Time = elapsedMsVector,
                    Length = length[i],
                    ordenation = OrdenationType.Vector
                });
            }
        }

        private static void GenerateReportInsertionSort(int[] length, System.Collections.Generic.List<ReportSortModel> report)
        {
            for (int i = 0; i < length.Length; i++)
            {
                var vet = new int[length[i]];
                var linked = new DoublyLinkedList();

                SetVectorAndList(length[i], linked, vet);

                var watch = Stopwatch.StartNew();
                SortWithLinkedList.InsertionSort(linked);
                watch.Stop();
                var elapsedMsList = watch.ElapsedMilliseconds;

                watch = Stopwatch.StartNew();
                SortWithVectors.InsertionSort(vet);
                watch.Stop();
                var elapsedMsVector = watch.ElapsedMilliseconds;

                report.Add(new ReportSortModel()
                {
                    Sort = "Insertion",
                    Time = elapsedMsList,
                    Length = length[i],
                    ordenation = OrdenationType.List
                });
                report.Add(new ReportSortModel()
                {
                    Sort = "Insertion",
                    Time = elapsedMsVector,
                    Length = length[i],
                    ordenation = OrdenationType.Vector
                });
            }
        }

        private static void SetVectorAndList(int length, DoublyLinkedList linked, int[] vet)
        {
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                var num = rnd.Next(1001);
                linked.Add(num);
                vet[i] = (rnd.Next(1001));
            }
        }

        private static void SetVectorAndList(int length, LinkedList linked, int[] vet)
        {
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                var num = rnd.Next(1001);
                linked.Add(num);
                vet[i] = (rnd.Next(1001));
            }
        }

        public static void GeneratReport(System.Collections.Generic.List<ReportSortModel> reports)
        {
            var reportModelProperties = new string[] { ReportSortSettings.Name.ToString(), ReportSortSettings.Time.ToString(),
                ReportSortSettings.SortType.ToString(), ReportSortSettings.Length.ToString() };

            var columnSettings = new HeaderColumnSettings[reportModelProperties.Length];

            for (int i = 0; i < columnSettings.Length; i++)
            {
                columnSettings[i].MaxWidth = _width[i];
                columnSettings[i].ColumnNumber = i + 1;
                columnSettings[i].ColumnValue = reportModelProperties[i];
            }
            var xlsx = new XlsxManipulator(new XlsxStyles());
            xlsx.GenerateReport(reports, "../../../Report", columnSettings, new ExcelRange[columnSettings.Length]);
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
