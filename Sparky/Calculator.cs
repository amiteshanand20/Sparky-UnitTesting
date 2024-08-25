namespace Sparky
{
    public class Calculator
    {
        public int AddNumbers(int a,int b)
        {
             return a + b; 
        } 
        public double AddNumbersDouble(double a,double b)
        {
             return a + b; 
        }

        public bool IsOddNumber(int number)
        {
        return number % 2 != 0;
        }
    }
}
