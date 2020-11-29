using System;
using lab1.calculatoroflifetime.model;

namespace lab1.calculator.service
{
    public class CalculatorService
    {
        public String getLivedDateTime(Calculator calculator)
        {
            DateTime convertedDateOfBirth = Convert.ToDateTime(calculator.dateOfBirth);
            DateTime dateTimeMarkNow = DateTime.Now;

            int countOfYears = getCountOfYear(dateTimeMarkNow.Year, convertedDateOfBirth.Year);
            int countOfMonth = getCountOfMonths(dateTimeMarkNow.Month, convertedDateOfBirth.Month, countOfYears);
            int countOfDays = getCountOfDays(dateTimeMarkNow, convertedDateOfBirth);

            int countOfHours = getCountOfHours(countOfDays, dateTimeMarkNow.Hour);
            long countOfMinutes = getCountOfMinutes(countOfHours, dateTimeMarkNow.Minute);
            long countOfSeconds = getCountOfSeconds(countOfMinutes, dateTimeMarkNow.Second);

            String years = getStringResult("years: ", countOfYears);
            String months = getStringResult(", month: ", countOfMonth);
            String days = getStringResult(", days: ", countOfDays);
            String hours = getStringResult(", hours: ", countOfHours);
            String minutes = getStringResult(", minutes: ", countOfMinutes);
            String seconds = getStringResult(", seconds: ", countOfSeconds);

            return calculator.nameOfPerson + " already lived - " + years + months + days + hours + minutes + seconds;
        }

        private String getStringResult(String str, long countOfTime)
        {
            return str + countOfTime;
        }

        private int getCountOfYear(int dateTimeMarkNow, int dateTimeMark)
        {
            return dateTimeMarkNow - dateTimeMark;
        }

        private int getCountOfMonths(int currentIntMonth, int birthIntMonth, int countOfYears)
        {
            if (countOfYears != 0)
            {
                int result = (countOfYears - 1) * 12;
                result += currentIntMonth - birthIntMonth;
                return result;
            }
            else
            {
                return 0;
            }
        }

        private int getCountOfDays(DateTime dateTimeMarkNow, DateTime convertedDateOfBirth)
        {
            int result = 0;
            for(int year = convertedDateOfBirth.Year; year <= dateTimeMarkNow.Year; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    if(year == convertedDateOfBirth.Year && month < convertedDateOfBirth.Month)
                    {
                        continue;
                    }
                    if (year == dateTimeMarkNow.Year && month == dateTimeMarkNow.Month)
                    {
                        result += DateTime.Today.Day - convertedDateOfBirth.Day;
                        return result;
                    }
                    else
                    {
                        result += DateTime.DaysInMonth(year, month);
                    }
                }
            }
            return result;
        }

        private int getCountOfHours(int countOfLivedDays, int currentHour)
        {
            return (countOfLivedDays * 24) - currentHour;
        }

        private int getCountOfMinutes(int countOfLivedHour, int currentMinute)
        {
            return (countOfLivedHour * 60) - currentMinute;
        }

        private long getCountOfSeconds(long countOfLivedMinutes, long currentSeconds)
        {
            return (countOfLivedMinutes * 60) - currentSeconds;
        }
    }
}