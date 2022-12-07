
namespace WestCoastEdu.BCL.People; 

public class Message 
{
    public int Id { get; set; }
    public string Content { get; set; }
    public Person Sender { get; set; }
    public Person Recipient { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}