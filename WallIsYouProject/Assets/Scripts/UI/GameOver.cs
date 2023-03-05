using Player;

namespace UI
{
   public class GameOver : BasePanel, IInit<Reborn>
   {
      private event Reborn _reborn;

      protected override void OnContinue()
      {
         _reborn?.Invoke();
      }

      public void Initialize(Reborn @delegate)
      {
         _reborn += @delegate;
      }
   }
}