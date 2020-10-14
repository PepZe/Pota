using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace PesquisaEOrdenacao.StyleSheet
{
    /// <summary>
    /// Xlsx file styles.
    /// </summary>
    public class XlsxStyles
    {
        /// <summary>
        /// Define horizontal alignment.
        /// </summary>
        /// <param name="excelStyle">An excel style.</param>
        /// <param name="alignment">Type alignment.</param>
        public void SetHorizontalAlignment(ExcelStyle excelStyle, ExcelHorizontalAlignment alignment)
        {
            excelStyle.HorizontalAlignment = alignment;
        }
        /// <summary>
        /// Define vertical alignment.
        /// </summary>
        /// <param name="excelStyle">An excel style.</param>
        /// <param name="alignment">Type alignment.</param>
        public void SetVerticalAlignment(ExcelStyle excelStyle, ExcelVerticalAlignment alignment)
        {
            excelStyle.VerticalAlignment = alignment;
        }
        /// <summary>
        /// Set cell value.
        /// </summary>
        /// <param name="excelRange">Excel cell.</param>
        /// <param name="value">Value cell.</param>
        public void SetValue(ExcelRange excelRange, string value)
        {
            excelRange.Value = value;
        }
        /// <summary>
        /// Define font style.
        /// </summary>
        /// <param name="excelFont">Excel font.</param>
        /// <param name="color">Font color.</param>
        public void SetColorFont(ExcelFont excelFont, Color color)
        {
            excelFont.Color.SetColor(color);
        }
        /// <summary>
        /// Define font bold.
        /// </summary>
        /// <param name="excelFont">Excel font.</param>
        /// <param name="activate">The bold value.</param>
        public void SetBoldFont(ExcelFont excelFont, bool activate)
        {
            excelFont.Bold = activate;
        }
        /// <summary>
        /// Define color styles.
        /// </summary>
        /// <param name="excelFill">Excel fill.</param>
        /// <param name="color">Color background.</param>
        public void SetColorBackground(ExcelFill excelFill, Color color)
        {
            excelFill.PatternType = ExcelFillStyle.Solid;
            excelFill.BackgroundColor.SetColor(color);
        }
        /// <summary>
        /// Define border style.
        /// </summary>
        /// <param name="border">Excel border.</param>
        /// <param name="borderStyle">Border type.</param>
        public void SetBorderStyle(Border border, ExcelBorderStyle borderStyle)
        {
            border.Top.Style = borderStyle;
            border.Left.Style = borderStyle;
            border.Right.Style = borderStyle;
            border.Bottom.Style = borderStyle;
        }
        /// <summary>
        /// Define column alignment.
        /// </summary>
        /// <param name="excelColumn">Excel column.</param>
        /// <param name="alignment">Alignment of the column.</param>
        public void SetColumnAlignment(ExcelColumn excelColumn, ExcelHorizontalAlignment alignment)
        {
            excelColumn.Style.HorizontalAlignment = alignment;
        }
        /// <summary>
        /// Define column width.
        /// </summary>
        /// <param name="excelColumn">Excel column.</param>
        /// <param name="maxWidth">Maximum column width.</param>
        /// <param name="minWidth">Minimum column width.</param>
        public void SetAutoFitColumn(ExcelColumn excelColumn, double maxWidth, double minWidth)
        {
            excelColumn.AutoFit(minWidth, maxWidth);
        }
        /// <summary>
        /// Set a column wrap value.
        /// </summary>
        /// <param name="column">Excel column.</param>
        /// <param name="activate">The wrap value.</param>
        public void SetColumnWrapTex(ExcelColumn column, bool activate)
        {
            column.Style.WrapText = activate;
        }
    }
}