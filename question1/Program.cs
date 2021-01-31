using System;
using System.Collections.Generic;


namespace question1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            //Console.WriteLine();
            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            //Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");


            if (n3 < 0)
            {
                Console.WriteLine("please enter a positive number");
            }
            else
            {
                bool flag = squareSums(n3);
                if (flag)
                {
                    Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
                }
                else
                {
                    Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");

                }
                Console.WriteLine("\n");

                // question 4
                int[] arr = { 3, 1, 4, 1, 5 };
                Console.WriteLine("Q4: Enter the absolute difference to check");
                int k = Convert.ToInt32(Console.ReadLine());
                int n4 = diffPairs(arr, k);
                Console.WriteLine("There exists {0} pairs with the given difference", n4);
                Console.WriteLine("\n");


                //Question 5:
                List<string> emails = new List<string>();
                emails.Add("dis.email+ bull@usf.com");     // disemail@usf.com
                emails.Add("dis.e.mail+bob.cathy@usf.com"); // disemail@usf.com
                emails.Add("disemail+david@us.f.com");      // disemail@us.f.com
                int ans5 = UniqueEmails(emails);
                Console.WriteLine("Q5");
                Console.WriteLine("The number of unique emails is " + ans5);
                Console.WriteLine("\n");


                //Quesiton 6:
                string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
                string destination = DestCity(paths);
                Console.WriteLine("Q6 ");


                Console.WriteLine("Destination city is " + destination);



            }



        }
        private static void printTriangle(int n)
        {
            try
            {
                // integer data types
                int row, space, symbol;

                if (n <= 0)
                {
                    Console.WriteLine("enter a valid number");

                }
                else
                {

                    // using for loop for printing multiple rows
                    for (row = 1; row <= n; row++)
                    {
                        // printing the spaces( formula implementation )
                        for (space = 1; space <= (n - row); space++)
                        {
                            Console.Write(" ");
                        }
                        // printing the symbol( formula implementation )
                        for (symbol = 1; symbol <= ((2 * row) - 1); symbol++)
                        {
                            Console.Write("*");
                        }
                        // to print the next row in a new line 
                        Console.WriteLine();


                    }
                    Console.ReadLine();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        private static void printPellSeries(int n2)
        {
            try
            {
                // declaring data types

                int a = 0;   // a = (n-2) element
                int b = 1;  // b = (n-1) element 
                int c;     // c = pell number
                int n;


                if (n2 <= 0)
                {
                    Console.WriteLine("enter a valid number");

                }
                else
                {
                    Console.WriteLine("\n");

                    Console.WriteLine(a);


                    for (n = 1; n < n2; n++)   // using for loop for printing n2 numbers

                    {
                        c = b + (2 * a);    // pell number = (n-1) + ( 2* (n-2) )
                        Console.WriteLine(c);

                        b = a;   // (n-1)th number = (n-2)th number for next loop
                        a = c;  // (n-2)th number = (n)th number for the next loop

                    }
                    Console.ReadLine();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private static bool squareSums(int n3)
        {
            try
            {

                int i, j;

                // impleminting for loops
                for (i = 0; i * i <= n3; i++)
                    for (j = 0; j * j <= n3; j++)


                        // logic for equating sum of squares
                        if (i * i + j * j == n3)
                        {
                            return true;
                        }
                return false;



            }
            catch (Exception)
            {

                throw;
            }
        }
        private static int diffPairs(int[] nums, int k)
        {
            try
            {
                int n = nums.Length;
                int count = 0;
                // for each pair
                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        // if difference is k, check if same number has appeared before
                        if ((nums[j] - nums[i] == k) || (nums[i] - nums[j] == k))
                        {
                            bool already_seen = false;
                            for (int l = j - 1; l > i; l--)
                            {
                                if (nums[l] == nums[j])
                                {
                                    already_seen = true;
                                    break;
                                }
                            }
                            // not appeared before, increase the count
                            if (already_seen == false)
                            {
                                count++;
                            }
                        }
                    }
                }

                return count;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        private static int UniqueEmails(List<string> emails)
        {
            try
            {
               
                List<string> unique_emails = new List<string>();
                // for each email
                foreach (string email in emails)
                {
                    string email_used = "";
                    // add the local part before first + and ignore . characters
                    foreach (char c in email)
                    {
                        if (c == '+' || c == '@')
                        {
                            break;
                        }
                        if (c == '.')
                        {
                            continue;
                        }
                        email_used += c;
                    }

                    // add the domain part and @ character
                    int atIndex = email.IndexOf('@');
                    email_used += email.Substring(atIndex);

                    // if this email is already added, ignore it
                    if (unique_emails.Contains(email_used) == false)
                    {
                        unique_emails.Add(email_used);
                    }
                }
                return unique_emails.Count;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }


        private static string DestCity(string[,] paths)
        {
            try
            {
                
                List<string> citiesWithOutgoingPaths = new List<string>(); // to store the result
                for (int i = 0; i < paths.GetLength(0); i++) // logic for taking destination paths
                {
                    citiesWithOutgoingPaths.Add(paths[i, 0]);
                }

                for (int i = 0; i < paths.GetLength(0); i++) // to check the value
                {
                    if (citiesWithOutgoingPaths.Contains(paths[i, 1]) == false) 
                    {
                        return paths[i, 1];
                    }
                }
                return "";


            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}


