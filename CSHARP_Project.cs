

namespace ConsoleApp3
{
    public class CardHolder {
        public string cardNum;
        public int pin;
        public string firstName;
        public string lastName;
        public double balance;

        public CardHolder(string c , int p, string f, string l, double b) {
        cardNum = c;
            pin = p;
            firstName = f;
            lastName = l;
            balance = b;
        }
        

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<CardHolder> cardHolders = new List<CardHolder>();
            cardHolders.Add(new CardHolder("1111111111", 1111, "Ahmed", "Eisa", 1000000));
            cardHolders.Add(new CardHolder("2222222222", 1111, "Ahmed", "Gamal", 1000000));
            cardHolders.Add(new CardHolder("3333333333", 1111, "Body", "Tawhed", 1000000));
            cardHolders.Add(new CardHolder("4444444444", 1111, "Mohamed", "Samer", 1000000));
            Console.WriteLine("-----Welcome To Online ATM------");
            Console.WriteLine("Please insert your debit card number: ");
            string debitCardNum = " ";
            CardHolder currentUser;
            while (true)
            {
                try
                {
                    debitCardNum = Console.ReadLine();
                    currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                    if (currentUser != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Card number is not correct -- Please try again ");
                    }

                }
                catch
                {
                    Console.WriteLine("Card number is not correct -- Please try again");
                }
            }
            Console.WriteLine("Insert your pin code: ");
            int pin = 0;

            while (true)
            {
                try
                {
                    pin = int.Parse(Console.ReadLine());
                    if (currentUser.pin == pin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect -- Please try again ");
                    }

                }
                catch
                {
                    Console.WriteLine("Incorrect -- Please try again");
                }
            }
            Console.WriteLine("Welcome Mr. " + currentUser.firstName + " "+ currentUser.lastName);

            int option = 0;
            do {
                printOptions();
                option = int.Parse(Console.ReadLine());
                if (option == 1) { deposit(currentUser); }
                else if (option == 2) { withdraw(currentUser); }
                else if (option == 3) { balance(currentUser); }
                else if (option == 4) { break; }
                else { option = 0; }
            } while (option != 4);
            Console.WriteLine("Thank You have a bad day....");
        }

        public static void printOptions()
        {
            Console.WriteLine("Please choose one of the following options ....");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        public static void balance(CardHolder currentUser)
        {
            Console.WriteLine("Hi Mr. "+ currentUser.firstName +" "+ currentUser.lastName+" your balance is "+ currentUser.balance);
        }

        public static void deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much would you like to deposit? ");
            double deposit = double.Parse(Console.ReadLine());
            currentUser.balance = currentUser.balance + deposit;
            Console.WriteLine("Thank you for your deposit "+ deposit+ "your new balance is "+ currentUser.balance);
        }

        public static void withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much would you like to withdraw?");
            double withdraw = double.Parse(Console.ReadLine());
            if(currentUser.balance < withdraw)
            {
                Console.WriteLine("Insufficint balance ");
            }
            else
            {
                currentUser.balance = currentUser.balance - withdraw;
                Console.WriteLine("Thank you -- you withdraw "+ withdraw +" your new balance is "+ currentUser.balance);
            }
        }
    }
}
