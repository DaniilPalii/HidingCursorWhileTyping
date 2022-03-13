using System.ComponentModel;

namespace HidingCursorWhileTyping.CursorVisibility
{
    internal class CursorVisibilityManager
    {
        public CursorVisibilityManager()
        {
            worker.DoWork += (_, __) => ReportEmptyProgressContinuosly();
            worker.ProgressChanged += (_, __) => cursorVisibilityService.UpdateCursorVisibility();
            worker.RunWorkerCompleted += (_, __) => cursorVisibilityService.ShowCursor();
        }

        public void Run()
            => worker.RunWorkerAsync();

        public void Stop()
            => worker.CancelAsync();

        private void ReportEmptyProgressContinuosly()
        {
            while (!worker.CancellationPending)
            {
                Thread.Sleep(millisecondsTimeout: 100);
                worker.ReportProgress(percentProgress: 0, userState: null);
            }
        }

        private readonly CursorVisibilityService cursorVisibilityService = new();
        private readonly BackgroundWorker worker = new()
        {
            WorkerReportsProgress = true,
            WorkerSupportsCancellation = true,
        };
    }
}
