using EfCore_Task.Context;
using EfCore_Task.Models;
using EfCore_Task.Helper_folder;
using EfCore_Task.Exceptions;


namespace EfCore_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Helper helper= new Helper();
            Console.WriteLine(" 1.Register\n 2.Login");
            int click = int.Parse(Console.ReadLine());
            switch (click)
            {

                case 1:

                    helper.Register();
                    //helper.ReadDataFromSql();
                    break;

                case 2:
                    Console.WriteLine("Enter username:");
                    string loginUsername = Console.ReadLine();
                    Console.WriteLine("Enter password:");
                    string loginPassword = Console.ReadLine();

                    helper.Login(loginUsername, loginPassword);

                    break;


                default:
                    Console.WriteLine("1)REGISTER\n2)lOGIN");
                    break;

            }




        }
    }
}
        
   