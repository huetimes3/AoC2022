public class day4
{    
    public static void q1() {
        var p = 0;
        var lines = File.ReadLines("./challenges/day4.txt");
        foreach (var line in lines)
        {
            char[] delims = {',', '-'};
            string[] list = line.Split(delims);
            int[] l = new int[4];
            for (int i = 0; i < 4; i++) {
                l[i]=int.Parse(list[i]);
            }
            if ((l[0]<=l[2] && l[1] >= l[3]) || (l[0]>=l[2] && l[1] <= l[3])) p++;
        }
        
        Console.WriteLine(p);
    }
    public static void q2() {
        var p = 0;
        var lines = File.ReadLines("./challenges/day4.txt");
        foreach (var line in lines)
        {
            char[] delims = {',', '-'};
            string[] list = line.Split(delims);
            int[] l = new int[4];
            for (int i = 0; i < 4; i++) {
                l[i]=int.Parse(list[i]);
            }
            if ((l[0]<=l[2] && l[1] >= l[2]) || (l[0]>=l[2] && l[0] <= l[3])) p++;
        }
        Console.WriteLine(p);
    }
}