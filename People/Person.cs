
namespace WestCoastEdu.BCL.People;

public abstract class Person
{
    public int Id { get; protected set; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    
    //All people will need the ability to send & receive messages
    public List<Message> Messages { get; set; } = new List<Message>();

    protected bool _authenticated = false;

    public bool Authenticate(string password)
    {
        /// TODO: Check if user matches with password in database and set _authenticated if it matches
        _authenticated = true;  
        return _authenticated;
    }
}