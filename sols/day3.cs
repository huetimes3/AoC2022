public class day3{
    public static void q1() 
    {
        var p = 0;
        var lines = File.ReadLines("./challenges/day3.txt");
        foreach (var line in lines)
        {
            var s1 = line.Substring(0, line.Length/2);
            var s2 = line.Substring(line.Length/2);
            var intersect = s1.Intersect(s2);
            foreach (var k in intersect) {
                if (k < 91) {
                    p += k-38;
                }
                else p += k-96;
            }
        }
        Console.WriteLine(p);
    }
    public static void q2() 
    {
        var p = 0;
        var s1 = "";
        var s2 = "";
        var s3 = "";
        string[] lines = File.ReadAllLines("./challenges/day3.txt");
        for (int i = 0; i < lines.Length; i += 3)
        {
            s1 = lines[i];
            s2 = lines[i+1];
            s3 = lines[i+2];
            var inter = s1.Intersect(s2.Intersect(s3));
            foreach (var k in inter) {
                if (k < 91) p += k-38;
                else p += k-96;
            }
        }
        Console.WriteLine(p);
    }
}