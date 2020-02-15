using System.Runtime.CompilerServices;

namespace SkPatelNet.Core.Infrastructure
{
    /// <summary>
    /// Singleton class
    /// </summary>
    public class EngineContext
    {
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Create()
        {
            return Singleton<IEngine>.Instance ?? (Singleton<IEngine>.Instance = new SkPatelEngine());
        }

        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }

        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                    Create();
                return Singleton<IEngine>.Instance;
            }
        }
    }
}
