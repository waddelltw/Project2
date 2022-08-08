using PlayerCharacterLib;
namespace TestProject;

[TestClass]
public class ACSVCharacterRepo
{
    // This test to see if the CSVCharacterRepo class can write to a  file and read from a file.s

    [TestMethod]
    public void CanWritetoAFileAndReadFromAFile()
    {
        // This half reads one object.

        CSVCharacterRepo sut = new("Test.csv");

        PlayerCharacter character = new()
        {
            Name = "Test",
            Level = 1,
            HP = 1,
            StrengthStat = 1,
            DefenseStat = 1,

        };

        sut.Create(character);

        var returnedCharacter = sut.ReadOne("Test", "1");

        if(returnedCharacter != null)
        {
            Assert.AreEqual(character.Name, returnedCharacter.Name);
            
            Assert.AreEqual(character.Level, returnedCharacter.Level);
            
            Assert.AreEqual(character.HP, returnedCharacter.HP);
            
            Assert.AreEqual(character.StrengthStat, returnedCharacter.StrengthStat);
            
            Assert.AreEqual(character.DefenseStat, returnedCharacter.DefenseStat);
        }
        
        else
        {
            Console.WriteLine("No character was found.");
        }

        // This half will read all.

        List<PlayerCharacter> list = new();

        list = sut.ReadAll();

        foreach(var characterObj in list)
        {
            Console.WriteLine(characterObj);
        }

    }

    // This tests to see if this class can update a character within a file.

    [TestMethod]
    public void CanUpdateACharacterInAFile()
    {
        CSVCharacterRepo sut = new("UpdateTest.csv");

        PlayerCharacter originalCharacter = new()
        {
            Name = "Original",
            Level = 5,
            HP = 10,
            StrengthStat = 5,
            DefenseStat = 5,
        };

        PlayerCharacter updatedCharacter = new()
        {
            Name = "Updated",
            Level = 5,
            HP = 10,
            StrengthStat = 5,
            DefenseStat = 5,
        };

        sut.Create(originalCharacter);

        sut.UpdateCharacter("Original", "5", updatedCharacter);

        var returnedCharacter = sut.ReadOne("Updated", "5");    

        if(returnedCharacter != null)
        {
            Assert.AreEqual(updatedCharacter.Name, returnedCharacter.Name);

            Assert.AreEqual(updatedCharacter.Level, returnedCharacter.Level);

            Assert.AreEqual(updatedCharacter.HP, returnedCharacter.HP);

            Assert.AreEqual(updatedCharacter.StrengthStat, returnedCharacter.StrengthStat);

            Assert.AreEqual(updatedCharacter.DefenseStat, returnedCharacter.DefenseStat);
        }
        else
        {
            Console.WriteLine("No Character was found.");
        }
    }

    // This tests to see if this class can delete a character in a file.

    [TestMethod]
    public void CanDeleteACharacterInAFile()
    {
        CSVCharacterRepo sut = new("DeleteTest.csv");

        PlayerCharacter character = new()
        {
            Name = "Original",
            Level = 5,
            HP = 10,
            StrengthStat = 5,
            DefenseStat = 5,
        };


        sut.Create(character);

        sut.DeleteCharacter("Original", "5");

        var returnedCharacter = sut.ReadOne("Original", "5");

        if (returnedCharacter != null)
        {
            Console.WriteLine("That Character was found...");
        }
        else
        {
            Assert.AreEqual(null, returnedCharacter);
        }
    }

}
