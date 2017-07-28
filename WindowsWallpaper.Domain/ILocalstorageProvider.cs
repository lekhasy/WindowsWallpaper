using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsWallpaper.Domain
{
    public interface ILocalstorageProvider
    {
        bool TryGet<T>(LocalStorageKeys key, out T value);
        void Set<T>(LocalStorageKeys key, T value);
    }    
}
