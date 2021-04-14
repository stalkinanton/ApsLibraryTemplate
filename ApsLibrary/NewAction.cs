using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Preactor;
using Preactor.Interop.PreactorObject;
using static ApsLibrary.LogFile;

namespace ApsLibrary
{
    // todo: Заменить все GUID
    [Guid("d13b2ba8-3112-42a0-8f00-c08fd88222bX")]
    [ComVisible(true)]
    public interface INewAction
    {
        int Run(ref PreactorObj preactorComObject, ref object pespComObject);
    }

    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.None)]
    [Guid("53e7d086-e01b-4895-8c8a-91182160472X")]
    public class NewAction : INewAction
    {
        public int Run(ref PreactorObj preactorComObject, ref object pespComObject)
        {
            CU.Preactor = PreactorFactory.CreatePreactorObject(preactorComObject);
            CU.Core = EventScriptsFactory.CreateEventScriptCoreObject(preactorComObject, pespComObject);
            string logFileName = System.IO.Path.Combine(CU.Preactor.ParseShellString("{PATH}"), "Action.log");
            LogFile.Init(logFileName);
            try
            {

                MessageBox.Show("Hello!");

            }
            catch (AbortException)
            {
                Log("Выполнение прервано");
                MessageBox.Show("Выполнение прервано", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                LogFile.Close();
            }
            return 0;
        }
    }
}
