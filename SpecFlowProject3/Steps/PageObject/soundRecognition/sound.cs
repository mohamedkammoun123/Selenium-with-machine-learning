﻿using System;
using System.IO;
using System.Speech.Recognition;
using System.Speech.AudioFormat;
namespace SpecFlowProject2.Steps.PageObject.soundRecognition
{
    class recognition
    {
        static bool completed;
        public static String text;
        public static String getText()
        {
            return text;
        }
        public static void soundToText(String path)

        // Initialize an in-process speech recognition engine.  
        {
            using (SpeechRecognitionEngine recognizer =
               new SpeechRecognitionEngine())
            {

                // Create and load a grammar.  
                Grammar dictation = new DictationGrammar();
                dictation.Name = "Dictation Grammar";

                recognizer.LoadGrammar(dictation);

                // Configure the input to the recognizer.  
                recognizer.SetInputToWaveFile(path);

                // Attach event handlers for the results of recognition.  
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(recognizer_SpeechRecognized);
                recognizer.RecognizeCompleted +=
                  new EventHandler<RecognizeCompletedEventArgs>(recognizer_RecognizeCompleted);

                // Perform recognition on the entire file.  
                Console.WriteLine("Starting asynchronous recognition...");
                completed = false;
                recognizer.RecognizeAsync();

                // Keep the console window open.  
                while (!completed)
                {
                    Console.ReadLine();
                }
                Console.WriteLine("Done.");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Handle the SpeechRecognized event.  
        static void recognizer_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            if (e.Result != null && e.Result.Text != null)
            {
                Console.WriteLine("  Recognized text =  {0}", e.Result.Text);
                text = e.Result.Text;
            }
            else
            {
                Console.WriteLine("  Recognized text not available.");
            }
        }

        // Handle the RecognizeCompleted event.  
        static void recognizer_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine("  Error encountered, {0}: {1}",
                e.Error.GetType().Name, e.Error.Message);
            }
            if (e.Cancelled)
            {
                Console.WriteLine("  Operation cancelled.");
            }
            if (e.InputStreamEnded)
            {
                Console.WriteLine("  End of stream encountered.");
            }
            completed = true;
        }
    }
}