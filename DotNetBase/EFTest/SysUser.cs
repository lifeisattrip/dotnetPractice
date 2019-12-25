using System;

namespace csharp_practice.EFTest
{
    public class SysUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime GmtCreate { get; set; }

        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, {nameof(UserName)}: {UserName}, {nameof(Account)}: {Account}, {nameof(Password)}: {Password}, {nameof(Email)}: {Email}, {nameof(Address)}: {Address}, {nameof(GmtCreate)}: {GmtCreate}";
        }
    }
}
