using System.Collections.Generic;

namespace DemoLibrary.Utilities
{
    public interface ISqliteDataAccess
    {
        List<T> LoadData<T>(string sql);
        void SaveData<T>(T laptop, string sql);
        void UpdateData<T>(T laptop, string sql);
    }
}