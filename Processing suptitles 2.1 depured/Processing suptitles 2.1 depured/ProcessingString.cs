using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Processing_suptitles_2._1_depured
{
    public class ProcessingString
    {
        public void ChangeFormar(List<string> text)
        {
            text.Insert(0, "");
            text.Insert(0, "WEBVTT");
            for (var i = 0; i < text.Count; i++)
            {
                if (text[i].All(char.IsDigit) && !text[i].All(char.IsWhiteSpace))
                    text.RemoveAt(i);
            }
            var count3 = text.Count;
            for (var i = 0; i < count3; i++)
            {
                if (text[i].Contains("-->"))
                {
                    text[i] = text[i].Replace(",", ".");
                }
            } 
        }

        public void TimeAlter(List<string> text)
        {
            var count = text.Count;
            for (var i = 0; i < count; i++)
            {
                if (text[i].Contains("-->"))
                {
                    if (i + 2 >= count) break;
                    if (!text[i + 2].All(char.IsWhiteSpace))
                    {
                        var Timer1 = float.Parse(text[i].Substring(0, 12).Replace(":", "").Replace(".", ""));
                        var Timer2 = float.Parse(text[i].Substring(17, 12).Replace(":", "").Replace(".", ""));
                        var timer1 = text[i].Substring(0, 12);
                        var timer2 = text[i].Substring(17, 12);

                        var TimerMedium = "" + ((int)((Timer2 - Timer1) / 2) + Timer1);
                        
                        

                        var TimerWhite = "00:00:00.000";

                        var ITimerMedium = TimerMedium.Length - 1;
                        for (var j = 11; j >= 0; j--)
                        {
                            if (TimerWhite[j] != '.' && TimerWhite[j] != ':')
                            {
                                TimerWhite = TimerWhite.Insert(j, "" + TimerMedium[ITimerMedium]).Remove(j + 1, 1);
                                ITimerMedium--;
                                if (ITimerMedium == -1)
                                     break;
                            }
                        }


                        if (int.Parse(TimerWhite.Substring(6,2)) >= 60)
                        {
                            TimerWhite = TimerWhite.Substring(0, 6) + "59" + TimerWhite.Substring(8, 4);
                        }

                        var TextToInser = text[i + 1];
                        var TextToInser2 = text[i + 2];

                        text.RemoveAt(i);
                        text.RemoveAt(i);
                        text.RemoveAt(i);

                        var TimeModifier2 = TimerWhite + " --> " + timer2;
                        text.Insert(i, TextToInser2);
                        text.Insert(i, TimeModifier2);

                        text.Insert(i, "");

                        var TimeModifier1 = timer1 + " --> " + TimerWhite;
                        text.Insert(i, TextToInser);
                        text.Insert(i, TimeModifier1);
                    }
                }
            } 
        }
     
        public List<string> RemoveToTranslate(List<string> text)
        {
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
                        itemResurt += " ";
                    else
                        itemResurt += textLine[i];
                }
                translateText.Add(itemResurt);
            }

            return translateText;
        }

        public void StringUnion(List<string> textEs, List<string> textOriginal)
        {
            var count = textOriginal.Count - 1;
            var j = textEs.Count - 1;
            for (var i = count; i > 0; i--)
            {
                if(!textOriginal[i].Contains("-->") && textOriginal[i] != "")
                {
                    textOriginal.Insert(i + 1, textEs[j]);
                    j--;
                }
            }
        }
    }
}
