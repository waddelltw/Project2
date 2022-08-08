using System.Text;

namespace PlayerCharacterLib;

// This is for the class "PlayerCharacter". This class realizes the "IEntityStats" interface.

public class PlayerCharacter : IEntityStats
{
    // Here are 4 private fields called "_level", "_hp", "_strengthStat", and "_defenseStat".
    // Each of these will hold their respective values

    private int _level;

    private int _hp;

    private int _strengthStat;

    private int _defenseStat;

    // This is a Property called "Name". It holds the name of the character that is created.

    public string Name { get; set; } = String.Empty;

    // This is the property called "Level". It sets the "_level" field as the incoming value if it is valid.

    public int Level
    {
        // The getter returns the current value in _level.

        get
        {
            return _level;
        }

        // The setter sets the value in _level. If the incoming value is below or equal to 0, then an InvalidStatException is thrown
        // If the incoming value is greater than 99, then an InvalidStatException is thrown.
        // If the incoming value is valid, then it is stored in _level.

        set
        {
            if(value <= 0)
            {
                throw new InvalidStatException("Your level can't be 0 or below!");
            }

            if(value > 99)
            {
                throw new InvalidStatException("Your level can't be greater than 99!");
            }

            _level = value;
        }
    }

    // This is the property called "HP". It sets the "_hp" field as the incoming value if it is valid.

    public int HP
    {
        // The getter return the current value in _hp.

        get
        {
            return _hp;
        }

        // The setter sets the value in _hp. If the incoming value is below 0, then an InvalidStatException is thrown.
        // If the incoming value is greater than 9999, then an InvalidStatException is thrown.
        // If the incoming value is valid, then it is stored in _hp.

        set
        {
            if(value < 0)
            {
                throw new InvalidStatException("You can't have your health below 0!");
            }

            if(value > 9999)
            {
                throw new InvalidStatException("You can't have your health exceed 9999!");
            }

            _hp = value;
        }
    }

    // This is the property called "StrengthStat". It sets the "_strengthStat" field as the incoming value if it is valid.

    public int StrengthStat
    {
        // The getter return the current value in _strengthStat.

        get
        {
            return _strengthStat;
        }

        // The setter sets the value in _strengthStat. If the incoming value is below 0, then an InvalidStatException is thrown.
        // If the incoming value is greater than 255, then an InvalidStatException is thrown.
        // If the incoming value is valid, then it is stored in _strengthStat.

        set
        {
            if (value < 0)
            {
                throw new InvalidStatException("You can't have your strength stat below 0!");
            }

            if (value > 255)
            {
                throw new InvalidStatException("You can't have your strength stat exceed 255!");
            }

            _strengthStat = value;
        }
    }

    // This is the property called "DefenseStat". It sets the "_defenseStat" field as the incoming value if it is valid.

    public int DefenseStat
    {
        // The getter return the current value in _defenseStat.

        get
        {
            return _defenseStat;
        }

        // The setter sets the value in _defenseStat. If the incoming value is below 0, then an InvalidStatException is thrown.
        // If the incoming value is greater than 255, then an InvalidStatException is thrown.
        // If the incoming value is valid, then it is stored in _defenseStat.

        set
        {
            if (value < 0)
            {
                throw new InvalidStatException("You can't have your defense stat below 0!");
            }

            if (value > 255)
            {
                throw new InvalidStatException("You can't have your defense stat exceed 255!");
            }

            _defenseStat = value;
        }
    }

    // This is the AttackEnemy method. This method is used inside the Battle Simulator.
    // It takes in an Enemy object as a parameter.

    public void AttackEnemy(Enemy enemy)
    {
        // For damage calculation, you would first subtract the character's StrengthStat by the enemy's DefsenseStat.
        // That value would be stored in the "differenceOfStrAndDef" variable.
        // If the difference is equal to or less than 0, the differnce would always be 1.
        // This is because a character or enemy should always take some amount of damage.

        int differenceOfStrAndDef = StrengthStat - enemy.DefenseStat;

        if (differenceOfStrAndDef <= 0)
        {
            differenceOfStrAndDef = 1;
        }

        // Next, the enemy's health is subtracted by the differnce. That value is stored in the "healthAfterDamage" variable.

        int healthAfterDamage = enemy.HP - differenceOfStrAndDef;

        // If the health is less than or equal to 0, then heathAfterDamage equals 0.
        // Then, the enemy's HP is equal to healthAfterDamage.

        if (healthAfterDamage <= 0)
        {
            healthAfterDamage = 0;

            enemy.HP = healthAfterDamage;
        }
        
        // If healthAfterDamage is not 0 or below, then the enemy's HP is equal to the healthAfterDamage.

        else
        {
            enemy.HP = healthAfterDamage;
        }
    }

    // This is the ToString method. All this does is display a PlayerCharacter object's stats

    public override string ToString()
    {
        StringBuilder builder = new();

        builder.AppendLine($"Name: {Name}");

        builder.AppendLine($"Level: {Level}");

        builder.AppendLine($"HP: {HP}");

        builder.AppendLine($"Strength: {StrengthStat}");

        builder.AppendLine($"Defense: {DefenseStat}");

        return builder.ToString();
    }

    // The ToCSV method is for storing object onto a .csv file.

    public string ToCSV()
    {
        return $"{Name},{Level},{HP},{StrengthStat},{DefenseStat}";
    }
}