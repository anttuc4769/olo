namespace olo.Services
{
    public static class TextService
    {
        public static List<string> WordWrap(string text, int length)
        {
            try
            {
                if (length == 0)
                    throw new ArgumentException("Length cannot be 0");
                if (string.IsNullOrEmpty(text))
                    throw new ArgumentException($"{nameof(text)} - cannot be null");
                if (text.Length <= length)
                    return new List<string>() { text };


                var listToReturn = new List<string>();
                var stringSplit = text.Split(" ");
                var runningString = "";
                var runningLength = 0;
                foreach (var currentWord in stringSplit)
                {

                    runningString += " ";

                    var currentWordLenth = currentWord.Length;
                    if (currentWordLenth > length)
                    {
                        if (currentWordLenth + runningString.Length > length)
                        {
                            listToReturn.Add(runningString);
                            runningString = "";
                        }

                        var c = 0;
                        foreach (var cw in currentWord)
                        {
                            runningLength = runningString.Length + cw.ToString().Length;
                            if (runningLength <= length)
                                runningString += $"{cw}";
                            else
                            {
                                listToReturn.Add($"{runningString}");
                                runningString = cw.ToString();
                                c = 0;
                            }

                            c++;
                        }
                        continue;
                    }

                    //1 is accounting for whitespace split
                    runningLength = runningString.Length + currentWord.Length + 1;
                    if (runningLength < length)
                    {
                        runningString += $"{currentWord}";
                        listToReturn.Add(runningString);
                        runningString = "";
                    }
                    else
                    {
                        listToReturn.Add($"{runningString}");
                        runningString = currentWord;
                    }
                }

                return listToReturn;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
