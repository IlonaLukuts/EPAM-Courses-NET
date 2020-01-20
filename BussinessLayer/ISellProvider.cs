namespace BussinessLayer
{
    using System;

    public interface ISellProvider : IDisposable
    {
        event FileProcessingStateHandler StartedFileProcessingEvent;

        event FileProcessingStateHandler FinishedFileProcessingEvent;

        void StartFilesProcessing();

        void StopFilesProcessing();
    }
}
