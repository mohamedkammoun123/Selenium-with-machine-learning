using System;
using TechTalk.SpecFlow;
using SpecFlowProject2.Steps.PageObject.soundRecognition;
using FluentAssertions;

namespace SpecFlowProject2.Steps.Sound_Recognition_Steps
{
    [Binding]
    public class SoundRecognitionSteps
    {
        String text;

        SoundRecognition soundRecognition = new SoundRecognition();
        [Given(@"i give the path of sound (.*)")]
        public void GivenIGiveThePathOfSound(string p0)
        {
            text = soundRecognition.fromSoundToText(p0);
        }
        
        [Then(@"I must have the same text")]
        public void ThenIMustHaveTheSameText()
        {
            text.Should().Be("aaa");
        }
    }
}
