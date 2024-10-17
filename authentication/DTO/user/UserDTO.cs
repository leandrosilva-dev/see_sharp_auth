namespace authentication.DTO.user{
    public class RequestCreateUserDTO{
        public string Name {set; get;}
        public string Email {set; get;}
        public string Password {set; get;}
    }

    public class ResponseCreateUserDTO{
        public int Id { set; get;}
        public string Name {set; get;}
        public string Email {set; get;}
    }
}