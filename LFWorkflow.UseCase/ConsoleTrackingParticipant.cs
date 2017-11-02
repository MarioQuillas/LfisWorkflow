namespace LFWorkflow.UseCase
{
    using System;
    using System.Activities.Tracking;

    internal class ConsoleTrackingParticipant : TrackingParticipant
    {
        protected override void Track(TrackingRecord record, TimeSpan timeout)
        {
            if (record != null)
            {
                Console.WriteLine("====================================");
                Console.WriteLine(record);
            }
        }
    }
}