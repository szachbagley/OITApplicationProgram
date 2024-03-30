internal class Program
{
    private static void Main(string[] args)
    {
        string? input = null;
        string result = "";
        Console.WriteLine("Enter a Roman Numeral:");
        do
        {
            input = Console.ReadLine();
            //Check for null input
            if (input != null && input.Length > 0)
            {
                result = ConvertNumerals(input);
            }
            else
            {
                Console.WriteLine("Please Enter a valid Roman Numeral: ");
            }
        } while (input is null || input.Length <= 0); //Repeat if input is still null

        Console.WriteLine(result);
       
    }

    //Method to convert roman numerals to arabic numerals
    public static string ConvertNumerals(string numerals)
    {
        numerals = numerals.ToUpper();

        //Variable to calculate and store total value
        int number = 0;

        //Create an array of numeric values from the string
        int[] values = new int[numerals.Length];

        //A list to stor values after subtractive notation is accounted for
        List<int> newValues = new List<int>();

        //Bool to track if input is valid
        bool valid = true;

        //Final result
        string output = "";

        //Store values in array
        for (int i = 0; i < numerals.Length; i++)
        {
            if (numerals[i] == 'I')
            {
                values[i] = 1;
            } 
            else if (numerals[i] == 'V')
            {
                values[i] = 5;
            }
            else if (numerals[i] == 'X')
            {
                values[i] = 10;
            }
            else if (numerals[i] == 'L')
            {
                values[i] = 50;
            }
            else if (numerals[i] == 'C')
            {
                values[i] = 100;
            }
            else if (numerals[i] == 'D')
            {
                values[i] = 500;
            }
            else if (numerals[i] == 'M')
            {
                values[i] = 1000;
            }
            else
            {
                valid = false;
            }
        }

        
        if (valid)
        {
            //Add values together from array
            for (int i = 0; i < values.Length; i++)
            {
                if (i + 1 < values.Length) //If we aren't at the end of the array,
                {
                    //Account for subtractive notation 
                    if (values[i] < values[i + 1]) //If value for symbol A is less than value for symbol B
                    {
                        if ((values[i] * 5 == values[i + 1]) || (values[i] * 10 == values[i + 1])) //Check if sequence of characters is valid
                        {
                            newValues.Add(values[i + 1] - values[i]); //Subract value A from value B and add value to list

                            i++; //Iterate to skip past value B after calculation has been done
                        }
                        else
                        {
                            valid = false;
                            output = $"{numerals} is not a valid Roman Numeral";
                        }

                    }
                    else //Otherwise, simply add the value of the current symbol to the running total.
                    {
                        newValues.Add(values[i]);
                    }
                }
                else //If we are at the end of the array
                {
                    newValues.Add(values[i]);
                }
            }
        } 
        else
        {
            output = $"{numerals} is not a valid Roman Numeral";
        }

        if (valid)
        {
            number = newValues[0];
            for (int i = 1; i < newValues.Count; i++) //Check if values are in descending sequential order; sum them if so
            {
                if (newValues[i] <= newValues[i - 1]) {
                    number += newValues[i];
                }
                else
                {
                    valid = false;
                }
            }
        }
       
        if (valid)
        {
            output = number.ToString();
        }
        else
        {
            output = $"{numerals} is not a valid Roman Numeral";
        }

        return output;
    }
}