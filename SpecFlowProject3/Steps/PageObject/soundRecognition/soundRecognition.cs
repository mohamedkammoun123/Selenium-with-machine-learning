using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Speech.AudioFormat;
using System.Speech.Recognition;
using System;
using System.Globalization;

namespace SpecFlowProject2.Steps.PageObject.soundRecognition
{
    public class SoundRecognition
    {
        public String fromSoundToText(string path_sound)
        {
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();
            recognizer.SetInputToWaveFile(path_sound);
            Grammar grammar = new DictationGrammar();
            grammar.Name = "Dictation Grammar";
            recognizer.LoadGrammar(grammar);
            //recognizer.RecognizeAsync(RecognizeMode.Multiple);
            
            RecognitionResult result = recognizer.Recognize();
            return result.Text;





        }
        
    }
}
