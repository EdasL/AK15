namespace AK15

{
    internal class InitialData
    {
        private readonly int[] data = { 0, 0, 0, 0, 0, 0 };


        public void Insert(int a)
        {
            for (int i = 5; i > 0; i--)
            {
                data[i] = data[i - 1];

            }
            data[0] = a;
        }
        public int[] GetData()
        {
            return data;
        }

        public int GetBitValue(int i)
        {
            int n = i + data[1] + data[4] + data[5];
 
            return n % 2;
        }

    }
}
