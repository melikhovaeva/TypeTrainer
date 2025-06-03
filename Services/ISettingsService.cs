using TypeMaster.Models;

namespace TypeMaster.Services
{
    public interface ISettingsService
    {
        SettingsModel Load();
        void Save(SettingsModel settings);
    }
}