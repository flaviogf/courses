using System;

namespace AluraCar.Interface
{
    public interface ICamera
    {
        void TirarFoto(Action<byte[]> callback);
    }
}
