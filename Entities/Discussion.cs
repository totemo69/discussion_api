using System;
using System.Collections.Generic;
using System.Text;

namespace discussion_api.Entities
{
  public class Discussion : BaseEntity
  {
      public string subject { get; set; }
      public string date { get; set; }
      public string location { get; set; }
      public string outcomes { get; set; }
      public string writtenBy { get; set; }
      public string notes { get; set; }
      public bool status { get; set; }
  }
}
