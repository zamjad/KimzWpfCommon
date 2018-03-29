using System.Windows;
using System.Windows.Input;

namespace KimzWpfCommon.Utils
{
    public class EventBehavior
    {
        private DependencyProperty _property;
        private readonly RoutedEvent _routedEvent;

        public EventBehavior(RoutedEvent routedEvent)
        {
            this._routedEvent = routedEvent;
        }

        public void CallBack(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            UIElement element = obj as UIElement;

            this._property = args.Property;

            if (element != null)
            {
                if (args.OldValue != null)
                {
                    element.AddHandler(this._routedEvent, new RoutedEventHandler(EventHandler));
                }

                if (args.NewValue != null)
                {
                    element.AddHandler(this._routedEvent, new RoutedEventHandler(EventHandler));
                }
            }
        }

        private void EventHandler(object sender, RoutedEventArgs args)
        {
            DependencyObject obj = sender as DependencyObject;

            if (obj?.GetValue(this._property) is ICommand command)
            {
                if (command.CanExecute(args))
                {
                    command.Execute(args);
                }
            }
        }
    }
}
