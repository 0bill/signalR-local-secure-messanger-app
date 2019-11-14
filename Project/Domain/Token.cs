namespace Domain
{
    public class Token
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
        public int UserId { get; set; }
    }
}