namespace LFWorkflow.WFConsole
{
    using System.Activities;
    using System.Collections.ObjectModel;

    public sealed class LFNativeActivity : NativeActivity
    {
        public Collection<Activity> Children { get; set; } // = new Collection<Activity>();

        public Collection<Variable> Variables { get; set; } // = new Collection<Variable>();

        // implementation variable
        public Variable<int> CurrentIndex { get; set; } // = new Variable<int>();

        public CompletionCallback Completed { get; set; }

        public LFNativeActivity()
        {
            this.Children = new Collection<Activity>();
            this.Variables = new Collection<Variable>();
            this.CurrentIndex = new Variable<int>();

            this.Completed = new CompletionCallback(this.Activity_Completed);
        }

        public Collection<Activity> Branches => this.Children;

        public void Activity_Completed(NativeActivityContext context, ActivityInstance activity)
        {
            var index = this.CurrentIndex.Get(context);
            this.CurrentIndex.Set(context, ++index);

            if (index < this.Children.Count)
            {
                context.ScheduleActivity(this.Children[index], this.Completed);
            }
        }

        protected override void Execute(NativeActivityContext context)
        {
            //foreach (var child in this.Children)
            //{
            //    context.ScheduleActivity(child, this.Completed);
            //}

            this.CurrentIndex.Set(context, 0);
            if (this.Children.Count > 0)
            {
                context.ScheduleActivity(this.Children[0], this.Completed);
            }
        }

        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.SetVariablesCollection(this.Variables);
            metadata.SetChildrenCollection(this.Children);

            metadata.AddImplementationVariable(this.CurrentIndex);
            //base.CacheMetadata(metadata);
        }
    }
}