using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerWindowService
{
    public class WriteToFile
    {
        public void Write(string contents)
        {

            //set up a filestream
            FileStream fs = new
       FileStream(@"C:\temp\log.txt", FileMode.OpenOrCreate, FileAccess.Write);

            //set up a streamwriter for adding text

            StreamWriter sw = new StreamWriter(fs);

            //find the end of the underlying filestream

            sw.BaseStream.Seek(0, SeekOrigin.End);

            //add the text 
            sw.WriteLine(contents);
            //add the text to the underlying filestream

            sw.Flush();
            //close the writer
            sw.Close();
        }
    }
}
