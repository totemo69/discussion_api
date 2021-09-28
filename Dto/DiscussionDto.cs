using System;
using System.Collections.Generic;
using System.Text;

namespace discussion_api.Dto
{
  public class DiscussionDto
  {
    public int Id { get; set; }
    public string Subject { get; set; }
    public string DiscussionDate { get; set; }
    public string Location { get; set; }
    public string Outcome { get; set; }
    public string Notes { get; set; }
    public bool Status { get; set; }
    public int UserId { get; set; }
    public UserDto WrittenBy { get; set; }
    public List<AttendeeDto> Attendees { get; set; } = new List<AttendeeDto>();
  }
}
