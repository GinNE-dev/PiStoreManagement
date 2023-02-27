﻿

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PiStoreManagement.Tools
{
    public class DataExporter
    {
        const string ResourceFolderName = "Resources";
        const string DataExportFolderName = "Exports";
        const string BillFolderName = "Bills";
        const string FILE_FILTER = "CSV (*.csv)|*.csv";
        const string CSV_FILE_EXTENSION = ".csv";
        const string PDF_FILE_EXTENSION = ".pdf";

        private static void PrepareExportFolder()
        {
            if(!Directory.Exists(ResourceFolderName))
            {
                Directory.CreateDirectory(ResourceFolderName);
            }

            if(!Directory.Exists(DataExportFolderName))
            {
                Directory.CreateDirectory(Path.Combine(ResourceFolderName, DataExportFolderName));
            }
        }

        private static void PrepareBillFolder()
        {
            if (!Directory.Exists(ResourceFolderName))
            {
                Directory.CreateDirectory(ResourceFolderName);
            }

            if (!Directory.Exists(DataExportFolderName))
            {
                Directory.CreateDirectory(Path.Combine(ResourceFolderName, BillFolderName));
            }
        }
        public static int ExportToCSV(DataGridView dg, string filename, List<string> skipColumns)
        {
            if(dg.Rows.Count == 0) return 0;

            PrepareExportFolder();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = FILE_FILTER;
            sfd.FileName = Path.Combine(ResourceFolderName, DataExportFolderName, filename+CSV_FILE_EXTENSION);

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

        public static void ExportBill(Bill bill)
        {
            GenerateBill(bill);
        }

        private static void GenerateBill(Bill bill)
        {
            Document document = new Document();

            PrepareBillFolder();
            string outputFilePath = "Bill " + DateTime.Now.ToString().Replace('/', '-').Replace(':', '-')+PDF_FILE_EXTENSION;
            outputFilePath = Path.Combine(ResourceFolderName, BillFolderName, outputFilePath);

            PdfWriter.GetInstance(document, new FileStream(outputFilePath, FileMode.Create));

            document.Open();

            Font lableFont = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.ITALIC + Font.BOLD);
            Font normalTextFont = new Font(Font.FontFamily.TIMES_ROMAN, 12, Font.ITALIC);
            Paragraph title = new Paragraph("Bill", new Font(Font.FontFamily.TIMES_ROMAN, 20, Font.BOLD));
            Paragraph shopName = new Paragraph("Pi Store", new Font(Font.FontFamily.TIMES_ROMAN, 24, Font.BOLD));
            shopName.Alignment = Element.ALIGN_CENTER;
            title.Alignment = Element.ALIGN_CENTER;
            
            Paragraph shopEmail = new Paragraph("Shop Contact: thanhvinhle73@gmail.com", lableFont);
            shopEmail.Alignment = Element.ALIGN_RIGHT;
            
            Paragraph staff = new Paragraph("Staff: ", lableFont);
            staff.Add(new Paragraph(bill.Employee.Name, normalTextFont));
            Paragraph customer = new Paragraph("Customer: ", lableFont);
            customer.Add(new Paragraph(bill.Client.Name, normalTextFont));
            Paragraph billDate = new Paragraph("Bill Date: ", lableFont);
            billDate.Add(new Paragraph(bill.BillDate.ToString(), normalTextFont));
            Paragraph billProducts = new Paragraph("Products: ", lableFont);
            Paragraph totalCost = new Paragraph("Total Cost: " + bill.TotalPrice.ToString("C"), lableFont);


            document.Add(shopName);
            document.Add(title);
            document.Add(shopEmail);
            document.Add(staff);
            document.Add(customer);
            document.Add(billDate);
            document.Add(billProducts);

            // Add a table to the document
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;
            table.AddCell("Name");
            table.AddCell("Quantity");
            table.AddCell("Unit Price");
            table.AddCell("Total Price");

            //Products
            foreach (OrderItem oi in bill.Order.OrderItems)
            {
                table.AddCell(oi.Product.Name);
                table.AddCell(oi.Quantity.ToString("N0"));
                table.AddCell(oi.Product.Price.ToString("C"));
                table.AddCell((oi.Quantity*oi.Product.Price).ToString("C"));
            }
            
            document.Add(table);
            document.Add(totalCost);

            document.Close();
        }

        static void AddContentToColumn(ColumnText columnText, string content)
        {
            columnText.AddElement(new Paragraph(content));
        }
    }
}
