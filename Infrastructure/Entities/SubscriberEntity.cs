namespace Infrastructure.Entities;

public class SubscriberEntity
{
    public int Id { get; set; }
    public string Email { get; set; } = null!;
    public bool IsSubscribed { get; set; }
    public bool NewsletterCheckbox1 { get; set; }
    public bool NewsletterCheckbox2 { get; set; }  
    public bool NewsletterCheckbox3 { get; set; }    
    public bool NewsletterCheckbox4 { get; set; }
    public bool NewsletterCheckbox5 { get; set; }
    public bool NewsletterCheckbox6 { get; set; }

}
