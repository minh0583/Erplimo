namespace Erplimo.Model.Models.Request
{
    public class ConfirmationInfoViewModel
    {
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAcceptedRule { get; set; }
        public bool IsSendEmail { get; set; }
    }
}
