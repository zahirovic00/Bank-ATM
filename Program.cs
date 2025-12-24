using System;
namespace ATM
{
	class Program
	{
		static void Main(string[] args)
		{
			/* To-do:
			   -Limit the name only to characters (@byt3 - done 12/24/2025)
			   -Limit the pincode only to 4 chiphers (@byt3 - done 12/24/2025)
			   -Limit the currency choice only to 4
			   -Generate error messages for wrong entries in personal data and automaticly restart the app (@byt3 - done 12/24/2025)
			 */
			//Set Variable values
			Console.Clear();
			int balance = 0;
			int currentBalance = 0;
			int pinCode = 0;
			string currency = "?";
			int menuChoice = 0;
			string name = "?";
			bool validateEntry = false;
			
			//Enter name
			do
			{
				Console.WriteLine("//////////Enter your Personal Data//////////\n");
				Console.Write("Please enter your name: ");
				string? nameEntry = Console.ReadLine();
				bool resultCheck = int.TryParse(nameEntry, out _); 
				if (resultCheck == false && nameEntry != "")
				{ 
					name = nameEntry.Trim();
					validateEntry = true;
					Console.Clear();
				}
				else
				{ 
					Console.WriteLine($"Your name cannot contain numbers or be empty ({nameEntry}), it can only consist of letters");
				}

			}while (validateEntry == false);

			//Enter PinCode
			do
			{
				validateEntry = false;				
		
				Console.WriteLine("//////////Enter your Personal Data//////////\n");
				Console.Write("Please enter your PIN Code: ");
				string? pinCodeEntry = Console.ReadLine();
				bool resultCheck = int.TryParse(pinCodeEntry, out pinCode);
				if ( resultCheck == true && pinCodeEntry != "" && pinCodeEntry.Length == 4)
				{
					validateEntry = true;
				}
				else
				{
					Console.WriteLine($"Your PIN Code cannot contain letters or be empty, it can only consist of four digits");
				}	
			}while(validateEntry == false);

			MainMenu.setCurrency(ref currency);
			Console.Clear();

			//Main Menu
			MainMenu.choiceMenu(ref name,ref balance,ref currentBalance,ref currency,ref pinCode);

		}
	}
	class MainMenu
	{
		public static void setCurrency(ref string currency)
		{
			Console.Clear();
			Console.WriteLine("//////////Enter your Personal Data//////////\n");
			Console.WriteLine("Please select a currency:\n\n1. US Dollar ($)\t\t\t\t\t\t2. Euro (€)\n3. Bosnia and Hercegovina Convertible Mark (BAM)\t\t4. Serbian Dinar (RSD)");
			Console.Write("\nEnter your choice: ");
			int currencyChoice = Convert.ToInt32(Console.ReadLine());

			switch (currencyChoice)
			{
				case 1:
					currency = "$";
					Console.WriteLine("\nCurrency is changed to: US Dollar \"$\"\n");
					Console.Write("Press Enter to continue");
					Console.ReadLine();
					break;
				case 2:
					currency = "€";
					Console.WriteLine("\nCurrency is changed to: Euro \"€\"\n");
					Console.Write("Press Enter to continue");
					Console.ReadLine();
					break;
				case 3:
					currency = "BAM";

					Console.WriteLine("\nCurrency is changed to: Bosnia and Hercegovina Convertible Mark \"BAM\"\n");
					Console.Write("Press Enter to continue");
					Console.ReadLine();
					break;
				case 4:
					currency = "RSD";
					Console.WriteLine("\nCurrency is changed to: Serbian Dinar \"RSD\"\n");
					Console.Write("Press Enter to continue");
					Console.ReadLine();
					break;
			}
		}

