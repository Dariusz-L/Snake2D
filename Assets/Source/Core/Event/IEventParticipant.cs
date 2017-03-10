namespace Core.Event {

    public interface IEventParticipant {

        /// <summary>
        /// In this method add your listening methods to eventController.
        /// </summary>
        void Subscribe(IEventController eventController);

    }
}
