using System;
using System.Linq;
using System.Collections.Generic;

namespace HelloWold;

public static class Program
{
    static string[] id = new string[100];
    static string[] name = new string[100];
    static string[] price = new string[100];
    static string[] quantity = new string[100];
    static int count = 0;

    //Arrays para sa recipt
    static string[] receiptID = new string[100];
    static string[] receiptProductName = new string[100];
    static string[] receiptQuantity = new string[100];
    static string[] receiptTotalPrice = new string[100];
    static string[] receiptDate = new string[100];
    static int receiptCount = 0;

    static void Main(string[] args)
    {
        string select, again;

        do
        {
            DisplayMainMenu();
            select = GetUserSelection();
            again = AskToContinue();
        } while (again == "Y" || again == "y");
    }


    public static void DisplayMainMenu()
    {
        string select;
        Console.Clear();
        Console.WriteLine("=================================================");
        Console.WriteLine("||                                             ||");
        Console.WriteLine("||     WELCOME TO PRODUCT INVENTORY SYSYEM     ||");
        Console.WriteLine("||                                             ||");
        Console.WriteLine("=================================================");
        Console.WriteLine();
        Console.WriteLine("[A] Add Item");
        Console.WriteLine("[B] View Item");
        Console.WriteLine("[C] Sell Item");
        Console.WriteLine("[D] Update Item");
        Console.WriteLine("[E] Delete Item");
        Console.WriteLine("[F] View Sales");
        Console.WriteLine("[X]  Exit");
    A1:
        Console.Write("\n\nSelect One:");
        select = Console.ReadLine().ToLower();

        switch (select)
        {
            case "A":
            case "a":
                Add();
                break;
            case "b":
            case "B":
                View();
                break;
            case "c":
            case "C":
                Sell();
                break;
            case "d":
            case "D":
                Update();
                break;
            case "e":
            case "E":
                Delete();
                break;
            case "f":
            case "F":
                Sale();
                break;
            default:
                Console.WriteLine("Invalid selection. Please try again.");
                goto A1;
                break;
        }
    }


    public static string GetUserSelection()
    {
        return Console.ReadLine().ToLower();
    }

    public static string AskToContinue()
    {
        while (true)
        {
            Console.Write("\nDo you want to go to Main Menu Y/N: ");
            string ask = Console.ReadLine().Trim().ToUpper();

            if (ask == "Y" || ask == "N")
            {
                return ask;
            }
            Console.WriteLine("Invalid input. Please enter Y or N.");
        }
    }




