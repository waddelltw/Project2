namespace PlayerCharacterLib;

// This is fr the class "CSVCharacterRepo". It realizes the interface "ICharacterRepo".

public class CSVCharacterRepo : ICharacterRepo
{
    // Below is a private field called "_filePath". This will help create the file to store PlayerCharacter objects.

    private string _filePath;

    // Below is the constructor for this class. It takes in a string as a parameter.
    // Whenever an oject from this class is made, you have to have a string to set the _filePath field.

    public CSVCharacterRepo(string filePath)
    {
        _filePath = filePath;
    }

    // This method called Create will create and/or edit a file.
    // It takes in a PlayerCharacter object as a parameter and returns a PlayerCharacter object.

    public void Create(PlayerCharacter character)
    {
        // This try/catch block will try to catch any error that might happen.

        try
        {
            // When this method is called, a StreamWriter object called "writer" is made.
            // This object will create the file using the _filePath field.
            // If the file already exists, then you will edit the file.

            StreamWriter writer = new(_filePath, append: true);

            // Then, "writer" will write onto the file with WriteLine. "writer" will write to character's values as comma separated values.

            writer.WriteLine(character.ToCSV());

            // After the writer has written this, "writer" will close the file.

            writer.Close();
        }

        // If something goes wrong, an error message is shown.

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // This is the ReadAll method. It will return a list of PlayerCharacter objects.

    public List<PlayerCharacter> ReadAll()
    {
        // First a new list of PlayerCharacter objects called "characterList" is created.

        List<PlayerCharacter> characterList = new();

        // This try/catch block will try to catch any error that might happen

        try
        {
            // Fisrt a nullable variable called "record" is declared.
            // Next, a StreamReader object called "reader" is created. The _filePath field is passed into this object.
            // "reader" will read the file from _filePath.
            // Then, "record" will store whatever "reader" reads in from the file.

            string? record;

            StreamReader reader = new(_filePath);

            record = reader.ReadLine();

            // While "record" did not store a null value("reader" didn't reach the EOF), these statements will execute.

            while (record != null)
            {
                // First, an array of strings called "fields" is created. This will store each value that was written onto the file.
                // Since each value was split by commas (,), each index will store a specifice value.
                // For example, a character's name would be "field[0]". A character's level would be "fields[1]", and etc.

                string[] fields = record.Split(',');

                // If fields is not null, then these statements are executed.

                if (fields != null)
                {
                    // Next, a new PlayerCharacter object is created with each value from the fields array.

                    PlayerCharacter character = new()
                    {
                        Name = fields[0],

                        Level = int.Parse(fields[1]),

                        HP = int.Parse(fields[2]),

                        StrengthStat = int.Parse(fields[3]),

                        DefenseStat = int.Parse(fields[4])
                    };

                    // That new PlayerCharacter object is added to the list.  Then, "record" will store whatever the "reader" reads in.

                    characterList.Add(character);
                }

                record = reader.ReadLine();
            }

            // Once the end of file is reached, the loop stops. Then, "reader" will close the file.

            reader.Close();
        }

        // If something goes wrong, an error message is displayed.

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // This returns the PlayerCharacter list back to the main.

        return characterList;
    }

    // This is the ReadOne method. It takes in two strings as its parameter and returns a possibly null PlayerCharacter object.
    // Like the method name suggets, It will read only one PlayerCharacter object from the .csv file.

    public PlayerCharacter? ReadOne(string name, string level)
    {
        // First, a PlayerCharacter object called "character" is set to null.

        PlayerCharacter? character = null;

        // Like all try/catch blocks, this will catch any errors that might happen.

        try
        {
            // Next, a nullable string variable called "record" is declared. Then, a Streamreader object called "reader" is created.
            // "reader" will read the contents of the _filePath. 
            // Then, "record" will store whatever "reader" reads in.

            string? record;

            StreamReader reader = new(_filePath);

            record = reader.ReadLine();

            // While "record" did not store a null value("reader" didn't reach the EOF), these statements will execute.

            while (record != null)
            {
                // First, an array of strings called "fields" is created. This will store each value that was written onto the file.
                // Since each value was split by commas (,), each index will store a specifice value.
                // For example, a character's name would be "field[0]". A character's level would be "fields[1]", and etc.

                string[] fields = record.Split(',');

                // If fields[0] (the read-in name) equals the name and fields[1] equals the level of the...
                // character the user wanted to see, then these statements are executed.

                if (fields[0] == name && fields[1] == level)
                {
                    // "character" becomes a new object with the properties being set as elements in the fields array.

                    character = new()
                    {
                        Name = fields[0],

                        Level = int.Parse(fields[1]),

                        HP = int.Parse(fields[2]),

                        StrengthStat = int.Parse(fields[3]),

                        DefenseStat = int.Parse(fields[4])
                    };

                    // Next, since the character was found, the program breaks out of the loop.

                    break;
                }

                // If the character was not found yet, "record" takes in a new value provided by "reader".

                record = reader.ReadLine();
            }

            // After either the character wasn't found or was found, "reader" closes the file.

            reader.Close();
        }

        // This will show an error message if something wrong happened.

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // The new character object is returned to the main.

        return character;
    }

    // This is the method UpdateCharacter. It takes two strings and a PlayerCharacter object as parameters.
    // This method will update an existing character,
    public void UpdateCharacter(string oldName, string oldLevel, PlayerCharacter character)
    {
        // Like with the earlier methods, the try/catch block will catch any error that might happen.

        try
        {
            // Since we need to update a character, we need to create a completely new file to make that updated character on.
            // First, make a temporary file name with the "_filePath" field and ".temp"
            // Next, the StreamWriter object called "writer" will write to this new file.

            string tempFilename = _filePath + ".temp";

            StreamWriter writer = new(tempFilename);

            // Like with the ReadOne and ReadAll methods, declare a nullable string variable called "record".
            // Next, the StreamReader object called "reader" will read from the original file.
            // Then, "record" will store in some value from "reader".

            string? record;

            StreamReader reader = new(_filePath);

            record = reader.ReadLine();

            // While "record" did not store a null value("reader" didn't reach the EOF), these statements will execute.

            while (record != null)
            {
                // An array of strings called "fields" is created.
                // For this "fields[0]" and "fields[1]" will be important, because they will have the name and level.

                string[] fields = record.Split(',');

                // If the name read from the file does not equal the name or level the user wanted to change, then write that record to the new file.

                if (fields[0] != oldName || fields[1] != oldLevel)
                {
                    writer.WriteLine(record);
                }

                // If the name read from the file equals the name and level the user wanted to change, then write the new character to the new file.

                else
                {
                    writer.WriteLine(character.ToCSV());
                }

                // Then, "record" is stored a value provided by "reader".

                record = reader.ReadLine();
            }

            // After both the new file has been writen to and the original file is read from, close both of them.

            reader.Close();

            writer.Close();

            // Now, to complete the update, you need to delete the original file and replace it with the new file.

            File.Delete(_filePath);

            File.Move(tempFilename, _filePath);
        }

        // This catches any error that might happen.

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // This is the DeleteCharacter method. It acts very similarly to UpdateCharacter, except this is deleting a character.

    public void DeleteCharacter(string name, string level)
    {
        // The try/catch acts the same like the previous ones.

        try
        {

            // You do the same steps as in UpdateCharacter.

            string tempFilename = _filePath + ".temp";

            StreamWriter writer = new(tempFilename);

            string? record;

            StreamReader reader = new(_filePath);

            record = reader.ReadLine();

            while (record != null)
            {
                string[] fields = record.Split(',');

                // Here is where things diverge from UpdateCharacter. 
                // If the read in name and level does not equal the name or level the user entered in, then write it to the new file.
                // The character's name and level that the user entered, will not show up on the new file.
                // (The object with these 2 things will not show up on the new file.)

                if (fields[0] != name || fields[1] != level)
                {
                    writer.WriteLine(record);
                }

                record = reader.ReadLine();
            }

            // After everything is done, both files are closed. Then the old file is delete, and the new file replaces the old one.

            reader.Close();

            writer.Close();

            File.Delete(_filePath);

            File.Move(tempFilename, _filePath);
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
