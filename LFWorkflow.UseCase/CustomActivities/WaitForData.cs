namespace LFWorkflow.UseCase.CustomActivities
{
    using System.Activities;

    public sealed class WaitForData<T> : NativeActivity<T>
    {
        [RequiredArgument]
        public InArgument<string> BookmarkName { get; set; }

        protected override bool CanInduceIdle => true;

        public void DataArrived(NativeActivityContext context, Bookmark bk, object data)
        {
            this.Result.Set(context, data);
        }

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(this.BookmarkName.Get(context), new BookmarkCallback(this.DataArrived));
        }
    }
}