using FirstLaboratory;
using FirstLaboratory.Option1;
using System.Diagnostics;
using System.Linq;

var person = new Person(
    "Stan",
    "Kudri",
    new DateTime(1998,01,15));

ConsoleWritePerson(person);
Console.WriteLine(person);
Console.ReadLine();

void ConsoleWritePerson(Person person)
{
    Console.WriteLine(person.Name);
    Console.WriteLine(person.Surname);
    Console.WriteLine(person.DataTime);
    person.Year = 2010;
    Console.WriteLine(person.Year);
    Console.WriteLine(person.DataTime);
}

//Console.WriteLine("Введите количество столбцов и строк массива через разделительный знак:");
//string strColumnAndRow = Console.ReadLine();
//Размер массива, где первое число количество столбцов, а второе число строк
/*int[] sizeArray = ArraySize(strColumnAndRow);

if (!DataValidation(sizeArray))
{
    return;
}
int sizeOneDimensionalArray = sizeArray[0] * sizeArray[1];
foreach (int i in sizeArray)
    Console.WriteLine(i);*/


int k = 3;
int t = 4;

var newTest = new ArrayGenerator(k,t);
var one = newTest.OneDimensionalArray();
var two = newTest.TwoDimensionalArray();
var jagged = newTest.JaggedGenerate();

PrintJaggedArray(jagged.Item1, jagged.Item2);
PrintOneArray(one.Item1, one.Item2);
PrintTwoArray(two.Item1, two.Item2);

var student = new Student();
Console.WriteLine(student.ToShortString());
Exam[] exam = new Exam[]
{
    new Exam("World", 9, new DateTime(2022,01,17)),
    new Exam("Mif", 4, new DateTime(2022,01,18)),
    new Exam("Country", 5, new DateTime(2022,01,19))
};
Console.WriteLine("Количество сданных экзаменов :{0}",student.Exams.Length + exam.Length);
student.AddExam(exam);
Console.WriteLine(student.ToShortString());
Console.WriteLine(student.ToString());
Console.WriteLine(student[Education.Вachelor]);


bool DataValidation(int[] array)
{
    foreach (int i in array)
    {
        if (i == 0)
        {
            Console.WriteLine("Данные не корректны");
            return false;
        }
    }
    return true;
}

static int[] ArraySize(string str)
{
    int[] sizeArray = new int[2];
    string[] arrayElementsSplitByDelimiters = str.Split(new char[] { ',', '.', ';', ':', '!', '?', '/', '|' });
    if(arrayElementsSplitByDelimiters.Length == 2)
    {        
        for(int i=0; i < 2; i++)
        {
            if(intParse(arrayElementsSplitByDelimiters[i]))
            {
                sizeArray[i] = int.Parse(arrayElementsSplitByDelimiters[i]);
            }                
        }
        return sizeArray;
    }
    return new int[2];
}

static bool intParse(string str) => int.TryParse(str, out int value);

void PrintJaggedArray(int[][] array, Stopwatch time)
{
    foreach (var innerArray in array)
        Console.WriteLine("[{0}]", string.Join(", ", innerArray));
    Console.WriteLine("Время в тактах таймера затраченное на заполнение массива : {0}", time.ElapsedTicks);
}

void PrintOneArray(int[] array, Stopwatch time)
{
    Console.WriteLine("[{0}]", string.Join(", ", array));
    Console.WriteLine("Время в тактах таймера затраченное на заполнение массива : {0}", time.ElapsedTicks);
}

void PrintTwoArray(int[,] array, Stopwatch time)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("[");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (j == array.GetLength(1) - 1)
                Console.Write("{0}", array[i, j]);
            else
                Console.Write("{0},", array[i, j]);
        }
        Console.WriteLine("]");
    }
    Console.WriteLine("Время в тактах таймера затраченное на заполнение массива : {0}", time.ElapsedTicks);
}

/*static string[] ArrayElementsSplitByDelimiters(string str)
{
   return str.Split(new char[] { ',', '.', ';', ':', '!', '?' });

}
string[] arrayElementsNotDelimiter = strColumnAndRow.Split(new char[] { ',', '.', ';', ':', '!', '?'} );
if (arrayElementsNotDelimiter.Length == 1)
{
    int number = 0;
    foreach(string intColumnAndeRow in arrayElementsNotDelimiter)
    {
        if(int.TryParse((intColumnAndeRow), out int value))
        {
            if(number == 0)
            {
                column = int.Parse(intColumnAndeRow);
                number++;
            }
            if (number == 1)
            {
                row = int.Parse(intColumnAndeRow);
            }            
        }
    }
}
else
{
    Console.WriteLine("Введите новую строку!");
}
 */
