
namespace WestCoastEdu.BCL.People;

public abstract class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    
    protected bool _authenticated = false;

    public bool Authenticate(string password)
    {
        /// TODO: Check if user matches with password in database and set _authenticated if it matches
        return _authenticated;
    }
}