public class day8 
{
    public static void q1() 
    {
        var vistrees = 0;
        int[][] f;  // the forest array we want to be left with at the end
        List<int[]> forest = new List<int[]>();
        var lines = File.ReadLines("./challenges/day8.txt");
        foreach (var line in lines) 
        {
            forest.Add(line.Select(c => (c - '0')).ToArray()); // since string is enumerable, enumerate on each character, and subtract the ascii
        }
        // now to convert the forest to a 2d array
        f = forest.ToArray();
        // now let's get into the nasty stuff, iterate through each elem and check its row and column
        // there's gotta be a more clever approach
        vistrees = f[0].Length * 2 + f.Length * 2 - 4; // outer edges always visible, remove 4 for counting corners twice
        for (int i = 1; i < f.Length-1; i++)
        {   
            for (int j = 1; j < f[0].Length-1; j++)
            {
                int[] col = f.Select(row => (int)row[j]).ToArray(); // column the tree is in
                int[] talltrees = {f[i].Take(j).Max(),
                                   f[i].Skip(j+1).Max(),
                                   col.Take(i).Max(),
                                   col.Skip(i+1).Max()
                };
                if (f[i][j] > talltrees.Min()) vistrees++;
            }
        }    
        Console.WriteLine(vistrees);    
    }

    public static void q2()
    {
        var scenic = 0;
        int[][] f;  // the forest array we want to be left with at the end
        List<int[]> forest = new List<int[]>();
        var lines = File.ReadLines("./challenges/day8.txt");
        foreach (var line in lines) 
        {
            forest.Add(line.Select(c => (c - '0')).ToArray()); // since string is enumerable, enumerate on each character, and subtract the ascii
        }
        // now to convert the forest to a 2d array
        f = forest.ToArray();
        // now let's get into the nasty stuff, iterate through each elem and check its row and column
        // there's gotta be a more clever approach
        // we ignore the sides because scenic score would get multiplied by 0 anyways
        for (int i = 1; i < f.Length-1; i++)
        {   
            for (int j = 1; j < f[0].Length-1; j++)
            {
                int[] col = f.Select(row => (int)row[j]).ToArray(); // column the tree is in

                var w = Math.Min(f[i].Take(j).Reverse().TakeWhile(t => t < f[i][j]).Count()+1, j);
                var e = Math.Min(f[i].Skip(j+1).TakeWhile(t => t < f[i][j]).Count()+1, f[i].Length - j - 1);
                var n = Math.Min(col.Take(i).Reverse().TakeWhile(t => t < f[i][j]).Count()+1, i);
                var s = Math.Min(col.Skip(i+1).TakeWhile(t => t < f[i][j]).Count(), f.Length - i - 1);

                var treescore = w * e * n * s;
                if (treescore > scenic) scenic = treescore;
            }
        }    
        Console.WriteLine(scenic);    
    }
}