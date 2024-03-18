using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardMatrix
{
    public class ChessBMatrix
    {
        public class InvalidSizeException : Exception { };
        public class InvalidVectorException : Exception { };
        public class DimensionMisMatchException : Exception { };
        public class InvalidIndexException : Exception { };
        public class ZeroCellException : Exception { };





        private List<int> vectors;
        private int MatrixSize;

        public ChessBMatrix() // Normal Constructor with some random data
        {
           this.vectors = new List<int>() {1, 1,1,1,1};
           this.MatrixSize = 3;
        }

        public ChessBMatrix(int size ,int prefilnumber) //// Constructor that creates a one ChessBMatrix(vector) from the length(size). (ALL ELEMENTS OF THE VECTORS ARE ONE) AND SIZE SHOULD BE GREATER THAN 0 AND ALSO CHECK IF THE SIZE IS EVEN OR ODD IN ORDER TO GET THE LENGTH 
        {
            int Length;
            if (size < 1)
            { 
                throw new InvalidSizeException(); 
            }
            else
            {
                this.MatrixSize = size;
                this.vectors = new List<int>();
                if (MatrixSize % 2 == 0)
                {
                    Length = size * size / 2;

                }
                else
                {
                    Length = (size * size / 2) + 1;
                }
                for (int i = 1; i <= Length; i++) ///starting from 1 incace i want to add i to the loop not 1
                {
                    this.vectors.Add(prefilnumber);

                }
            }



        }
        public ChessBMatrix(List<int> List)/// another constructor that Matrixsize from counting sizebased on vector
        {
            this.MatrixSize = CalVecSize(List);
            this.vectors = List;

        }
       
        public ChessBMatrix(ChessBMatrix Matrix)
        {
            if (Matrix == null)
            {
                throw new ArgumentNullException(nameof(Matrix), "Input matrix cannot be null.");
            }

            // Copy the vectors from the other matrix
            this.vectors = new List<int>(Matrix.vectors);
            this.MatrixSize = Matrix.MatrixSize;
        }
        
     

        public bool IsVecGood(List<int> list) /// helper funtion to help check if the vector is good (complete) 
        {
            int Numberofvector = list.Count;

            if (Numberofvector % 2 == 0)
            {
                return Math.Sqrt(Numberofvector * 2) == Math.Floor(Math.Sqrt(Numberofvector * 2));
            }
            else
            {
                return Math.Sqrt(Numberofvector * 2 - 1) == Math.Floor(Math.Sqrt(Numberofvector * 2 - 1));
            }



        }

        public int CalVecSize(List<int> list) // helper funtion to help calculate vector size from vector
        {
            int Numberofvector = list.Count;

            if (IsVecGood(list))
            {

                if (Numberofvector % 2 == 0)
                {
                    return Convert.ToInt32(Math.Sqrt(Numberofvector * 2));
                }
                else
                {
                    return Convert.ToInt32(Math.Sqrt(Numberofvector * 2 - 1));
                }
            }
            else
            {
                throw new InvalidVectorException();

            }


        }

        public int index(int i, int j) // method to help calculate index of a 2d matrix stored in a 1d matrix (helps to skip the zero element)
        {
            
            j++;
            
            return (i)* MatrixSize - Convert.ToInt32((i) * MatrixSize  / 2) + j - Convert.ToInt32(j / 2) - 1;


        }
      

        public int GetSize() /// method to get size since the size is private
        {
            return this.MatrixSize;
        }
        public int GetNumOfVector() // method to get the number of vector
        {
            return this.vectors.Count;
        }
        public int GetElement(int i, int j)
        {
            if (i >= 0 && i < MatrixSize && j >= 0 && j < MatrixSize)
            {
                if ((i + j) % 2 == 0)
                {
                    //Console.WriteLine("here");
                    int ind = index(i, j);
                    //Console.WriteLine(ind);
                    //Console.WriteLine(this.vectors.Count());
                    
                    return this.vectors[ind];
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                throw new InvalidIndexException();

            }
        }
        public int SetElement(int i, int j, int answer) //SETING ELEMENT TO THE CALCULATED INDEX
        {
            if (i >= 0 && i < MatrixSize && j >= 0 && j < MatrixSize)
            {
                if ((i + j) % 2 == 0)
                {
                    return this.vectors[index(i, j)] = answer;
                }
                else
                {
                    throw new ZeroCellException();
                }
            }
            else
            {
                throw new InvalidIndexException();
            }

        }

        public static ChessBMatrix Sum(ChessBMatrix a, ChessBMatrix b, int prefillNumber=1, int prefillenumber2 = 1) // adding two matrix together or bassically adding one matrix to the other
        {
            if (a.MatrixSize == b.MatrixSize)
            {
                ChessBMatrix summation = new ChessBMatrix(a.GetSize(), prefillNumber);
                for (int i = 0; i <a.vectors.Count; i++)
                {
                    summation.vectors[i] += b.vectors[i];
                }
                return summation;
            }
            else
            {
                throw new DimensionMisMatchException();
            }
        }
       

        public static ChessBMatrix Multiply(ChessBMatrix x, ChessBMatrix y, int prefillNumber =1, int prefillenumber2 =1) // multiply two matix
        {
            if (x.GetSize() == y.GetSize())
            {

                int size = x.GetSize();
                ChessBMatrix multiplication = new ChessBMatrix(size,  prefillNumber);
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if ((i + j) % 2 == 0)
                        {
                            int sum = 0;
                            for (int k = 0; k < size; k++)
                            {
                                sum += x.GetElement(i, k) * y.GetElement(k, j);
                            }

                            multiplication.SetElement(i, j, sum);


                        }
                    }
                }
                return multiplication;

            }
            else { throw new DimensionMisMatchException(); }

        }
        public override string ToString()
        {
            string str = "The matrix of size ";
            str += this.MatrixSize.ToString() + "x" + this.MatrixSize.ToString() + ":\n";
            for (int i = 0; i < MatrixSize; i++)
            {
                for (int j = 0; j  < MatrixSize; j++)
                {
                    str += GetElement(i, j).ToString() + " ";
                }
                str += "\n";
            }
            return str;

        }
       
        








    }
}

