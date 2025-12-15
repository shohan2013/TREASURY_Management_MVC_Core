namespace TREASURY.UI.Models.CommonModel
{
    public static class EnamProcess
    {
        public static string APILOGIN = "https://fileuploaddownloadapi.akijbashir.com/api/Login/Login";

        public static string APIDOWNLOADMULTIPLEFILE = "https://fileuploaddownloadapi.akijbashir.com/api/FileUploadDownload/DownloadMultipleFileAsBase64";
        public static string APIUPLOADMULTIPLEFILE = "https://fileuploaddownloadapi.akijbashir.com/api/FileUploadDownload/UploadMultipleFile";
    }


    /*==========================================Treasury Management=============================================== */
    public enum EnumTreasuryProcess { IC,LF,BL }
    public enum EnumTreasurySubMenu { IC00001,LF00001,BL00001 }
    public enum EnumTreasuryMessage { SAVE, EDIT, DEL, APPR, REJ }
    public enum EnumTreasuryDocStatus { INIT, PEND, ACKDLG, GEN, APPR, REJC }
    public enum EnumTreasuryNotification { SUBMIT, APPR, REJECT }
    /*==========================================Treasury Management End=============================================== */

    //======================== API Connection ===============================

    public enum enumIMPRootModule { CODE0002 }
}
