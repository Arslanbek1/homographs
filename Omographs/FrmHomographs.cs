using BrightIdeasSoftware;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using DocumentFormat.OpenXml.Spreadsheet;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Homographs
{
    public partial class FrmHomographs : Form
    {
        public FrmHomographs()
        {
            InitializeComponent();
        }

        private void FrmHomographs_Load(object sender, EventArgs e)
        {
            // Grouping by courses==========================================
            OLVColumn clm = ((OLVColumn)olvHomographs.Columns[0]);

            /* clm.GroupKeyGetter = delegate (object rowObject) {
                 WordForm wf = (WordForm)rowObject;
                 return wf.Title;
             };

             clm.GroupKeyToTitleConverter = delegate (object groupKey) {
                 return groupKey.ToString();
             };
             clm.Groupable = true;
             // ==============================================================
         
             */

            olvHomographs.SetObjects(WordForm.GetHomographsList());
            label1.Text = "Количество омографов:" + olvHomographs.Items.Count;
            olvHomographs.Refresh();
        }

        public static void ErrLog(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter("DoshStat.log", true)) {
                sw.WriteLine(GetCurrentDateTime() + " : " + ex.Message);
                sw.WriteLine(ex.StackTrace.ToString());
                sw.WriteLine();
            }
        }
        public static void ErrLog(String caption, String msg)
        {
            using (StreamWriter sw = new StreamWriter("DoshStat.log", true)) {
                sw.WriteLine(GetCurrentDateTime() + " : " + caption);
                sw.WriteLine(msg);
                sw.WriteLine();
            }
        }
        public static void Logging(String ex)
        {
            Debug.WriteLine("Internal String Error" + ex);
        }
        public static void Logging(string format, params object[] args)
        {
            Debug.WriteLine(format, args);
        }
        public static string GetCurrentDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
        public static string GetCurrentDateTime()
        {
            string dt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return dt;
        }

        public static void ExcelExport(ObjectListView olv, string defaultName)
        {
            SLDocument sl = new SLDocument();
            SLStyle style = sl.CreateStyle();

            for (int i = 1; i <= olv.Columns.Count; ++i) {
                sl.SetCellValue(1, i, olv.Columns[i - 1].Text);
            }

            for (int i = 1; i <= olv.Columns.Count; ++i) {
                for (int j = 1; j <= olv.Items.Count; ++j) {
                    string cellVal = olv.Items[j - 1].SubItems[i - 1].Text;
                    int cellValNumeric = -1;
                    if (int.TryParse(cellVal, out cellValNumeric)) {
                        sl.SetCellValue(j + 1, i, cellValNumeric);
                    } else {
                        sl.SetCellValue(j + 1, i, cellVal);
                    }

                        System.Drawing.Color backColor = olv.Items[j - 1].BackColor;
                        System.Drawing.Color foreColor = olv.Items[j - 1].ForeColor;
                        style.Fill.SetPattern(PatternValues.Solid, backColor, foreColor);

                        sl.SetCellStyle(j + 1, i, style);

                    SLTable tbl = sl.CreateTable(1, 1, olv.Items.Count + 1, olv.Columns.Count);
                    // Синий
                    //tbl.SetTableStyle(SLTableStyleTypeValues.Medium2);
                    // Зеленый
                    //tbl.SetTableStyle(SLTableStyleTypeValues.Medium4);
                    // Красный
                    //tbl.SetTableStyle(SLTableStyleTypeValues.Medium3); 
                    tbl.Sort(1, false);
                    sl.InsertTable(tbl);
                }
            }                              

            SaveFileDialog saveFileDialog1 = new SaveFileDialog() {
                Filter = "XLS Format|*.xlsx",
                FileName = defaultName + " " + GetCurrentDate() + ".xlsx",
                Title = "Экспорт ... "
            };

            DialogResult dResult = saveFileDialog1.ShowDialog();
            if (dResult == DialogResult.OK) {
                sl.SaveAs(saveFileDialog1.FileName);
                Process.Start(saveFileDialog1.FileName);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            ExcelExport(olvHomographs, "Homographs " + GetCurrentDate());
        }

        private void olvHomographs_SelectedIndexChanged(object sender, EventArgs e)
        {
            var v = olvHomographs.SelectedObject;
            

        }
    }
}
