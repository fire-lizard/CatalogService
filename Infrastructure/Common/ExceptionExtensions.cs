using System.Text;

namespace Infrastructure.Common;

public static class ExceptionExtensions
{
    public static string GetExceptionMessages(this Exception exc)
    {
        var result = new StringBuilder();
        if (exc is AggregateException aggExc)
        {
            foreach (Exception innerExc in aggExc.InnerExceptions)
            {
                result.AppendLine(GetExceptionMessages(innerExc));
            }
        }
        else
        {
            result.AppendLine($"{exc.GetType().Name}: {exc.Message}");
            if (exc.InnerException != null)
            {
                result.AppendLine(GetExceptionMessages(exc.InnerException));
            }
        }
        return result.ToString();
    }
}