using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suptitles_ass_format
{
        class Program
        {
            static void Main(string[] args)
            {

                step1();
                Console.WriteLine("Saltar al paso 2");
                Console.ReadLine();
                step2();


                /* }
                 catch (Exception e)
                 {
                     Console.WriteLine(e);
                     Console.ReadLine();
                 }*/
            }

        static void step1()
            {
                string suptitlesFiles = Directory.GetFiles(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurt")[0].Substring(106);
                var text = new List<string>(File.ReadAllLines(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurt\" + suptitlesFiles));


                File.WriteAllLines(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurt\" + "1-" + suptitlesFiles, text);
            
                var translateText = ProcessingString.RemoveToTranslate(text);

                File.WriteAllLines(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurt\" + "2-" + suptitlesFiles, translateText);
                File.Create(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurt\" + "3-" + suptitlesFiles).Close();

                var p = new Process();
                p.StartInfo = new ProcessStartInfo(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurt\" + "3-" + suptitlesFiles)
                {
                    UseShellExecute = true
                };
                p.Start();
            }

            static void step2()
            {
                string suptitlesFiles = Directory.GetFiles(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurt")[0].Substring(108);

                var text = new List<string>(File.ReadAllLines(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurt\" + "1-" + suptitlesFiles));
                var uuuu2 = new List<string>(File.ReadAllLines(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurt\" + "3-" + suptitlesFiles));



                ProcessingString.StringUnion(uuuu2, text);

                File.WriteAllLines(@"C:\Users\JODETE\Desktop\resurt suptitles\" + "4-" + suptitlesFiles, text);


                File.Delete(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurt\" + "1-" + suptitlesFiles);
                File.Delete(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurt\" + "2-" + suptitlesFiles);
                File.Delete(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurt\" + "3-" + suptitlesFiles);
                File.Delete(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurt\" + suptitlesFiles);

            }

        }
    }
