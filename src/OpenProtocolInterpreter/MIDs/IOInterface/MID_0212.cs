﻿namespace OpenProtocolInterpreter.MIDs.IOInterface
{
    /// <summary>
    /// MID: Status externally monitored inputs acknowledge
    /// Description: 
    ///     Acknowledgement for the message status externally monitored inputs upload.
    /// Message sent by: Integrator
    /// Answer: None
    /// </summary>
    public class MID_0212 : MID, IIOInterface
    {
        public const int MID = 212;
        private const int length = 20;
        private const int revision = 1;

        public MID_0212() : base(length, MID, revision) { }

        internal MID_0212(IMID nextTemplate) : base(length, MID, revision)
        {
            this.nextTemplate = nextTemplate;
        }

        public override MID processPackage(string package)
        {
            if (base.isCorrectType(package))
                return (MID_0212)base.processPackage(package);

            return this.nextTemplate.processPackage(package);
        }

        protected override void registerDatafields() { }
    }
}
