using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApi.FileAccess
{
    public interface IFileAccess
    {
        void CopyFile(string strFileName, string sourceFilePath, string destFilePath);
        void CreateFile(string strFileName, string strFiledata, string strFilePath);
        void DeleteFile(string strFileName, string destFilePath);
        Task<OleDbConnection> ExcelConnection(string filePath);
    }
}
