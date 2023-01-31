using System;


//What do cardholders have information wise?
public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance)
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    //Getters

    public String getNum()
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;
    }

    public double getBalance()
    {
        return balance;
    }

    //Setters

    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;
    }

    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }

    public void setLastName(String newLastName)
    {
        lastName = newLastName;
    }

    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    //Main function to run the ATM

    public static void Main(String[] args)
    {
        //Once logged in this will give user options
        void printOptions()
        {
            Console.WriteLine("Please choose form one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");
        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit today? ");
            //Parse the ReadLine into a double from a string
            double deposit = Double.Parse(Console.ReadLine());
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw today: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance available :");
            }
            else
            {
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("Thank you for your withdrawal, have a great day! :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        //fake names database pins etc to check the functions
        List<cardHolder> cardHolders = new List<cardHolder>();
        cardHolders.Add(new cardHolder("4536774635243546", 1234, "John", "Jones", 150.31));
        cardHolders.Add(new cardHolder("4659586452345121", 2345, "Jim", "Pickens", 1230.45));
        cardHolders.Add(new cardHolder("1526352448575968", 3456, "Suckonia", "Hersheys", 24.32));
        cardHolders.Add(new cardHolder("5649485725361542", 4567, "Hughja", "Knickabolokov", 23456.00));
        cardHolders.Add(new cardHolder("5847695825361425", 5678, "Ian", "Patrick", 2.21));

        //Initial User Prompt
        Console.WriteLine("Welcome to Shifty Bank, your home of shifty banking...");
        Console.Write("Please insert your Shifty debit or credit card: ");
        String userCardNum = "";
        cardHolder currentUser;

        //In case of errors response
        while(true)
        {
            try
            {
                userCardNum = Console.ReadLine();
                //check against database
                //first or default checks the whole db entry for the prson
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == userCardNum);
                if (currentUser != null) { break;  }
                else { Console.WriteLine("Card not recognised, please try again..."); }
            }
            catch { Console.WriteLine("Card not recognised, please try again...");  }
        }

        //Prove this person is who they say by requesting PIN
        Console.WriteLine("Please enter your PIN: ");
        //initialise with 0
        int userPin = 0;
        while (true)
        {
            try
            {
                //Parse the pin
                userPin = int.Parse(Console.ReadLine());
                //if user pin is correct
                if (currentUser.getPin() == userPin) { break; }
                //if not
                else { Console.WriteLine("Incorrect PIN, please try again..."); }
            }
            catch { Console.WriteLine("Incorrect PIN, please try again..."); }
        }

        //once verified user options
        Console.WriteLine("Welcome " + currentUser.getFirstName() + " !");
        int option = 0;
        do
        {
            //display user options
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option == 1) { deposit(currentUser); }
            else if(option == 2) { withdraw(currentUser); }
            else if(option == 3) { balance(currentUser); }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("Thank you, have a nuce day.");
    }

}