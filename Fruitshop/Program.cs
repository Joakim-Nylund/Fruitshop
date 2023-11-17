using System.Runtime.InteropServices;
using static System.Console;
using static System.Convert;
// using System.Text.RegularExpressions;

/*

GroupBy för att skriva ut?? Lambda för att definiera kriterier och sen .dictionary?



A customer can choose any number of fruits to buy.
Calculate the total cost.

The customer can pay in any combination of bills and coins.
Calculate the least amount of bills and coins needed for the change
Return the number of different bills and coins required
*/
IDictionary<string, int> fruitsForSale = new Dictionary<string, int>()
{
    { "bananas", 5 },
    { "apples", 7 },
    { "kiwis", 10 },
    { "avocados", 15 },
    { "kakis", 6 },
    { "melons", 50 }
};

int sum = 0;
int quantity;
foreach (KeyValuePair<string, int> item in fruitsForSale)
{
    Write("Insert how many {0} you want to buy: ", item.Key); //Regex could allow for a string input with names and amounts ?. Is Regex even necessary?
    quantity = ToInt32(ReadLine());
    sum += quantity * item.Value;
}

IDictionary<string, int> changeTable = new Dictionary<string, int>()
{
    { "five-hundred crown bill", 500 },
    { "one-hundred crown bill", 100},
    { "fifty-crown bill", 50},
    { "twenty-crown bill", 20},
    { "ten-crown coin", 10},
    { "five-crown coin", 5},
    { "two-crown coin", 2},
    { "one-crown coin", 1}
};

WriteLine($"TOTAL: {sum} kr");
Write("Now input the values of the bank notes and coins used in your payment. (ex 500+100+20+20+2+1) :"); //regex would allow for neat code that handles *, as well ? 
string paymentString = ReadLine();

string[] billOrCoinValue = paymentString.Split('+');
int[] payment = new int[paymentString.Length];
for (int i = 0; i < billOrCoinValue.Length; i++)
{
    payment[i] = ToInt32(billOrCoinValue[i]);
}
WriteLine($"You paid: {payment.Sum()}\n");
sum -= payment.Sum();

while (sum > 0)
{
    Write($"{sum} kr remains to be paid. Insert payment here: ");
    sum -= ToInt32(ReadLine());
}

int[] changeVector = new int[changeTable.Count];
changeCalculator(changeVector, changeTable); //placing the logic inside the method made no difference to the readability nor size of the program....

void changeCalculator(int[] changeVector, IDictionary<string, int> changeTable) //more compact to print out the change in the same method
{
    sum = Math.Abs(sum);
    WriteLine($"You are owed {sum} and your change is: ");
    int dictionaryIndex = 0; //Is there a way to obviate this variable?  GetEnumerator() - Returns an IDictionaryEnumerator object for the IDictionary object.
    foreach (KeyValuePair<string, int> currencyPair in changeTable)
    {
        changeVector[dictionaryIndex] = sum / currencyPair.Value; //number of units of the given size
        sum %= currencyPair.Value; //sum takes on the value of the remainder


        if (changeVector[dictionaryIndex] == 1)
            WriteLine($"{changeVector[dictionaryIndex]}: {currencyPair.Key}");
        if (changeVector[dictionaryIndex] > 1)
            WriteLine($"{changeVector[dictionaryIndex]}: {currencyPair.Key}s");

        if (sum == 0)
            break;
        dictionaryIndex++;
    }
}

ReadKey();

// KeyByValue
//make an array to print out the numbers as strings instead?
//create an inverse dictionary where values are keys and keys are values ? 

// use a for loop instead? will necessitate using KeyByValue?
// int fiveHundredBills;
// int oneHundredBills;
// int fiftyBills;
// int twentyBills;
// int tenCoin;
// int fiveCoin;
// int twoCoin;
// int oneCoin;
// int[] billsAndCoin = new int[8];


//for printing to console - var priceMenu = Enumerable(0, maxLength);  
//later, another var printPriceMenu = priceMenu.Select(priceMenu => {priceMenu.Item1} {priceMenu.Item2}").ToList(); )
//string.Join(environment.NewLine, priceMenu)
//Write($"randomWords{variableName, -int} \t