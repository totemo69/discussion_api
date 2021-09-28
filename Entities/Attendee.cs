using System;
using System.Collections.Generic;
using System.Text;

namespace discussion_api.Entities
{
  public class Attendee : BaseEntity
  {
    public int DiscussionId { get; private set; }
    public int UserId { get; private set; }
    public User User { get; set; }
    public string Notes { get; private set; }

    public Attendee(int discussionId, int userId, string notes)
    {
      DiscussionId = discussionId;
      UserId = userId;
      Notes = notes;
    }
  }
}
