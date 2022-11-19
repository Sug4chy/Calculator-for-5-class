using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using System.Net.NetworkInformation;
using System.Text;

namespace Calculator
{
    class Calculations
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.Title = "Calculator for 5 class";
            Console.ForegroundColor = ConsoleColor.Cyan;

            BeginWork();

            try
            {
                GetInput();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ArgumentException))
                {
                    Console.WriteLine(ex.Message);
                    Console.Clear();
                }
                else Console.WriteLine("Извините, что-то пошло не так. Прошу, повторите ввод данных. Скорее всего, предыдущий ввод был некорректен!");

                Main();
            }

        }

        public static void BeginWork()
        {
            Console.WriteLine("Приветствую! Я калькулятор для человека, учащегося в 5 классе. Могу работать с любыми системами счисления от 1 до 50 включительно, а также с римской СС.");
            Console.WriteLine("Мой создатель - Бойко Степан, студент группы ПрИ-102.");
            Console.WriteLine("\n");
            ShowMenu();
            Console.WriteLine("Выберите, какую из моих функций будете использовать в этот раз.");
        }

        public static void ShowMenu()
        {
            Console.WriteLine("Функция 1: перевод числа из любой СС от 1 до 50 в десятичную СС;");
            Console.WriteLine("Функция 2: перевод числа из десятичной СС в любую СС от 1 до 50;");
            Console.WriteLine("Функция 3: перевод числа в римскую СС;");
            Console.WriteLine("Функция 4: перевод числа из римской СС");
            Console.WriteLine("Функция 5: сложение двух чисел в любой СС от 1 до 50;");
            Console.WriteLine("Функция 6: вычитание двух чисел в любой СС от 1 до 50;");
            Console.WriteLine("Функция 7: умножение двух чисел в любой СС от 1 до 50;");
            Console.WriteLine("Функция 8: показать алфавит систем счисления.");
            Console.WriteLine("\n");
        }

        public static void DoYouWantToContinue()
        {
            Console.WriteLine("Если хотите продолжить работу с калькулятором, нажмите любую кнопку.");
            Console.ReadKey();
            Console.Clear();
            BeginWork();
        }

        public static int GetInput()
        {
            Console.WriteLine("Введите число, соответствующее выбранной вами функции.");
            while (true)
            {
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int function) || !(function >= 1 && function <= 8))
                {
                    throw new ArgumentException("");
                }

                switch (function)
                {
                    case 1:
                        Console.WriteLine("\n");
                        FirstFunction();
                        DoYouWantToContinue();
                        break;
                    case 2:
                        Console.WriteLine("\n");
                        SecondFunction();
                        DoYouWantToContinue();
                        break;
                    case 3:
                        Console.WriteLine("\n");
                        ThirdFunction();
                        DoYouWantToContinue();
                        break;
                    case 4:
                        Console.WriteLine("\n");
                        FourthFunction();
                        DoYouWantToContinue();
                        break;
                    case 5:
                        Console.WriteLine("\n");
                        FifthFunction();
                        DoYouWantToContinue();
                        break;
                    case 6:
                        Console.WriteLine("\n");
                        SixthFunction();
                        DoYouWantToContinue();
                        break;
                    case 7:
                        Console.WriteLine("\n");
                        SeventhFunction();
                        DoYouWantToContinue();
                        break;
                    case 8:
                        Console.WriteLine("\n");
                        EigthFunction();
                        DoYouWantToContinue();
                        break;
                    default:
                        Console.WriteLine("Обнаружена неисправность в программе, повторите попытку позже");
                        break;
                }

            }

        }

        public static void BuildATower(string number1, string number2, string operation)
        {
            int maxLen = Math.Max(number1.Length, number2.Length);

            switch (operation)
            {
                case "+":
                    if (maxLen == number1.Length)
                    {
                        for (int i = 0; i <= maxLen - number2.Length; i++) number2 = " " + number2;
                        Console.WriteLine("Для удобства запишем число с большим числом разрядов выше.");
                        Console.WriteLine("Запишем числа в столбик, и будем складывать поразрядно.\n");
                        Console.WriteLine($" {number1}\n+\n {number2}");
                        Console.Write("=");
                        for (int i = 0; i < maxLen; i++) Console.Write("=");
                        Console.Write("\n");
                    }

                    else
                    {
                        for (int i = 0; i <= maxLen - number1.Length; i++) number1 = " " + number1;
                        Console.WriteLine("Для удобства запишем число с большим числом разрядов выше.");
                        Console.WriteLine("Запишем числа в столбик, и будем складывать поразрядно.\n");
                        Console.WriteLine($" {number2}\n+\n {number1}");
                        Console.Write("=");
                        for (int i = 0; i < maxLen; i++) Console.Write("=");
                        Console.Write("\n");
                    }

                    break;
                case "-":
                    if (maxLen == number1.Length)
                    {
                        for (int i = 0; i <= maxLen - number2.Length; i++) number2 = " " + number2;
                        Console.WriteLine("Запишем числа в столбик, и будем вычитать поразрядно.\n");
                        Console.WriteLine($" {number1}\n-\n {number2}");
                        Console.Write("=");
                        for (int i = 0; i < maxLen; i++) Console.Write("=");
                        Console.Write("\n");
                    }

                    else
                    {
                        for (int i = 0; i <= maxLen - number1.Length; i++) number1 = " " + number1;
                        Console.WriteLine("Запишем числа в столбик, и будем вычитать поразрядно.\n");
                        Console.WriteLine($" {number1}\n-\n {number2}");
                        Console.Write("=");
                        for (int i = 0; i < maxLen; i++) Console.Write("=");
                        Console.Write("\n");
                    }

                    break;
                case "*":
                    if (maxLen == number1.Length)
                    {
                        for (int i = 0; i <= maxLen - number2.Length; i++) number2 = " " + number2;
                        Console.WriteLine("Для удобства запишем число с большим числом разрядов выше.");
                        Console.WriteLine("Запишем числа в столбик, и будем умножать поразрядно.\n");
                        Console.WriteLine($" {number1}\n*\n {number2}");
                        Console.Write("=");
                        for (int i = 0; i < maxLen; i++) Console.Write("=");
                        Console.Write("\n");
                    }

                    else
                    {
                        for (int i = 0; i <= maxLen - number1.Length; i++) number1 = " " + number1;
                        Console.WriteLine("Для удобства запишем число с большим числом разрядов выше.");
                        Console.WriteLine("Запишем числа в столбик, и будем умножать поразрядно.\n");
                        Console.WriteLine($" {number2}\n*\n {number1}");
                        Console.Write("=");
                        for (int i = 0; i < maxLen; i++) Console.Write("=");
                        Console.Write("\n");
                    }

                    break;
                default:
                    throw new ArgumentException("");
                    break;
            }

        }

        public static List<int> ParseStringToList(string numberInput)
        {
            string numbers = "0123456789";
            string lettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lettersLower = "abcdefghijklmn";
            List<int> number = new();

            for (int i = 0; i < numberInput.Length; i++)
            {
                if (numbers.Contains(numberInput[i])) number.Add(numberInput[i] - '0');
                if (lettersUpper.Contains(numberInput[i])) number.Add(lettersUpper.IndexOf(numberInput[i]) + 10);
                if (lettersLower.Contains(numberInput[i])) number.Add(lettersLower.IndexOf(numberInput[i]) + 36);
            }

            return number;
        }

        public static void FirstFunction()
        {
            Console.WriteLine("Введите систему счисления, ИЗ которой будем переводить.");
            string numberSystemInput = Console.ReadLine();
            if (!(int.TryParse(numberSystemInput, out int numberSystem)) || !(numberSystem >= 1 && numberSystem <= 50))
                throw new ArgumentException("Основание системы счисления введено некорректно!");
            Console.WriteLine("Введите число, которое будем переводить.");
            string userInput = Console.ReadLine();

            Console.WriteLine($"Разобьём число на разряды.");
            List<char> digits = new List<char>();
            List<char> foolTest = new List<char>();
            string numbers = "0123456789";
            string lettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lettersLower = "abcdefghijklmn";

            double result = 0;

            for (int h = 0; h < userInput.Length; h++)
            {
                foolTest.Add(userInput[h]);
            }

            foreach (char c in foolTest)
            {
                if (numbers.Contains(c) && (c - '0') >= numberSystem)
                    throw new ArgumentException("Введённое число не соответствует выбранной системе счисления!");
                else if (lettersUpper.Contains(c) && (lettersUpper.IndexOf(c) + 10) >= numberSystem)
                    throw new ArgumentException("Введённое число не соответствует выбранной системе счисления!");
                else if (lettersLower.Contains(c) && (lettersLower.IndexOf(c) + 36) >= numberSystem)
                    throw new ArgumentException("Введённое число не соответствует выбранной системе счисления!");
            }

            for (int i = 0; i < userInput.Length; i++)
            {
                digits.Add(userInput[i]);
                Console.Write($"{userInput[i]} ");
            }

            Console.WriteLine($"Далее мы должны каждый разряд умножить на основание СС в степени этого разряда минус один.");
            int CurrentIndex = userInput.Length - 1;
            for (int j = 0; j < digits.Count; j++)
            {
                if (numbers.Contains(digits[j]))
                {
                    Console.WriteLine($"{digits[j]} * {Math.Pow(numberSystem, CurrentIndex)} = {(digits[j] - '0') * Math.Pow(numberSystem, CurrentIndex)}");
                    result += (digits[j] - '0') * Math.Pow(numberSystem, CurrentIndex);
                    CurrentIndex--;
                }

                else if (lettersUpper.Contains(digits[j]))
                {
                    Console.WriteLine($"{lettersUpper.IndexOf(digits[j]) + 10} * {Math.Pow(numberSystem, CurrentIndex)} = {(lettersUpper.IndexOf(digits[j]) + 10) * Math.Pow(numberSystem, CurrentIndex)}");
                    result += (lettersUpper.IndexOf(digits[j]) + 10) * Math.Pow(numberSystem, CurrentIndex);
                    CurrentIndex--;
                }

                else if (lettersLower.Contains(digits[j]))
                {
                    Console.WriteLine($"{lettersLower.IndexOf(digits[j]) + 36} * {Math.Pow(numberSystem, CurrentIndex)} = {(lettersLower.IndexOf(digits[j]) + 36) * Math.Pow(numberSystem, CurrentIndex)}");
                    result += (lettersLower.IndexOf(digits[j]) + 36) * Math.Pow(numberSystem, CurrentIndex);
                    CurrentIndex--;
                }
            }
            Console.WriteLine($"После сложения всех результатов умножения мы получаем результат: число {userInput} в {numberSystem}-тичной системе счисления равняется {result} в десятичной СС.");
        }

        public static void SecondFunction()
        {
            Console.WriteLine("Введите систему счисления, в которую будем переводить число.");
            string numberSystemInput = Console.ReadLine();
            if (!int.TryParse(numberSystemInput, out int numberSystem) || !(numberSystem >= 1 && numberSystem <= 50))
                throw new ArgumentException("Система счисления введена некорректно.");
            Console.WriteLine("Введите число, которое будем переводить.");
            string numberInput = Console.ReadLine();
            if (!int.TryParse(numberInput, out int number))
                throw new ArgumentException("Число введено некорректно.");

            List<int> tailings = new List<int>();
            string output = "";
            string numbers = "0123456789";
            string lettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lettersLower = "abcdefghijklmn";
            int dividend = number;

            while (dividend > 0)
            {
                Console.WriteLine("Будем делить изначальное число на основание СС нацело и записывать остатки, пока изначальное число не станет равным 0.");
                Console.WriteLine($"{dividend} / {numberSystem} = {dividend / numberSystem}\tОстаток:{dividend % numberSystem}");
                tailings.Add(dividend % numberSystem);
                int quotient = dividend / numberSystem;
                dividend = quotient;
            }

            Console.WriteLine("Далее мы записываем полученные остатки в обратном порядке, заменяя цифры соответствующими символами в алфавите СС.");
            tailings.Reverse();
            foreach (int e in tailings)
            {
                if (e >= 0 && e <= 9) output += e.ToString();
                else if (e >= 10 && e <= 35) output += lettersUpper[e - 10];
                else if (e >= 36 && e <= 50) output += lettersLower[e - 36];
            }

            Console.WriteLine($"И в итоге получаем, что число {number} равняется {output} в {numberSystem}-тичной системе счисления.");
        }

        public static void ThirdFunction()
        {
            int[] arab = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] rim = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            Console.WriteLine("Введите число для перевода в диапозоне от 1 до 5000.");
            string input = Console.ReadLine();

            bool foolTest = int.TryParse(input, out int number);
            if ((!foolTest) || !(number >= 1 && number <= 5000))
                throw new ArgumentException("Пожалуйста, убедитесь, что вы ввели корректное число и повторите попытку");

            int origin = number;
            string output = "";
            int i = 0;

            Console.WriteLine($"Будем параллельно отнимать от {number} числа, и записывать в отдельную строку символы или символьные комбинации, соответствующее этим числам, пока исходное число не станет равным 0.");
            while (number > 0)
            {
                if (arab[i] <= number)
                {
                    Console.WriteLine($"{number} - {arab[i]} = {number - arab[i]}\tЗаписываем {rim[i]}");
                    number -= arab[i];
                    output += rim[i];
                }

                else i++;
            }

            Console.WriteLine($"Число {origin} в римской СС выглядит так: {output}");
        }

        public static void FourthFunction()
        {
            char[] rim = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            int[] arab = { 1, 5, 10, 50, 100, 500, 1000 };
            Console.WriteLine("Введите число в римской СС в промежутке от 1 до 5000, которое будем переводить в десятичную.");
            string userInput = Console.ReadLine();
            string origin = userInput;

            bool foolTest = false;
            for (int i = 0; i < userInput.Length; i++)
            {
                for (int j = 0; j < rim.Length; j++)
                {
                    if (userInput[i] == rim[j])
                        foolTest = true;
                }

                if (!foolTest)
                    throw new ArgumentException("Введённое значение не входит в заданный промежуток или не является числом в римской СС.");
            }


            List<char> programInput = new();
            for (int i = 0; i < userInput.Length; i++)
            {
                programInput.Add(userInput[i]);
            }

            int result = 0;
            programInput.Reverse();
            Console.WriteLine("Развернём наше число и пройдёмся по каждому его символу.");
            Console.WriteLine("Так как мы развернули число, то все символы должны идти в порядке возрастания соответствующих им значений. Если это правило соблюдается, то мы прибавляем это число к итоговому результату. Если же нет - отнимаем.");

            result += arab[Array.IndexOf(rim, programInput[0])];
            for (int i = 1; i < programInput.Count; i++)
            {
                if (Array.IndexOf(rim, programInput[i - 1]) > Array.IndexOf(rim, programInput[i])) result -= arab[Array.IndexOf(rim, programInput[i])];
                else result += arab[Array.IndexOf(rim, programInput[i])];
            }

            Console.WriteLine(result);
        }

        public static void FifthFunction()
        {
            Console.WriteLine("Введите систему счисления от 1 до 50.");
            string numberSystemInput = Console.ReadLine();
            if (!int.TryParse(numberSystemInput, out int numberSystem) || !(numberSystem >= 1 && numberSystem <= 50))
                throw new ArgumentException("Система счисления введена некорректно");
            Console.WriteLine("Введите первое число.");
            string number1Input = Console.ReadLine();
            Console.WriteLine("Введите второе число.");
            string number2Input = Console.ReadLine();
            Console.WriteLine("\n");

            List<int> number1 = new();
            List<int> number2 = new();

            string numbers = "0123456789";
            string lettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lettersLower = "abcdefghijklmn";

            for (int i = 0; i < number1Input.Length; i++)
            {
                if (!numbers.Contains(number1Input[i]) && !lettersUpper.Contains(number1Input[i]) && !lettersLower.Contains(number1Input[i]))
                    throw new ArgumentException("Одно из чисел или оба числа введены некорректно.");
            }

            for (int i = 0; i < number2Input.Length; i++)
            {
                if (!numbers.Contains(number2Input[i]) && !lettersUpper.Contains(number2Input[i]) && !lettersLower.Contains(number2Input[i]))
                    throw new ArgumentException("Одно из чисел или оба числа введены некорректно.");
            }

            number1 = ParseStringToList(number1Input);
            number2 = ParseStringToList(number2Input);

            bool foolTest1 = false;
            bool foolTest2 = false;
            for (int i = 0; i < number1.Count; i++)
            {
                if (number1[i] >= numberSystem) foolTest1 = true;
                if (foolTest1)
                    throw new ArgumentException("Одно из чисел или оба числа введены некорректно.");
            }

            for (int i = 0; i < number2.Count; i++)
            {
                if (number2[i] >= numberSystem) foolTest2 = true;
                if (foolTest2)
                    throw new ArgumentException("Одно из чисел или оба числа введены некорректно.");
            }

            int maxLen = Math.Max(number1.Count, number2.Count);

            if (number1.Count < maxLen)
            {
                number1.Reverse();
                for (int i = 0; i < maxLen - number1Input.Length; i++) number1.Add(0);
                number1.Reverse();
            }
            if (number2.Count < maxLen)
            {
                number2.Reverse();
                for (int i = 0; i < maxLen - number2Input.Length; i++) number2.Add(0);
                number2.Reverse();
            }

            BuildATower(number1Input, number2Input, "+");

            int overage = 0;
            List<int> result = new();

            for (int i = (maxLen - 1); i > -1; i--)
            {
                int sumRes = number1[i] + number2[i];
                if (sumRes >= numberSystem)
                {
                    result.Add(sumRes % numberSystem + overage);
                    overage = sumRes / numberSystem;
                }

                else result.Add(sumRes + overage);
                overage = sumRes / numberSystem;
            }

            if (overage > 0)
            {
                if (overage >= 1 && overage <= 9) result.Add(overage);
                if (overage >= 10 && overage <= 35) result.Add(lettersUpper[overage - 10]);
                if (overage >= 36) result.Add(lettersLower[overage - 36]);
            }

            string programOutput = "";
            result.Reverse();

            foreach (int item in result)
            {
                if (item >= 0 && item <= 9) programOutput += item;
                if (item >= 10 && item <= 35) programOutput += lettersUpper[item - 10];
                if (item >= 36) programOutput += lettersLower[item - 36];
            }

            Console.WriteLine(" " + programOutput);
            Console.WriteLine($"В результате получаем, что {number1Input} + {number2Input} = {programOutput} в {numberSystem}-тичной системе счисления.");
        }

        public static void SixthFunction()
        {
            Console.WriteLine("Введите систему счисления от 1 до 50.");
            string numberSystemInput = Console.ReadLine();
            bool foolTest = int.TryParse(numberSystemInput, out int numberSystem);
            if (!foolTest || !(numberSystem >= 1 && numberSystem <= 50))
                throw new ArgumentException("Система счисления введена некорректно.");
            Console.WriteLine("Введите первое число.");
            string number1Input = Console.ReadLine();
            Console.WriteLine("Введите второе число.");
            string number2Input = Console.ReadLine();

            string numbers = "0123456789";
            string lettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lettersLower = "abcdefghijklmn";

            List<int> number1 = new();
            List<int> number2 = new();

            for (int i = 0; i < number1Input.Length; i++)
            {
                if (!numbers.Contains(number1Input[i]) && !lettersUpper.Contains(number1Input[i]) && !lettersLower.Contains(number1Input[i]))
                    throw new ArgumentException("Одно из чисел или оба числа введены некорректно.");
            }

            for (int i = 0; i < number2Input.Length; i++)
            {
                if (!numbers.Contains(number2Input[i]) && !lettersUpper.Contains(number2Input[i]) && !lettersLower.Contains(number2Input[i]))
                    throw new ArgumentException("Одно из чисел или оба числа введены некорректно.");
            }

            number1 = ParseStringToList(number1Input);
            number2 = ParseStringToList(number2Input);

            string Test1 = "";
            string Test2 = "";

            for (int i = 0; i < number1.Count; i++) Test1 += number1[i].ToString();
            for (int i = 0; i < number2.Count; i++) Test2 += number2[i].ToString();

            bool minus;

            if (int.Parse(Test1) >= (int.Parse(Test2))) minus = false;
            else minus = true;

            int maxLen = Math.Max(number1.Count, number2.Count);

            if (number1.Count < maxLen)
            {
                number1.Reverse();
                for (int i = 0; i < maxLen - number1Input.Length; i++) number1.Add(0);
                number1.Reverse();
            }

            if (number2.Count < maxLen)
            {
                number2.Reverse();
                for (int i = 0; i < maxLen - number2Input.Length; i++) number2.Add(0);
                number2.Reverse();
            }

            BuildATower(number1Input, number2Input, "-");

            List<int> result = new();

            if (!minus)
            {
                for (int i = maxLen - 1; i >= 0; i--)
                {
                    if (number1[i] >= number2[i]) result.Add(number1[i] - number2[i]);
                    else
                    {
                        number1[i - 1] -= 1;
                        number1[i] += numberSystem;
                        result.Add(number1[i] - number2[i]);
                    }
                }
                string programOutput = "";
                result.Reverse();
                foreach (int item in result)
                {
                    if (item >= 0 && item <= 9) programOutput += item.ToString();
                    if (item >= 10 && item <= 35) programOutput += lettersUpper[item - 10];
                    if (item >= 36) programOutput += lettersLower[item - 36];
                }

                for (int i = 0; i < programOutput.Length; i++)
                {
                    if (programOutput[i] == '0')
                    {
                        programOutput = programOutput.Remove(i, 1);
                        programOutput = " " + programOutput;
                    }
                    else break;
                }

                Console.WriteLine(" " + programOutput);
                Console.WriteLine($"В результате получаем, что {number1Input} - {number2Input} = {programOutput} в {numberSystem}-тичной системе счисления.");
            }

            else
            {
                for (int i = maxLen - 1; i >= 0; i--)
                {
                    if (number2[i] >= number1[i]) result.Add(number2[i] - number1[i]);
                    else
                    {
                        number2[i - 1] -= 1;
                        number2[i] += numberSystem;
                        result.Add(number2[i] - number1[i]);
                    }

                }

                string programOutput = "";
                result.Reverse();
                foreach (int item in result)
                {
                    if (item >= 0 && item <= 9) programOutput += item.ToString();
                    if (item >= 10 && item <= 35) programOutput += lettersUpper[item - 10];
                    if (item >= 36) programOutput += lettersLower[item - 36];
                }

                for (int i = 0; i < programOutput.Length; i++)
                {
                    if (programOutput[i] == '0')
                    {
                        programOutput = programOutput.Remove(i, 1);
                    }
                    else break;
                }

                programOutput = "-" + programOutput;
                Console.WriteLine(" " + programOutput);
                Console.WriteLine($"В результате получаем, что {number1Input} - {number2Input} = {programOutput} в {numberSystem}-тичной системе счисления.");
            }

        }

        public static void SeventhFunction()
        {
            Console.WriteLine("Введите систему счисления от 1 до 50.");
            string numberSystemInput = Console.ReadLine();
            if (!int.TryParse(numberSystemInput, out int numberSystem) || !(numberSystem >= 1 && numberSystem <= 50))
                throw new ArgumentException("Основание системы счисления введена не корректно.");
            Console.WriteLine("Введите первый множитель.");
            string number1Input = Console.ReadLine();
            Console.WriteLine("Введите второй множитель.");
            string number2Input = Console.ReadLine();

            string numbers = "0123456789";
            string lettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lettersLower = "abcdefghijklmn";

            for (int i = 0; i < number1Input.Length; i++)
            {
                if (!numbers.Contains(number1Input[i]) && !lettersUpper.Contains(number1Input[i]) && !lettersLower.Contains(number1Input[i]))
                    throw new ArgumentException("Одно из чисел или оба числа введены некорректно.");
            }

            for (int i = 0; i < number2Input.Length; i++)
            {
                if (!numbers.Contains(number2Input[i]) && !lettersUpper.Contains(number2Input[i]) && !lettersLower.Contains(number2Input[i]))
                    throw new ArgumentException("Одно из чисел или оба числа введены некорректно.");
            }

            List<int> number1 = new();
            List<int> number2 = new();

            number1 = ParseStringToList(number1Input);
            number2 = ParseStringToList(number2Input);

            int maxLen = Math.Max(number1.Count, number2.Count);
            BuildATower(number1Input, number2Input, "*");

            List<int> result = new();
            int overage = 0;
            for (int i = number2.Count - 1; i >= 0; i--)
            {
                for (int j = number1.Count - 1; j >= 0; j--)
                {
                    int midterm = number1[j] * number2[i];
                    if (midterm >= numberSystem)
                    {
                        result.Add(midterm % numberSystem + overage);
                        overage = midterm / numberSystem;
                    }
                    else result.Add(midterm + overage);
                    overage = midterm / numberSystem;
                }

            }

            if (overage > 0)
            {
                if (overage >= 1 && overage <= 9) result.Add(overage);
                if (overage >= 10 && overage <= 35) result.Add(lettersUpper[overage - 10]);
                if (overage >= 36) result.Add(lettersLower[overage - 36]);
            }

            result.Reverse();
            string programOutput = "";
            foreach (int e in result)
            {
                if (e >= 0 && e <= 9) programOutput += e;
                if (e >= 10 && e <= 35) programOutput += lettersUpper[e - 10];
                if (e >= 36) programOutput += lettersLower[e - 36];
            }

            Console.WriteLine(programOutput);
            Console.WriteLine($"В результате получаем, что {number1Input} * {number2Input} = {programOutput} в {numberSystem}-тичной системе счисления.");
        }

        public static void EigthFunction()
        {
            string numbers = "0123456789";
            string lettersUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lettersLower = "abcdefghijklmn";

            for (int i = 0; i < 50; i++)
            {
                if (i >= 0 && i <= 9) Console.WriteLine($"{i} -- {numbers[i]}");
                else if (i >= 10 && i <= 35) Console.WriteLine($"{i} -- {lettersUpper[i - 10]}");
                else if (i >= 36 && i <= 50) Console.WriteLine($"{i} -- {lettersLower[i - 36]}");
            }

        }

    }

}