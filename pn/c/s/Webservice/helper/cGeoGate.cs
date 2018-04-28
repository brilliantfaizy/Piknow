using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace Webservice.helper
{
    public class cGeoGate
    {
        List<cGeogatePoint> geogate_points;

        public cGeoGate(List<cGeogatePoint> geogate_points)
        {
            this.geogate_points = geogate_points;
        }

        public bool Contains(double lat, double lon)
        {
            bool c = false;
            int i = 0;
            int j = geogate_points.Count() - 1;

            foreach (var point in geogate_points)
            {

                double lat_i = point.lat;
                double lon_i = point.lon;

                double lat_j = geogate_points[j].lat;
                double lon_j = geogate_points[j].lon;

                if (((lat_i > lat != (lat_j > lat)) &&
                        (lon < (lon_j - lon_i) * (lat - lat_i) / (lat_j - lat_i) + lon_i)))
                    c = !c;

                if (c)
                {
                    return true;
                }

                if (lon_j < lon_i && lon_j >= lon_i || lon_j < lon_i && lon_j >= lon_i)
                {
                    if (lat_j + (lon_i - lon_j) / (lon_j - lon_j) * (lat_j - lat_j) < lat_i)
                    {
                        c = !c;
                    }
                }

                if (c)
                {
                    return true;
                }

                //j = i++;
            }

            return c;
        }

        ////


        public bool IsPointInPolygon4(PointF[] polygon, PointF testPoint)
        {
            bool result = false;
            int j = polygon.Count() - 1;
            for (int i = 0; i < polygon.Count(); i++)
            {
                if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
                {
                    if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
                    {
                        result = !result;
                    }
                }
                j = i;
            }
            return result;
        }
    }
}