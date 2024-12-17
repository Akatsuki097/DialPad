
namespace Application {
    public class Pad
    {

        private static Dictionary<char, string> dialMap = new Dictionary<char, string>
        {
            { '1', "&'(" },
            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" },
            { '*', "" },
        };

        public static string OldPhonePad(string input)
        {
            string output = "";
            int sameCharCount = 0;

            if (input[0] != '*') 
                sameCharCount = 1;

            for (int i = 1; i < input.Length; i++)
            {

                if (input[i] == '*')
                {
                    sameCharCount = 0;
                }
                else if (input[i] == '#' || input[i] == ' ')
                {
                    if (input[i - 1] == '*' || input[i - 1] == ' ') continue;

                    int blockSize = dialMap[input[i - 1]].Length;
                    int blockIdx = (sameCharCount - 1) % blockSize;
                    char tempOutput = dialMap[input[i - 1]][blockIdx];

                    output += tempOutput;
                    sameCharCount = 1;

                    if (input[i] == '#')
                    {
                        break;
                    }
                    i++;
                }
                else
                {
                    if (input[i - 1] == '*')
                    {
                        sameCharCount = 1;
                    }
                    else if (input[i] == input[i - 1])
                    {
                        sameCharCount++;
                    }
                    else
                    {
                        int blockSize = dialMap[input[i - 1]].Length;
                        int blockIdx = (sameCharCount - 1) % blockSize;
                        char tempOutput = dialMap[input[i - 1]][blockIdx];

                        output += tempOutput;
                        sameCharCount = 1;
                           
                    }

                }
            }
            return output;
        }
    }

}


