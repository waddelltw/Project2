namespace PlayerCharacterLib;

// This is for the custom exception "InvalidStatException". This is thrown if the user entered an invalid stat.

public class InvalidStatException : Exception
{
    public InvalidStatException() : base("Invalid Stat!")
    {
     
    }

    public InvalidStatException(string message) : base(message)
    {

    }

    public InvalidStatException(string message, Exception inner) : base(message, inner)
    {

    }
}
