namespace WebApi.Constants
{
    public class SqlConstants
    {
        public const string GET_SENT_FOLDER = @"
            SELECT
                m.Id, 
                su.StaffName as SendingStaffName, 
                su.StaffEmail as SendingStaffEmail, 
                ru.StaffName as ReceivingStaffName, 
                ru.StaffEmail as ReceivingStaffEmail, 
                m.Subject, 
                m.Message, 
                m.SentTime, 
                m.SentSuccessToSMTPServer, 
                m.[Read],
                m.Starred, 
                m.Important, 
                m.HasAttachments, 
                m.[Label], 
                m.Folder
            FROM Mail m
            LEFT JOIN Users su ON su.UserID = m.SendingUserID
            LEFT JOIN Users ru ON ru.UserID = m.ReceivingUserID
            WHERE 
                m.SendingUserID = @UserID AND 
                m.Folder = @Folder
            ORDER BY m.SentTime DESC;";
    }
}