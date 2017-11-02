namespace LFWorkflow.UseCase
{
    using System;
    using System.Activities;
    using System.Activities.Tracking;
    using System.Threading;
    using Infrastructure;
    using Microsoft.Activities.Extensions.Diagnostics;

    internal class Application
    {
        private readonly InstanceStoreSetupper instanceStoreSetupper;

        public Application(InstanceStoreSetupper instanceStoreSetupper)
        {
            this.instanceStoreSetupper = instanceStoreSetupper;
        }

        public void Run(AutoResetEvent syncEvent, AutoResetEvent idleEvent)
        {
            try
            {
                // var act = new ProcessActivity();
                // var result = WorkflowInvoker.Invoke(act);
                var workflow1 = new Workflow1(); // new Workflow1();

                var workflowApplication = new WorkflowApplication(workflow1);
                workflowApplication.InstanceStore = this.instanceStoreSetupper.InstanceStore;

                var trackingProfile =
                    new TrackingProfile()
                    {
                        Name = "SampleTrackingProfile",
                        ActivityDefinitionId = "*", // "ProcessOrder",
                        ImplementationVisibility = ImplementationVisibility.All,
                        Queries =
                        {
                            new WorkflowInstanceQuery()
                            {
                                States = {"*"}
                            },
                            new ActivityStateQuery()
                            {
                                Variables = {"*"},
                                Arguments = {"*"},
                                ActivityName = "*",
                                States = {"*"}
                            },
                            new ActivityScheduledQuery()
                            {
                                ActivityName = "*",
                                ChildActivityName = "*"
                            },
                            new FaultPropagationQuery(),
                            new CancelRequestedQuery(),
                            new CustomTrackingQuery(),
                            new BookmarkResumptionQuery()
                            {
                                Name = "*"
                            },
                        }
                    };

                var trackingParticipant =
                    new TraceTrackingParticipant()
                    {
                        TrackingProfile = trackingProfile
                    };

                workflowApplication.Extensions.Add(trackingParticipant);

                // workflowApplication.RunEpisode();
                // configure here the workflowapplication
                workflowApplication.Run();

                workflowApplication.Completed = wac =>
                {
                    syncEvent.Set();
                    // var stdOutput = wac.Outputs["MyStandardOutput"];

                    // Console.WriteLine(stdOutput);
                };

                workflowApplication.Aborted = abortedEventArgs =>
                {
                    Console.WriteLine(abortedEventArgs.Reason);
                    syncEvent.Set();
                };

                //wfApp.PersistableIdle wfApp.Unloaded

                workflowApplication.OnUnhandledException = unhandledExceptionEventArgs =>
                {
                    Console.WriteLine(unhandledExceptionEventArgs.UnhandledException.ToString());
                    return UnhandledExceptionAction.Terminate;
                };

                workflowApplication.Idle = (WorkflowApplicationIdleEventArgs e) =>
                {
                    idleEvent.Set();
                };

                //Thread.Sleep(1000); // give time for events to record to the screen
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}