using PlayerCharacterLib;

// For these 2 lines below, I am creating an object from the CSV class called repo.
// "Characters.csv" will be the file where I store the data for the PlayerCharacter objects.
// "repo" will be the object to help store and retrieve that data on th .csv file.
// Also, a new list of PlayerCharacter objects called "characterList' is created.

ICharacterRepo repo = new CSVCharacterRepo("Characters.csv");

List<PlayerCharacter> characterList = new();

// The "answer" variable will stored whatever the user decides to do in this program.

string answer;

// This WriteLine statement tells the user "Welcome to the Character Creator App!"

Console.WriteLine("Welcome to the Character Creator App!");

Console.WriteLine();

// Below is the beginning of the do - while loop. This will keep on repeating until the user enters "X" or "x".

do
{
    // If the file called "Characters.csv" exists, the repo's method called ReadAll will update the list of all current characters.

    if(File.Exists("Characters.csv"))
    {
        characterList = repo.ReadAll();
    }

    // This method shows the main menu.

    MainMenu();

    // This asks the user what they want to do. That answer is stored in the "answer" variable.

    answer = ReadString("What would you like to do: ");

    // Below are a series of If - else if - else statements. An action is took depending on what the user chose.
    // If "C" or "c" is entered, then repo's Create method is performed.
    // Since the CreateCharacter method returns a PlayerCharacter object, you can use it inside of the Create method.
 
    if(answer.ToUpper() == "C")
    {
        Console.WriteLine();

        repo.Create(CreateCharacter());

        Console.WriteLine();
    }

    // If the user entered "A" or "a", then the program goes to this block. Next the program checks to see if the file "Characters.csv" exists.
    // If so, then the method ShowAllCharacters is called. If not, then the program says that no characters were found..
    
    else if(answer.ToUpper() == "A")
    {
        if(File.Exists("Characters.csv"))
        {
            Console.WriteLine();

            ShowAllCharacters(characterList);
        }
        else
        {
            Console.WriteLine("No characters were found...");

            Console.WriteLine();
        }
    }

    // If the user entered "V" or "v", then the program goes to this block. Next the program checks to see if the file "Characters.csv" exists.
    // If so, then the method ShowOneCharacter is called and "repo" is passed into it.
    // If not, then the program says that no characters were found..

    else if (answer.ToUpper() == "V")
    {
        if(File.Exists("Characters.csv"))
        {
            Console.WriteLine();

            ShowOneCharacter(repo);
        }
        else
        {
            Console.WriteLine("No characters were found...");

            Console.WriteLine();
        }
    }

    // If the user entered "U" or "u", then the program goes to this block. Next the program checks to see if the file "Characters.csv" exists.
    // If so, then the method UpdateOneCharacter is called and "repo" is passed into it.
    // If not, then the program says that no characters were found..

    else if (answer.ToUpper() == "U")
    {
        if (File.Exists("Characters.csv"))
        {
            Console.WriteLine();

            UpdateOneCharacter(repo);

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No characters were found...");

            Console.WriteLine();
        }
    }

    // If the user entered "D" or "d", then the program goes to this block. Next the program checks to see if the file "Characters.csv" exists.
    // If so, then the method DeleteOneCharacter is called and "repo" is passed into it.
    // If not, then the program says that no characters were found..

    else if (answer.ToUpper() == "D")
    {
        if (File.Exists("Characters.csv"))
        {
            Console.WriteLine();

            DeleteOneCharacter(repo);

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No characters were found...");

            Console.WriteLine();
        }
    }

    // If the user entered "B" or "b", then the program goes to this block. Next the program checks to see if the file "Characters.csv" exists.
    // If so, then the method BattleSimulator is called and "repo" is passed into it.
    // If not, then the program says that no characters were found..

    else if (answer.ToUpper() == "B")
    {
        if(File.Exists("Characters.csv"))
        {
            Console.WriteLine();

            BattleSimulation(repo);

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("No characters were found...");

            Console.WriteLine();
        }
    }

    // If the user entered "X" or "x", then the program goes to this block.
    // This is here to tell the user Goodbye, and then the program closes.

    else if(answer.ToUpper() == "X")
    {
        Console.WriteLine("Goodbye!");
    }

    // If the user entered anything other than the previously mentioned letters...
    // ...then the program will say that they entered an invalid letter.

    else
    {
        Console.WriteLine("You entered an invalid choice!");

        Console.WriteLine();
    }

} while (answer.ToUpper() != "X");


// This is the MainMenu mehtod. All it does is show the user what choices they can make.

static void MainMenu()
{
    Console.WriteLine("C = Create Character");
    
    Console.WriteLine("A = View All Created Characters");
    
    Console.WriteLine("V = View One Character");
    
    Console.WriteLine("U = Update A Character");
    
    Console.WriteLine("D = Delete A Character");

    Console.WriteLine("B = Battle Simulator");

    Console.WriteLine("X = Exit");
}

// This is the ReadString method. It takes in a string as a parameter.
// In this, the variable called "value" is created with an empty string.
// Eventually, "value" will be returned to the main.

