namespace ASoftware.Enterprise.Aplicacion.DTO {
    public class UsersDTO {
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public string? Token { get; set; }
    }
}
