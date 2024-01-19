using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace testapp
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        private int age;
        public int Age
        {
            get { return age; }
            set { age = value > 17 ? value : 1; }
        }

        public string Phone { get; set; }
        public string Email { get; set; }

        public User()
        {
            Name = "";
            Surname = "";
            age = 18;
            Phone = "";
            Email = "";
        }
        public User(string n, string s, int a, string p, string e)
        {
            Name = n;
            Surname = s;
            age = a;
            Phone = p;
            Email = e;
        }

        public override string ToString()
        {
            return $"{Name} {Surname}, {Age}.\n\t{Phone}, {Email}";
        }
    }

    [Serializable]
    class Users
    {
        List<User> users;

        public Users()
        {
            users = new List<User>();
        }

        public void AddUser()
        {
            User user = new User();
            Console.Clear();
            Console.WriteLine("\tAdding new user");

            Console.Write("\n\tEnter name: ");
            string str = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(str))
            {
                user.Name = str;
            }
            else
            {
                bool isNull = true;
                do
                {
                    Console.WriteLine("\tEnter proper name!");
                    Console.Write("\tEnter name: ");
                    str = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        user.Name = str;
                        isNull = false;
                    }
                } while (isNull);
            }

            Console.Write("\tEnter surname: ");
            str = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(str))
            {
                user.Surname = str;
            }
            else
            {
                bool isNull = true;
                do
                {
                    Console.WriteLine("\tEnter proper surname!");
                    Console.Write("\tEnter surname: ");
                    str = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(str))
                    {
                        user.Name = str;
                        isNull = false;
                    }
                } while (isNull);
            }

            Console.Write("\tEnter age: ");
            int age = int.Parse(Console.ReadLine());
            if (age > 17)
            {
                user.Age = age;
            }
            else
            {
                do
                {
                    Console.WriteLine("\tEnter proper age!");
                    Console.Write("\tEnter age: ");
                    age = int.Parse(Console.ReadLine());
                    if (age > 17)
                    {
                        user.Age = age;
                    }
                } while (age < 17);
            }

            Console.Write("\tEnter phone: ");
            str = Console.ReadLine();
            if (Regex.IsMatch(str, @"^\+38\d{10}"))
            {
                user.Phone = str;
            }
            else
            {
                do
                {
                    Console.WriteLine("\tEnter proper phone!");
                    Console.Write("\tEnter phone: ");
                    str = Console.ReadLine();
                    if (Regex.IsMatch(str, @"^\+38\d{10}"))
                    {
                        user.Phone = str;
                    }
                } while (!Regex.IsMatch(str, @"^\+38\d{10}"));
            }

            Console.Write("\tEnter email: ");
            str = Console.ReadLine();
            if (Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                foreach (var item in users)
                {
                    if (item.Email == str)
                    {
                        do
                        {
                            Console.WriteLine("\tEnter unique email!");
                            Console.Write("\tEnter email: ");
                            str = Console.ReadLine();
                            if (Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                            {
                                user.Email = str;
                            }
                        } while (!Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"));
                        break;
                    }
                }
                user.Email = str;
            }
            else
            {
                do
                {
                    Console.WriteLine("\tEnter proper email!");
                    Console.Write("\tEnter email: ");
                    str = Console.ReadLine();
                    if (Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                    {
                        user.Email = str;
                    }
                } while (!Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"));
            }

            users.Add(user);
        }
        public void DeleteUser(int index)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("\tThere are any users in the list!");
                return;
            }
            if (index >= 0 && index < users.Count)
                users.RemoveAt(index);
            else
                Console.WriteLine("\tError! Index is out of range");
        }
        public void UpdateUser(int index)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("\tThere are any users in the list!");
                return;
            }
            if (index >= 0 && index < users.Count)
            {
                User newUser = new User();
                Console.Clear();
                Console.WriteLine("\tUpdating user");

                Console.Write("\n\tEnter new name: ");
                string str = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(str))
                {
                    newUser.Name = str;
                }
                else
                {
                    bool isNull = true;
                    do
                    {
                        Console.WriteLine("\tEnter proper name!");
                        Console.Write("\tEnter new name: ");
                        str = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            newUser.Name = str;
                            isNull = false;
                        }
                    } while (isNull);
                }

                Console.Write("\tEnter new surname: ");
                str = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(str))
                {
                    newUser.Surname = str;
                }
                else
                {
                    bool isNull = true;
                    do
                    {
                        Console.WriteLine("\tEnter proper surname!");
                        Console.Write("\tEnter new surname: ");
                        str = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            newUser.Name = str;
                            isNull = false;
                        }
                    } while (isNull);
                }

                Console.Write("\tEnter new age: ");
                int age = int.Parse(Console.ReadLine());
                if (age > 17)
                {
                    newUser.Age = age;
                }
                else
                {
                    do
                    {
                        Console.WriteLine("\tEnter proper age!");
                        Console.Write("\tEnter new age: ");
                        age = int.Parse(Console.ReadLine());
                        if (age > 17)
                        {
                            newUser.Age = age;
                        }
                    } while (age < 17);
                }

                Console.Write("\tEnter new phone: ");
                str = Console.ReadLine();
                if (Regex.IsMatch(str, @"^\+38\d{10}"))
                {
                    newUser.Phone = str;
                }
                else
                {
                    do
                    {
                        Console.WriteLine("\tEnter proper phone!");
                        Console.Write("\tEnter phone: ");
                        str = Console.ReadLine();
                        if (Regex.IsMatch(str, @"^\+38\d{10}"))
                        {
                            newUser.Phone = str;
                        }
                    } while (!Regex.IsMatch(str, @"^\+38\d{10}"));
                }

                Console.Write("\tEnter new email: ");
                str = Console.ReadLine();
                if (Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    foreach (var item in users)
                    {
                        if (item.Email == str)
                        {
                            do
                            {
                                Console.WriteLine("\tEnter unique email!");
                                Console.Write("\tEnter email: ");
                                str = Console.ReadLine();
                                if (Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                                {
                                    newUser.Email = str;
                                }
                            } while (!Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"));
                            break;
                        }
                    }
                    newUser.Email = str;
                }
                else
                {
                    do
                    {
                        Console.WriteLine("\tEnter proper email!");
                        Console.Write("\tEnter new email: ");
                        str = Console.ReadLine();
                        if (Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                        {
                            newUser.Email = str;
                        }
                    } while (!Regex.IsMatch(str, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"));
                }

                users[index] = newUser;
            }
            else
            {
                Console.WriteLine("\tError! Index is out of range");
            }
        }

        public void Show()
        {
            if (users.Count == 0)
            {
                Console.WriteLine("\tThere are any users in the list!");
                return;
            }
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"\t{i + 1}. {users[i]}");
            }
        }
        public void ShowByName(string name)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("\tThere are any users in the list!");
                return;
            }
            bool userFound = false;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Name == name)
                {
                    Console.WriteLine("\t" + users[i]);
                    userFound = true;
                    break;
                }
            }
            if (!userFound)
            {
                Console.WriteLine($"\tThere is no user with the name {name}");
            }
        }
        public void ShowByEmail(string email)
        {
            if (users.Count == 0)
            {
                Console.WriteLine("\tThere are any users in the list!");
                return;
            }
            bool userFound = false;
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Email == email)
                {
                    Console.WriteLine("\t" + users[i]);
                    userFound = true;
                    break;
                }
            }
            if (!userFound)
            {
                Console.WriteLine($"\tThere is no user with the email {email}");
            }
        }

        public void SaveToFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
            try
            {
                using (Stream stream = File.Create("Users.xml"))
                {
                    xmlSerializer.Serialize(stream, users);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t" + ex.Message);
            }
        }
        public void LoadFromFile()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
            try
            {
                if (File.Exists("Users.xml"))
                {
                    using (Stream stream = File.OpenRead("Users.xml"))
                    {
                        List<User> newUsers = (List<User>)xmlSerializer.Deserialize(stream);
                        users = newUsers;
                    }
                }
                else
                {
                    SaveToFile();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t" + ex.Message);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Users users = new Users();
            int choice = -1;
            users.LoadFromFile();
            do
            {
                try
                {
                    Console.WriteLine("User managment: ");
                    Console.WriteLine("1. Add new user");
                    Console.WriteLine("2. Delete user");
                    Console.WriteLine("3. Update user");
                    Console.WriteLine("4. Show all users");
                    Console.WriteLine("5. Show user by name");
                    Console.WriteLine("6. Show user by email");
                    Console.WriteLine("7. Save to file");
                    Console.WriteLine("8. Load from file");
                    Console.WriteLine("0. Exit");
                    Console.Write("Enter your choice: ");
                    choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            users.AddUser();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("\tDelete user");
                            users.Show();
                            Console.Write("\tEnter user to delete: ");
                            int index = int.Parse(Console.ReadLine());

                            users.DeleteUser(index - 1);
                            break;
                        case 3:
                            Console.Clear();
                            users.Show();
                            Console.Write("\tEnter user index to update: ");
                            index = int.Parse(Console.ReadLine());

                            users.UpdateUser(index - 1);
                            break;
                        case 4:
                            Console.Clear();
                            users.Show();
                            Console.WriteLine();
                            break;
                        case 5:
                            Console.Clear();
                            Console.Write("\tEnter the name to search for: ");
                            string str = Console.ReadLine();

                            users.ShowByName(str);
                            break;
                        case 6:
                            Console.Clear();
                            Console.Write("\tEnter the email to search for: ");
                            str = Console.ReadLine();

                            users.ShowByEmail(str);
                            break;
                        case 7:
                            Console.Clear();
                            users.SaveToFile();
                            break;
                        case 8:
                            Console.Clear();
                            users.LoadFromFile();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\t" + ex.Message);
                }
            } while (choice != 0);
        }
    }
}