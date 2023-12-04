namespace UserDB;

public class User : BaseId
{
    public string Name { get; set;}
    public int Age { get; set;}
    public string Email { get; set;}
    public string Password { get; set;}

    constructor(string Name, int Age, string Email, string Password){
        this.Name = Name;
        this.Age = Age;
        this.Email = Email;
        this.Password = Password;
    }

    public static list<UserDB> Users = new list <UserDB>
    {
        new User{
            id = 1,
            Name = "teste 1",
            Age = 19,
            Email = "teste@teste.com",
            Password = "123qwe"
        },

        new User1{
            id = 2,
            Name = "teste 2",
            Age = 16,
            Email = "teste@testandodando.com",
            Password = "qwe123"
        }
    };
}