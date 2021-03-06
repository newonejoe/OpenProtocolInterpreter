﻿namespace OpenProtocolInterpreter.MIDs.PLCUserData
{
    /// <summary>
    /// MID: User data download
    /// Description: 
    ///     Used by the integrator to send user data input to the PLC.
    /// Message sent by: Controller
    /// Answer: MID 0243 User data acknowledge
    /// </summary>
    public class MID_0242 : MID, IPLCUserData
    {
        private const int length = 220;
        public const int MID = 242;
        private const int revision = 1;

        public string UserData { get; set; }

        public MID_0242() : base(length, MID, revision) { }

        internal MID_0242(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override string buildPackage()
        {
            this.HeaderData.Length = 20 + this.UserData.Length;

            string package = this.buildHeader();
            package += this.UserData;

            return package;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
            {
                this.UserData = package.Substring(20);
                return this;
            }

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields()
        {
            this.RegisteredDataFields.Add(new DataField((int)DataFields.USER_DATA, 20, 220));
        }

        internal enum DataFields
        {
            USER_DATA
        }
    }
}
