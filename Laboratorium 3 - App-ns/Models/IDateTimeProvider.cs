using Laboratorium_3___App_ns.Models;

namespace Laboratorium_3___App_ns.Models
{
    public interface IDateTimeProvider
    {
        DateTime GetCurrentDateTime();
    }
}

public class CurrentDateTimeProvider : IDateTimeProvider
{
    public DateTime GetCurrentDateTime()
    {
        return DateTime.Now;
    }
}