    //Para maka add ug item
    public static void Add()
    {
        string ask;
        do
        {
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("||                                             ||");
            Console.WriteLine("||               ADDING ITEM                   ||");
            Console.WriteLine("||                                             ||");
            Console.WriteLine("=================================================");
            Console.WriteLine();

            if (count >= 100)
            {
                Console.WriteLine("Inventory is full! Cannot add more items.");
                return;
            }

            try
            {
                string newid;
                while (true)
                {
                    Console.Write("Enter Product ID: ");
                    newid = Console.ReadLine().Trim();


                    if (string.IsNullOrEmpty(newid))
                    {
                        Console.WriteLine("\nProduct ID cannot be empty.");
                        continue;
                    }


                    if (!int.TryParse(newid, out int number))
                    {
                        Console.WriteLine("\nProduct ID must be a numeric value.");
                        continue;
                    }


                    if (number < 0)
                    {
                        Console.WriteLine("\nProduct ID cannot be negative.");
                        continue;
                    }


                    if (number >= 101)
                    {
                        Console.WriteLine("\nProduct ID must be 100 or below.");
                        continue;
                    }
                    if (number <= 0)
                    {
                        Console.WriteLine("\nProduct ID cannot be zero and negative.");
                        continue;
                    }


                    bool dup = false;
                    for (int h = 0; h < id.Length; h++)
                    {
                        if (id[h] == newid)
                        {
                            dup = true;
                            break;
                        }
                    }
                    if (dup)
                    {
                        Console.WriteLine("\nProduct ID cannot be duplicate.");
                        continue;
                    }

                    break;
                }


                string newname;
                while (true)
                {
                    Console.Write("Enter Product Name: ");
                    newname = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(newname))
                    {
                        Console.WriteLine("\nProduct name cannot be empty.");
                        continue;
                    }

                    bool dupli = false;
                    for (int i = 0; i < name.Length; i++)
                    {
                        if (name[i] == newname)
                        {
                            dupli = true;
                            break;
                        }
                    }
                    if (dupli)
                    {
                        Console.WriteLine("\nProduct Name cannot be duplicate.");
                        continue;
                    }

                    if (newname.Any(char.IsDigit))
                    {
                        Console.WriteLine("\nProduct name cannot contain numbers.");
                        continue;
                    }

                    break;
                }

                string newprice;
                while (true)
                {
                    Console.Write("Enter Product Price {₱}: ");
                    newprice = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(newprice))
                    {
                        Console.WriteLine("\nProduct price cannot be empty.");
                        continue;
                    }

                    if (!decimal.TryParse(newprice, out decimal pricevalue))
                    {
                        Console.WriteLine("\nPrice must be a valid number.");
                        continue;
                    }

                    if (pricevalue <= 0)
                    {
                        Console.WriteLine("\nPrice cannot be zero or negative.");
                        continue;
                    }

                    break;
                }

                string newquan;
                while (true)
                {
                    Console.Write("Enter Product Quantity: ");
                    newquan = Console.ReadLine().Trim();

                    if (string.IsNullOrEmpty(newquan))
                    {
                        Console.WriteLine("\nQuantity cannot be empty.");
                        continue;
                    }

                    if (!int.TryParse(newquan, out int quanValue))
                    {
                        Console.WriteLine("\nQuantity must be a valid number.");
                        continue;
                    }

                    if (quanValue <= 0)
                    {
                        Console.WriteLine("\nQuantity must be positive and cannot be zero.");
                        continue;
                    }

                    break;
                }


                id[count] = newid;
                name[count] = newname;
                price[count] = newprice;
                quantity[count] = newquan;
                count++;

                Console.WriteLine("\nItem added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nError. Please try again.");
            }


