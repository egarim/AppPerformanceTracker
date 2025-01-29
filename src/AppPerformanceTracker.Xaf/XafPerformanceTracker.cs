using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPerformanceTracker.Xaf
{
    public class XafPerformanceTracker
    {
     public void Init(string AppId)
        {
            var harmony = new Harmony(AppId);
            try
            {
                harmony.PatchAll(typeof(XafPerformanceTracker).Assembly);
           
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
              
            }
        }
    }
}
