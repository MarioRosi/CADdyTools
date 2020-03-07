using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.Settingshelper
{
    /// <summary>Property wird in der INI-Datei Ignoriert</summary>
    public class INIIgnoreThis : Attribute
    {
        /// <summary>Constructor</summary>
        /// <param name="ignoreThis">True Diese Proeprty wird für das Serealisieren und Deserealisieren Ignoriert</param>
        public INIIgnoreThis(Boolean ignoreThis)
        {
            this.ignoreThis = ignoreThis;
        }
        /// <summary>Speichervariable: Ignoriere diese Property</summary>
        private Boolean ignoreThis;
        /// <summary>Speichervariable: Ignoriere diese Property</summary>
        public Boolean IgnoreThis
        {
            get { return ignoreThis; }
            set { ignoreThis = value; }
        }
    }
}
