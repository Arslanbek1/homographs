using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homographs
{
    class WordRoot
    {
        public int Id { get; set; } = -1;
        public bool isProcessed { get; set; } = false;
        public string Title { get; set; }
        public string Description { get; set; }

        public static HashSet<WordRoot> Roots = new HashSet<WordRoot>();

        public static WordRoot GetWordRoot(int id) {
            return Roots.Single(x => x.Id == id);
        }

        public WordRoot(int id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
