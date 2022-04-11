using olo.Models;

namespace olo.Services
{
    public static class TextService
    {
        public static WordWrapModel WordWrap(string text, int length)
        {
            try
            {
                //Exception handling
                if (length == 0)
                    throw new ArgumentException("Length cannot be 0");
                if (string.IsNullOrEmpty(text))
                    throw new ArgumentException($"{nameof(text)} - cannot be null");

                var wordWrapModel = new WordWrapModel()
                {
                    OriginalText = text,
                    LengthPerLine = length
                };

                if (text.Length <= length)
                {
                    wordWrapModel.ConvertedText = new List<string>() {text};
                    return wordWrapModel;
                }


                wordWrapModel.ConvertedText = new List<string>();
                var stringSplit = text.Split(" ");
                var runningString = "";

                foreach (var currentWord in stringSplit)
                {
                    if(!string.IsNullOrEmpty(runningString))
                        runningString += " ";

                    var currentWordLength = currentWord.Length;
                    int runningLength;

                    if (currentWordLength > length)
                    {
                        if (currentWordLength + runningString.Length > length && !string.IsNullOrEmpty(runningString))
                        {
                            wordWrapModel.ConvertedText.Add(runningString);
                            runningString = "";
                        }

                        foreach (var cw in currentWord)
                        {
                            runningLength = runningString.Length + cw.ToString().Length;
                            if (runningLength <= length)
                                runningString += cw;
                            else
                            {
                                if (!string.IsNullOrEmpty(runningString))
                                    wordWrapModel.ConvertedText.Add(runningString);

                                runningString = cw.ToString();
                            }
                        }
                        continue;
                    }

                    //1 is accounting for whitespace split
                    runningLength = runningString.Length + currentWord.Length + 1;
                    if (runningLength < length)
                    {
                        runningString += $"{currentWord}";
                        if (!string.IsNullOrEmpty(runningString))
                            wordWrapModel.ConvertedText.Add(runningString);
                        runningString = "";
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(runningString))
                            wordWrapModel.ConvertedText.Add(runningString);

                        runningString = currentWord;
                    }
                }

                if(!string.IsNullOrEmpty(runningString))
                    wordWrapModel.ConvertedText.Add(runningString);

                return wordWrapModel;
            }
            catch (Exception ex)
            {
                return new WordWrapModel() { IsError = true, Msg = ex.Message };
            }
        }
    }
}
