using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.CADdy
{
    public class ClassTransformdisplayPoint
    {
        private Int32 decimalesCoord;
        private Int32 decimalesRiwi;
        private ClassTransformPointPair pointpair;

        public ClassTransformdisplayPoint(ClassTransformPointPair withMe, Int32 decimalesCoord, Int32 decimalesRiwi)
        {
            if (withMe == null) throw new ArgumentNullException("withme must not null!");
            pointpair = withMe;
            this.decimalesCoord = decimalesCoord;
            this.decimalesRiwi = decimalesRiwi;
        }


        public String PointName
        {
            get { return pointpair.PointName; }
        }


        public bool BUsePoint
        {
            get { return pointpair.BUsePoint; }
            set { pointpair.BUsePoint = value; }
        }

        public bool BUseZ
        {
            get { return pointpair.BUseZ; }
            set { pointpair.BUseZ = value; }
        }

        public String SSrcRW
        {
            get { return ClassConverters.ToString(pointpair.SrcPoint.Rechtswert, ",", "", decimalesCoord); }
        }
        public String SSrcHW
        {
            get { return ClassConverters.ToString(pointpair.SrcPoint.Hochwert, ",", "", decimalesCoord); }
        }
        public String SSrcZ
        {
            get { return ClassConverters.ToString(pointpair.SrcPoint.Hoehe, ",", "", decimalesCoord); }
        }
        public String SDesRW
        {
            get { return ClassConverters.ToString(pointpair.DestPoint.Rechtswert, ",", "", decimalesCoord); }
        }
        public String SDesHW
        {
            get { return ClassConverters.ToString(pointpair.DestPoint.Hochwert, ",", "", decimalesCoord); }
        }
        public String SDesZ
        {
            get { return ClassConverters.ToString(pointpair.DestPoint.Hoehe, ",", "", decimalesCoord); }
        }

        public String SDeltaRW
        {
            get { return ClassConverters.ToString(pointpair.DeltaRW, ",", "", decimalesCoord, true); }
        }
        public String SDeltaHW
        {
            get { return ClassConverters.ToString(pointpair.DeltaHW, ",", "", decimalesCoord, true); }
        }
        public String SDeltaZ
        {
            get { return ClassConverters.ToString(pointpair.DeltaZ, ",", "", decimalesCoord, true); }
        }

    }
}
