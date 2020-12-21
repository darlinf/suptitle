using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suptitles_ass_format
{
    public static class ProcessingString
    {
        private static readonly List<string> translateTextTime = new List<string>();

        public static List<string> RemoveToTranslate(List<string> text)
       {
            var translateText = new List<string>();
            
            for (var i = 0; i < text.Count; i++)
            {
                if (text[i].Contains(",,0000,0000,0000,,")|| text[i].Contains(",0000,0000,0000,,") || text[i].Contains(",,0,0,0,,") || text[i].Contains(",0,0,0,,"))
                {
                    int iComa = 0;
                    for (var j = text[i].Length-1; j > 0; j--)
                    {
                        if (text[i][j] == ',')
                        {
                            iComa++;
                            if (iComa == 2)
                            {
                                var oo = text[i].Substring(j + 2);
                                translateText.Add(oo);
                                translateTextTime.Add(text[i].Substring(0, Math.Abs(text[i].Length - oo.Length)));
                                break;
                            }
                        }
                        else
                            iComa = 0;
                    }
                }
            }
            return translateText;
        }

        public static void StringUnion(List<string> textEs, List<string> textOriginal)
        {
            // 
            var  unionTextEs = new List<string>(); 

            for (var i = 0; i < translateTextTime.Count - 2; i++)
            {
                unionTextEs.Add(translateTextTime[i] + textEs[i]);
            }
            
             var count = textOriginal.Count - 1;
             var j = unionTextEs.Count - 1;
             for (var i = count; i > 0; i--)
             {
                if (j != -1 /*textOriginal[i].Contains(",,0000,0000,0000,,")*/)
                {
                    textOriginal.Insert(i - 2, unionTextEs[j]);
                    j--;
                }
                else break;
             }
        }
    }
}
