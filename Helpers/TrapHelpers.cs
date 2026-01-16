using Archipelago.Core.Traps;
namespace Helpers
{
    class Traps
    {
        public async void RunLagTrap()
        {
            using (var lagTrap = new LagTrap(TimeSpan.FromSeconds(20)))
            {
                lagTrap.Start();
                await lagTrap.WaitForCompletionAsync();
            }
        }
    }
}