using System;

var scheduler = new Scheduler();

scheduler.AddHoliday(7, 4);

scheduler.AddHoliday(month: 7, day: 4);

var independencyDay = new Date(7, 4);

scheduler.AddHoliday(independencyDay);

scheduler.AddHoliday(Constants.Month.JULY, Constants.Day.DAY_4);

scheduler.AddHoliday(Enums.Month.July, Enums.Day.Day_4);

public class Scheduler
{
    public void AddHoliday(int month, int day)
    {
        Console.WriteLine("Adding holiday at month {0} and day {1}", month, day);
    }

    public void AddHoliday(Date date)
    {
        Console.WriteLine("Adding holiday at month {0} and day {1}", date.Month, date.Day);
    }

    public void AddHoliday(Enums.Month month, Enums.Day day)
    {
        Console.WriteLine("Adding holiday at month {0} and day {1}", (int)month, (int)day);
    }
}

public struct Date
{
    public Date(int month, int day)
    {
        Month = month;
        Day = day;
    }

    public int Month { get; }

    public int Day { get; }
}

public static class Constants
{
    public static class Month
    {
        public static readonly int JULY = 7;
    }

    public static class Day
    {
        public static readonly int DAY_4 = 4;
    }
}

public static class Enums
{
    public enum Month
    {
        July = 7
    }

    public enum Day
    {
        Day_4 = 4
    }
}
