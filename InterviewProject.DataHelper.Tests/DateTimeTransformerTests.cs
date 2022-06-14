using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace InterviewProject.DataHelper.Tests
{
    [TestClass]
    public class DateTimeTransformerTests
    {
        [TestMethod]
        public void Does_ReturnNull_When_TemplateValueIsNull()
        {
            //Arrange
            var startDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 12, 00, 00), TimeSpan.FromHours(2));
            var endDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 18, 00, 00), TimeSpan.FromHours(-7));

            var points = new PointDate()
            {
                DateTimeStart = startDateTime,
                DateTimeEnd = endDateTime
            };

            string templateValue = null;

            //Act
            var result = DateTimeTransformer.CalculateToRightDateTime(points, templateValue);

            //Assert
            Assert.IsFalse(result.HasValue);
        }

        [TestMethod]
        public void Does_ReturnNull_When_TemplateValueIsEmptyString()
        {
            //Arrange
            var startDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 12, 00, 00), TimeSpan.FromHours(2));
            var endDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 18, 00, 00), TimeSpan.FromHours(-7));

            var points = new PointDate()
            {
                DateTimeStart = startDateTime,
                DateTimeEnd = endDateTime
            };

            var templateValue = string.Empty;

            //Act
            var result = DateTimeTransformer.CalculateToRightDateTime(points, templateValue);

            //Assert
            Assert.IsFalse(result.HasValue);
        }

        [TestMethod]
        public void Does_ReturnDateTimeStart_When_TemplateValue_first()
        {
            //Arrange
            var startDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 12, 00, 00), TimeSpan.FromHours(2));
            var endDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 18, 00, 00), TimeSpan.FromHours(-7));

            var points = new PointDate()
            {
                DateTimeStart = startDateTime,
                DateTimeEnd = endDateTime
            };

            var templateValue = "first";

            //Act
            var result = DateTimeTransformer.CalculateToRightDateTime(points, templateValue);

            //Assert
            Assert.AreEqual(startDateTime, result.Value);
        }

        [TestMethod]
        public void Does_ReturnDateTimeEnd_When_TemplateValue_last()
        {
            //Arrange
            var startDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 12, 00, 00), TimeSpan.FromHours(2));
            var endDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 18, 00, 00), TimeSpan.FromHours(-7));

            var points = new PointDate()
            {
                DateTimeStart = startDateTime,
                DateTimeEnd = endDateTime
            };

            var templateValue = "last";

            //Act
            var result = DateTimeTransformer.CalculateToRightDateTime(points, templateValue);

            //Assert
            Assert.AreEqual(endDateTime, result.Value);
        }

        [TestMethod]
        public void Does_Return_1DayBefore_StartDateTime_When_TemplateValue_first_With_MinusTime()
        {
            //Arrange
            var startDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 12, 00, 00), TimeSpan.FromHours(2));
            var endDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 18, 00, 00), TimeSpan.FromHours(-7));

            var points = new PointDate()
            {
                DateTimeStart = startDateTime,
                DateTimeEnd = endDateTime
            };

            var templateValue = "first-1440";

            //Act
            var result = DateTimeTransformer.CalculateToRightDateTime(points, templateValue);

            //Assert
            Assert.AreEqual("2019/03/31 12:00:00", result.Value.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        [TestMethod]
        public void Does_Return_30MinutesBefore_StartDateTime_When_TemplateValue_first_With_MinusTime()
        {
            //Arrange
            var startDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 12, 00, 00), TimeSpan.FromHours(2));
            var endDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 18, 00, 00), TimeSpan.FromHours(-7));

            var points = new PointDate()
            {
                DateTimeStart = startDateTime,
                DateTimeEnd = endDateTime
            };

            var templateValue = "first-30";

            //Act
            var result = DateTimeTransformer.CalculateToRightDateTime(points, templateValue);

            //Assert
            Assert.AreEqual("2019/04/01 11:30:00", result.Value.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        [TestMethod]
        public void Does_Return_2DaysAfter_StartDateTime_When_TemplateValue_first_With_PlusTime()
        {
            //Arrange
            var startDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 12, 00, 00), TimeSpan.FromHours(2));
            var endDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 18, 00, 00), TimeSpan.FromHours(-7));

            var points = new PointDate()
            {
                DateTimeStart = startDateTime,
                DateTimeEnd = endDateTime
            };

            var templateValue = "first+2880";

            //Act
            var result = DateTimeTransformer.CalculateToRightDateTime(points, templateValue);

            //Assert
            Assert.AreEqual("2019/04/03 12:00:00", result.Value.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        [TestMethod]
        public void Does_Return_1DaysAfter_EndDateTime_When_TemplateValue_last_With_PlusTime()
        {
            //Arrange
            var startDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 12, 00, 00), TimeSpan.FromHours(2));
            var endDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 18, 00, 00), TimeSpan.FromHours(-7));

            var points = new PointDate()
            {
                DateTimeStart = startDateTime,
                DateTimeEnd = endDateTime
            };

            var templateValue = "last+1440";

            //Act
            var result = DateTimeTransformer.CalculateToRightDateTime(points, templateValue);

            //Assert
            Assert.AreEqual("2019/04/02 18:00:00", result.Value.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        [TestMethod]
        public void Does_Return_12HoursBefore_EndDateTime_When_TemplateValue_last_With_MinusTime()
        {
            //Arrange
            var startDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 12, 00, 00), TimeSpan.FromHours(2));
            var endDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 18, 00, 00), TimeSpan.FromHours(-7));

            var points = new PointDate()
            {
                DateTimeStart = startDateTime,
                DateTimeEnd = endDateTime
            };

            var templateValue = "last-720";

            //Act
            var result = DateTimeTransformer.CalculateToRightDateTime(points, templateValue);

            //Assert
            Assert.AreEqual("2019/04/01 06:00:00", result.Value.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        [TestMethod]
        public void Does_Return_12HoursBefore_EndDateTime_When_TemplateValue_last_With_MinusTime_with_leading_zero()
        {
            //Arrange
            var startDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 12, 00, 00), TimeSpan.FromHours(2));
            var endDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 18, 00, 00), TimeSpan.FromHours(-7));

            var points = new PointDate()
            {
                DateTimeStart = startDateTime,
                DateTimeEnd = endDateTime
            };

            var templateValue = "last-0720";

            //Act
            var result = DateTimeTransformer.CalculateToRightDateTime(points, templateValue);

            //Assert
            Assert.AreEqual("2019/04/01 06:00:00", result.Value.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        [TestMethod]
        public void Does_Return_1DaysAfter_EndDateTime_When_TemplateValue_last_With_PlusTime_with_leading_zero()
        {
            //Arrange
            var startDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 12, 00, 00), TimeSpan.FromHours(2));
            var endDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 18, 00, 00), TimeSpan.FromHours(-7));

            var points = new PointDate()
            {
                DateTimeStart = startDateTime,
                DateTimeEnd = endDateTime
            };

            var templateValue = "last+001440";

            //Act
            var result = DateTimeTransformer.CalculateToRightDateTime(points, templateValue);

            //Assert
            Assert.AreEqual("2019/04/02 18:00:00", result.Value.ToString("yyyy/MM/dd HH:mm:ss"));
        }

        [TestMethod]
        public void Does_ReturnNull_When_a_weird_value()
        {
            //Arrange
            var startDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 12, 00, 00), TimeSpan.FromHours(2));
            var endDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 18, 00, 00), TimeSpan.FromHours(-7));

            var points = new PointDate()
            {
                DateTimeStart = startDateTime,
                DateTimeEnd = endDateTime
            };

            string templateValue = "thisisaweirdvalue";

            //Act
            var result = DateTimeTransformer.CalculateToRightDateTime(points, templateValue);

            //Assert
            Assert.IsFalse(result.HasValue);
        }

        [TestMethod]
        public void Does_ReturnDateTimeStart_When_TemplateValue_First()
        {
            //Arrange
            var startDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 12, 00, 00), TimeSpan.FromHours(2));
            var endDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 18, 00, 00), TimeSpan.FromHours(-7));

            var points = new PointDate()
            {
                DateTimeStart = startDateTime,
                DateTimeEnd = endDateTime
            };

            var templateValue = "First";

            //Act
            var result = DateTimeTransformer.CalculateToRightDateTime(points, templateValue);

            //Assert
            Assert.AreEqual(startDateTime, result.Value);
        }

        [TestMethod]
        public void Does_ReturnDateTimeStart_When_TemplateValue_Last()
        {
            //Arrange
            var startDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 12, 00, 00), TimeSpan.FromHours(2));
            var endDateTime = new DateTimeOffset(new DateTime(2019, 04, 01, 18, 00, 00), TimeSpan.FromHours(-7));

            var points = new PointDate()
            {
                DateTimeStart = startDateTime,
                DateTimeEnd = endDateTime
            };

            var templateValue = "Last";

            //Act
            var result = DateTimeTransformer.CalculateToRightDateTime(points, templateValue);

            //Assert
            Assert.AreEqual(endDateTime, result.Value);
        }
    }
}