		public static void choiceMenu(ref string name, ref int balance, ref int currentBalance, ref string currency, ref int pinCode)
		{
			Console.Clear();
			Console.WriteLine($"//////////Welcome {name}//////////\n");
			Console.WriteLine("Please choose one option: \n\n1. Withdraw Balance \t\t2. Deposit Balance \n3. Check Balance\t\t4. Change PIN Code\n5. Change your currency\t\t0. Exit application");
			Console.Write("\nEnter your choice: ");
			int menuChoice = Convert.ToInt32(Console.ReadLine());

			//Change the If statement with a Switch Statement -byt3 @12/24/2025

			if (menuChoice == 0)
			{
				Console.WriteLine("\nThank you for using our Bank ATM\nWe wish you a nice day\n\nPress Enter to quit");
				Console.ReadKey();
				Environment.Exit(0);
			}
			else
			{

				switch(menuChoice) {
					case 1:
						withdrawAmount(ref name, ref balance, ref currentBalance, ref currency, ref pinCode);
						Console.Clear();
						choiceMenu(ref name, ref balance, ref currentBalance, ref currency, ref pinCode);
						break;
					case 2:
						depositAmount(ref name, ref balance, ref currentBalance, ref currency, ref pinCode);
						Console.Clear();
						choiceMenu(ref name, ref balance, ref currentBalance, ref currency, ref pinCode);
						break;
					case 3:
						checkBalance(ref name, ref balance, ref currentBalance, ref currency, ref pinCode);
						Console.Clear();
						choiceMenu(ref name, ref balance, ref currentBalance, ref currency, ref pinCode);
						break;
					case 4:
						changePin(ref name, ref balance, ref currentBalance, ref currency, ref pinCode);
						Console.Clear();
						choiceMenu(ref name, ref balance, ref currentBalance, ref currency, ref pinCode);
						break;
					case 5: 
						setCurrency(ref currency);
						Console.Clear();
						choiceMenu(ref name, ref balance, ref currentBalance, ref currency, ref pinCode);
						break;
					default:
						Console.Clear();
						Console.WriteLine("Error: You have entered the wrong choice.\nYou will be returned to the main menu!\n");
						Console.Write("Press Enter to continue");
						Console.ReadKey();
						choiceMenu(ref name, ref balance, ref currentBalance, ref currency, ref pinCode);
						break;
				};
			};

		}
		public static void depositAmount(ref string name, ref int balance, ref int currentBalance, ref string currency, ref int pinCode)
		{
			Console.Clear();
			Console.Write("\nPlease enter the amount of balance you want to deposit: ");
			int entryNewBalance = Convert.ToInt32(Console.ReadLine());
			currentBalance = (currentBalance + entryNewBalance);

			Console.WriteLine($"\nYou deposited {entryNewBalance} {currency}\nYour current balance is: {currentBalance} {currency}\n");
			printRecepit();
		}
		public static void withdrawAmount(ref string name, ref int balance, ref int currentBalance, ref string currency, ref int pinCode)
		{
			Console.Clear();
			Console.Write($"\nPlease enter the amount of balance you want to withdraw: ");
			int withdrawBalance = Convert.ToInt32(Console.ReadLine());
			currentBalance = (currentBalance - withdrawBalance);

			Console.WriteLine($"\nYou have withdrawn {withdrawBalance} {currency}\nYour current balance is: {currentBalance} {currency}");
			printRecepit();
		}
		public static void checkBalance(ref string name, ref int balance, ref int currentBalance, ref string currency, ref int pinCode)
		{
			Console.Clear();
			Console.Write($"In order to check your balance please enter your PIN Code: ");
			int checkBalance = Convert.ToInt32(Console.ReadLine());
			Console.Clear();

			if (checkBalance == pinCode)
			{
				Console.WriteLine($"Your current balance is: {currentBalance} {currency}");
				printRecepit();
			}else
			{
				Console.Clear();
				Console.WriteLine("\nError:You entered the wrong PIN code.\nYou will be retuned to the main menu!\n");
				Console.Write("\nPress Enter to continue");
				Console.ReadLine(); 
			}
		}
		public static void changePin(ref string name, ref int balance, ref int currentBalance, ref string currency, ref int pinCode)
		{
			Console.Clear();
			Console.Write("Please enter your current PIN Code: ");
			int currentPin = Convert.ToInt32(Console.ReadLine());

			if (currentPin == pinCode)
			{
				Console.Clear();
				Console.Write("Please enter your new PIN Code: ");
				int newPinCode = Convert.ToInt32(Console.ReadLine());
				Console.Clear();

				pinCode = newPinCode;

				Console.Write("Please confirm your new PIN Code: ");
				int confirmPinCode = Convert.ToInt32(Console.ReadLine());
				Console.Clear();

				if (confirmPinCode == pinCode)
				{
					Console.WriteLine("Your PIN Code is changed sucessfully!\n\nThank you for choosung our Bank.\nWe wish you a nice rest of the day!\n");
					Console.Write("Press Enter to continue");
					Console.ReadLine();
				} else
				{
					Console.Clear();
					Console.WriteLine("\nError:You entered the wrong confirmation PIN.You will be retuned to the main menu!\n");
					Console.Write("Press Enter to continue");
					Console.ReadLine();
				} 
			} else
			{
				Console.Clear();
				Console.WriteLine("\nError:You entered the wrong PIN code.\nYou will be retuned to the main menu!\n");
				Console.Write("\nPress Enter to continue");
				Console.ReadLine(); 
			}
		}
		public static void printRecepit()
		{
			Console.Write("\nWould you like to print out the balance recepit? Yes/No\nEnter your choice: ");
			string? choRecepit = Console.ReadLine();

			string? recepitCapital = choRecepit.ToUpper();

			if (recepitCapital == "YES" || recepitCapital == "Y")
			{
				Console.Clear();
				Console.WriteLine("\nThank you for choosing our Bank!\nPlease take out your recepit and keep it safe\n\nWe wish you a nice rest of the day!\n");
				Console.Write("\nPress Enter to continue");
				Console.ReadLine();
			} else if (recepitCapital == "NO" || recepitCapital == "N")
			{
				Console.Clear();
				Console.WriteLine("\nThank you for choosing our Bank.\nWe wish you a nice rest of the day!\n");
				Console.Write("\nPress Enter to continue");
				Console.ReadLine();
			} else
			{
				Console.Clear();
				Console.WriteLine("\nError:You entered the wrong choice.\nThe recepit won't be printed out, and you will be retuned to the main menu!\n");
				Console.Write("\nPress Enter to continue");
				Console.ReadLine();
			}
		}
	}
}

