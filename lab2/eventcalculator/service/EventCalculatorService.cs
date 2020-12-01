using System;

namespace lab2.eventcalculator.service
{
    public class EventCalculatorService
    {
        public String getCalculationDate(String pathToFile)
        {
            String result = "";

            if (pathToFile != null && pathToFile != "")
            {
                String[] lines = getContentOfFile(pathToFile);
                String[] resultArray = new String[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    String line = lines[i];

                    int indexSeparator = line.IndexOf('|');

                    String date = line.Substring(0, indexSeparator).Trim();
                    String eventTitle = line.Substring(indexSeparator).Replace('|', ' ').Trim();

                    DateTime dateTimeMarkNow = getCurrentDateTime();
                    String countOfDays = getCountOfDays(dateTimeMarkNow, date);

                    resultArray[i] = date + " | " + eventTitle + ". " + countOfDays;
                }

                for (int i = 0; i < resultArray.Length; i++)
                {
                    result += resultArray[i] + "\n";
                }
            }

            return result;
        }

        public DateTime getCurrentDateTime()
        {
            return DateTime.Now;
        }

        private String[] getContentOfFile(String pathToFile)
        {
            return System.IO.File.ReadAllLines(@"" + pathToFile + "");
        }

        public String getCountOfDays(DateTime dateTimeMarkNow, String dateEvent)
        {
            DateTime convertedDateEvent = Convert.ToDateTime(dateEvent);

            TimeSpan span = convertedDateEvent.Subtract(dateTimeMarkNow);
            int days = (int)span.TotalDays + 1;

            return "Days to event " + days;
        }
    }
}