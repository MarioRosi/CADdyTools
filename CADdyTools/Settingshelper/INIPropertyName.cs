using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.Settingshelper
{
    /// <summary>Name der INI-Property</summary>
    public class INIPropertyName : Attribute
    {
        /// <summary>Constructor</summary>
        /// <param name="name">Name der Property</param>
        public INIPropertyName(String name)
        {
            this.name = name;
        }
        /// <summary>Speichervariable: Wie heißt die Property</summary>
        private String name;
        /// <summary>Speichervariable: Wie heißt die Property</summary>
        public String Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}
