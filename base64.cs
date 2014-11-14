//Encode and decode Bsae64.
using System;
using System.Text;

public class Base64
{
	//Method for printing the menu.
	public static int mainMenu()
	{
		Console.WriteLine("Enter what you'd like to do.");
		Console.WriteLine("1.) Encode to Base64.");
		Console.WriteLine("2.) Decode from Base64.");
		Console.WriteLine("3.) Quit.");
		Console.Write("> ");
		string userValue = Console.ReadLine();
		
		//Make sure the user entered a number and parse it.
		int userNum = 0;
		bool successfulParse = Int32.TryParse(userValue, out userNum);
		
		if(!successfulParse)
		{
			Console.WriteLine("{0} isn't an option!\n", userValue);
		}
		
		return userNum;
	}
	
	//Method for encoding to base64.
	public static void encodeToBase64(string userText)
	{
		//Convert it.
		byte[] toEncode = Encoding.UTF8.GetBytes(userText);
		string nowEncoded = Convert.ToBase64String(toEncode);
		Console.WriteLine("\n==================================");
		Console.WriteLine("Encoded text is: {0}", nowEncoded);
		Console.WriteLine("==================================\n");
	}
	
	//Method to decode from base64.
	public static void decodeFromBase64(string userText)
	{
		//Convert it.
		byte[] toDecode = Convert.FromBase64String(userText);
		string nowDecoded = Encoding.UTF8.GetString(toDecode);
		Console.WriteLine("\n==================================");
		Console.WriteLine("Decoded text is: {0}", nowDecoded);
		Console.WriteLine("==================================\n");
	}
	
	//Print help documentation.
	public static void printHelp()
	{
		Console.WriteLine("\nBase64.exe Help Documentation");
		Console.WriteLine("=============================");
		Console.WriteLine("\nThis application can be used interactively or via the command line.");
		Console.WriteLine("When using interactive mode, you'll be prompted for the appropriate information.");
		Console.WriteLine("\nCommand line mode supports 3 switches:\n");
		Console.WriteLine("\t-e [stringToEncode]\tWill encode the supplied string.\n");
		Console.WriteLine("\t-d [stringToDecode]\tWill decode the supplied string.\n");
		Console.WriteLine("\t-h                 \tWill display this help documentation.");
	}
	
	public static int Main(string[] args)
	{
		//Parse out possible command line switches.
		if(args.Length > 0)
		{
			string userText = "";
			//User wants to encode.
			if(args[0].Equals("-e") || args[0].Equals("-E"))
			{
				//Make sure there is a second parameter passed!
				if(args.Length > 1)
				{
					//Parse together anything else to account for spaces if the user does not use double quotes.
					for(int i = 1; i < args.Length; i++)
					{
						if(i == 1)
						{
							userText += args[i];
						}
						else if(i < (args.Length))
						{
							userText += " ";
							userText += args[i];
						}
						else
						{
							userText += args[i];
						}
					}
					
					//Pass this to the correct function.
					encodeToBase64(userText);
				}
				else
				{
					//Let the user know they didn't supply anything.
					Console.WriteLine("No supplied value to encode!");
				}
			}
			//User wants to decode.
			else if(args[0].Equals("-d") || args[0].Equals("-D"))
			{
				//Make sure there is a second parameter passed
				if(args.Length > 1)
				{
					//No spaces possible, so only take the next entry...
					decodeFromBase64(args[1]);
				}
				else
				{
					//Let the user know they didn't supply anything to decode.
					Console.WriteLine("No supplied value to decode!");
				}
			}
			//User wants help.
			else if(args[0].Equals("-h") || args[0].Equals("-H"))
			{
				printHelp();
			}
		}
		//There were no switches, so we'll go interactive.
		else
		{
			int choice;
			
			do
			{
				choice = mainMenu();
				
				//Figure out what to do.
				if(choice == 1)
				{
					//Get input from the user.
					Console.WriteLine("\nEnter your text to encode.");
					Console.Write("> ");
					string userText = Console.ReadLine();
					encodeToBase64(userText);
				}
				else if(choice == 2)
				{
					//Get input from the user.
					Console.WriteLine("\nEnter your text to decode.");
					Console.Write("> ");
					string userText = Console.ReadLine();
					decodeFromBase64(userText);
				}
				//Quit
				else if(choice == 3)
				{
					Console.WriteLine("Exiting...");
				}
			}
			//Keep going until the choice is 3 since that means the user wants to exit.
			while(choice != 3);
		}
		
		return 0;
	}
}