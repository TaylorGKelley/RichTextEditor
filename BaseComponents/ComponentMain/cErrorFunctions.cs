using Microsoft.AspNetCore.Components;

namespace RichTextEditor.BaseComponents.ComponentMain
{
    public class cErrorFunctions : ComponentBase
    {
        #region Class Declarations
        //Protected access modifier lets inherited classes access the below variables
        internal structAssemblyInformation msruAssemblyInformation = new structAssemblyInformation("", "", "", "", "");
        internal bool mblnShowMethodName = true;
        internal string mstrTracePrefix = " - ";
        internal string mstrLastError = "";
        internal enumTraceType menmTraceType = enumTraceType.typNone;
        #endregion

        #region Enumerations
        public enum enumTraceType
        {
            typNone = 0,
            typTextFile = 1,
            typEventLog = 2
        }
        #endregion

        #region Structures
        public struct structAssemblyInformation
        {
            public structAssemblyInformation(string pstrRootPath, string pstrName, string pstrTitle, string pstrDescription, string pstrVersion)
            {
                strRootPath = pstrRootPath;
                strName = pstrName;
                strTitle = pstrTitle;
                strDescription = pstrDescription;
                strVersion = pstrVersion;
            }
            public string strRootPath;
            public string strName;
            public string strTitle;
            public string strDescription;
            public string strVersion;
        }
        #endregion

        #region Properties
        public structAssemblyInformation prpAssemblyInformation
        {
            get
            {
                return msruAssemblyInformation;
            }
        }

        public string prpLastError
        {
            get
            {
                return mstrLastError;
            }
            set
            {
                mstrLastError = value;
            }
        }

        public bool prpShowMethodName
        {
            get
            {
                return mblnShowMethodName;
            }
            set
            {
                mblnShowMethodName = value;
            }
        }
        #endregion

        #region subSetLastError
        public void subSetLastError(System.String pstrMethodName, System.String pstrErrorMessage)
        {
            System.Diagnostics.Trace.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()?.Name + " Public Function.");
            mstrLastError = (mblnShowMethodName ? pstrMethodName + " " : "") + pstrErrorMessage;
            System.Diagnostics.Trace.WriteLine("ERROR: " + mstrLastError);
            System.Diagnostics.Trace.WriteLine(System.Reflection.MethodBase.GetCurrentMethod()?.Name + " END");

            // This logs the error to event viewer and silently ignores it
        }
        #endregion
    }
}
