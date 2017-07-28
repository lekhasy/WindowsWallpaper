using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsWallpaper.Domain;

namespace WindowsWallpaper.Storage
{
    public class LocalStorageProvider : ILocalstorageProvider
    {
        public void Set<T>(LocalStorageKeys key, T value)
        {
            throw new NotImplementedException();
        }

        public bool TryGet<T>(LocalStorageKeys key, out T value)
        {
            throw new NotImplementedException();
        }
    }
}
