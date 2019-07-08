using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Homographs
{
    class SlovnikEntry
    {
        public static List<SlovnikEntry> Entries;

        public int RootId { get; set; } = -1;
        public string RootTitle { get; set; }
        public string RootDescription { get; set; }
        public List<WordForm> Forms { get; set; }

        public SlovnikEntry(int id, string inputLine)
        {
            RootId = id;
            RootTitle = inputLine.Substring(0, inputLine.IndexOf(']')).Split(' ')[0];
            RootDescription = inputLine.Substring(inputLine.IndexOf('['), inputLine.IndexOf(']') - RootTitle.Length);
            WordRoot.Roots.Add(new WordRoot(RootId, RootTitle, RootDescription));
            string[] parts = inputLine.Substring(inputLine.IndexOf(']') + 1).Split(',');

            Forms = new List<WordForm>();
            for (int i = 0; i < parts.Length; i++) {
                Forms.Add(new WordForm(i, id, parts[i]));
            }
        }
    }
}
