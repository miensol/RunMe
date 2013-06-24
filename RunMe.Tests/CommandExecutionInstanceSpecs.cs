using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using miensol.RunMe;
using FluentAssertions;
using System.Linq;

namespace RunMe.Tests
{
    public class ExecutingCommandThatWritesToStandardOutput
    {
        private CommandExecutionInstance _instance;
        private IList<string> _output;

        [SetUp]
        public void SetUp()
        {
            _output  = new List<string>();
            _instance = new CommandExecutionInstance(FakeCommands.IpConfig(), Guid.NewGuid())
                {
                    TextOutputer = (text) => _output.Add(text)
                };
        }

        [Test]
        public void DoesNotOutputAntyhingUntilStarted()
        {
            _output.Should().BeEmpty();
        }

        [Test]
        public void OutputsStandardOutputProperly()
        {
            _instance.Start();

            _instance.WaitUntilDone();

            _output.Where(text => text.Contains("Windows IP Configuration")).Should().NotBeEmpty();
        }

        [Test]
        public void OutputsProcessExitCodeAtTheEnd()
        {
            _instance.Start();

            _instance.WaitUntilDone();
            _output.Last().Should().Contain("Process exited with code: 0");
        }

        [Test]
        public void OutputsFullCommandLineAtStart()
        {
            _instance.Start();
            _output.First().Should().Contain("ipconfig.exe");
        }
         
    }

    public class FakeCommands
    {
        public static ICommandToRun IpConfig()
        {
            return new CmdCommand("c:/Windows/system32/ipconfig.exe");
        }

    }

    public class CmdCommand : ICommandToRun
    {
        private readonly string _command;

        public CmdCommand(string command)
        {
            _command = command;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public ProcessStartInfo CreateProcessStartInfo()
        {
            return ProcessFactory.Create(_command, "");
        }
    }
}