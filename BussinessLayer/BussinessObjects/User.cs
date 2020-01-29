namespace BussinessLayer.BussinessObjects
{
    using Enums;

    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public UserRole UserRole { get; set; }
    }
}
