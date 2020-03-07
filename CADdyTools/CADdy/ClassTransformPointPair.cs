using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.CADdy
{
    /// <summary>Klasse um zwei Punkte zu vergleichen</summary>
    public class ClassTransformPointPair
    {
        private ClassCADdyPunkt srcPoint;
        private ClassCADdyPunkt destPoint;
        private String punktnummer;
        private Double deltaRW;
        private Double deltaHW;
        private Double deltaZ;
        private Boolean bUsePoint;
        private Boolean bUseZ;

        public String PointName
        {
            get { return punktnummer; }
        }


        public bool BUsePoint
        {
            get { return bUsePoint; }
            set { bUsePoint = value; }
        }

        public bool BUseZ
        {
            get { return bUseZ; }
            set { bUseZ = value; }
        }

        public double DeltaRW
        {
            get { return deltaRW; }
            set { deltaRW = value; }
        }

        public double DeltaHW
        {
            get { return deltaHW; }
            set { deltaHW = value; }
        }

        public double DeltaZ
        {
            get { return deltaZ; }
            set { deltaZ = value; }
        }

        public ClassCADdyPunkt SrcPoint
        {
            get { return srcPoint; }
        }
        public ClassCADdyPunkt DestPoint
        {
            get { return destPoint; }
        }


        /// <summary>Vergleicht a mit b delta = b-a</summary>
        /// <param name="srcPoint"></param>
        /// <param name="desPoint"></param>
        /// <param name="decimalesCoord"></param>
        /// <param name="decimalesRiwi"></param>
        public ClassTransformPointPair(ClassCADdyPunkt srcPoint, ClassCADdyPunkt desPoint)
        {
            if (srcPoint.Punktnummer.Equals(desPoint.Punktnummer))
            {
                this.srcPoint = srcPoint;
                this.destPoint = desPoint;
                punktnummer = srcPoint.Punktnummer;
                bUsePoint = true;
                bUseZ = true;
            }
            else
                throw new Exception("Punkt a ist nicht Punkt b (Punktnummer nicht identisch!)");
        }

    }
}
