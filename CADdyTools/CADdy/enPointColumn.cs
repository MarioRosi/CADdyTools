using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.CADdy
{
    /// <summary>Spalte der Punkte</summary>
    public enum enPointColumn
    {
        /// <summary>Punktnummer</summary>
        colPointnumber = 0,
        /// <summary>Rechtswert</summary>
        colEast = 1,
        /// <summary>Hochwert</summary>
        colNorth = 2,
        /// <summary>Höhe</summary>
        colElev = 3,
        /// <summary>Code</summary>
        colCode = 4
    }
}
