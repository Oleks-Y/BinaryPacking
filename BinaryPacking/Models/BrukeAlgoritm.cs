using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace BinaryPacking.Models
{
    public static class BrukeAlgoritm
    {
        

        public static List<Detail> Bruke(Sheet sheet)
        {
            sheet.DetailsUnpacked = sheet.DetailsUnpacked.OrderByDescending(x => x.Width).ThenByDescending(x => x.Height).ToList();
            List<int> Gap= new List<int>();
            for(int i =0; i<sheet.Width; i++)
            {
                Gap.Add(0);
            }
            while(sheet.DetailsUnpacked.Count != 0)
            {
                int min = Gap[0];
                int coorX = 0;
                for (int j =1; j < Gap.Count; j++)
                {
                    if(Gap[j] < min)
                    {
                        min = Gap[j];
                        coorX = j;
                    }
                }
                
                int i = coorX + 1;
                int gapWidth = 1;
                while( i < Gap.Count && Gap[i] == Gap[i - 1])
                {
                    gapWidth++;
                    i++;
                }
                int start = coorX;
                int end = coorX + gapWidth ;

                var detail = sheet.DetailsUnpacked.Where(x => x.Width <= gapWidth).FirstOrDefault();
                
                if (detail != null)
                {
                    if (detail.Height > sheet.Height - min) { return null; }
                    detail.View.Margin = new Thickness(start, sheet.Height-( min + detail.Height), sheet.Width-(start+detail.Width), min);
                    sheet.DetailsPacked.Add(detail);
                    sheet.DetailsUnpacked.Remove(detail);

                    for (int j = coorX; j < coorX + detail.Width; j++)
                    {
                        Gap[j] += (int)detail.Height;
                    }
                }
                else
                {
                    int lowest=0;
                    if (coorX == 0)
                    {
                        lowest = Gap[gapWidth];

                    }else if(coorX + gapWidth == Gap.Count)
                    {
                        lowest = Gap[Gap.Count - gapWidth - 1];
                    }else if(Gap[coorX - 1] < Gap[coorX + gapWidth])
                    {
                        lowest = Gap[coorX - 1];
                    }
                    else
                    {
                        lowest = Gap[coorX + gapWidth];
                    }
                    for(int j = coorX; j< coorX + gapWidth; j++)
                    {
                        Gap[j] = lowest;
                    }
                }
            }
            return sheet.DetailsPacked;
        }
    }
}
