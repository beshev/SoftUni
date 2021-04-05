namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            Worker robotWorker = new Robot("P45ZPU",200);
            ISleeper humanWorker = new Employee("Pesho4320");
            robotWorker.Work(12);
            humanWorker.Sleep();
        }
    }
}
