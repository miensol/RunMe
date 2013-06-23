using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using miensol.RunMe;
using FluentAssertions;

namespace RunMe.Tests
{
    public class FindingRakeCommands
    {
        private CachedCommands _cached;
        private IEnumerable<ICommandToRun> _commands;

        [SetUp]
        public void SetUp()
        {
            _cached = new CachedCommands(Path.Combine(Directory.GetCurrentDirectory(), "../../../TestSolution/Empty"));
            _commands = _cached.FindCommands();
        }
        
        [Test]
        public void find_undocumented_commands()
        {
            _commands.Should().Contain(c => c.Name == "one");
        }

        [Test]
        public void find_documented_tasks()
        {
            _commands.Should().Contain(c => c.Name == "two");
            _commands.Should().Contain(c => c.Description == "two description");
        }

        [Test]
        public void find_nested_task()
        {
            _commands.Should().Contain(c => c.Name == "parent:nested_one");
        }

        [Test]
        public void find_documented_nested_tasks()
        {
            _commands.Should().Contain(c => c.Name == "parent:nested_two");
            _commands.Should().Contain(c => c.Description == "nested_two description");
        }

        [Test]
        public void find_only_tasks_with_name()
        {
            _commands.Should().NotContain(c => string.IsNullOrWhiteSpace(c.Name));
        }
    }
}
