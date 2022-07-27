namespace NewWebAPI.Models
{
    public class ContactDetailItem
    {
        public long Id { get; set; }
        public long Branch { get; set; }
        public string? Company { get; set; }
        public string? MailAdress { get; set; }
        public string? Tittle { get; set; }
        public string? CompanyHp { get; set; }
        public string? MainText { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}
