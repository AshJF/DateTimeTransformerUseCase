using System;
using System.Globalization;

namespace InterviewProject.DataHelper
{
    public class DateTimeTransformer
    {
        /// <summary>
        ///     Calculated date and time, based on the given template value
        /// </summary>
        /// <param name="points">start and end date and time of a specific tripitem</param>
        /// <param name="templateValue">contains the definition for calculation i.e. 'first', 'last', 'first-(minutes)', 'first+(minutes)', 'last+(minutes)' or 'last-(minutes)'</param>
        /// <returns>Returns the calculated date and time</returns>
        public static DateTimeOffset? CalculateToRightDateTime(PointDate points, string templateValue)
        {
            try
            {
                if (!string.IsNullOrEmpty(templateValue))
                {
                    // Getting the dates and times
                    DateTimeOffset? startTime = points.DateTimeStart;
                    DateTimeOffset? endTime = points.DateTimeEnd;

                    // Conditional calls to the Sub-Function
                    if (templateValue.Contains("first+", StringComparison.OrdinalIgnoreCase))
                    {
                        return CalculateDateTime(startTime, true, Convert.ToDouble(templateValue.Split("+")[1].Trim()), true);
                    }
                    else if (templateValue.Contains("first-", StringComparison.OrdinalIgnoreCase))
                    {
                        return CalculateDateTime(startTime, true, Convert.ToDouble(templateValue.Split("-")[1].Trim()), false);
                    }
                    else if (templateValue.Contains("first", StringComparison.OrdinalIgnoreCase))
                    {
                        return CalculateDateTime(startTime, false, 0, false);
                    }
                    else if (templateValue.Contains("last+", StringComparison.OrdinalIgnoreCase))
                    {
                        return CalculateDateTime(endTime, true, Convert.ToDouble(templateValue.Split("+")[1].Trim()), true);
                    }
                    else if (templateValue.Contains("last-", StringComparison.OrdinalIgnoreCase))
                    {
                        return CalculateDateTime(endTime, true, Convert.ToDouble(templateValue.Split("-")[1].Trim()), false);
                    }
                    else if (templateValue.Contains("last", StringComparison.OrdinalIgnoreCase))
                    {
                        return CalculateDateTime(endTime, false, 0, false);
                    }
                    else
                    {
                        return null;
                    }
                }
                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }

            #region Trial Code

            // Setting the Culture Info
            //var ci = new CultureInfo("nl-NL");
            //DateTime dt = DateTime.ParseExact(points.DateTimeStart, "yyyy/MM/dd HH:mm:ss", ci);

            //DateTimeOffset? dateTimeStart = points.DateTimeStart;
            //DateTimeOffset? endTimeStart = points.DateTimeEnd;

            //string? startStr = dateTimeStart.Value.ToString("yyyy/MM/dd HH:mm:ss zzz", CultureInfo.InvariantCulture);
            //string? endStr = endTimeStart.Value.ToString("yyyy/MM/dd HH:mm:ss zzz", CultureInfo.InvariantCulture);

            //DateTimeOffset? startTime = DateTimeOffset.ParseExact(startStr, "yyyy/MM/dd HH:mm:ss zzz", CultureInfo.InvariantCulture);
            //DateTimeOffset? endTime = DateTimeOffset.ParseExact(endStr, "yyyy/MM/dd HH:mm:ss zzz", CultureInfo.InvariantCulture));

            //return templateValue.ToLower() switch
            //{
            //    "first+" when templateValue.Contains("first+", StringComparison.OrdinalIgnoreCase) => CalculateDateTime(startTime, true, Convert.ToDouble(templateValue.Split("+")[1].Trim()), true),
            //    "first-" when templateValue.Contains("first-", StringComparison.OrdinalIgnoreCase) => CalculateDateTime(startTime, true, Convert.ToDouble(templateValue.Split("-")[1].Trim()), false),
            //    "first" when templateValue.Contains("first", StringComparison.OrdinalIgnoreCase) => CalculateDateTime(startTime, false, 0, false),
            //    "last+" when templateValue.Contains("last+", StringComparison.OrdinalIgnoreCase) => CalculateDateTime(endTime, true, Convert.ToDouble(templateValue.Split("+")[1].Trim()), true),
            //    "last-" when templateValue.Contains("last-", StringComparison.OrdinalIgnoreCase) => CalculateDateTime(endTime, true, Convert.ToDouble(templateValue.Split("-")[1].Trim()), false),
            //    "last" when templateValue.Contains("last", StringComparison.OrdinalIgnoreCase) => CalculateDateTime(endTime, false, 0, false),
            //    _ => null
            //};

            #endregion
        }

        /// <summary>
        ///     Sub module to Calculate date and time, based on the required parameters
        /// </summary>
        /// <param name="time">start or end date and time of a specific tripitem </param>
        /// <param name="change">boolean to recognize if addition/subtraction is required </param>
        /// <param name="offset">value of minutes to be added or subtracted </param>
        /// <param name="isAddition">boolean to decide addition or subtraction of minutes </param>
        /// <returns>Returns the calculated date and time</returns>
        public static DateTimeOffset? CalculateDateTime(DateTimeOffset? time, bool change, double offset, bool isAddition)
        {
            try
            {
                DateTimeOffset? returnValue = new DateTimeOffset();

                double addOn = (isAddition) ? offset : offset * -1;

                returnValue = (change) ? time.Value.AddMinutes(addOn) : time;
                return returnValue;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
