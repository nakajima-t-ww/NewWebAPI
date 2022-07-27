namespace NewWebAPI.Models
{
    public class ContactItem
    {
        public long Id { get; set; }
        public string? Addresser { get; set; }
        public string? MailAdress  { get; set; }
        public string? Url { get; set; }
        public string? Tittle { get; set; }
        public string? BodyText { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public string? UpdatePeople { get; set; }
        public string? ResponsPeople { get; set; }
}
}