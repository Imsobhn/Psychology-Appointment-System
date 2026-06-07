using System;
using System.Globalization;

namespace PsychologyAppointmentSystem.Helpers;

public static class CultureHelper
{
    public static void ChangeCulture()
    {
        var culture = new CultureInfo("fa-IR");

        culture.DateTimeFormat.Calendar = new PersianCalendar();

        culture.DateTimeFormat.AbbreviatedDayNames =
            new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };

        culture.DateTimeFormat.DayNames =
            new[]
            {
                "یکشنبه", "دوشنبه", "سه‌شنبه",
                "چهارشنبه", "پنجشنبه", "جمعه", "شنبه"
            };

        culture.DateTimeFormat.AbbreviatedMonthNames =
            new[]
            {
                "فروردین", "اردیبهشت", "خرداد",
                "تیر", "مرداد", "شهریور",
                "مهر", "آبان", "آذر",
                "دی", "بهمن", "اسفند", ""
            };

        culture.DateTimeFormat.MonthNames =
            new[]
            {
                "فروردین", "اردیبهشت", "خرداد",
                "تیر", "مرداد", "شهریور",
                "مهر", "آبان", "آذر",
                "دی", "بهمن", "اسفند", ""
            };

        culture.DateTimeFormat.AMDesignator = "ق.ظ";
        culture.DateTimeFormat.PMDesignator = "ب.ظ";
        culture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd";
        culture.DateTimeFormat.FirstDayOfWeek = DayOfWeek.Saturday;
        culture.DateTimeFormat.ShortestDayNames =
            new[] { "ی", "د", "س", "چ", "پ", "ج", "ش" };

        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
    }
}