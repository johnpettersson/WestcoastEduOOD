
using WestCoastEdu.BCL.Communications;

namespace WestCoastEdu.BCL.People;

public abstract class Person // abstract pga ingen Person ska instantieras
{
    public int Id { get; protected set; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    

    public List<Message> Messages { get; set; } = new List<Message>();

    protected bool _authenticated = false;

    public virtual bool Find(int id)
    {
        //find the person with the passed in id
        //fill properties
        return true;
    }

    public virtual bool Save()
    {
        if(!Validate())
            return false;
        
        //save properties

        return true;
    }

    protected virtual bool Validate()
    {
        //validate properties and return true if all are valid
        return true;
    }

    public bool Authenticate(string password)
    {
        /// TODO: Check if user matches with password in database and set _authenticated if it matches
        _authenticated = true;  
        return _authenticated;
    }
    protected void CheckAuthentication()
    {
        if(!_authenticated)
            throw new Exception("User is not authenticated for this action.");
    }
}