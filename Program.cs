using System;
namespace firstProject
{   
    //Object Tasks CLASS
    public class Tasks {
        private string title;
        private bool checkBox = false ;
        private static int amount = 0;
        public Tasks(string title) {
            this.title = title;

            amount++;
        }
        public string getTitle() { return title; }
        public void setTitle(string title) { this.title = title; }
        public void check() { checkBox = true; }
        public bool getCheck() { return checkBox; }
        public static void clearAll() { amount = 0; }
        public static int getAmount() { return amount; }
    }
    
    public class Program
    {
        static List<Tasks> list = new List<Tasks>();

        /// <summary>
        /// This function print text, add, show, check,...
        /// </summary>
        private static void header() {
            Console.WriteLine("------------------------");
            Console.WriteLine("1. Add a task");
            Console.WriteLine("2. Show tasks");
            Console.WriteLine("3. Check task");
            Console.WriteLine("4. Clear task");
            Console.WriteLine("5. End program");

            Console.Write("Enter choice: ");
            int choice;
            if (!int.TryParse(Console.ReadLine(),out choice)) {
                Console.WriteLine("Invalid format!");
                endProgram();
            }
            switch (choice) {
                case 1:
                    addTask();
                    break;
                case 2:
                    showTask();
                    break;
                case 3:
                    checkTask();
                    break;
                case 4:
                    list.Clear();
                    Tasks.clearAll();
                    header();
                    break;
                case 5:
                    endProgram();
                    break;
                default:
                    Console.WriteLine("Something wrong... Try again");
                    endProgram();
                    break;
            }
        }
        

        /// <summary>
        /// Function
        /// </summary>
        //ADD
        private static void addTask() {
            Console.Write("Enter title: "); 
            string title = Console.ReadLine() ?? "";
            try
            {
                list.Add(new Tasks(title));
                Console.WriteLine("Add successfully!");
                header();
            }
            catch (System.Exception)
            {
                Console.WriteLine("Invalid format!");
                endProgram();
                throw;
            }
        }
        //SHOW
        private static void showTask() {
            Console.WriteLine("-----------------");
            int id = 1;
            Console.WriteLine($"Size: {Tasks.getAmount()}");
            foreach (Tasks i in list) {
                string title = i.getTitle();
                bool check = i.getCheck();
                Console.WriteLine($"{id}. {title,-30}Status: {check}");
                id++;
            }
            header();
        }
        //CHECK the task if you're done
        private static void checkTask() {
            Console.Write("Enter the index to check: ");
            int index; 
            if (!int.TryParse(Console.ReadLine(),out index)) {
                Console.WriteLine("Invalid format!");
                endProgram();
            }
            if (index == 0 || index > Tasks.getAmount()) {
                Console.WriteLine("invalid number!");
            }
            else {
                list[index-1].check();
            }
            header();
        }
        //END program
        private static void endProgram() {
            Console.WriteLine("Thanks for using program!");
        }

        /// <summary>
        /// MAIN
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Welcome to To-do List program!");
            header();
        }
    }
}