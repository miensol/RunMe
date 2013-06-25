// Guids.cs
// MUST match guids.h
using System;

namespace miensol.RunMe
{
    static class Guids
    {
        public const string guidRunMePkgString = "32fa4324-909a-48e0-b542-4355224f5d38";
        public const string guidRunMeCmdSetString = "39779841-efdb-4f39-bf3e-9063745e8ca2";

        public static readonly Guid guidRunMeCmdSet = new Guid(guidRunMeCmdSetString);
        public const string OptionsPageGuid = "BCEB372B-76B0-425D-9DE5-7DA3E20300C1";
    };

    static class PkgCmdIDs
    {
        public const int idRunMeCmd = 0x100;
    }
}