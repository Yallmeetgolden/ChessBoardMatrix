using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardMatrix
{
    public class Menu
    {
        ChessBMatrix matrix;
        public void Run()
        {

            while (true)
            {
                Console.WriteLine("******Matrix Menu********");
                Console.WriteLine("1. Create Matrix");
                Console.WriteLine("2. Display Matrix");
                Console.WriteLine("3. Get Entry position of Matrix");
                Console.WriteLine("4. Set An Element in position of  Matrix");
                Console.WriteLine("5. Add Two Matrix");
                Console.WriteLine("6. Multiply Two Matrix");
                Console.WriteLine("0. Exit Menu");
                Console.WriteLine(" Select Option");

                string option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        CreateMatrix();
                        break;
                    case "2":
                        DisplayMatrix();
                        break;
                    case "3":
                        GetEntryAtPosition();
                        break;
                    case "4":
                        SetElementAtPosition();
                        break;
                    case "5":
                        AddMatrixes();
                        break;
                    case "6":
                        MultiplyMatrixes();
                        break;
                    case "0":
                        Console.WriteLine("Exiting Menu********");
                        return;
                    default:
                        Console.WriteLine("Invalid option..please select a valid option");
                        break;
                }
                Console.WriteLine("PROCESSING........ ");
                //Thread.Sleep(2000);

            }
        }
        public void CreateMatrix()
        {
            try
            {
                Console.WriteLine("Enter Matrix Size");
                int Input = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Number to Prefill the Matrix:");
                int prefillNumber = Convert.ToInt32(Console.ReadLine());
                matrix = new ChessBMatrix(Input, prefillNumber);
                Console.WriteLine("Successfully created");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Please enter an integer.");
            }
        }


        public void DisplayMatrix()
        {
            if (matrix == null)
            {
                Console.WriteLine("You have not created matrix yet, Please create matrix first with option 1 ");
            }
            else
            {
                Console.WriteLine("Displaying matrix");
                Console.WriteLine(matrix.ToString());
            }


        }
        public void GetEntryAtPosition()
        {
            if (matrix == null)
            {
                Console.WriteLine("You have not created matrix yet, Please create matrix first with option 1 ");
            }
            else
            {
                try
                {
                    Console.WriteLine("Enter Row:");
                    int i = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Column");
                    int j = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine($"Entry position at index {i} and {j} is {matrix.GetElement(i, j)} ");


                }
                catch (ChessBMatrix.InvalidIndexException)
                {
                    Console.WriteLine("invalid index");

                }
            }

        }
        public void SetElementAtPosition()
        {
            if (matrix == null)
            {
                Console.WriteLine("You have not created matrix yet, Please create matrix first with option 1 ");
            }
            else
            {
                try
                {
                    Console.WriteLine("Enter Row:");
                    int i = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Column");
                    int j = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter Number To Set ");
                    int set = Convert.ToInt32(Console.ReadLine());
                    matrix.SetElement(i, j, set);
                    Console.WriteLine("Element Has Been Seted Succefully");



                }
                catch (ChessBMatrix.InvalidIndexException)
                {
                    Console.WriteLine("invalid index");

                }
                catch (ChessBMatrix.ZeroCellException)
                {
                    Console.WriteLine("Can not set to a zero index entry, please choose a non zero entry");

                }

            }


        }
        public void AddMatrixes()
        {
            if (matrix != null)
            {
                try
                {
                    Console.WriteLine("Create another matrix to add");
                    Console.WriteLine("Enter size:");
                    int newSize = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter prefill number:");
                    int prefillNumber = Convert.ToInt32(Console.ReadLine());
                    ChessBMatrix newMatrix = new ChessBMatrix(newSize, prefillNumber);

                    Console.WriteLine("Enter size for the second matrix:");
                    int secondSize = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter prefill number for the second matrix:");
                    int secondPrefillNumber = Convert.ToInt32(Console.ReadLine());
                    ChessBMatrix secondMatrix = new ChessBMatrix(secondSize, secondPrefillNumber);

                    ChessBMatrix sum = ChessBMatrix.Sum(newMatrix, secondMatrix, prefillNumber,secondPrefillNumber );

                    Console.WriteLine("MATRIX ADDED ");
                    Console.WriteLine("RESULT");
                    Console.WriteLine(sum.ToString());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter an integer.");
                }
                catch (ChessBMatrix.DimensionMisMatchException)
                {
                    Console.WriteLine("MATRIX SIZE DOES NOT MATCH");
                }
            }
            else
            {
                Console.WriteLine("Original matrix has not been created");
            }
        }


        public void MultiplyMatrixes()
        {
            if (matrix != null)
            {
                try
                {
                    Console.WriteLine("Creating another matrix for multiplication...");
                    Console.Write("Enter size of matrix 1: ");
                    int size1ToMultiply = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter prefill number for matrix 1: ");
                    int prefillNumber1 = Convert.ToInt32(Console.ReadLine());
                    ChessBMatrix matrix1ToMultiply = new ChessBMatrix(size1ToMultiply, prefillNumber1);

                    Console.Write("Enter size of matrix 2: ");
                    int size2ToMultiply = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter prefill number for matrix 2: ");
                    int prefillNumber2 = Convert.ToInt32(Console.ReadLine());
                    ChessBMatrix matrix2ToMultiply = new ChessBMatrix(size2ToMultiply, prefillNumber2);

                    Console.WriteLine("Matrices multiplied successfully.");
                    Console.WriteLine("RESULT:");
                    Console.WriteLine(ChessBMatrix.Multiply(matrix1ToMultiply, matrix2ToMultiply,prefillNumber1, prefillNumber2).ToString());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter an integer.");
                }
                catch (ChessBMatrix.DimensionMisMatchException)
                {
                    Console.WriteLine("Matrix sizes do not match.");
                }
            }
            else
            {
                Console.WriteLine("Original matrix has not been created yet.");
            }
        }


    }


}




