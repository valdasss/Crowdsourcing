namespace CrowdSourcing.Application.Web.ViewModels
{
    public class ChangePasswordVM
    {
        public string PersonId { get; set; }
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
    }
}