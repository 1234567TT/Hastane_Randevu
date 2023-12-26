namespace B201210597.Models.DTO
{
    public class Users
    {
        public int UsersId { get; set; }
        public string UsersName { get; set; }
        public string Password { get; set; }
        // Other user information
        public List<Appointment> Appointments { get; set; }

    }
}
