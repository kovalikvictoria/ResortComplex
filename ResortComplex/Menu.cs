using Repository;
using Repository.Concrete;
using Services.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResortComplex
{
    public class Menu : ConnectionManager
    {
        public void ChooseTable()
        {
            Console.Clear();
            Console.WriteLine("Welcome to start page!\n\n");
            Console.WriteLine("What table you want to choose?\n1. Services\n2. Rooms\n3. Employees");
            Console.WriteLine("\nYour selection: ");
            string ch = Console.ReadLine();

            switch (ch)
            {
                case "1":
                    {
                        ChooseActionForService();
                        break;
                    }

                case "2":
                    {
                        ChooseActionForRoom();
                        break;
                    }

                case "3":
                    {
                        ChooseActionForEmployee();
                        break;
                    }

                default:
                    Console.WriteLine("Invalid selection. Please select 1, 2 or 3.");
                    break;
            }
        }

        public void ChooseActionForService()
        {
            ServiceRepository serviceRepository = new ServiceRepository();
            ServiceServices serviceServices = new ServiceServices();

            Console.Clear();
            Console.WriteLine("Repository: SERVICE\n\n");
            Console.WriteLine("What action you want to choose?\n" +
                          "1. View table\n" +
                          "2. Add row\n" +
                          "3. Update row\n" +
                          "4. Delete row\n" +
                          "5. View maximum price\n" +
                          "6. Viev minimum price\n" +
                          "7. Back to start menu");
            Console.Write("\nYour selection: ");

            string ch = Console.ReadLine();
            switch (ch)
            {
                case "1":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: SERVICE\n\n");
                            serviceRepository.Select(serviceRepository.CreateFilter());
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForService();
                        }
                    }

                case "2":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: SERVICE\n\n");
                            serviceRepository.Add(serviceRepository.CreateModel());
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForService();
                        }
                    }

                case "3":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: SERVICE\n\n");
                            serviceRepository.Update(serviceRepository.CreateModel(), serviceRepository.CreateFilter());
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForService();
                        }
                    }

                case "4":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: SERVICE\n\n");
                            serviceRepository.Delete(serviceRepository.CreateFilter());
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForService();
                        }
                    }

                case "5":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: SERVICE\n\n");
                            Console.WriteLine("MaxPrice: " + serviceServices.MaxPrice());
                            Console.ReadKey();
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForService();
                        }
                    }

                case "6":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: SERVICE\n\n");
                            Console.WriteLine("MinPrice: " + serviceServices.MinPrice());
                            Console.ReadKey();
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForService();
                        }
                    }

                case "7":
                    {
                        Menu menu = new Menu();
                        menu.ChooseTable();
                        break;
                    }

                default:
                    Console.WriteLine("Invalid selection. Please select 1, 2, 3, 4 or 5.");
                    break;
            }
        }

        public void ChooseActionForRoom()
        {
            RoomRepository roomRepository = new RoomRepository();
            RoomServices roomServices = new RoomServices();

            Console.Clear();
            Console.WriteLine("Repository: ROOM\n\n");
            Console.WriteLine("What action you choose?\n" +
                          "1. View table\n" +
                          "2. Add row\n" +
                          "3. Update row\n" +
                          "4. Delete row\n" +
                          "5. View maximum price\n" +
                          "6. Viev minimum price\n" +
                          "7. Back to start menu");
            Console.Write("\nYour selection: ");

            string ch = Console.ReadLine();
            switch (ch)
            {
                case "1":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: ROOM\n\n");
                            roomRepository.Select(roomRepository.CreateFilter());
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForRoom();
                        }
                    }

                case "2":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: ROOM\n\n");
                            roomRepository.Add(roomRepository.CreateModel());
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForRoom();
                        }
                    }

                case "3":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: ROOM\n\n");
                            roomRepository.Update(roomRepository.CreateModel(), roomRepository.CreateFilter());
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForRoom();
                        }
                    }

                case "4":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: ROOM\n\n");
                            roomRepository.Delete(roomRepository.CreateFilter());
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForRoom();
                        }
                    }

                case "5":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: ROOM\n\n");
                            Console.WriteLine("MaxPrice: " + roomServices.MaxPrice());
                            Console.ReadKey();
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForRoom();
                        }
                    }

                case "6":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: ROOM\n\n");
                            Console.WriteLine("MinPrice: " + roomServices.MaxPrice());
                            Console.ReadKey();
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForRoom();
                        }
                    }

                case "7":
                    {
                        Menu menu = new Menu();
                        menu.ChooseTable();
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Invalid selection. Please select 1, 2, 3, 4 or 5.");
                        break;
                    }
            }
        }

        public void ChooseActionForEmployee()
        {
            EmployeeRepository employeeRepository = new EmployeeRepository();

            Console.Clear();
            Console.WriteLine("Repository: EMPLOYEE\n\n");
            Console.WriteLine("What action you choose?\n" +
                          "1. View table\n" +
                          "2. Add row\n" +
                          "3. Update row\n" +
                          "4. Delete row\n" +
                          "5. Back to start menu");
            Console.Write("\nYour selection: ");

            string ch = Console.ReadLine();
            switch (ch)
            {
                case "1":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: EMPLOYEE\n\n");
                            employeeRepository.Select(employeeRepository.CreateFilter());
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForEmployee();
                        }
                    }

                case "2":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: EMPLOYEE\n\n");
                            employeeRepository.Add(employeeRepository.CreateModel());
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForEmployee();
                        }
                    }

                case "3":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: EMPLOYEE\n\n");
                            employeeRepository.Update(employeeRepository.CreateModel(), employeeRepository.CreateFilter());
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForEmployee();
                        }
                    }

                case "4":
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Repository: DISCOUNT\n\n");
                            employeeRepository.Delete(employeeRepository.CreateFilter());
                            break;
                        }
                        finally
                        {
                            Menu menu = new Menu();
                            menu.ChooseActionForEmployee();
                        }
                    }

                case "5":
                    {
                        Menu menu = new Menu();
                        menu.ChooseTable();
                        break;
                    }

                default:
                    Console.WriteLine("Invalid selection. Please select 1, 2, 3, 4 or 5.");
                    break;
            }
        }
    }
}
