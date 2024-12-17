
namespace Application {
    /// <summary>
    /// The Pad class simulates the behavior of an old phone keypad.
    /// It converts a sequence of key presses into a text string based on a defined key-to-letter mapping.
    /// </summary>
    public class Pad
    {

        /// <summary>
        /// A dictionary that maps each phone key (1-9) to its corresponding characters.
        /// </summary>
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
        };

        /// <summary>
        /// Simulates the old phone keypad behavior and converts a sequence of key presses into text.
        /// </summary>
        /// <param name="input">A string containing the key press sequence.</param>
        /// <returns>A string representing the output text after processing the key presses.</returns>
        public static string OldPhonePad(string input)
        {
            string output = ""; 
            int sameCharCount = 0; 

            // Initialize the count for the first character unless it is '*'
            if (input[0] != '*') 
                sameCharCount = 1;

            for (int i = 1; i < input.Length; i++)
            {

                // Handle backspace character '*'
                if (input[i] == '*')
                {
                    if (input[i - 1] == ' ' && output.Length > 0)
                    {
                        output = output.Remove(output.Length - 1);
                    }
                    sameCharCount = 0; 
                }
                // Handle 'space' or 'send' key ('#')
                else if (input[i] == '#' || input[i] == ' ')
                {
                    // Skip processing if the previous character was '*' or space
                    if (input[i - 1] == '*' || input[i - 1] == ' ') continue;

                    // Determine which character to append to the output
                    int blockSize = dialMap[input[i - 1]].Length;
                    int blockIdx = (sameCharCount - 1) % blockSize;
                    char tempOutput = dialMap[input[i - 1]][blockIdx];

                    output += tempOutput;
                    sameCharCount = 0; 

              
                }
                else
                {
                    // If the previous character was '*' or space, reset the count
                    if (input[i - 1] == '*' || input[i - 1] == ' ')
                    {
                        sameCharCount = 1;
                    }
                    // If the same key is pressed again, increment the count
                    else if (input[i] == input[i - 1])
                    {
                        sameCharCount++;
                    }
                    else
                    {
                        // Append the last character of the previous key to the output
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

        /// <summary>
        /// The Main method serves as the entry point for the program.
        /// </summary>
        /// <param name="args">Command-line arguments (unused).</param>
        public static void Main(string[] args)
        {
            string ans = Pad.OldPhonePad("8 88777444666*664#”");
            Console.WriteLine(ans);
        }
    }
}


