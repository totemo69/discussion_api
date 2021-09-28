using System;
using System.Collections.Generic;
using System.Text;

namespace discussion_api.Dto
{
  public class AttendeeDto
  {
    public int Id { get; set; }
    public int DiscussionId { get; private set; }
    public int UserId { get; private set; }
    public UserDto UserInfo { get; set; }
    public string Notes { get; private set; }
  }
}
