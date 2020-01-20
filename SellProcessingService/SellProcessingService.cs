namespace SellProcessingService
{
    using System;

    using System.ServiceProcess;
    
    using BussinessLayer;

    public partial class SellProcessingService : ServiceBase
    {
        ISellProvider sellProvider;

        public SellProcessingService()
        {
            InitializeComponent();
            sellProvider = new SellProvider(false);
            this.CanStop = true;
            this.CanPauseAndContinue = true;
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                sellProvider.StartFilesProcessing();
            }
            catch(Exception ex)
            {

            }
        }

        protected override void OnStop()
        {
            try
            {
                sellProvider.StopFilesProcessing();
                sellProvider.Dispose();
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnPause()
        {
            try
            {
                sellProvider.StopFilesProcessing();
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnContinue()
        {
            try
            {
                sellProvider.StartFilesProcessing();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
