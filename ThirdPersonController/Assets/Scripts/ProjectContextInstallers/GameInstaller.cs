using Signals;
using Zenject;

namespace ProjectContextInstallers
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.DeclareSignal<PlayerHpChangeSignal>();
        }
    }
}
