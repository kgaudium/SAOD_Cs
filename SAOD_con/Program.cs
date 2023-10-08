
namespace SAOD_con
{
    static class Program
    {
        static void Main()
        {
            MyList<int> intList = new MyList<int>(new[] {1,2,3});
            
            intList.Add(1);
            intList.Add(4);
            intList.Add(8);
            intList.Add(9);
            // MessageBox.Show(intList.ToString());
            // intList.Clear();
            Console.WriteLine(intList.ToString());
            intList.Insert(2,0);
            Console.WriteLine(intList.ToString());
            intList.Remove(2);
            Console.WriteLine(intList.ToString());
            Console.WriteLine(intList.Count.ToString());
            Console.WriteLine(1488.GetHashCode());
            
            Terminal.Loop();
        }
    }
}
