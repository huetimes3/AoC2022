public class day6 
{
    public static void q1()
    {
        var msg = File.ReadLines("./challenges/day6.txt").First();
        char[] last4 = new char[4];
        for (int i = 0; i < 4; i++) {
            last4[i] = msg[i];
        }
        for (int i = 4; i < msg.Length; i++) {
            last4[i%4] = msg[i];
            if (last4.Distinct().Count() == last4.Length) 
            {
                Console.WriteLine(i+1);
                break;
            }
        }
    }

    public static void q2()
    {
        var msg = File.ReadLines("./challenges/day6.txt").First();
        char[] last14 = new char[14];
        for (int i = 0; i < 14; i++) {
            last14[i] = msg[i];
        }
        for (int i = 14; i < msg.Length; i++) {
            last14[i%14] = msg[i];
            if (last14.Distinct().Count() == last14.Length) 
            {
                Console.WriteLine(i+1);
                break;
            }
        }
    }
}