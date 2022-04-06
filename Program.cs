using System;
public class HumanTimeFormat
{
    static string strSec = "seconds";
    static string strMin = "minutes";
    static string strHour = "hours";
    static string strDay = "days";
    static string strYear = "years";

    static void Main()
    {
        Console.WriteLine(HumanTimeFormat.formatDuration(418543201));
    }
    public static string formatDuration(int seconds)
    {
        const int SecondsPerYear = 31536000;
        const int SecondsPerDay = 86400;
        const int SecondsPerHour = 3600;
        const int SecondsPerMinute = 60;

        int count = 0;

        if (seconds == 0)
            return "now";

        int remainder;
        var year = System.Math.DivRem(seconds, SecondsPerYear, out remainder);
        var day = Math.DivRem(remainder, SecondsPerDay, out remainder);
        var hour = Math.DivRem(remainder, SecondsPerHour, out remainder);
        var minute = Math.DivRem(remainder, SecondsPerMinute, out remainder);

        if (remainder != 0)
            count++;

        if (minute != 0)
            count++;

        if (hour != 0)
            count++;

        if (day != 0)
            count++;

        if (year != 0)
            count++;

        CheckingS(remainder, minute, hour, day, year);

        var secDisplay = remainder == 0 ? "" : $"{remainder} {strSec}";
        var minDisplay = minute == 0 ? "" : $"{minute} {strMin}";
        var hourDisplay = hour == 0 ? "" : $"{hour} {strHour}";
        var dayDisplay = day == 0 ? "" : $"{day} {strDay}";
        var yearDisplay = year == 0 ? "" : $"{year} {strYear}";

        if (count == 2)
        {
            minDisplay = minute == 0 ? "" : $"{minute} {strMin} and ";
            hourDisplay = hour == 0 ? "" : $"{hour} {strHour} and ";
            dayDisplay = day == 0 ? "" : $"{day} {strDay} and ";
            yearDisplay = year == 0 ? "" : $"{year} {strYear} and ";
        }
        if (count >= 3)
        {
            minDisplay = minute == 0 ? "" : $"{minute} {strMin} and ";
            hourDisplay = hour == 0 ? "" : $"{hour} {strHour}, ";
            dayDisplay = day == 0 ? "" : $"{day} {strDay}, ";
            yearDisplay = year == 0 ? "" : $"{year} {strYear}, ";

            if (remainder == 0)
                minDisplay = minute == 0 ? "" : $"{minute} {strMin}";
            if (minute == 0 && remainder == 0)
                hourDisplay = hour == 0 ? "" : $"{hour} {strHour}";
            if (minute != 0 && remainder == 0)
                hourDisplay = hour == 0 ? "" : $"{hour} {strHour} and ";
            if (minute == 0 && remainder != 0)
                hourDisplay = hour == 0 ? "" : $"{hour} {strHour} and ";
            if (hour == 0 && minute == 0 && remainder == 0)
                dayDisplay = day == 0 ? "" : $"{day} {strDay}";
            if (day == 0 && hour == 0 && minute == 0 && remainder == 0)
                yearDisplay = year == 0 ? "" : $"{year} {strYear}";
        }

        return $"{yearDisplay}{dayDisplay}{hourDisplay}{minDisplay}{secDisplay}";

    }
    public static void CheckingS(int seconds, int minute, int hour, int day, int year)
    {
        if (seconds == 1)
            strSec = "second";

        if (minute == 1)
            strMin = "minute";

        if (hour == 1)
            strHour = "hour";

        if (day == 1)
            strDay = "day";

        if (year == 1)
            strYear = "year";
    }
}
