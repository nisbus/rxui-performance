using System;
using System.Reactive.Concurrency;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;

namespace RXUIPerformance
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitializeAttribute]
        public void Init()
        {

            //RxApp.DeferredScheduler = Scheduler.TaskPool;
        }

        int TestCount = 100000;
        [TestMethod]
        public void TestSettingOldRXStyle()
        {
            var RX = new RXClass();
            for (int i = 0; i < TestCount; i++)
                RX.OldSetter = i;
        }

        [TestMethod]
        public void TestSettingNewRXStyle()
        {
            var RX = new RXClass();
            for (int i = 0; i < TestCount; i++)
                RX.RXSetter = i;
        }

        [TestMethod]
        public void TestSettingWPFAttachedChangedOnly()
        {
            var WPF = new PlainWPFWithAttachedPropertyChangeEvents();
            for (int i = 0; i < TestCount; i++)
                WPF.NotifySetter = i;
        }

        [TestMethod]
        public void TestSettingWPFBothAttached()
        {
            var WPF = new PlainWPFWithAttachedPropertyChangeEvents();
            for (int i = 0; i < TestCount; i++)
                WPF.ChangingAndChangedSetter = i;
        }

        [TestMethod]
        public void TestSettingWPFNonAttachedChangedOnly()
        {
            var WPF = new PlainWPFWithoutAttachedPropertyChangeEvents();
            for (int i = 0; i < TestCount; i++)
                WPF.NotifySetter = i;
        }

        [TestMethod]
        public void TestSettingWPFBothNonAttached()
        {
            var WPF = new PlainWPFWithoutAttachedPropertyChangeEvents();
            for (int i = 0; i < TestCount; i++)
                WPF.ChangingAndChangedSetter = i;
        }

        [TestMethod]
        public void TestSettingPlain()
        {
            var Plain = new PlainClass();
            for (int i = 0; i < TestCount; i++)
                Plain.PlainSetter = i;
        }

        [TestMethod]
        public void TestSettingPlainAuto()
        {
            var Plain = new PlainClass();
            for (int i = 0; i < TestCount; i++)
                Plain.AutoSetter = i;
        }
    }
}
