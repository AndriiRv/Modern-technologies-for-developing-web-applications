using System;

namespace lab1.simplecalculator.service
{
    public class SimpleCalculatorService
    {
        private static int counter = 0;
        public double calculate(String content)
        {
            double result = 0;
            char lastCalculationSign = '0';
            String strResult = "";

            Char[] array = new Char[content.Length];
            for (int i = 0; i < content.Length; i++)
            {
                array[i] = content[i];
            }

            for(int i = 0; i < array.Length; i++)
            {
                if (Char.IsDigit(array[i]))
                {
                    counter++;
                    if (counter >= 2)
                    {
                        strResult = result.ToString();
                        if (lastCalculationSign == ',' || lastCalculationSign == '.')
                        {
                            strResult += ',';
                        }
                        strResult += array[i];
                        result = Double.Parse(strResult);
                        lastCalculationSign = '0';
                        continue;
                    }
                    double number = Char.GetNumericValue(array[i]);
                    result = calculateContentByCalculationSign(result, lastCalculationSign, number);
                }
                else
                {
                    counter = 0;
                    lastCalculationSign = getCalculationSign(array[i]);
                }
            }
            counter = 0;
            return result;
        }

        private double calculateContentByCalculationSign(double result, char character, double numberForCalculationToRestNumber)
        {
            double resultForCalculation = result;

            switch (character)
            {
                case '0':
                case '+':
                    resultForCalculation += numberForCalculationToRestNumber;
                    break;
                case '-':
                    resultForCalculation -= numberForCalculationToRestNumber;
                    break;
                case '*':
                    resultForCalculation *= numberForCalculationToRestNumber;
                    break;
                case '/':
                    resultForCalculation /= numberForCalculationToRestNumber;
                    break;
            }
            return resultForCalculation;
        }

        private char getCalculationSign(char character)
        {
            char lastCalculationSign = '0';
            switch (character)
            {
                case '+':
                case '-':
                case '*':
                case '/':
                    lastCalculationSign = character;
                    break;
                case ',':
                case '.':
                    counter++;
                    lastCalculationSign = character;
                    break;
            }
            return lastCalculationSign;
        }
    }
}
