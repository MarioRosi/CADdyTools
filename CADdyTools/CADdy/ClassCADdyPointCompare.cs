using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.CADdy
{
    /// <summary>Klasse um zwei Punkte zu vergleichen</summary>
    public class ClassCADdyPointCompare
    {
        private Int32 decimalesCoord;
        private Int32 decimalesRiwi;
        private ClassCADdyPunkt point1;
        private ClassCADdyPunkt point2;
        private String punktnummer;
        private Double deltaRW;
        private Double deltaHW;
        private Double deltaZ;
        private Double delta2D;
        private Double delta3D;
        private Double deltaRiwi;

        public String PointName
        {
            get { return punktnummer; }
        }

        public String SEp1RW
        {
            get { return ClassConverters.ToString(point1.Rechtswert, ",", "", decimalesCoord); }
        }
        public String SEp1HW
        {
            get { return ClassConverters.ToString(point1.Hochwert, ",", "", decimalesCoord); }
        }
        public String SEp1Z
        {
            get { return ClassConverters.ToString(point1.Hoehe, ",", "", decimalesCoord); }
        }
        public String SEp2RW
        {
            get { return ClassConverters.ToString(point2.Rechtswert, ",", "", decimalesCoord); }
        }
        public String SEp2HW
        {
            get { return ClassConverters.ToString(point2.Hochwert, ",", "", decimalesCoord); }
        }
        public String SEp2Z
        {
            get { return ClassConverters.ToString(point2.Hoehe, ",", "", decimalesCoord); }
        }

        public String SDeltaRW
        {
            get { return ClassConverters.ToString(deltaRW, ",", "", decimalesCoord); }
        }
        public String SDeltaHW
        {
            get { return ClassConverters.ToString(deltaHW, ",", "", decimalesCoord); }
        }
        public String SDeltaZ
        {
            get { return ClassConverters.ToString(deltaZ, ",", "", decimalesCoord); }
        }
        public String SDelta2D
        {
            get { return ClassConverters.ToString(delta2D, ",", "", decimalesCoord); }
        }
        public String SDelta3D
        {
            get { return ClassConverters.ToString(delta3D, ",", "", decimalesCoord); }
        }
        public String SDeltaRIWI
        {
            get { return ClassConverters.ToString(deltaRiwi, ",", "", decimalesRiwi); }
        }

        /// <summary>Vergleicht a mit b delta = b-a</summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="decimalesCoord"></param>
        /// <param name="decimalesRiwi"></param>
        public ClassCADdyPointCompare(ClassCADdyPunkt a, ClassCADdyPunkt b, Int32 decimalesCoord, Int32 decimalesRiwi)
        {
            if (a.Punktnummer.Equals(b.Punktnummer))
            {
                this.decimalesCoord = decimalesCoord;
                this.decimalesRiwi = decimalesRiwi;
                point1 = a;
                point2 = b;
                punktnummer = a.Punktnummer;
                ClassCADdyPunkt delta = b - a;
                deltaRW = delta.Rechtswert;
                deltaHW = delta.Hochwert;
                deltaZ = delta.Hoehe;
                delta2D = delta.length();
                delta3D = delta.distance();
                deltaRiwi = delta.gonRiwi();
                delta = null;
            }
            else
                throw new Exception("Punkt a ist nicht Punkt b (Punktnummer nicht identisch!)");
        }

    }
}
