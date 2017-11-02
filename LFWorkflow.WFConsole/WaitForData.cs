namespace LFWorkflow.WFConsole
{
    using System.Activities;

    public class WaitForData<T> : NativeActivity<T>
    {
        [RequiredArgument]
        public InArgument<string> BookmarkName { get; set; }

        protected override bool CanInduceIdle => true;

        protected override void Execute(NativeActivityContext context)
        {
            context.CreateBookmark(this.BookmarkName.Get(context), new BookmarkCallback(this.DataArrived));
        }

        private void DataArrived(NativeActivityContext context, Bookmark bookmark, object data)
        {
            this.Result.Set(context, data);
        }
    }
}