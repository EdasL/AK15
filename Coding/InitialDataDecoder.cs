namespace AK15

{
    internal class InitialDataDecoder
    {
        private readonly int[] initialData = { 0, 0, 0, 0, 0, 0 };

        public void Insert(int value)
        {
            for (int i = initialData.Length - 1; i > 0; i--)
            {
                initialData[i] = initialData[i - 1];
            }
            initialData[0] = value;

        }

        public int[] GetData()
        {
            return initialData;
        }

        public int GetLastElement()
        {
            return initialData[initialData.Length - 1];
        }

        public int GetBitValue(int i, int j)
        {
            int n = i + j + initialData[1] + initialData[4] + initialData[5];

            return n % 2;
        }

        public int GetPrevBitSumsValue(int i)
        {
            int n = i + initialData[0] + initialData[3] + initialData[5];

            if (n > 2)
            {
                return 1;
            }

            return 0;
        }

    }
}
