using KimzWpfCommon.ViewModel;

namespace KimzWpfCommon.Interfaces
{
    interface IMediator<TMessage, in TParameter>
    {
        Mediator<TMessage> Mediator { get; set; }

        void Send(TMessage message, TParameter parameter);

        void Notify(TParameter parameter);
    }
}
