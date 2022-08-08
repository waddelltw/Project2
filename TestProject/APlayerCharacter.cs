using PlayerCharacterLib;

namespace TestProject;

// This is to test the PlayerCharacter class.

[TestClass]
public class APlayerCharacter
{
    // This test if a character can't have an HP below 0 or above 9999.

    [TestMethod]
    public void CanNotHaveAnHPBelow0Or9999()
    {
        PlayerCharacter sut = new();

        try
        {
            sut.HP = -5;
        }

        catch (InvalidStatException ex)
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

    // This test if a character can't have an Level below 0 or above 99.

    [TestMethod]
    public void CanNotHaveALevelBelow0OrAbove99()
    {
        PlayerCharacter sut = new();

        try
        {
            sut.Level = -5;
        }

        catch (InvalidStatException ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            sut.Level = 100;
        }

        catch (InvalidStatException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    // This test if a character can't6 have an StrengthStat or DefenseStat below 0 or above 255.

    [TestMethod]
    public void CanNotHaveAStrengthOrDefenseStatBelow0OrAbove255()
    {
        PlayerCharacter sut = new();

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

    // This tests if a character can attack an enemy.

    [TestMethod]
    public void CanAttackAnEnemy()
    {
        PlayerCharacter sut = new()
        {
            StrengthStat = 5
        };

        Enemy enemy = new()
        {
            HP = 10
        };

        sut.AttackEnemy(enemy);

        Assert.AreEqual(5, enemy.HP);
    }
}
