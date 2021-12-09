using System.Threading;
Console.WriteLine("Введите число элементов в массиве:");
int n = Convert.ToInt32(Console.ReadLine());
int[] array = new int[n];
Random random = new Random();
 int Method1()
{
    Console.WriteLine("Method1 начал работу");
    int S = 0;
    for (int i = 0; i < n; i++)
    {
        array[i] = random.Next(0, n);
        S += array[i];
        Thread.Sleep(100);
        Console.Write("{0} ", array[i]);
    }
    Console.WriteLine();
    Console.WriteLine(S);
    Console.WriteLine("Method1 окончил работу");
    return (S);
}
int Method2(Task task2)
{
    Console.WriteLine("Method2 начал работу");
    int max = array[0];
    foreach (int a in array)
    {
        if (a > max)
            max = a;
        Thread.Sleep(200);
     
    }
    Console.WriteLine(max);
    Console.WriteLine("Method2 окончил работу");
    return (max);
}

Func<int> func1 = new Func<int>(Method1);
Task<int> task1 = new Task<int>(func1);
Func<Task,int> func2 = new Func<Task,int>(Method2);
Task<int> task2 = task1.ContinueWith(func2);
task1.Start();
task2.Wait();
Console.WriteLine("Main закончил работу");
