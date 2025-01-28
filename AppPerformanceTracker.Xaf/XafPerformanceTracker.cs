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
     public void Init()
        {
            var harmony = new Harmony("com.yourcompany.xafapp");
            try
            {
                harmony.PatchAll(typeof(XafPerformanceTracker).Assembly);
           
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }
    }
}
