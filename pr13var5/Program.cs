/*
Записать 1000 случайных чисел в диапазоне [-100;100] в файл a.txt.
В файл otr.txt вывести отрицательные значения
в файл plus.txt положительные значения
в файл even.txt все нечетные числа.
*/

using System.IO;

string a = "a.txt";
string otr = "otr.txt";
string plus = "plus.txt";
string even = "even.txt";

Random random = new Random();

/*
  StreamWriter открывает файлы для записи. 
  Если файл уже существует, его содержимое будет перезаписано. 
  Если файла нет, он будет создан.

  Когда блок using завершает выполнение (по достижению конца блока или при возникновении исключения)
  StreamReader и StreamWriter вызывают метод Dispose(), который автоматически закрывает файлы.
*/
using (StreamWriter writer1 = new StreamWriter(a))
{
    //генерация случайных чисел и запись в файлы
    for (int i = 0; i < 100; i++)
    {
        int value1 = random.Next(-100,101);
        writer1.WriteLine(value1);
    }
}

using (StreamReader reader1 = new StreamReader(a))
using (StreamWriter writer2 = new StreamWriter(otr))
using (StreamWriter writer3 = new StreamWriter(plus))
using (StreamWriter writer4 = new StreamWriter(even))
{
    string line1;


    /*
     ReadLine() считывает строку из каждого файла поочередно
     если файл закончился (нет больше строк для чтения), то ReadLine() возвращает null.
     != null проверяет, что возвращённая строка не является null (файл ещё не закончился).
    */
    while ((line1 = reader1.ReadLine()) != null)
    {
        int number = int.Parse(line1);

        //проверяем на отрицательное
        if (number < 0)
        {
            writer2.WriteLine(number);
        }

        //проверяем на положительное
        if (number > 0)
        {
            writer3.WriteLine(number);
        }

        //проверяем на четность
        if (number % 2 == 0)
        {
            writer4.WriteLine(number);
        }
    }

 Console.WriteLine("Файлы a.txt, otr.txt, plus.txt и even.txt успешно созданы.");
}

//вывод результата для проверки
Console.WriteLine("\nСодержимое a.txt:");
Console.WriteLine(File.ReadAllText(a));

Console.WriteLine("\nСодержимое otr.txt:");
Console.WriteLine(File.ReadAllText(otr));

Console.WriteLine("\nСодержимое plus.txt:");
Console.WriteLine(File.ReadAllText(plus));

Console.WriteLine("\nСодержимое even.txt:");
Console.WriteLine(File.ReadAllText(even));



