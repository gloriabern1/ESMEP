using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.IO;
using OfficeOpenXml;
using System.Collections;
using Newtonsoft.Json;

namespace ESMEP_EdoStateMinistryOfEducationPortal_.Infrastructure
{
    /// <summary>
    /// Summary description for ExcelPlus
    /// </summary>
    public class ExcelPlus
    {
        public ExcelPlus()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DataSet ReadExcel(string fullFilePath, int startColumnHeader)
        {
            DataSet ds = null;

            FileInfo savedFile = new FileInfo(fullFilePath);
            if (savedFile.Exists)
            {
                using (ExcelPackage package = new ExcelPackage(savedFile))
                {

                    ds = new DataSet("ExcelRecords");

                    foreach (ExcelWorksheet ws in package.Workbook.Worksheets)
                    {

                        //DataTable dt = ds.Tables.Add(ws.Name);

                        DataTable dt = new DataTable(ws.Name);

                        //First read the first row assuming they are the column headers
                        //Stop reading when we encounter a blank cell or if we reach column limit of 100 columns
                        int columnLimit = 200;
                        int startingRow = 1;
                        string cellValue = "";

                        for (int i = 1; i <= columnLimit; i++)
                        {
                            cellValue = Convert.ToString(ws.Cells[startingRow, i].Value).Trim();

                            //If the column value is blank then break out of the loop assuming there is no more column header to read
                            if (cellValue == "")
                            {
                                break;
                            }

                            dt.Columns.Add(cellValue);

                        }

                        //Now read each subsequent row, using column count as cell index, until we encounter a row that has no value in any of its cells
                        //Max row is set at 1000000
                        int columnCount = dt.Columns.Count;
                        int maxRow = 1000000;
                        ArrayList rowCells = new ArrayList();
                        bool rowHasValue = false;
                        string rowCellValue = "";

                        for (int i = 2; i <= maxRow; i++)
                        {
                            //init internal variables: rowCellValue is to hold the respective cell values at each iteration
                            //rowHasValue indicates whether a row had any value at all in any of its cells
                            rowCells.Clear();
                            rowCellValue = "";
                            rowHasValue = false;

                            for (int j = 1; j <= columnCount; j++)
                            {
                                rowCellValue = Convert.ToString(ws.Cells[i, j].Value).Trim();

                                //check if a value was retrieved
                                rowHasValue = rowCellValue != "" ? true : rowHasValue;

                                rowCells.Add(rowCellValue);

                            }

                            //if no value was retrieved from any cell of the row then break out of the loop
                            if (!rowHasValue)
                            {
                                break;
                            }

                            dt.Rows.Add(rowCells.ToArray());
                        }

                        if (dt.Rows.Count > 0)
                        {
                            ds.Tables.Add(dt);
                        }
                    }

                    if (ds.Tables.Count < 1)
                    {
                        ds = null;
                    }
                }
            }
            return ds;
        }
    }

}