using EfCore_Task.Context;
using EfCore_Task.Models;

using EfCore_Task.Exceptions;

namespace EfCore_Task.Helper_folder


{
    public class Helper
    {
        int idProduct;
        int idUser;

        List<User> Users = [];
        List<Basket> Baskets = [];
        List<Product> Products = [];
        public void ReadDataFromSql()
        {
            {


                using (AppDbContext sql = new AppDbContext())
                {
                    Users = sql.users.ToList();
                }
                Users.ForEach(u => Console.WriteLine(u.Username));
            }
        }
        public void Register()
        {
            Console.WriteLine("Enter name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter surname:");
            string surname = Console.ReadLine();
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            string password = Console.ReadLine();

            using (AppDbContext sql = new AppDbContext())
            {
                sql.users.Add(new User
                {
                    Name = name,
                    Surname = surname,
                    Username = username,
                    Password = password
                });
                sql.SaveChanges();
                Console.WriteLine("registered successfullly");

            }

        }
        public void Login(string username, string password)
        {
            List<User> UsersFromsql = [];

            using (AppDbContext sql2 = new AppDbContext())
            {
                UsersFromsql = sql2.users.ToList();
            }

            var userLogin = UsersFromsql.Find(u => u.Username == username && u.Password == password);
            if (userLogin == null) throw new UserNotFoundException("User not found.");
            else
            {
                Console.WriteLine("Login successful");


                //---------------------------------------------------------------------------------------

                Console.WriteLine("1)Mehsullara bax\n2)Sebete bax\n3)Hesabdan cix");

                int menyu = int.Parse(Console.ReadLine());
                switch (menyu)
                {

                case 1:
                        ReadProductsFromSql();
                        Console.WriteLine("Sebete elave etmek istediyiniz mehsulun id'i daxil edin;");
                        idProduct = int.Parse(Console.ReadLine());

                        Console.WriteLine("Oz id'inizi daxil edin:");
                        if (idProduct == 0)
                        {
                            Console.WriteLine("1)Mehsullara bax\n2)Sebete bax\n3)Hesabdan cix");
                        }
                       
                            idUser = int.Parse(Console.ReadLine());

                            SearchProduct(idProduct, idUser);
                        
                         break;
                case 2:
                                Console.WriteLine("2");
                         break;
                case 3:
                        Console.WriteLine("1)REGISTER\n2)lOGIN");
                        break;


                             default:
                                Console.WriteLine("1)Mehsullara bax\n2)Sebete bax\n3)Hesabdan cix");

                             break;

                            }
                        }

                }
                public void ReadProductsFromSql()
                {
                    using (AppDbContext sqlProduct = new AppDbContext())
                    {
                        Products = sqlProduct.products.ToList();
                    }
                    Products.ForEach(p => Console.WriteLine(p.Id + "." + p.Name + p.Price));
                }
                public void SearchProduct(int id, int idUser)
                {
                    using (AppDbContext productsFromSql = new AppDbContext())
                    {
                        Products = productsFromSql.products.ToList();
                    }
                    var foundProduct = Products.Find(p => p.Id == id);
                    if (foundProduct == null) throw new ProductNotFoundException("Product not found.");
                    else {
                        using (AppDbContext addBasket = new AppDbContext())
                        {
                            addBasket.baskets.Add(new Basket
                            {
                                UserId = idUser,
                                ProductId = id
                            });
                            addBasket.SaveChanges();
                            Console.WriteLine("Product added basket");
                            Console.ReadLine();
                        }
                    }
                }

            }

        } 


           

 