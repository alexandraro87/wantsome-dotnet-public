namespace DependencyInversionWorkerAfter
{
    public class Manager
    {
        private readonly Worker worker;

        public Manager(Worker worker)
        {
            this.worker = worker;
        }

        public void Manage()
        {
            this.worker.Work();
        }
    }
}
