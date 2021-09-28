using System;
using System.Collections.Generic;
using System.Text;

namespace discussion_api.Dto
{
  public class UserDto
  {
    public int Id { get; set; }
    public string Username { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
  }
}
