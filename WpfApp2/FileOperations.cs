using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class FileOperations
    {
        List<double?> listTosave = new List<double?>();
        public FileOperations(List<double?> listToSV)
        {
            listTosave = listToSV;
        }
        public void saveToFile()
        {
            using (StreamWriter sw = new StreamWriter("E:\\Users\\dromanow\\source\\repos\\TemperatureSimulation(Lab1)\\plikDane.txt"))
            {
                foreach (var item in listTosave)
                {
                    sw.WriteLine(item);
                }
            }
            Console.WriteLine("File save success");
        }
        public IEnumerable<string> readFile(int numberOfLines)
        {
            string fileName = @"E:\Users\dromanow\source\repos\TemperatureSimulation(Lab1)\plikDane.txt";

            IEnumerable<string> lines = File.ReadLines(fileName).Take(numberOfLines);
            //Console.WriteLine("ss");
            Console.WriteLine(String.Join(Environment.NewLine, lines));
            return lines;
        }
        public void serializationSaveToFile()
        {
            Serializator ser = new Serializator();
            string dataTime = DateTime.Now.ToString("yyyyMMdd_hhmmss");
            ser.Serialization("E:\\Users\\dromanow\\source\\repos\\TemperatureSimulation(Lab1)\\"+dataTime+".txt", listTosave);
            Console.WriteLine("File save success");
        }

        public string getNewestFileInDirectory()
        {
            string newestFile="";
            //var file = Directory.GetFiles().Where(x => new FileInfo(x).CreationTime.Date == DateTime.Today.Date);
            var file =new DirectoryInfo("E:\\Users\\dromanow\\source\\repos\\TemperatureSimulation(Lab1)").GetFiles().OrderByDescending(o => o.CreationTime).FirstOrDefault();
            newestFile = file.ToString();
            return newestFile;
        }
        public void serializationRead(bool delateDirectory)
        {
            string path = "";
            Serializator ser = new Serializator();
            try
            {
                 path=getNewestFileInDirectory();
                if (File.Exists(path))
                {
                    ser.Deserialize(getNewestFileInDirectory());
                    if (delateDirectory == true)
                    {
                        File.Delete(path);
                    }
                }
            }
            catch
            {
                Console.WriteLine("No newest file in directory");
            }
             
        }

    }
}
