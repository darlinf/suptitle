using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Processing_suptitles
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                step1();
                Console.WriteLine("Saltar al paso 2");
                Console.ReadLine();
                step2();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }
        }

        static void step1()
        {
            string suptitlesFiles = Directory.GetFiles(@"C:\Users\JODETE\Desktop\suptitles union\step 1\1. New file INPUT")[0].Substring(65);

            var text = new List<string>(File.ReadAllLines(@"C:\Users\JODETE\Desktop\suptitles union\step 1\1. New file INPUT\" + suptitlesFiles));

            
            text.Insert(0, "");
            text.Insert(0, "WEBVTT");

            for (var i = 0; i < text.Count; i++)
            {
                if (text[i].All(char.IsDigit) && !text[i].All(char.IsWhiteSpace))
                    text.RemoveAt(i);
                if (text[i].Contains("-->"))
                    text[i] = text[i].Replace(",", ".");
            }
            File.WriteAllLines(@"C:\Users\JODETE\Desktop\suptitles union\step 1\1. New file INPUT\" + suptitlesFiles, text);
            

            text.RemoveAt(0);
            for (var i = 0; i < text.Count; i++)
            {
                if (text[i] == "")
                    text.RemoveAt(i);
            }
            for (var i = 0; i < text.Count; i++)
            {
                if (text[i].Contains("-->"))
                    text.RemoveAt(i);
            }

            var translateText = new List<string>();
            for (var j = 0; j < text.Count; j++)
            {
                string itemResurt = "";
                var textLine = text[j];
                for (var i = 0; i < textLine.Length; i++)
                {
                    if (textLine[i] == ' ')
                        itemResurt += " | ";
                    else
                        itemResurt += textLine[i];
                }
                translateText.Add(itemResurt);
            }

            File.WriteAllLines(@"C:\Users\JODETE\Desktop\suptitles union\step 1\2. File procesado OUTPUT\" + suptitlesFiles, translateText);
            File.Create(@"C:\Users\JODETE\Desktop\suptitles union\step 2\3. Translate INPUT\" + suptitlesFiles).Close();

            var p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Users\JODETE\Desktop\suptitles union\step 2\3. Translate INPUT\" + suptitlesFiles)
            {
                UseShellExecute = true
            };
            p.Start();
        }

        static void step2()
        {

            string suptitlesFiles = Directory.GetFiles(@"C:\Users\JODETE\Desktop\suptitles union\step 1\2. File procesado OUTPUT")[0].Substring(72);

            var text = new List<string>(File.ReadAllLines(@"C:\Users\JODETE\Desktop\suptitles union\step 1\1. New file INPUT\" + suptitlesFiles));
            var uuuu2 = new List<string>(File.ReadAllLines(@"C:\Users\JODETE\Desktop\suptitles union\step 2\3. Translate INPUT\" + suptitlesFiles));

            bool stop = true;
            int counter = 0, j = 2, nuLine = 0;
            for (var i = 0; i < uuuu2.Count; i++)
            {
                

                while (stop)
                {
                    if (text.Count - 1 == j)
                        break;
                    if (text[j] == "")
                    {
                        counter -= 1;
                        nuLine += j;

                        for (var t = 0; t < counter; t++)
                        {
                            if (uuuu2.Count - 1 == i)
                                break;
                            text.Insert(j, uuuu2[i]);
                            nuLine++;
                            i++;

                        }
                        i -= 1;
                        j += counter;
                        stop = false;
                        counter = 0;
                    }
                    else
                        counter++;
                    j++;
                }
                stop = true;
            }
            File.WriteAllLines(@"C:\Users\JODETE\Desktop\proyect\Video translation\Video translation\resources\video\New folder\" + suptitlesFiles, text);


            File.Delete(@"C:\Users\JODETE\Desktop\suptitles union\step 1\1. New file INPUT\" + suptitlesFiles);
            File.Delete(@"C:\Users\JODETE\Desktop\suptitles union\step 1\2. File procesado OUTPUT\" + suptitlesFiles);
            File.Delete(@"C:\Users\JODETE\Desktop\suptitles union\step 2\3. Translate INPUT\" + suptitlesFiles);

        }
    }
    
}
