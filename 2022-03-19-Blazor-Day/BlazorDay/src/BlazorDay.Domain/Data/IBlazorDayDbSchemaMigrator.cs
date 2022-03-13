using System.Threading.Tasks;

namespace BlazorDay.Data;

public interface IBlazorDayDbSchemaMigrator
{
    Task MigrateAsync();
}