            while (true)
            {
                Console.Write("\nDo you want to add another product? Y/N: ");
                ask = Console.ReadLine().Trim().ToUpper();

                if (ask == "Y" || ask == "N")
                    break;

                Console.WriteLine("Invalid input. Please enter Y or N.");
            }
        }
        while (ask == "Y");
    }

    //Para maka view sa item
    public static void View()
    {
        Console.Clear();
        Console.WriteLine("=================================================");
        Console.WriteLine("||                                             ||");
        Console.WriteLine("||               VIEW INVENTORY ITEM           ||");
        Console.WriteLine("||                                             ||");
        Console.WriteLine("=================================================");
        Console.WriteLine();

        if (count == 0)
        {
            Console.WriteLine("\nNo items available in the inventory.");
            Console.WriteLine("Please add items first.");
        }
        else
        {
            Console.WriteLine("\nLIST OF ALL ITEMS IN INVENTORY");
            Console.WriteLine("==============================");

            for (int i = 0; i < count; i++)
            {
                DisplaySingleItem(i);
            }
        }
    }

    public static void DisplaySingleItem(int index)
    {
        Console.WriteLine("\n==================================");
        Console.WriteLine("ID: " + id[index]);
        Console.WriteLine("Name: " + name[index]);
        Console.WriteLine("Price: ₱ " + price[index]);
        Console.WriteLine("Quantity: " + quantity[index]);
        Console.WriteLine("==================================");
    }

    // para makapagawas ug item
    public static void Sell()
    {
        string ask;
        do
        {
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("||              PROCESS SALES                 ||");
            Console.WriteLine("=================================================");

            if (count == 0)
            {
                Console.WriteLine("\nNo items available for selling!");
                return;
            }


            View();


        A1:
            Console.Write("\nEnter Product ID to sell: ");
            string productId = Console.ReadLine().Trim();

            int itemIndex = -1;
            for (int i = 0; i < count; i++)
            {
                if (id[i] == productId)
                {
                    itemIndex = i;
                    break;
                }
            }

            if (itemIndex == -1)
            {
                Console.WriteLine("Item not found!");
                goto A1;
            }

        A2:
            Console.Write("Enter quantity to sell ({0}): ", quantity[itemIndex]);
            if (!int.TryParse(Console.ReadLine(), out int sellQuantity) || sellQuantity <= 0)
            {
                Console.WriteLine("Invalid quantity!");
                goto A2;
            }

            int currentStock;
            if (!int.TryParse(quantity[itemIndex], out currentStock))
            {
                Console.WriteLine("Invalid stock quantity!");
                goto A2;
            }

            if (sellQuantity > currentStock)
            {
                Console.WriteLine($"Insufficient stock! Available: {0}", currentStock);
                goto A2;
            }


            decimal itemPrice;
            if (!decimal.TryParse(price[itemIndex], out itemPrice))
            {
                Console.WriteLine("Invalid price format!");
                goto A2;
            }

            decimal totalPrice = itemPrice * sellQuantity;


            quantity[itemIndex] = (currentStock - sellQuantity).ToString();

            if (receiptCount < 100)
            {
                receiptID[receiptCount] = "R" + (receiptCount + 1).ToString();
                receiptProductName[receiptCount] = name[itemIndex];
                receiptQuantity[receiptCount] = sellQuantity.ToString();
                receiptTotalPrice[receiptCount] = totalPrice.ToString("N2");
                receiptDate[receiptCount] = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                receiptCount++;
            }
            else
            {
                Console.WriteLine("Receipt history is full!");
            }

            Console.WriteLine("\n=== BUY SUCCESSFULLY ===");
            Console.WriteLine("Item " + name[itemIndex]);
            Console.WriteLine("Quantity Sold " + sellQuantity);
            Console.WriteLine("Unit Price: ₱ " + itemPrice);
            Console.WriteLine("Total Price: ₱ " + totalPrice);
            Console.WriteLine("Remaining Stock: " + quantity[itemIndex]);
            Console.WriteLine("======================");
            Console.WriteLine();

            ask = Asking("Do you want to sell another Product? Y/N:");


        } while (ask == "Y");
    }

    public static string Asking(string message)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine().Trim().ToUpper();

            if (input == "Y" || input == "N")
            {
                return input;
            }
            Console.WriteLine("Invalid input. Please enter Y or N.");
        }
    }


    //Para maka update ug item
    public static void Update()
    {
        string ask;
        do
        {
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("||                                             ||");
            Console.WriteLine("||         UPDATE PRODUCT INFORMATION          ||");
            Console.WriteLine("||                                             ||");
            Console.WriteLine("=================================================");
            Console.WriteLine();

            Console.WriteLine("Current Products:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("ID: {0}, \t\t\t Name: {1} \t\t\t Price: {2} \t\t\tQuantity: {3}", id[i], name[i], price[i], quantity[i]);
            }

            Console.Write("Enter Product ID to Update: ");
            string searchid = Console.ReadLine();

            bool found = false;
            for (int i = 0; i < count; i++)
            {
                if (id[i] == searchid)
                {
                    found = true;
                    Console.WriteLine("Current Information:");
                    Console.WriteLine("ID: " + id[i]);
                    Console.WriteLine("Name: " + name[i]);
                    Console.WriteLine("Price: " + price[i]);
                    Console.WriteLine("Quantity: " + quantity[i]);

                    Console.WriteLine("\nEnter New Information (leave name unchanged):");
                    Console.WriteLine("Name: {0}  (Cannot be changed.)", name[i]);

                    string newprice;
                    while (true)
                    {
                        Console.Write("Price: ");
                        newprice = Console.ReadLine();

                        if (string.IsNullOrEmpty(newprice))
                        {
                            Console.WriteLine("Product price cannot be empty");
                            continue;
                        }

                        if (!decimal.TryParse(newprice, out decimal pricevalue) || pricevalue < 0)
                        {
                            Console.WriteLine("Invalid price value");
                            continue;
                        }
                        break;
                    }
                    price[i] = newprice;

                    string newquantity;
                    while (true)
                    {
                        Console.Write("Quantity: ");
                        newquantity = Console.ReadLine();

                        if (string.IsNullOrEmpty(newquantity))
                        {
                            Console.WriteLine("Please enter a Quantity");
                            continue;
                        }

                        if (!int.TryParse(newquantity, out int quanvalue) || quanvalue <= 0)
                        {
                            Console.WriteLine("Quantity must be positive number");
                            continue;
                        }
                        break;
                    }
                    quantity[i] = newquantity;

                    Console.WriteLine("\nProduct Information Updated Successfully!");
                    Console.WriteLine("Updated Product: ID: {0}, \nName: {1}, \nPrice: {2}, \nQuantity: {3}", id[i], name[i], price[i], quantity[i]);
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("Product ID not found!");
            }

            while (true)
            {
                Console.Write("\nDo you want to update another product? Y/N: ");
                ask = Console.ReadLine().Trim().ToUpper();

                if (ask == "Y" || ask == "N")
                {
                    break;
                }

                Console.WriteLine("Invalid input. Please enter Y or N.");
            }
        }
        while (ask == "Y");
    }

   // Para maka delete ug item
    public static void Delete()
    {
        string ask;
        do
        {
            Console.Clear();
            Console.WriteLine("=================================================");
            Console.WriteLine("||                                             ||");
            Console.WriteLine("||                DELETE PRODUCT               ||");
            Console.WriteLine("||                                             ||");
            Console.WriteLine("=================================================");
            Console.WriteLine();
            if (count == 0)
            {
                Console.WriteLine("\nNo items available in the inventory.");
                Console.WriteLine("There's nothing to delete.");
                break;
            }


            Console.WriteLine("\nCurrent Products:");
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("ID: {0}, \t\t\t Name: {1} \t\t\t Price: {2} \t\t\tQuantity: {3}", id[i], name[i], price[i], quantity[i]);
            }

            Console.Write("\nEnter Product ID to delete: ");
            string searchid = Console.ReadLine();

            bool found = false;
            for (int i = 0; i < count; i++)
            {
                if (id[i].Equals(searchid, StringComparison.InvariantCultureIgnoreCase))
                {
                    found = true;


                    Console.WriteLine("\nProduct Information:");
                    Console.WriteLine("ID: " + id[i]);
                    Console.WriteLine("Name: " + name[i]);
                    Console.WriteLine("Price: " + price[i]);
                    Console.WriteLine("Quantity: " + quantity[i]);


                    Console.Write("\nAre you sure you want to delete this product? Y/N: ");
                    string confirm = Console.ReadLine().ToUpper();

                    if (confirm == "Y")
                    {

                        for (int j = i; j < count - 1; j++)
                        {
                            id[j] = id[j + 1];
                            name[j] = name[j + 1];
                            price[j] = price[j + 1];
                            quantity[j] = quantity[j + 1];
                        }
                        count--;

                        Console.WriteLine("\nProduct deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("\nDeletion cancelled.");
                    }
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine("\nProduct with ID not found.");
            }

            while (true)
            {
                Console.Write("\nDo you want to delete another product? Y/N: ");
                ask = Console.ReadLine().Trim().ToUpper();

                if (ask == "Y" || ask == "N")
                {
                    break;
                }

                Console.WriteLine("Invalid input. Please enter Y or N.");
            }
        }
        while (ask == "Y");
        //while (ask.Equals("Y", StringComparison.InvariantCultureIgnoreCase));


    }
    public static void Sale()
    {
        Console.Clear();
        Console.WriteLine("=================================================");
        Console.WriteLine("||              SALES RECEIPT HISTORY           ||");
        Console.WriteLine("=================================================");
        Console.WriteLine();

        if (receiptCount == 0)
        {
            Console.WriteLine("No sales transactions yet!");
            return;
        }

        for (int i = 0; i < receiptCount; i++)
        {
            Console.WriteLine("═════════════════════════════════════════════");
            Console.WriteLine($" Receipt ID:    {receiptID[i]}");
            Console.WriteLine($" Product:       {receiptProductName[i]}");
            Console.WriteLine($" Quantity Sold: {receiptQuantity[i]}");
            Console.WriteLine($" Total Price:   ₱{receiptTotalPrice[i]}");
            Console.WriteLine($" Date:          {receiptDate[i]}");
            Console.WriteLine("═════════════════════════════════════════════\n");
        }
    }

}

