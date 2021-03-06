﻿using System;

namespace BenTools.Extensions.Date
{
    public static class DateTimeExtension
    {
        public static TimeSpan ToTimeSpan(this DateTime dateTime) => TimeSpan.FromTicks(dateTime.Ticks);

        public static DateTime ResetMilliseconds(this DateTime dateTime) => dateTime.AddMilliseconds(-dateTime.Millisecond);

        public static DateTime ResetSeconds(this DateTime dateTime) => dateTime.AddSeconds(-dateTime.Second);

        public static DateTime ResetMinutes(this DateTime dateTime) => dateTime.AddMinutes(-dateTime.Minute);

        public static DateTime ResetHours(this DateTime dateTime) => dateTime.AddHours(-dateTime.Hour);

        public static DateTime ResetDays(this DateTime dateTime) => dateTime.AddDays(-dateTime.Day);

        public static DateTime ResetMonths(this DateTime dateTime) => dateTime.AddMonths(-dateTime.Month);

        /// <summary>
        /// Paris => 1 because GMT+1.
        /// </summary>
        public static DateTime ToLocalTime(this DateTime dateTime) =>  dateTime.AddHours(TimeZone.CurrentTimeZone.GetUtcOffset(new DateTime()).Hours);

        /// <summary>
        /// Paris => -1 because GMT+1.
        /// </summary>
        public static DateTime ToUtc(this DateTime dateTime) =>  dateTime.AddHours(-TimeZone.CurrentTimeZone.GetUtcOffset(new DateTime()).Hours);
    }
}
