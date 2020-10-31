namespace UIDataAccess.Library.Models
{
    public class UserLoginInformationModel
    {
        public string Access_Token { get; set; }
        public string UserName { get; set; }
        public ErrorModel Error { get; set; } = new ErrorModel();

    }
}
