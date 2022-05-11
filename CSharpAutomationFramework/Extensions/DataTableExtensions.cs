using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace CSharpAutomationFramework.Extensions
{
    public static class DataTableExtensions
    {
        public static Table ToTable(this DataTable dataTable, string dateFormat = "dd/MM/yyyy HH:mm:ss")
        {
            var columnNames = dataTable.Columns.Cast<DataColumn>()
                .Select(x => x.ColumnName)
                .ToArray();
            var returnTable = new Table(columnNames);
            foreach (DataRow row in dataTable.Rows)
            {
                var list = new List<string>();
                foreach (DataColumn column in dataTable.Columns)
                {
                    if (column.DataType == Type.GetType("System.DateTime"))
                    {
                        if (string.IsNullOrEmpty(row[column].ToString()))
                        {
                            list.Add(string.Empty);
                        }
                        else
                        {
                            list.Add(Convert.ToDateTime(row[column].ToString()).ToString(dateFormat));
                        }
                    }
                    else
                    {
                        list.Add(row[column].ToString());
                    }
                }

                returnTable.AddRow(list.ToArray());
            }

            return returnTable;
        }
    }
}
