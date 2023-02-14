using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PiStoreManagement.Tools
{
    public class DataExporter
    {
        const string FILE_FILTER = "CSV (*.csv)|*.csv";
        const string CSV_FILE_EXTENSION = ".csv";
        public static int ExportToCSV(DataGridView dg, string filename, List<string> skipColumns)
        {
            if(dg.Rows.Count == 0) return 0;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = FILE_FILTER;
            sfd.FileName = filename+CSV_FILE_EXTENSION;

            bool isDuplicated = false;
            if (File.Exists(sfd.FileName))
            {
                try
                {
                    File.Delete(sfd.FileName);
                }
                catch (IOException ex)
                {
                    isDuplicated = true;
                    MessageBox.Show("Can't replace existed file!" + ex.Message);
                }
            }
            if (isDuplicated) return -2;

            string[] csvlines = new string[dg.Rows.Count + 1];
            List<string> lines = new List<string>();
            StringBuilder line = new StringBuilder();
            foreach(DataGridViewColumn column in dg.Columns)
            {
                if (skipColumns.Contains(column.Name)) continue;
                line.Append(column.Name+",");
            }

            line.Remove(line.Length-1, 1);
            lines.Add(line.ToString());
            foreach(DataGridViewRow row in dg.Rows)
            {
                line.Clear();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (skipColumns.Contains(cell.OwningColumn.Name)) continue;
                    line.Append(cell.Value.ToString().Replace(',', ' ')+ ",");
                }
                line.Remove(line.Length - 1, 1);
                lines.Add(line.ToString());
            }
            
            File.WriteAllLines(sfd.FileName, lines, Encoding.UTF8);

            return lines.Count-1;
        }

        public void ExportBill()
        {
            //GcWordDocument doc = new GcWordDocument();

            //Load the template DOCX
            //doc.Load(Path.Combine("Resources", "WordDocs", "InvoiceTemplate.docx"));
        }
    }
}
