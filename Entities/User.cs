using System;
using System.Collections.Generic;
using System.Text;

namespace discussion_api.Entities
{
  public class User : BaseEntity
  {
    public string Username { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public bool Status { get; set; }
    public User(string username, string name, string email, bool status)
    {
      Username = username;
      Name = name;
      Email = email;
      Status = status;
    }
  }
}
