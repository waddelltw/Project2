using PlayerCharacterLib;

namespace TestProject;

// This is to test the PlayerCharacter class.

[TestClass]
public class APlayerCharacter
{
    // This test if a character can't have an HP below 0 or above 9999.

    [TestMethod]
    [ExpectedException(typeof(InvalidStatException))]
    public void CanNotHaveAnHPBelow0()
    {
        PlayerCharacter sut = new();

        sut.HP = -5;
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidStatException))]
    public void CanNotHaveAnHPAbove9999()
    {
        PlayerCharacter sut = new();

        sut.HP = 10000;
    }

    [TestMethod]
    public void CanHaveAnHPAboveOrEqualTo0AndBelowOrEqualTo9999()
    {
        PlayerCharacter sut = new();

        sut.HP = 5000;

        Assert.AreEqual(5000, sut.HP);
    }

    // This test if a character can't have an Level below 0 or above 99.

    [TestMethod]
    [ExpectedException(typeof(InvalidStatException))]
    public void CanNotHaveALevelBelow0()
    {
        PlayerCharacter sut = new();

        sut.Level = -5;
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidStatException))]
    public void CanNotHaveALevelAbove99()
    {
        PlayerCharacter sut = new();

        sut.Level = 100;
    }

    [TestMethod]
    public void CanHaveALevelAbove0AndBelowOrEqualTo99()
    {
        PlayerCharacter sut = new();

        sut.Level = 50;

        Assert.AreEqual(50, sut.Level);
    }

    // This test if a character can't6 have an StrengthStat or DefenseStat below 0 or above 255.

    [TestMethod]
    [ExpectedException(typeof(InvalidStatException))]
    public void CanNotHaveAStrengthStatBelow0()
    {
        PlayerCharacter sut = new();

        sut.StrengthStat = -5;
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidStatException))]
    public void CanNotHaveAStrengthStatAbove255()
    {
        PlayerCharacter sut = new();

        sut.StrengthStat = 256;
    }

    [TestMethod]
    public void CanHaveAStrengthStatAboveOrEqualTo0AndBelowOrEqualTo255()
    {
        PlayerCharacter sut = new();

        sut.StrengthStat = 100;

        Assert.AreEqual(100, sut.StrengthStat);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidStatException))]
    public void CanNotHaveADefenseStatBelow0()
    {
        PlayerCharacter sut = new();

        sut.DefenseStat = -5;
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidStatException))]
    public void CanNotHaveADefenseStatAbove255()
    {
        PlayerCharacter sut = new();

        sut.DefenseStat = 256;
    }

    [TestMethod]
    public void CanHaveADefenseStatAboveOrEqualTo0AndBelowOrEqualTo255()
    {
        PlayerCharacter sut = new();

        sut.DefenseStat = 100;

        Assert.AreEqual(100, sut.DefenseStat);
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
