using org.rosenbohm.csharp.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace org.rosenbohm.csharp.CADdy
{
    public class ClassTransformation
    {
        private List<ClassTransformPointPair> matchPoints;
        private ClassCADdyPunkte srcPoints;
        private ClassCADdyPunkte dstPoints;
        private ClassCADdyPunkte transfPoints;
        private ClassLanguage language;
        private Int32 decimalsCoord;
        private Int32 decimalsRiwi;
        private Double a;
        private Double o;
        private Double X0;
        private Double Y0;
        private Double m;
        private Double translZ;
        private Double sigmaXY;
        private Double sigmaZ;
        private List<String> usedMatchPoints;

        public double M
        {
            get { return m; }
        }

        public double SigmaXY
        {
            get { return sigmaXY; }
        }

        public double SigmaZ
        {
            get { return sigmaZ; }
        }

        public List<ClassTransformPointPair> MatchPoints
        {
            get { return matchPoints; }
        }

        public List<ClassCADdyPunkt> newPoints
        {
            get { return transfPoints.Punkte; }

        }

        public ClassTransformation(ClassCADdyPunkte srcPoints, ClassCADdyPunkte dstPoints, ref ClassLanguage language, Int32 decimalsCoord, Int32 decimalsRiwi)
        {
            matchPoints = new List<ClassTransformPointPair>();
            transfPoints = new ClassCADdyPunkte(ref language);
            this.decimalsCoord = decimalsCoord;
            this.decimalsRiwi = decimalsRiwi;
            this.language = language;
            this.srcPoints = srcPoints;
            this.dstPoints = dstPoints;
            this.usedMatchPoints = new List<String>();
            prepare();
            calcResiduen();
        }

        public void clearForDestroy()
        {
            if (matchPoints != null) matchPoints.Clear();
            if (newPoints != null) newPoints.Clear();
            if (usedMatchPoints != null) usedMatchPoints.Clear();
            sigmaXY = Double.NaN;
            sigmaZ = Double.NaN;
        }

        public void prepare()
        {
            dstPoints.sortBy(enPointColumn.colPointnumber);
            matchPoints.Clear();
            foreach (ClassCADdyPunkt dstPoint in dstPoints.Punkte)
            {
                ClassCADdyPunkt srcPoint = srcPoints.getPointByName(dstPoint.Punktnummer);
                if (srcPoint != null)
                {
                    ClassTransformPointPair matchPoint = new ClassTransformPointPair(srcPoint, dstPoint);
                    matchPoints.Add(matchPoint);
                }
            }
        }

        public void calcResiduen()
        {
            if (matchPoints.Count >= 2)
            {
                // Schwerpunkt berechnen
                Double Xs = 0.0;
                Double Ys = 0.0;
                Double Zs = 0.0;
                Double xs = 0.0;
                Double ys = 0.0;
                Double zs = 0.0;
                Double nxy = 0.0;
                Double nz = 0.0;
                usedMatchPoints.Clear();
                foreach (ClassTransformPointPair matchPoint in matchPoints)
                {
                    if (matchPoint.BUsePoint)
                    {
                        usedMatchPoints.Add(matchPoint.PointName.ToLower());
                        xs += matchPoint.SrcPoint.Rechtswert;
                        ys += matchPoint.SrcPoint.Hochwert;
                        Xs += matchPoint.DestPoint.Rechtswert;
                        Ys += matchPoint.DestPoint.Hochwert;
                        nxy += 1.0;
                        if (matchPoint.BUseZ)
                        {
                            zs += matchPoint.SrcPoint.Hoehe;
                            Zs += matchPoint.DestPoint.Hoehe;
                            nz += 1.0;
                        }
                    }
                }
                xs /= nxy;
                ys /= nxy;
                zs /= nz;
                Xs /= nxy;
                Ys /= nxy;
                Zs /= nz;
                translZ = Zs - zs;

                Double xr = 0.0;
                Double yr = 0.0;
                Double Xr = 0.0;
                Double Yr = 0.0;

                Double SxYyX = 0.0;
                Double SxXyY = 0.0;
                Double Sxxyy = 0.0;
                Double SWxWx = 0.0;
                Double SWyWy = 0.0;
                Double SWzWz = 0.0;

                // reduzierte Koordinaten  und a / o berechnen
                foreach (ClassTransformPointPair matchPoint in matchPoints)
                {
                    if (matchPoint.BUsePoint)
                    {
                        xr = matchPoint.SrcPoint.Rechtswert - xs;
                        yr = matchPoint.SrcPoint.Hochwert - ys;
                        Xr = matchPoint.DestPoint.Rechtswert - Xs;
                        Yr = matchPoint.DestPoint.Hochwert - Ys;
                        SxYyX += ((xr * Yr) - (yr * Xr));
                        SxXyY += ((xr * Xr) + (yr * Yr));
                        Sxxyy += ((xr * xr) + (yr * yr));
                    }
                }
                a = SxXyY / Sxxyy;
                o = SxYyX / Sxxyy;
                m = Math.Sqrt((a * a) + (o * o));
                // Maßstab 1.0 !!
                a /= m;
                o /= m;
                X0 = Xs + (o * ys) - (a * xs);
                Y0 = Ys - (a * ys) - (o * xs);
                // Widersprüche berechnen
                foreach (ClassTransformPointPair matchPoint in matchPoints)
                {
                    if (matchPoint.BUsePoint)
                    {
                        matchPoint.DeltaRW = -X0 + (o * matchPoint.SrcPoint.Hochwert) - (a * matchPoint.SrcPoint.Rechtswert) + matchPoint.DestPoint.Rechtswert;
                        SWxWx += (matchPoint.DeltaRW * matchPoint.DeltaRW);
                        matchPoint.DeltaHW = -Y0 - (a * matchPoint.SrcPoint.Hochwert) - (o * matchPoint.SrcPoint.Rechtswert) + matchPoint.DestPoint.Hochwert;
                        SWyWy += (matchPoint.DeltaHW * matchPoint.DeltaHW);

                        if (matchPoint.BUseZ)
                        {
                            matchPoint.DeltaZ = -matchPoint.SrcPoint.Hoehe - translZ + matchPoint.DestPoint.Hoehe;
                            SWzWz += (matchPoint.DeltaZ * matchPoint.DeltaZ);
                        }
                        else
                            matchPoint.DeltaZ = Double.NaN;
                    }
                    else
                    {
                        matchPoint.DeltaRW = Double.NaN;
                        matchPoint.DeltaHW = Double.NaN;
                        matchPoint.DeltaZ = Double.NaN;
                    }
                }
                if (nxy > 2.0)
                    sigmaXY = Math.Sqrt((SWxWx + SWyWy) / ((2.0 * nxy) - 4.0));
                else
                    sigmaXY = Double.NaN;
                if (nz > 1.0)
                    sigmaZ = Math.Sqrt((SWzWz) / (2.0 * (nz - 1.0)));
                else
                    sigmaZ = Double.NaN;
                
            }
        }

        public void calcTransformation()
        {
            transfPoints.clear();
            foreach (ClassCADdyPunkt srcPoint in srcPoints.Punkte)
            {
                if (!usedMatchPoints.Contains(srcPoint.Punktnummer.ToLower()))
                {
                    ClassCADdyPunkt transform = srcPoint.getAsCopy();
                    transform.Rechtswert = X0 - (o * srcPoint.Hochwert) + (a * srcPoint.Rechtswert);
                    transform.Hochwert = Y0 + (a * srcPoint.Hochwert) + (o * srcPoint.Rechtswert);
                    transform.Hoehe = srcPoint.Hoehe + translZ;
                    transfPoints.Punkte.Add(transform);
                }
            }
        }

        public void setUsing(ClassTransformPointPair fromMe)
        {
            if (fromMe != null)
            {
                foreach(ClassTransformPointPair matchPoint in matchPoints)
                {
                    if (matchPoint.PointName.ToLower().Equals(fromMe.PointName.ToLower()))
                    {
                        matchPoint.BUsePoint = fromMe.BUsePoint;
                        matchPoint.BUseZ = fromMe.BUseZ;
                        break;
                    }
                }
            }
        }
    }
}
