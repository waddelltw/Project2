using PlayerCharacterLib;

namespace TestProject;

// This is to test the Enemy class.

[TestClass]
public class AnEnemy
{
    // This tests if an enemy can't have an HP below 0 or above 9999

    [TestMethod]
    [ExpectedException(typeof(InvalidStatException))]
    public void CanNotHaveAnHPBelow0()
    {
        Enemy sut = new();

        sut.HP = -5;
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidStatException))]
    public void CanNotHaveAnHPAbove9999()
    {
        Enemy sut = new();

        sut.HP = 10000;
    }

    [TestMethod]
    public void CanHaveAnHPAboveOrEqualTo0AndBelowOrEqualTo9999()
    {
        Enemy sut = new();

        sut.HP = 5000;

        Assert.AreEqual(5000, sut.HP);
    }

    // This tests if an enemy can't have a StrengthStat or DefenseStat below 0 or above 255

    [TestMethod]
    [ExpectedException(typeof(InvalidStatException))]
    public void CanNotHaveAStrengthStatBelow0()
    {
        Enemy sut = new();

        sut.StrengthStat = -5;
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidStatException))]
    public void CanNotHaveAStrengthStatAbove255()
    {
        Enemy sut = new();

        sut.StrengthStat = 256;
    }

    [TestMethod]
    public void CanHaveAStrengthStatAboveOrEqualTo0AndBelowOrEqualTo255()
    {
        Enemy sut = new();

        sut.StrengthStat = 100;

        Assert.AreEqual(100, sut.StrengthStat);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidStatException))]
    public void CanNotHaveADefenseStatBelow0()
    {
        Enemy sut = new();

        sut.DefenseStat = -5;
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidStatException))]
    public void CanNotHaveADefenseStatAbove255()
    {
        Enemy sut = new();

        sut.DefenseStat = 256;
    }

    [TestMethod]
    public void CanHaveADefenseStatAboveOrEqualTo0AndBelowOrEqualTo255()
    {
        Enemy sut = new();

        sut.DefenseStat = 100;

        Assert.AreEqual(100, sut.DefenseStat);
    }

    // This tests to see if an Enemy object can attack a PlayerCharacter object.

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