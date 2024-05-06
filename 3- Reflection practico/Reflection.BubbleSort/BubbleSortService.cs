namespace Reflection.BubbleSort
{
    public class BubbleSortService : ISort
    {
        public void Sort(ref List<int> elements)
        {
            Console.WriteLine("Ordenando por BubbleSort");
            for (int write = 0; write < elements.Count; write++)
            {
                for (int sort = 0; sort < elements.Count - 1; sort++)
                {
                    if (elements[sort] > elements[sort + 1])
                    {
                        (elements[sort], elements[sort + 1]) = (elements[sort + 1], elements[sort]);
                    }
                }
            }
        }
    }
}
