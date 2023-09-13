using DotNetNuke.Collections;
using System.Text.RegularExpressions;

namespace Connect.ApiBrowser.Core.Common
{
  public static class Extensions
  {
    public static SerializedPagedList<T> Serialize<T>(this IPagedList<T> list)
    {
      var res = new SerializedPagedList<T>();
      res.IsFirstPage = list.IsFirstPage;
      res.IsLastPage = list.IsLastPage;
      res.PageCount = list.PageCount;
      res.TotalCount = list.TotalCount;
      res.data = list;
      return res;
    }

    public static string SanetizeFilePath(this string input)
    {
      var m = Regex.Match(input, @"^\w:\\");
      if (m.Success)
      {
        var fragments = input.Split('\\');
        return fragments[fragments.Length - 1];
      }
      return input;
    }
  }
}
