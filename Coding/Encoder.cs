using System;
using System.Collections.Generic;
using System.Linq;

namespace AK15
{
    internal class Encoder
    {
        public string Encode(string userInput)
        {
            InitialData initialData = new InitialData();
            OutputDecoder output = new OutputDecoder();

            int[] binary = this.ConvertUserInputToBinaryFormat(userInput, true);

            for (int i = 0; i < binary.Length; i++)
            {
                // 1 input bit results in 2 output bits
                output.Insert(binary[i]);

                int sumBitValue = initialData.GetBitValue(binary[i]);
                output.Insert(sumBitValue);

                // add input bit to initial six 0's data first slot
                initialData.Insert(binary[i]);
            }

            List<int> outputList = output.ReturnOutput();
            string result = this.ConvertBinaryFormatToString(outputList);

            outputList.Clear();

            return result;
        }

        public int[] ConvertUserInputToBinaryFormat(string userInput, bool addAdditionalValues = false)
        {
            char[] userInputArray = userInput.ToCharArray();

            int zerosAddition = 0;
            if (addAdditionalValues) zerosAddition = 6;

            int[] userInputBinary = new int[userInputArray.Count() + zerosAddition];

            for (int i = 0; i < userInputArray.Length; i++)
            {
                userInputBinary[i] = userInputArray[i] - '0';
            }
            // add additional six 0's to the user input
            if(addAdditionalValues) this.AppendAdditionalValues(userInputBinary);

            return userInputBinary;
        }

        public string ConvertBinaryFormatToString(List<int> binary, string joinValue = "")
        {
            return string.Join(joinValue, binary.Select(intValue => intValue.ToString()).ToArray());
        }

        private int[] AppendAdditionalValues(int[] binary)
        {
            List<int> binaryList = binary.ToList();

            for(int i = 0; i < 6; i ++)
            {
                binaryList.Add(0);
            }

            return binaryList.ToArray();
        }
    }
}
