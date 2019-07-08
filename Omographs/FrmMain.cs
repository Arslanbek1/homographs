using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Linq;

namespace Homographs
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void HomographsFromMaciev()
        {
            Boolean isHomograph = false;
            string[] macievLines = File.ReadAllLines(txtDict.Text);
            List<String> newLines = new List<string>();

            for (int i = 0; i < macievLines.Length; i++) {
                if (i != macievLines.Length - 1 && (macievLines[i].Split(' ')[0] == macievLines[i + 1].Split(' ')[0])) {
                    isHomograph = true;
                    newLines.Add(macievLines[i]);
                } else if (isHomograph) {
                    isHomograph = false;
                    newLines.Add(macievLines[i]);
                }
            }
            File.WriteAllLines("output.txt", newLines.ToArray(), System.Text.Encoding.UTF8);
            Process.Start("output.txt");
        }

        private void RemoveUnnecessaryLines()
        {
            string[] lines = File.ReadAllLines(txtSlovnik.Text);

            using (StreamWriter sw = new StreamWriter("slovnik_out.txt", false, System.Text.Encoding.UTF8)) {
                for (int i = 0; i < lines.Length; i++) {
                    if (i + 1 != lines.Length && lines[i + 1].Substring(1, 1) == ".") {
                        sw.Write(lines[i] + ", ");
                    } else {
                        sw.WriteLine(lines[i]);
                    }
                }
            }
            Console.WriteLine("Done");
        }

        private void LoadSlovnikData()
        {
            string[] slovnikLines = File.ReadAllLines(txtSlovnik.Text);

            SlovnikEntry.Entries = new List<SlovnikEntry>();
            for (int i = 0; i < slovnikLines.Length; i++) {
                SlovnikEntry sw = new SlovnikEntry(i, slovnikLines[i]);
                SlovnikEntry.Entries.Add(sw);
            }
            Console.WriteLine("LoadSlovnikData - Done");
        }


        private void FindHomographs()
        {
            WordForm.Homographs = new List<List<WordForm>>();

            // Get all the words, i.e. word forms
            var q = SlovnikEntry.Entries.SelectMany(x => x.Forms);

            foreach (var w in q) {
                // Get all the word forms that occur two or more times
                var occurrences = q.Where(x => x.Title.Equals(w.Title) && x.isProcessed == false);
                if (occurrences.Count() > 1) {
                    // Iterate through homographs

                    List<WordForm> homo = new List<WordForm>();
                    foreach (var o in occurrences) {
                        // Find out which is the root word
                        // var parent = SlovnikData.Single(x => x.Id == o.ParentId);
                        // progress report
                        homo.Add(o);
                        // Clear to prevent from forming duplicates
                        o.isProcessed = true;
                    }
                    WordForm.Homographs.Add(homo);
                }
            }
            using (StreamWriter sw = new StreamWriter("export.txt", false, System.Text.Encoding.UTF8)) {
                foreach (var homo in WordForm.Homographs) {
                    // homo.Sort((x, y) => x.WordId.CompareTo(y.WordId));
                    foreach (var wordForm in homo) {
                        sw.WriteLine(string.Format("WordId:{0,7} ║ Word:{1,25} ║ WordDescription:{2,100} ║ WordFormId:{3,7} ║ WordForm:{4, 25} ║ WordFormDescription:{5,6}",
                           wordForm.RootId, SlovnikEntry.Entries.Single(x => x.RootId == wordForm.RootId).RootTitle, SlovnikEntry.Entries.Single(x => x.RootId == wordForm.RootId).RootDescription, wordForm.Id, wordForm.Title, wordForm.Description));
                    }
                }
            }

            Console.WriteLine("Done");
        }

        private void ClearSlovnik()
        {
            // Remove all but homographs
            HashSet<string> raw_homographs = new HashSet<string>();
            foreach (var line in File.ReadAllLines("duplicates.txt", System.Text.Encoding.UTF8)) raw_homographs.Add(line);

            using (StreamWriter oStream = new StreamWriter("slovnik_homographs.txt", false, System.Text.Encoding.UTF8)) {
                foreach (var line in File.ReadAllLines(txtSlovnik.Text)) {
                    string l = line.Substring(line.IndexOf(']'));
                    foreach (var word in raw_homographs) {
                        l = line.Replace(',', ' ');
                        if (l.IndexOf(word + " ") != l.LastIndexOf(word + " ")) {
                            oStream.WriteLine(line);
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("ClearSlovnik - Done");
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            LoadSlovnikData();
            FindHomographs();


            //ClearSlovnik();

            /* TODO: 
             * 
             * 1. Load the export file into an object array
             * 2. Get translations from Maciev
             * 3. Export with Maciev
             * 
             */
        }

        public static void HomographsImport()
        {
            // Clear collections for new data
            WordForm.Homographs = new List<List<WordForm>>();
            WordRoot.Roots = new HashSet<WordRoot>();

            using (StreamReader sr = new StreamReader("export.txt", System.Text.Encoding.UTF8)) {
                string[] lineParts = { };
                int wId, rId;
                string wTitle, wDef, rTitle, rDef;
                List<WordForm> homos = new List<WordForm>();

                while (!sr.EndOfStream) {
                    lineParts = sr.ReadLine().Split('║');

                    wId = Convert.ToInt32(lineParts[3].Split(':')[1].Trim());
                    wTitle = lineParts[4].Split(':')[1].Trim();
                    wDef = lineParts[5].Split(':')[1].Trim();

                    rId = Convert.ToInt32(lineParts[0].Split(':')[1].Trim());
                    rTitle = lineParts[1].Split(':')[1].Trim();
                    rDef = lineParts[2].Split(':')[1].Trim();

                    WordForm wf = new WordForm(wId, rId, wTitle, wDef);
                    WordRoot wr = new WordRoot(rId, rTitle, rDef);

                    // Prevent duplicates
                    if (!WordRoot.Roots.Any(item => item.Id == rId)) WordRoot.Roots.Add(wr);

                    if (homos.LastOrDefault() != null && wf.Title.Equals(homos.LastOrDefault().Title)) {
                        homos.Add(wf);
                    } else if (homos.LastOrDefault() != null) {
                        WordForm.Homographs.Add(homos);
                        homos = new List<WordForm>();
                        homos.Add(wf);
                    } else {
                        homos.Add(wf);
                    }
                }

                // Add the last homographs collection because the check happens only after the each iteration
                WordForm.Homographs.Add(homos);
                Console.WriteLine("HomographsImport - Done");
            }
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            HomographsImport();
            var frmHomographs = new FrmHomographs();
            frmHomographs.Show();
        }
    }
}