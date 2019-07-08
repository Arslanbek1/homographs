using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace Homographs
{
    class WordForm
    {
        public static List<List<WordForm>> Homographs;

        public int Id { get; set; } = -1;
        public int RootId { get; set; } = -1;
        public bool isProcessed { get; set; } = false;
        public string Title { get; set; }
        public string Description { get; set; }



        public string GetTranslation()
        {
            string noSignsFilePath = "maciev-dictionary-no-signs.txt";
            string translation = "";
            if (Id == 0) {

                Regex re = new Regex("^" + Title + "\\s");
                foreach (var line in File.ReadLines(noSignsFilePath)) {
                    var matches = re.Matches(line);
                    foreach (var m in matches) {
                        return line;
                    }
                }

            } else {
                translation = "см. " + WordRoot.GetWordRoot(RootId).Title;
            }
            return translation;
        }


        public string GetType()
        {
            string notes = "Главная";
            if (Id != 0) {
                notes = "Производная";
            }
            return notes;
        }

        public string GetNotes()
        {
            string notes = Description;
            return notes;
        }

        public WordForm() { }

        public WordForm(int formId, int rootId, string inputLine)
        {
            Id = formId;
            RootId = rootId;
            Description = inputLine.Substring(0, inputLine.IndexOf('/'));
            Title = inputLine.Substring(inputLine.LastIndexOf('/') + 1);
        }

        public WordForm(int formId, int wordId, string title, string description)
        {
            Id = formId;
            RootId = wordId;
            Title = title;
            Description = description;
        }

        public static List<WordForm> GetHomographsList()
        {
            List<WordForm> wfs = new List<WordForm>();
            foreach (var wf in Homographs) {
                wfs.AddRange(wf);
            }
            return wfs;
        }
    }
}