using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.Settingshelper
{
    /// <summary>Der Gruppenname des Attributes in der INI-Datei</summary>
    public class INIGroupName : Attribute
    {
        /// <summary>Constructor</summary>
        /// <param name="name">Gruppenname</param>
        public INIGroupName(String name)
        {
            this.gName = name;
        }
        /// <summary>Speichervariable: Gruppenname</summary>
        private String gName;
        /// <summary>Speichervariable: Gruppenname</summary>
        public String GName
        {
            get { return gName; }
            set { gName = value; }
        }
    }
}
