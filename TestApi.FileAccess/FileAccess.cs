using System;
using System.Data.OleDb;
using System.IO;
using System.Threading.Tasks;
using TestApi.Services.Dependency;

namespace TestApi.FileAccess
{
    [TransientLifetime]
    public class FileAccess: IFileAccess
    {

        public void CopyFile(string strFileName, string sourceFilePath, string destFilePath)
        {


            string sourceFile = Path.Combine(sourceFilePath, strFileName);
            string destFile = Path.Combine(destFilePath, strFileName);


            if (!Directory.Exists(destFilePath))
            {
                Directory.CreateDirectory(destFilePath);

            }
            if (Directory.Exists(destFilePath))
            {
                File.Copy(sourceFile, destFile, true);
            }
        }

        public void CreateFile(string strFileName, string strFiledata, string strFilePath)
        {

            if (!Directory.Exists(strFilePath))
            {
                Directory.CreateDirectory(strFilePath);
            }

            try
            {
                File.WriteAllText(strFilePath + strFileName, strFiledata);
                var file = File.Open(strFilePath + strFileName, FileMode.Open);
                file.Close();
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public void DeleteFile(string strFileName, string destFilePath)
        {
            string ThisDir = destFilePath + strFileName;
            File.Delete(ThisDir);
        }

        public async Task<OleDbConnection> ExcelConnection(string filePath)
        {
            //string SourceConstr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source='" + filePath + "';Extended Properties= 'Excel 8.0;HDR=Yes;IMEX=1'";
            string excelConnString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", filePath);
            OleDbConnection con = new OleDbConnection(excelConnString);
            return con;


        }
    }
}
