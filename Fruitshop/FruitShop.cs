using System;
using static System.Console;
internal static class FruitShop
{
    public enum CurrencyAmounts { one = 1, two = 2, five = 5, twenty = 20, fifty = 50, hundred = 100, fivehundred = 500, thousand = 1000 };
    public static IDictionary<string, int> FruitsForSale { get; set; } = new Dictionary<string, int>() { { "bananas", 5 },{ "apples", 7 },{ "kiwis", 10 },{ "avocados", 15 },{ "kakis", 6 },{ "melons", 50 }};
    public static IDictionary<CurrencyAmounts, int> changeTable { get; set; } = new Dictionary<CurrencyAmounts, int>();
    public static int Sum { get; set; } = 0;
    public static int Quantity {  get; set; } 
    public static void PurchaseOrder()
    {
        foreach (KeyValuePair<string, int> item in FruitsForSale)
        {
            Write("Insert how many {0} you want to buy: ", item.Key);
            Quantity = Convert.ToInt32(ReadLine());
            Sum += Quantity * item.Value;
        }
    }
    public static void TakePayment()
    {
        WriteLine($"TOTAL: {Sum} kr");
        Write("Now input the values of the bank notes and coins used in your payment. (ex 500+100+20+20+2+1) :");
        string paymentString = ReadLine();
    }

    public static void changeCalculator(int[] changeVector)
    {
        Sum = Math.Abs(Sum);
        //WriteLine($"You are owed {Sum} and your change is: ");
        int dictionaryIndex = 0; //Is there a way to obviate this variable?
        foreach (KeyValuePair<CurrencyAmounts, int> currencyPair in changeTable)
        {
            changeVector[dictionaryIndex] = Sum / currencyPair.Value; //number of units of the given size
            Sum %= currencyPair.Value; //sum takes on the value of the remainder


            if (changeVector[dictionaryIndex] == 1)
                WriteLine($"{changeVector[dictionaryIndex]}: {currencyPair.Key}");
            if (changeVector[dictionaryIndex] > 1)
                WriteLine($"{changeVector[dictionaryIndex]}: {currencyPair.Key}s");

            if (Sum == 0)
                break;
            dictionaryIndex++;
        }
    }
}
