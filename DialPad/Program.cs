
namespace Application {
    public class Pad
    {

        private static Dictionary<char, string> dialMap = new Dictionary<char, string>
        {
            { '1', "&'(" },
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" },
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
                    var xx = input[i - 1];
                    if (input[i - 1] == ' ' && output.Length > 0)
                    {
                        output = output.Remove(output.Length - 1);
                    }
                    sameCharCount = 0;
                }
                else if (input[i] == '#' || input[i] == ' ')
                {
                    if (input[i - 1] == '*' || input[i - 1] == ' ') continue;

                    int blockSize = dialMap[input[i - 1]].Length;
                    int blockIdx = (sameCharCount - 1) % blockSize;
                    char tempOutput = dialMap[input[i - 1]][blockIdx];

                    output += tempOutput;
                    sameCharCount = 0;

                    if (input[i] == '#')
                    {
                        break;
                    }
                    //i++;
                }
                else
                {
                    if (input[i - 1] == '*' || input[i - 1] == ' ')
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

        public static void Main(string[] args)
        {
            string ans = Pad.OldPhonePad("8 88777444666*664#”");
            Console.WriteLine(ans);
        }
    }
}


