namespace ADHUIServer.Models.Users
{
    public class UserLoginInformationModel
    {
        public string Access_Token { get; set; }
        public string UserName { get; set; }
        public HttpInfoModel Error { get; set; } = new HttpInfoModel();
    }
}
