namespace Database
{
    using System;
    using System.Linq;

    public class Database
    {
        private const int Capacity = 16;
        private int[] data;
        private int count;

        public Database()
        {
            this.data = new int[Capacity];
        }

        public Database(params int[] integers)
            :this()
        {
            if (integers != null)
            {
                foreach (var number in integers)
                {
                    this.Add(number);
                }
            }
        }

        public int Count => this.count;

        public void Add(int number)
        {
            if (this.count == this.data.Length)
            {
                throw new InvalidOperationException();
            }

            this.data[this.count] = number;
            this.count++;
        }

        public void Remove()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException();
            }
			
			this.data[this.count] = default(int);
            this.count--;
        }

        public int[] Fetch() => this.data.Take(this.count).ToArray();
    }
}
