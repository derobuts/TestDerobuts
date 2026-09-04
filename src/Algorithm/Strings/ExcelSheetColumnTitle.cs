using System.Text;

namespace DSAandAlgo.Strings;


public class ExcelSheetColumnTitle
{
  /*
 * Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet.

   For example:

   A -> 1
   B -> 2
   C -> 3
   ...
   Z -> 26
   AA -> 27
   AB -> 28
   ...

 */
  public string ConvertToTitle(int columnNumber) {
      StringBuilder b = new StringBuilder();
      while (columnNumber > 0)
      {
          columnNumber--;
          b.Insert(0, (char)('A' + columnNumber % 26));
          columnNumber /= 26;
      }
      return b.ToString();
  }
}