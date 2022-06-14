using System;

namespace InterviewProject.DataHelper
{
    /// <summary>
    ///     Contains the start and end date and time of a trip item
    /// </summary>
    public class PointDate
    {
        public DateTimeOffset? DateTimeStart { get; set; }
        public DateTimeOffset? DateTimeEnd { get; set; }
    }
}
