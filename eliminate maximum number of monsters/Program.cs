namespace eliminate_maximum_number_of_monsters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol= new Solution();
            var dist = new int[] { 3, 2, 4 };
            var speed = new int[] { 5, 3, 2 };
            var answer = sol.EliminateMaximum(dist, speed);
            Console.WriteLine(answer);
        }


        public class Solution
        {
            public int EliminateMaximum(int[] dist, int[] speed)
            {
                // step 1 - calculate the travel time for each monster and put in a double array
                // step 2 - sort the travel time, as we can kill in any order, we target the sortest reaching time monsters first.
                // step 3 - will start killing monster at 0 time, now for each travel time element, if we found any travel time is lesser or equal to gun next killing time, which means we lost the game.

                // step 1
                int size = dist.Length;
                var travelTime = new double[size];
                for (int i = 0; i < dist.Length; i++)
                {
                    travelTime[i] = (double)(dist[i]) / speed[i];
                }

                // step 2
                Array.Sort(travelTime);
                // step 3
                double currentTime = 0.0;
                int count = 0;
                for (int i = 0; i < size; i++)
                {
                    if (travelTime[i] > currentTime)
                    {
                        count += 1;
                    }
                    else
                    {
                        return count;
                    }
                    currentTime = currentTime + 1.0;
                }
                return count;
            }
        }
    }
}