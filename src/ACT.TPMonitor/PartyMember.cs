namespace ACT.TPMonitor
{
    public class PartyMember
    {
        public JOB Job { get; set; }
        public string Name { get; set; }
        public int TP { get; set; }

        public PartyMember()
        {
            this.Job = JOB.Unknown;
            this.Name = "";
            this.TP = 0;
        }
    }
}
