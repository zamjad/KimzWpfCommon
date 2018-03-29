using System.Windows;
using System.Windows.Input;

namespace KimzWpfCommon.Utils
{
    public class BehaviorFactory<T>
    {
        public BehaviorFactory()
        {

        }

        public static DependencyProperty CreateBehavior(string name, RoutedEvent routedEvent)
        {
            EventBehavior eventBehavior = new EventBehavior(routedEvent);

            DependencyProperty dp = DependencyProperty.RegisterAttached(name, typeof(ICommand),
                typeof(T), new PropertyMetadata(eventBehavior.CallBack));

            return dp;
        }
    }
}
