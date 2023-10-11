using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT2_Wiki_Task
{
    public class Information : IComparable
    {
        private String name;
        private String category;
        private String structure;
        private String definition;

        #region setters & getters
        public String getName => name;
        public String getCategory => category;
        public String getStructure => structure;
        public String getDefinition => definition;

        public String Name
        {
            get => name;
            set => name = value;
        }

        public String Category
        {
            get => category;
            set => category = value;
        }

        public String Structure
        {
            get => structure;
            set => structure = value;
        }

        public String Definiton
        {
            get => definition;
            set => definition = value;
        }

        #endregion

        public int CompareTo(object obj) 
        {
            Information CompareClass = obj as Information;
            return this.name.CompareTo(CompareClass.Name);
        }
        public Information(String _name, String _category, String _structure, String _definition) 
        {
            name = _name;
            category = _category;
            structure = _structure;
            definition = _definition;
        }
    }
}
