using System;
using System.Collections.Generic;
using System.Text;

namespace discussion_api.Entities
{
  public class Discussion : BaseEntity
  {
    public string Subject { get; private set; }
    public string DiscussionDate { get; private set; }
    public string Location { get; private set; }
    public string Outcome { get; private set; }
    public string Notes { get; private set; }
    public bool Status { get; private set; }
    public int UserId { get; private set; }
    public User User { get; private set; }
    public ICollection<Attendee> Attendees { get; set; }

    public Discussion(
      string subject,
      string discussionDate,
      string location,
      string outcome,
      string notes,
      bool status,
      int userId
      )
    {
      Subject = subject;
      DiscussionDate = discussionDate;
      Location = location;
      Outcome = outcome;
      Notes = notes;
      Status = status;
      UserId = userId;
    }
  }

}
