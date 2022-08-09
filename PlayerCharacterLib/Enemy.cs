namespace PlayerCharacterLib;

// This is for the class "Enemy". This class realizes the "IEntityStats" interface.

public class Enemy : IEntityStats
{
    // Below are 3 fields: "_hp", "_strengthStat", and "_defenseStat". These will store their respective values.

    private int _hp;

    private int _strengthStat;

    private int _defenseStat;

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
            if (value < 0)
            {
                throw new InvalidStatException("You can't have this enemy's health below 0!");
            }

            if (value > 9999)
            {
                throw new InvalidStatException("You can't have this enemy's health exceed 9999!");
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
                throw new InvalidStatException("You can't have this enemy's strength stat below 0!");
            }

            if (value > 255)
            {
                throw new InvalidStatException("You can't have this enemy's strength stat exceed 255!");
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

    // This is the AttackPlayerCharacter method. This method is used inside the Battle Simulator.
    // It takes in a PlayerCharacter object as a parameter.

    public void AttackPlayerCharacter(PlayerCharacter character)
    {
        // For damage calculation, you would first subtract the enemy's StrengthStat by the character's DefsenseStat.
        // That value would be stored in the "differenceOfStrAndDef" variable.
        // If the difference is equal to or less than 0, the differnce would always be 1.

        int differenceOfStrAndDef = StrengthStat - character.DefenseStat;

        if (differenceOfStrAndDef <= 0)
        {
            differenceOfStrAndDef = 1;
        }

        // Next, the character's health is subtracted by the differnce. That value is stored in the "healthAfterDamage" variable.

        int healthAfterDamage = character.HP - differenceOfStrAndDef;

        // If the health is less than or equal to 0, then heathAfterDamage equals 0.
        // Then, the character's HP is equal to healthAfterDamage.

        if (healthAfterDamage <= 0)
        {
            healthAfterDamage = 0;

            character.HP = healthAfterDamage;
        }

        // If healthAfterDamage is not 0 or below, then the enemy's HP is equal to the healthAfterDamage.

        else
        {
            character.HP = healthAfterDamage;
        }
    }

    // This is the ToSrting method. This just shows the enemy's stats.

    public override string ToString()
    {
        return $"HP: {HP}\nStrength: {StrengthStat}\nDefense: {DefenseStat}";
    }
}
