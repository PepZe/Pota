﻿using OfficeOpenXml;
using OfficeOpenXml.Style;
using PesquisaEOrdenacao.Model;
using PesquisaEOrdenacao.StyleSheet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace PesquisaEOrdenacao.Manipulator
{
    public class XlsxManipulator
    {
        /// <summary>
        /// Instante of XlsxStyles.
        /// </summary>
        private XlsxStyles _xlsxStyles;
        /// <summary>
        /// First line of excel.
        /// </summary>
        private const int FIRST_LINE = 1;

        /// <summary>
        /// Instantiate the class attributes.
        /// </summary>
        /// <param name="xlsxStyles">Instante of XlsxStyles.</param>
        public XlsxManipulator(XlsxStyles xlsxStyles)
        {
            _xlsxStyles = xlsxStyles;
        }

        /// <summary>
        /// Generate a xlsx report.
        /// </summary>
        /// <param name="reports">Values of the report.</param>
        /// <param name="path">File path.</param>
        /// <param name="columnsSettings">Columns settings.</param>
        /// <param name="excelFirstColumn">First column of the excel.</param>
        /// <returns>Successful file creation.</returns>
        //public bool GenerateReport(List<ReportBcModel> reports, string path,
        //    HeaderColumnSettings[] columnsSettings, ExcelRange[] excelFirstColumn)
        //{
        //    path += ".xlsx";
        //    bool successful = true;
        //    try
        //    {
        //        using (var package = new ExcelPackage(new FileInfo(path)))
        //        {
        //            var sheet = AddWorksheet(package, "Report");
        //            SetExcelRange(sheet, excelFirstColumn);
        //            SetStyles(columnsSettings, excelFirstColumn);

        //            var startRow = 2;
        //            foreach (var report in reports)
        //            {
        //                startRow = BcFillsTableRow(columnsSettings, sheet, startRow, report);
        //            }

        //            SetColumnStyles(sheet, columnsSettings);
        //            package.SaveAs(new FileInfo(path));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        successful = false;
        //    }
        //    return successful;
        //}

        /// <summary>
        /// Fill the row with the bc informations.
        /// </summary>
        /// <param name="columnsSettings">Columns settings.</param>
        /// <param name="sheet">The current sheet.</param>
        /// <param name="row">Row to be filled.</param>
        /// <param name="bcModel">The bc informations.</param>
        /// <returns>The next row to be filled.</returns>
        //private int BcFillsTableRow(HeaderColumnSettings[] columnsSettings, ExcelWorksheet sheet, int row, ReportBcModel bcModel)
        //{
        //    _xlsxStyles.SetBorderStyle(sheet.Cells
        //                    [row, columnsSettings.First().ColumnNumber,
        //                    row, columnsSettings.Last().ColumnNumber]
        //                    .Style.Border, ExcelBorderStyle.Thin);

        //    _xlsxStyles.SetColorBackground(sheet.Cells[row, columnsSettings.First().ColumnNumber,
        //        row, columnsSettings.Last().ColumnNumber].Style.Fill, Color.LightGray);

        //    var method = GetHeaderColumnSettingsByKey(columnsSettings, ReportBcSettings.Method);
        //    sheet.Cells[row, method.First().ColumnNumber].Value = bcModel.BcModel.Method;

        //    var timeStart = GetHeaderColumnSettingsByKey(columnsSettings, ReportBcSettings.StartTime);
        //    sheet.Cells[row, timeStart.First().ColumnNumber].Value = bcModel.StartDate.ToString(DateFilter.DATE_PRINTER_FORMAT);

        //    var timeSpent = GetHeaderColumnSettingsByKey(columnsSettings, ReportBcSettings.TimeSpent);
        //    sheet.Cells[row, timeSpent.First().ColumnNumber].Value = bcModel.TimeSpan.ToString();

        //    var parameters = GetHeaderColumnSettingsByKey(columnsSettings, ReportBcSettings.Parameters);
        //    sheet.Cells[row, parameters.First().ColumnNumber].Value = bcModel.BcModel.Parameters;

        //    var statusReturn = GetHeaderColumnSettingsByKey(columnsSettings, ReportBcSettings.Status);
        //    sheet.Cells[row, statusReturn.First().ColumnNumber].Value = bcModel.BcModel.Status;

        //    row++;
        //    return row;
        //}

        /// <summary>
        /// Get header column by key.
        /// </summary>
        /// <param name="columnSettings">The header to consult.</param>
        /// <param name="reportBcSetting">Selection key.</param>
        /// <returns>The selected header.</returns>
        //private HeaderColumnSettings[] GetHeaderColumnSettingsByKey(HeaderColumnSettings[] columnSettings, ReportBcSettings reportBcSetting)
        //{
        //    return columnSettings.Where(column => column.ColumnValue == reportBcSetting.ToString()).ToArray();
        //}

        /// <summary>
        /// Add worksheet.
        /// </summary>
        /// <param name="package">Excel package.</param>
        /// <param name="name">Name of the sheet.</param>
        /// <returns>Created Work sheet.</returns>
        private ExcelWorksheet AddWorksheet(ExcelPackage package, string name)
        {
            var workbook = package.Workbook;
            return workbook.Worksheets.Add(name);
        }
        /// <summary>
        /// Set excel range with the first column.
        /// </summary>
        /// <param name="sheet">The excel sheet.</param>
        /// <param name="excelFirstColumn">First column of the excel.</param>
        private void SetExcelRange(ExcelWorksheet sheet, ExcelRange[] excelFirstColumn)
        {
            for (int i = 0, column = 1; i < excelFirstColumn.Length; i++, column++)
            {
                excelFirstColumn[i] = sheet.Cells[FIRST_LINE, column];
            }
        }
        /// <summary>
        /// Set the column width.
        /// </summary>
        /// <param name="sheet">The excel sheet.</param>
        /// <param name="_columnsSettings">Columns settings.</param>
        private void SetColumnStyles(ExcelWorksheet sheet, HeaderColumnSettings[] _columnsSettings)
        {
            foreach (HeaderColumnSettings columnSetting in _columnsSettings)
            {
                _xlsxStyles.SetAutoFitColumn(sheet.Column(columnSetting.ColumnNumber), columnSetting.MaxWidth, 0);
                _xlsxStyles.SetColumnWrapTex(sheet.Column(columnSetting.ColumnNumber), true);
                _xlsxStyles.SetColumnAlignment(sheet.Column(columnSetting.ColumnNumber), ExcelHorizontalAlignment.Center);
                _xlsxStyles.SetVerticalAlignment(sheet.Column(columnSetting.ColumnNumber).Style, ExcelVerticalAlignment.Center);
            }
        }
        /// <summary>
        /// Set styles of the table.
        /// </summary>
        /// <param name="_columnsSettings">Columns settings.</param>
        /// <param name="excelFirstColumn">First column of the excel.</param>
        private void SetStyles(HeaderColumnSettings[] _columnsSettings, ExcelRange[] excelFirstColumn)
        {
            for (int i = 0; i < excelFirstColumn.Length; i++)
            {
                _xlsxStyles.SetBorderStyle(excelFirstColumn[i].Style.Border, ExcelBorderStyle.Thin);
                _xlsxStyles.SetBoldFont(excelFirstColumn[i].Style.Font, true);
                _xlsxStyles.SetColorBackground(excelFirstColumn[i].Style.Fill, Color.Gray);
                _xlsxStyles.SetColorFont(excelFirstColumn[i].Style.Font, Color.White);
                _xlsxStyles.SetValue(excelFirstColumn[i], _columnsSettings[i].ColumnValue);
                _xlsxStyles.SetHorizontalAlignment(excelFirstColumn[i].Style, ExcelHorizontalAlignment.Center);
            }
        }
    }
}