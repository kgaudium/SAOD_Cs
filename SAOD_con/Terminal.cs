namespace SAOD_con;

public static class Terminal
{
    public static void Loop()
    {
        MyList<int> list = new MyList<int>();
        while (true)
        {
            string input = Console.ReadLine();
            var input_arr = input.Split(' ');
            try
            {
                switch (input_arr[0])
                {
                    case "":
                        break;
                    
                    case "add":
                    case "Add":
                        list.Add(int.Parse(input_arr[1]));
                        Console.WriteLine(">>> " + list.ToString());
                        break;
                    
                    case "print":
                    case "Print":
                        Console.WriteLine(">>> " + list.ToString());
                        break;
                    
                    case "count":
                    case "Count":
                        Console.WriteLine(">>> " + list.Count.ToString());
                        break;
                    
                    case "get":
                    case "Get":
                        Console.WriteLine(">>> " + list.Get(int.Parse(input_arr[1])).ToString());
                        break;
                    
                    case "removeIndex":
                    case "RemoveIndex":
                        list.RemoveByIndex(int.Parse(input_arr[1]));
                        Console.WriteLine(">>> " + list.ToString());
                        break;
                    
                    case "remove":
                    case "Remove":
                        list.Remove(int.Parse(input_arr[1]));
                        Console.WriteLine(">>> " + list.ToString());
                        break;
                    
                    case "insert":
                    case "Insert":
                        list.Insert(int.Parse(input_arr[1]), int.Parse(input_arr[2]));
                        Console.WriteLine(">>> " + int.Parse(input_arr[1])+ " " + int.Parse(input_arr[2]));
                        Console.WriteLine(">>> " + list.ToString());
                        break;
                    
                    case "clear":
                    case "Clear":
                        list.Clear();
                        Console.WriteLine(">>> " + list.ToString());
                        break;
                    
                    case "hash":
                    case "Hash":
                        Console.WriteLine(">>> " + list.GetHashCode());
                        break;
                    
                    case "contains":
                    case "Contains":
                        Console.WriteLine(">>> " + list.Contains(int.Parse(input_arr[1])));
                        break;
                    
                    default:
                        Console.WriteLine(">>> Incorrect command: " + input);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                // throw;
            }
            
            if (input == "exit") break;
        }
    }
}