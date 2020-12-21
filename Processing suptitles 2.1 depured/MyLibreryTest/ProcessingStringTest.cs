using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Processing_suptitles_2._1_depured;

namespace MyLibreryTest
{
    [TestClass]
    public class ProcessingStringTest
    {
        [TestMethod]
        public void ChangeFormar_()
        {
            // Arrangue
            var actual = new List<string>(File.ReadAllLines(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurtTest\ChangeFormar_( )\Gotham.S03E01 Actual.txt"));
            var textToProcessing = new List<string>(File.ReadAllLines(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurtTest\ChangeFormar_( )\Gotham.S03E01 Expect.txt"));


            var changeString = new ProcessingString();

            // Act
            changeString.ChangeFormar(textToProcessing);
            var expected = textToProcessing;

            // Assert
            Assert.AreEqual(expected.Count, actual.Count);
            for(var i = 0; i < actual.Count; i++)
                Assert.AreEqual(expected[i], actual[i]);

        }
        
        [TestMethod]
        public void StringUnion_()
        {
            // Arrangue
            var actual = new List<string>(File.ReadAllLines(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurtTest\StringUnion_( )\Actual.txt"));
            var textToProcessing = new List<string>(File.ReadAllLines(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurtTest\StringUnion_( )\Expect 1.txt"));
            var textToProcessing2 = new List<string>(File.ReadAllLines(@"C:\Users\JODETE\source\repos\Processing suptitles 2.1 depured\Processing suptitles 2.1 depured\FileResurtTest\StringUnion_( )\Expect 2.txt"));
           

            var changeString = new ProcessingString();

            // Act
            changeString.StringUnion(textToProcessing, textToProcessing2);

            // Assert
        }
    }
}



/*
  resurtadoEsperado.Add("WEBVTT");
            resurtadoEsperado.Add("");
            resurtadoEsperado.Add("00:00:00.380 --> 00:00:02.979");
            resurtadoEsperado.Add("I understand, but look, forget the trial.");
            resurtadoEsperado.Add("");
            resurtadoEsperado.Add("00:00:03.003 --> 00:00:05.181");
            resurtadoEsperado.Add("It's too risky.");
            resurtadoEsperado.Add("They have video of the robbery.");
            resurtadoEsperado.Add("");
            resurtadoEsperado.Add("00:00:05.205 --> 00:00:07.183");
            resurtadoEsperado.Add("So what do you recommend?");
     */


/* textToProcessing.Add("1");
        textToProcessing.Add("00:00:00,380 --> 00:00:02,979");
        textToProcessing.Add("I understand, but look, forget the trial.");
        textToProcessing.Add("");
        textToProcessing.Add("2");
        textToProcessing.Add("00:00:03,003 --> 00:00:05,181");
        textToProcessing.Add("It's too risky.");
        textToProcessing.Add("They have video of the robbery.");
        textToProcessing.Add("");
        textToProcessing.Add("3");
        textToProcessing.Add("00:00:05,205 --> 00:00:07,183");
        textToProcessing.Add("So what do you recommend?");*/
