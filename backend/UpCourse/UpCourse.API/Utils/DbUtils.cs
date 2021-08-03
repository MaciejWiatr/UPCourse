using UpCourse.API.Config;

namespace UpCourse.API.Utils
{
    public static class DbUtils
    {
        public static string GenerateConnectionString(DbConfig config)
        {
            return $"server={config.Host};user={config.Login};password={config.Password};database={config.DatabaseName}";
        }
    }
}