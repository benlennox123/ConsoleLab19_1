using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLab19_1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Модель компьютера  характеризуется кодом  и названием  марки компьютера, типом  процессора,
            //частотой работы  процессора,  объемом оперативной памяти, объемом жесткого диска, объемом памяти видеокарты,
            //стоимостью компьютера в условных единицах и количеством экземпляров, имеющихся в наличии.
            //Создать список, содержащий 6 - 10 записей с различным набором значений характеристик.
            //Определить:
            //-все компьютеры с указанным процессором. Название процессора запросить у пользователя;
            //-все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;
            //-вывести весь список, отсортированный по увеличению стоимости;
            //-вывести весь список, сгруппированный по типу процессора;
            //-найти самый дорогой и самый бюджетный компьютер;
            //-есть ли хотя бы один компьютер в количестве не менее 30 штук ?
            List<Comp> compList = new List<Comp>()
            {
                new Comp(){ID=1, MarkName="HP", Processor="Intel", FrProcessor=3600, DDR=8, HDD=1000, GpuDDR=4, Price=75000, Quantity=5 },
                new Comp(){ID=2, MarkName="Asus", Processor="AMD", FrProcessor=5600, DDR=32, HDD=1000, GpuDDR=8, Price=175000, Quantity=32 },
                new Comp(){ID=3, MarkName="Lenovo", Processor="Intel", FrProcessor=4800, DDR=16, HDD=500, GpuDDR=2, Price=98000, Quantity=5 },
                new Comp(){ID=4, MarkName="DELL", Processor="Intel", FrProcessor=3100, DDR=16, HDD=500, GpuDDR=2, Price=55000, Quantity=25 },
                new Comp(){ID=5, MarkName="Acer", Processor="AMD", FrProcessor=4600, DDR=16, HDD=1000, GpuDDR=4, Price=120000, Quantity=1 },
                new Comp(){ID=6, MarkName="Samsung", Processor="Intel", FrProcessor=3600, DDR=16, HDD=1000, GpuDDR=4, Price=80000, Quantity=12 },
                new Comp(){ID=7, MarkName="MSI", Processor="Intel", FrProcessor=3100, DDR=8, HDD=500, GpuDDR=2, Price=50000, Quantity=44 },
                new Comp(){ID=8, MarkName="NoName", Processor="AMD", FrProcessor=4600, DDR=16, HDD=2000, GpuDDR=8, Price=145000, Quantity=10 }
            };
            //-все компьютеры с указанным процессором. Название процессора запросить у пользователя;
            Console.Write("Список компьютеров с процессором - ");
            String processor = Convert.ToString(Console.ReadLine());
            List<Comp> comps = compList.Where(s => s.Processor == processor).ToList();
            Console.WriteLine("ID\tMarkName\tProcessor\tFrProcessor\tDDR\tHDD\tGpuDDR\tPrice\tQuantity");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            foreach (Comp s in comps)
            {
                Console.WriteLine($"{s.ID}\t{s.MarkName}      \t{s.Processor}\t\t{s.FrProcessor} \t\t{s.DDR} \t{s.HDD} \t{s.GpuDDR} \t{s.Price} \t{s.Quantity}");
            }
            //-все компьютеры с объемом ОЗУ не ниже, чем указано.Объем ОЗУ запросить у пользователя;
            Console.WriteLine();
            Console.Write("Список компьютеров с объёмом ОЗУ не менее - ");
            int ddr = Convert.ToInt32(Console.ReadLine());
            comps = compList.Where(s => s.DDR >= ddr).ToList();
            Console.WriteLine("ID\tMarkName\tProcessor\tFrProcessor\tDDR\tHDD\tGpuDDR\tPrice\tQuantity");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            foreach (Comp s in comps)
            {
                Console.WriteLine($"{s.ID}\t{s.MarkName}      \t{s.Processor}\t\t{s.FrProcessor} \t\t{s.DDR} \t{s.HDD} \t{s.GpuDDR} \t{s.Price} \t{s.Quantity}");
            }
            //-вывести весь список, отсортированный по увеличению стоимости;
            Console.WriteLine();
            Console.WriteLine("Сортировка по увеличению стоимости");
            comps = compList.OrderBy(s => s.Price).ToList();
            Console.WriteLine("ID\tMarkName\tProcessor\tFrProcessor\tDDR\tHDD\tGpuDDR\tPrice\tQuantity");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            foreach (Comp s in comps)
            {
                Console.WriteLine($"{s.ID}\t{s.MarkName}      \t{s.Processor}\t\t{s.FrProcessor} \t\t{s.DDR} \t{s.HDD} \t{s.GpuDDR} \t{s.Price} \t{s.Quantity}");
            }
            //-вывести весь список, сгруппированный по типу процессора;
            Console.WriteLine();
            Console.WriteLine("Сортировка с группировкой по типу процессора");
            var compsGroup = compList.GroupBy(s => s.Processor);
            foreach (var t in compsGroup)
            {
                Console.WriteLine(t.Key);
                Console.WriteLine("ID\tMarkName\tProcessor\tFrProcessor\tDDR\tHDD\tGpuDDR\tPrice\tQuantity");
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                foreach (var s in t)
                    Console.WriteLine($"{s.ID}\t{s.MarkName}      \t{s.Processor}\t\t{s.FrProcessor} \t\t{s.DDR} \t{s.HDD} \t{s.GpuDDR} \t{s.Price} \t{s.Quantity}");
                Console.WriteLine();
            }
            //-найти самый дорогой и самый бюджетный компьютер;
            Console.WriteLine();
            Console.WriteLine("Самый дорогой и самый бюджетный компы");
            comps = compList.Where(s => s.Price == compList.Max(item => item.Price) || s.Price == compList.Min(item => item.Price)).ToList();
            Console.WriteLine("ID\tMarkName\tProcessor\tFrProcessor\tDDR\tHDD\tGpuDDR\tPrice\tQuantity");
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            foreach (Comp s in comps)
            {
                Console.WriteLine($"{s.ID}\t{s.MarkName}      \t{s.Processor}\t\t{s.FrProcessor} \t\t{s.DDR} \t{s.HDD} \t{s.GpuDDR} \t{s.Price} \t{s.Quantity}");
            }
            //-есть ли хотя бы один компьютер в количестве не менее 30 штук ?
            Console.WriteLine();
            Console.WriteLine("Есть хотя бы одна позиция в кол-ве не менее 30 штук?");
            if (compList.Any(s => s.Quantity >= 30) == true)
            {
                Console.WriteLine("Да");
                Console.WriteLine();
                Console.WriteLine("Сортировка по количеству не менее 30 штук");
                comps = compList.Where(s => s.Quantity >= 30).ToList();
                Console.WriteLine("ID\tMarkName\tProcessor\tFrProcessor\tDDR\tHDD\tGpuDDR\tPrice\tQuantity");
                Console.WriteLine("---------------------------------------------------------------------------------------------");
                foreach (Comp s in comps)
                {
                    Console.WriteLine($"{s.ID}\t{s.MarkName}      \t{s.Processor}\t\t{s.FrProcessor} \t\t{s.DDR} \t{s.HDD} \t{s.GpuDDR} \t{s.Price} \t{s.Quantity}");
                }
            }
            else
            {
                Console.WriteLine("Нет");
            }
            Console.WriteLine();
            Console.WriteLine("Для завершения нажмите любую клавишу");
            Console.ReadKey();


        }
    }

    public class Comp
    {
        public int ID { get; set; }
        public string MarkName { get; set; }
        public string Processor { get; set; }
        public int FrProcessor { get; set; }
        public int DDR { get; set; }
        public int HDD { get; set; }
        public int GpuDDR { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}