static string ReadString(string prompt)
{
    string value = "";
    
    // This do - while loop will keep on repeating until the user enters something.
    // When the user enters something valid, it is stored in the "stringValue" variable.
    // Then, "value" will equal "stringValue" and the loop will stop. Finally, "value" is returned.

    do
    {
        Console.Write(prompt);

        string? stringValue = Console.ReadLine();

        if (stringValue != null && stringValue != "")
        {
            value = stringValue.Trim();

            break;
        }

    } while (true);

    return value;
}

// Below are a series of methods that read in certain stats for a character or entity. 
// All practically act the same, with the exception of setting certain properites with values.
// The ReadLevel method is for reading in levels and setting the object's level as the incoming value.

static void ReadLevel(PlayerCharacter character)
{
    // At the beginning, the variable "value" is declared.

    int value;

    // This do - while loop will keep on repeating until the user enters a valid level for their character.
    // A try-catch block is also here to catch any errors that might happen.

    do
    {       
        try
        {
            // The ReadString method is uesed here to return a string that hopefully will be parsed as an int.
            // If everything passes fine, then the method ends.

            value = int.Parse(ReadString("Please enter a level: "));

            character.Level = value;

            break;
        }

        // If the format is wrong (You can't pass letters as an integer), the Format Exception is thrown.

        catch(FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }

        // If the user enters in an invalid stat, this exception is thrown.

        catch(InvalidStatException ex)
        {
            Console.WriteLine(ex.Message);
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    } while (true);
}

// The ReadHP method is for reading in HP values and setting the object's HP as the incoming value.
// This takes in an object that realizes the IEntityStats interface.
// This method, ReadStrength, and ReadDefense have this same parameter.
// Both PlayerCharacter objects and Enemy objects will use these methods

static void ReadHP(IEntityStats entity)
{
    int value;

    do
    {
        try
        {
            value = int.Parse(ReadString("Please enter the amount of HP this entity has: "));

            entity.HP = value;

            break;
        }

        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }

        catch (InvalidStatException ex)
        {
            Console.WriteLine(ex.Message);
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    } while (true);
}

// The ReadStrength method is for reading in  the strength stat and setting the object's strength stat as the incoming value.

static void ReadStrength(IEntityStats entity)
{
    int value;

    do
    {
        try
        {
            value = int.Parse(ReadString("Please enter this entity's strength stat: "));

            entity.StrengthStat = value;

            break;
        }

        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }

        catch (InvalidStatException ex)
        {
            Console.WriteLine(ex.Message);
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

    } while (true);
}

// The ReadDefense method is for reading in the defense stat and setting the object's strength stat as the incoming value.

static void ReadDefense(IEntityStats entity)
{
    int value;

    do
    {
        try
        {
            value = int.Parse(ReadString("Please enter this entity's defense stat: "));

            entity.DefenseStat = value;

            break;
        }

        catch (FormatException ex)
        {
            Console.WriteLine(ex.Message);
        }

        catch (InvalidStatException ex)
        {
            Console.WriteLine(ex.Message);
        }

        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    } while (true);
}

// Below is the CreateCharacter method. It is used to create PlayerCharacters. It will return that object back to the main to be used.

static PlayerCharacter CreateCharacter()
{
    PlayerCharacter character = new();

    character.Name = ReadString("Please enter a name: ");

    ReadLevel(character);

    ReadHP(character);

    ReadStrength(character);

    ReadDefense(character);

    return character;
}

// This is the ShowAllCharacters method. It thakes a list of PlayerCharacter objects as a parameter.
// It displays all objects that are currently stored in that list.
// (If the .csv file doesn't exist, the list won't have any values stored in it...)

static void ShowAllCharacters(List<PlayerCharacter> list)
{
    foreach(var character in list)
    {
        Console.WriteLine(character);
    }
}

// Below is the ShowOneCharacter method. It takes in an object that implements the ICharacterRepo interface.
// Since the CSVCharacterRepo does realize the interface, any object from this class can be used.

static void ShowOneCharacter(ICharacterRepo repo)
{
    // At first, the program asks the user for the name and level of the character they want to see.
    // That name and level is passed into the repo's ReadOne method. Then, some value is stored in the "character" variable.

    string name = ReadString("Please enter the name of the character you would like to view: ");

    string strLevel = ReadString("Please enter that character's level: ");

    var character = repo.ReadOne(name, strLevel);

    // If "character" is not null, then the object ToString is used to display that character's information.

    if(character != null)
    {
        Console.WriteLine(character);
    }

    // If "character" is null, then the program says that the character was not found.

    else
    {
        Console.WriteLine($"{name} was not found...");
    }
}

// Below is the UpdateOneCharacter method. It takes in an object that implements the ICharacterRepo interface.

static void UpdateOneCharacter(ICharacterRepo repo)
{
    // At first, the program asks the user to enter the name and level of the character that they would like to update.
    // That name and level is passed into the repo's ReadOne method. Then, some value is stored in the "character" variable.

    string name = ReadString("Please enter the name of the character that you would like to update: ");

    string strLevel = ReadString("Please enter that character's level: ");

    var character = repo.ReadOne(name, strLevel);

    // If that character is not null, then the name and level the user entered is passed into the repo's UpdateCharacter method.
    // Also, the CreateCharacter method is called here because is return a PlayerCharacter object.
    // Finally, the program says that original character was updated.

    if (character != null)
    {
        repo.UpdateCharacter(name, strLevel, CreateCharacter());

        Console.WriteLine($"{name} was updated.");
    }

    // If "character" is null, then the programs says that the character was not found.

    else
    {
        Console.WriteLine($"{name} was not found...");
    }
}

// Below is the DeleteOneCharacter method. It takes in an object that implements the ICharacterRepo interface.

static void DeleteOneCharacter(ICharacterRepo repo)
{
    // At first, the program asks the user to enter the name and level of the character that they would like to delete.
    // That name and level is passed into the repo's ReadOne method. Then, some value is stored in the "character" variable.

    string name = ReadString("Please enter the name of the character that you would like to delete: ");

    string strLevel = ReadString("Please enter that character's level: ");

    var character = repo.ReadOne(name, strLevel);

    // If that character is not null, then the name and level the user entered is passed into the repo's DeleteCharacter method.
    // Finally, the program says that character was deleted.

    if (character != null)
    {
        repo.DeleteCharacter(name, strLevel);

        Console.WriteLine($"{name} was deleted.");
    }

    // If "character" is null, then the programs says that the character was not found.

    else
    {
        Console.WriteLine($"{name} was not found...");
    }
}

// Below is the method BattleSimulation. This method takes in an object that realizes the ICharacterRepo interface.
// This method will allow the user to use their characters to fight against enemies they create.

static void BattleSimulation(ICharacterRepo repo)
{
    // At first, the program asks the user to enter the name and level of the character that they would like to fight with.
    // That name and level is passed into the repo's ReadOne method. Then, some value is stored in the "character" variable.

    string name = ReadString("Please enter the name of the character you would like to fight as: ");

    string strLevel = ReadString("Please enter that character's level: ");

    var character = repo.ReadOne(name, strLevel);

    // If "character" is not null, then a few thing happen. The variable "choice" is initalized to an empty string.
    // Next, the program tell the user to create an enemy to fight against. An object called "enemy" from the Enemy class is created.
    // Then, that object will be given an HP stat, a Strength stat, and a Defense stat.
    // Then, the program says that the player character and enemy meet and are about to fight.

    if (character != null)
    {
        string choice = "";

        Console.WriteLine();

        Console.WriteLine("Now, create an enemy to fight against.");

        Console.WriteLine();

        Enemy enemy = new();

        ReadHP(enemy);

        ReadStrength(enemy);

        ReadDefense(enemy);

        Console.WriteLine();

        Console.WriteLine($"Your character's stats is:\n{character}");

        Console.WriteLine($"The enemy's stats is:\n{enemy}");

        Console.WriteLine();

        Console.WriteLine("The two meet and they start to fight each other!!!");

        Console.WriteLine();

        // This do - while loop will repeat until a condition is meet. If the player character's HP goes to 0, the loop stops.
        // If the enemy's HP goes to 0, the loop stops. If the user enters "Y" or "y", the loop stops.

        do
        {
            // The program will say that the player character attacks. Then, the character's AttackEnemy method is used.
            // The enemy object is passed into this method. Then the program will display the enemy's HP.

            Console.WriteLine($"{character.Name} attacks!"); 
            
            character.AttackEnemy(enemy);

            Console.WriteLine($"The enemy's HP is now: {enemy.HP}");

            // If the enemy's HP is 0, the program will say that the player character defeated the enemy.
            // Then, the program will say that it is closing the battle simulation. The loop ends after that.

            if(enemy.HP == 0)
            {
                Console.WriteLine($"{character.Name} has defeated the enemy!");

                Console.WriteLine("Closing the battle simulation...");

                break;
            }

            // The program will say that the enemy attacks. Then, the enemy's AttackPlayerCharacter method is used.
            // The character object is passed into this method. Then the program will display the character's HP.

            Console.WriteLine("The enemy attacks!");

            enemy.AttackPlayerCharacter(character);

            Console.WriteLine($"{character.Name}'s HP is now: {character.HP}");

            // If the character's HP is 0, the program will say that the enemy defeated the player character.
            // Then, the program will say that it is closing the battle simulation. The loop ends after that.

            if (character.HP == 0)
            {
                Console.WriteLine($"The enemy has defeated {character.Name}...");

                Console.WriteLine("Closing the battle simulation...");

                break;
            }

            // After both the character and enemy are still alive, this question is displayed.
            // If the user enters "Y" or "y", the loop ends. If the user enters anything else, the battle continues.

            choice = ReadString("Do you wish to escape (Y for yes | Anything else for No): ");

            Console.WriteLine();

        } while (choice.ToUpper() != "Y");

        // If "Y" or "y" was entered, the program will say that the character escaped while they still could.

        if(choice.ToUpper() == "Y")
        {
            Console.WriteLine($"{character.Name} ran away...");
        }
    }

    // If "character" is null, then the program will show that the character was not found.

    else
    {
        Console.WriteLine($"{name} was not found...");
    }
}



