namespace PlayerCharacterLib;

// This is for the interface ICharacterRepo
// If someone else wanted to make something for binary files, they could use this interface.

public interface ICharacterRepo
{
    void Create(PlayerCharacter character);

    List<PlayerCharacter> ReadAll();

    PlayerCharacter? ReadOne(string name, string level);

    void UpdateCharacter(string name, string level, PlayerCharacter character);

    void DeleteCharacter(string name, string level);
}
