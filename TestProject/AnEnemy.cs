using PlayerCharacterLib;

namespace TestProject;

// This is to test the Enemy class.

[TestClass]
public class AnEnemy
{
    // This tests if an enemy can't have an HP below 0 or above 9999

    [TestMethod]
    public void CanNotHaveAnHPBelow0Or9999()
    {
        Enemy sut = new();

        try
        {
            sut.HP = -5;
        }

        catch(InvalidStatException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            sut.HP = 10000;
        }

        catch (InvalidStatException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // This tests if an enemy can't have a StrengthStat or DefenseStat below 0 or above 9999

    [TestMethod]
    public void CanNotHaveAStrengthOrDefenseStatBelow0OrAbove255()
    {
        Enemy sut = new();

        try
        {
            sut.StrengthStat = -5;
        }

        catch (InvalidStatException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            sut.StrengthStat = 256;
        }

        catch (InvalidStatException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            sut.DefenseStat = -5;
        }

        catch (InvalidStatException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            sut.DefenseStat = 256;
        }

        catch (InvalidStatException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    [TestMethod]
    public void CanAttackAPlayerCharacter()
    {
        Enemy sut = new()
        {
            StrengthStat = 5
        };

        PlayerCharacter character = new()
        {
            HP = 10
        };

        sut.AttackPlayerCharacter(character);

        Assert.AreEqual(5, character.HP);
    }
}