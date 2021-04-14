using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Preactor;
using Preactor.Interop.PreactorObject;

namespace ApsLibrary
{
    /// <summary>
    /// Interface for the custom window. It must contain at least two methods called OnOpen and OnClose
    /// </summary>
    [ComVisible(true)]
    [Guid("c1f12524-941c-4ee3-a0fa-b30ee58794eX")]
    public interface INewWindow
    {
        /// <summary>
        /// Called when Preactor opens this window
        /// </summary>
        /// <param name="preactorComObject">The preactor COM object</param>
        /// <param name="parameter">A string parameter</param>
        /// <returns>If no errors occured return 0 (zero)</returns>
        int OnOpen(ref PreactorObj preactorComObject, ref string parameter);

        /// <summary>
        /// Called when Preactor closes this window
        /// </summary>
        /// <param name="preactorComObject">The preactor COM object</param>
        /// <param name="parameter">A string parameter</param>
        /// <returns>If no errors occurred return 0 (zero)</returns>
        int OnClose(ref PreactorObj preactorComObject, ref string parameter);
    }

    /// <summary>
    /// Concrete implementation of the custom window
    /// </summary>
    [ComVisible(true)]
    [Guid("bf87022b-8da9-4831-9fd8-f8c6c0437a5X")]
    [ClassInterface(ClassInterfaceType.None)]
    public partial class NewWindow : UserControl, INewWindow
    {
        #region ICustomWindow Members

        /// <summary>
        /// Constructs the custom window
        /// </summary>
        public NewWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Called when Preactor opens this window
        /// </summary>
        /// <param name="preactorComObject">The preactor COM object</param>
        /// <param name="parameter">A string parameter</param>
        /// <returns>If no errors occured return 0 (zero)</returns>
        public int OnOpen(ref PreactorObj preactorComObject, ref string parameter)
        {
            CU.Preactor = PreactorFactory.CreatePreactorObject(preactorComObject);
            CU.Core = EventScriptsFactory.CreateEventScriptCoreObject(preactorComObject, pespComObject);
            return 0;
        }

        /// <summary>
        /// Called when Preactor closes this window
        /// </summary>
        /// <param name="preactorComObject">The preactor COM object</param>
        /// <param name="parameter">A string parameter</param>
        /// <returns>If no errors occured return 0 (zero)</returns>
        public int OnClose(ref PreactorObj preactorComObject, ref string parameter)
        {
            return 0;
        }

        #endregion
    }
}
