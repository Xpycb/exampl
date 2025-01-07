using System;
using System.IO;
class Program
{
    
    static void Main(string[] args)
    {
        #region Суходрочка с переходом к нужному каталогу

        string currentDirectory = Directory.GetCurrentDirectory(); // исходный каталог программы 
        string parentDirectory = Directory.GetParent(currentDirectory).FullName; // Первый уровень вверх
        string grandparentDirectory = Directory.GetParent(parentDirectory).FullName; // Второй уровень вверх
        string grandGrandparentDirectory = Directory.GetParent(parentDirectory).FullName; // Третий уровень вверх
        string pathSQLLiteOne = Path.Combine(grandGrandparentDirectory, @"\Data\StudentCRUD-app.db");
        Console.ReadKey();
        #endregion

        #region Поиск папки с именем Data
        // Получаем путь к каталогу, где находится исполняемый файл
        string exePath = AppDomain.CurrentDomain.BaseDirectory;
        string folderNameToFind = "Data"; // Имя папки для поиска
        // Запускаем поиск
        string pathSQLLiteTwo = FindFolderUpwards(exePath, folderNameToFind);
        #endregion
    }
    #region Функция поиска указанной папки
    static string FindFolderUpwards(string currentDirectory, string folderName)
    {
        while (!string.IsNullOrEmpty(currentDirectory))
        {
            // Проверяем наличие папки в текущем каталоге
            string targetFolderPath = Path.Combine(currentDirectory, folderName);
            if (Directory.Exists(targetFolderPath))
            {
                Console.WriteLine($"Папка найдена: {targetFolderPath}");
                string pathSQLLite = targetFolderPath + @"\StudentCRUD-app.db";
                return pathSQLLite; // Завершаем поиск, если папка найдена
            }

            // Переходим на уровень выше
            DirectoryInfo parentDir = Directory.GetParent(currentDirectory);
            currentDirectory = parentDir?.FullName; // Обновляем текущий каталог
        }

        return null;
    }
    #endregion


}