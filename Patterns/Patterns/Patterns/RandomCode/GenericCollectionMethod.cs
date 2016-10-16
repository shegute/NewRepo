using System;
using System.Collections.Generic;

namespace Patterns.RandomCode
{
    public class GenericCollectionMethod
    {
        public static void Run()
        {
            GenericCollectionMethod g = new GenericCollectionMethod();
            g.GenericMethod1();
            g.GenericMethod2();
        }
        public void GenericMethod<T>(IEnumerable<T> input)
        {
            foreach (T item in input)
            {
                Console.WriteLine("Item: " + item);
            }
        }

        //internal static void SyncGenericChangesToIcmV3<T>(
        //   IEnumerable<T> entitySet,
        //    string logMessage,
        //    Orchestrator orchestrator,
        //    bool syncEnabled)
        //{
        //    if (syncEnabled && entitySet.Any())
        //    {
        //        // Queue the task and data.
        //        ThreadPool.QueueUserWorkItem(OnChangeSyncUtility.InvokeOnChangeSync, orchestrator);
        //    }
        //    else
        //    {
        //        OnChangeSyncUtility.Logger.LogInfo((TofuTagId)0x306e6738 /* tag_0ng8 */, logMessage);
        //    }
        //}

        //internal static void SyncContactChangesToIcmV3(
        //   IEnumerable<EntityIdOpType> entitySet)
        //{
        //    var orchestrator = OnChangeSyncUtility.SyncFactory.GetContactsSyncOrchestrator(entitySet);
        //    string logMessage ="Onchange sync is turned off for contacts";
        //    bool syncEnabled = ProcessorConfig.Settings.EnableContactsSyncToIcmV3;
        //    this.SyncGenericChangesToIcmV3(
        //        entitySet,
        //        logMessage,
        //        orchestrator,
        //        syncEnabled);

        //}

        public void GenericMethod1()
        {
            int[] ints = new int[] { 1, 5, 8, 34 };
            this.GenericMethod(ints);
        }

        public void GenericMethod2()
        {
            string[] strings = new string[] { "One", "Five", "Eight", "ThirtyFour" };
            this.GenericMethod(strings);
        }
    }
}
