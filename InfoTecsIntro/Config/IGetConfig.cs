using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;

namespace InfoTecsIntro.Config
{
    public interface IGetConfig<out T>
    {
        public T GetConfig();
    }
}