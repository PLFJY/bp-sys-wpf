using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Updater
{
    public class MultiDownload
    {
        #region 初始化参数

        private int bufferSize = 512;//缓冲池大小
        private int threadNum;//线程数

        private string Url;//接受文件的URL
        //private List<string> Urls;

        private bool HasMerge;//文件合并标志
        private string DestFileName;
        private long receiveSize;//已经接收到的字节数
        private long fileSizeAll;//文件字节数
        private int RowIndex;//任务索引

        private List<ThreadInfo> threadinfos;

        private object lockPercent;//用于在加载下载进度是上锁

        private object lockFile;

        #endregion 初始化参数

        /// <summary>
        /// 下载进度
        /// </summary>
        /// <param name="rowIndex">任务索引</param>
        /// <param name="percent">进度</param>
        public delegate void DownloadingPercent(double percent);

        public event DownloadingPercent OnDownloadingPercent;

        /// <summary>
        /// 源文件大小
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <param name="size"></param>
        public delegate void UpdateSrcFileSize(int rowIndex, long size);

        public event UpdateSrcFileSize OnUpdateSrcFileSize;

        /// <summary>
        /// 响应开始时间和结束时间的事件
        /// </summary>
        /// <param name="date"></param>
        public delegate void GetRunTime(DateTime date);

        public event GetRunTime OnGetStartTime;

        public event GetRunTime OnGetFinalTime;

        /// <summary>
        /// 响应改变控件状态事件，变为可使用
        /// </summary>
        public delegate void SetControlStaus();

        public event SetControlStaus OnSetControlStaus;

        public MultiDownload()
        {
            threadinfos = new List<ThreadInfo>();
            lockPercent = new object();
            lockFile = new object();
        }

        /// <summary>
        /// Http方式多线程下载一个文件
        /// </summary>
        /// <param name="srcFileUrl">文件地址</param>
        /// <param name="destFileName">保存全名</param>
        /// <param name="maxThreadNum">线程数</param>
        /// <param name="rowIndex">任务索引</param>

        public void DownloadFile(string srcFileUrl, string destFileName, int maxThreadNum = 8, int rowIndex = 0)
        {
            if (OnGetStartTime != null)
                OnGetStartTime(DateTime.Now);
            Url = srcFileUrl;
            DestFileName = destFileName;
            RowIndex = rowIndex;
            threadNum = maxThreadNum;//多少个线程下载
            receiveSize = 0;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.Url);
            fileSizeAll = request.GetResponse().ContentLength;
            request.Abort();
            if (OnUpdateSrcFileSize != null)
                OnUpdateSrcFileSize(0, fileSizeAll);

            //初始化多线程
            List<Task> taskList = new List<Task>();
            //每个线程平均分配文件大小
            long pieceSize = (long)fileSizeAll / threadNum + (long)fileSizeAll % threadNum;
            for (int i = 0; i < threadNum; i++)
            {
                var resetEvent = new ManualResetEvent(false);
                ThreadInfo currentThread = new ThreadInfo();
                currentThread.ThreadId = i;
                currentThread.ThreadStatus = false;
                string filename = System.IO.Path.GetFileName(DestFileName);//带拓展名的文件名
                string dir = System.IO.Path.GetDirectoryName(DestFileName);     //返回文件所在目录
                currentThread.TmpFileName = string.Format($"{dir}{i}_{filename}.tmp");
                currentThread.Url = Url;
                currentThread.FileName = DestFileName;

                long startPosition = (i * pieceSize);
                currentThread.StartPosition = startPosition == 0 ? 0 : startPosition + 1;
                currentThread.FileSize = startPosition + pieceSize;

                threadinfos.Add(currentThread);

                taskList.Add(Task.Factory.StartNew(() =>
                {
                    ReceiveHttp(currentThread);
                }));
            }

            TaskFactory taskFactory = new TaskFactory();
            taskList.Add(taskFactory.ContinueWhenAll(taskList.ToArray(), tArray =>
            {
                //启动合并线程
                MergeFile();
                threadinfos.Clear();
                taskList.Clear();
            }));
        }

        /// <summary>
        /// Http方式接收一个区块
        /// </summary>
        private void ReceiveHttp(object thread)
        {
            FileStream fs = null;
            Stream ns = null;
            try
            {
                ThreadInfo currentThread = (ThreadInfo)thread;
                byte[] buffer = new byte[bufferSize];         // 接收缓冲区
                if (!File.Exists(currentThread.FileName))
                {
                    fs = new FileStream(currentThread.TmpFileName, FileMode.Create);
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(currentThread.Url);
                    request.Headers["Accept-Ranges"] = "bytes";
                    request.AddRange(currentThread.StartPosition, currentThread.FileSize);
                    ns = request.GetResponse().GetResponseStream();
                    int readSize = ns.Read(buffer, 0, bufferSize);
                    while (readSize > 0)
                    {
                        fs.Write(buffer, 0, readSize);

                        buffer = new byte[bufferSize];

                        readSize = ns.Read(buffer, 0, buffer.Length);

                        receiveSize += readSize;
                        double percent = (double)receiveSize / (double)fileSizeAll * 100;
                        //Debug.WriteLine($"下载进度:{percent}");
                        if (OnDownloadingPercent != null)
                            OnDownloadingPercent(percent);//触发下载进度事件
                    }
                }
                currentThread.ThreadStatus = true;
            }
            catch //这里不用处理异常，如果等待超时了，会自动继续等待到可以下载为止
            {
                //throw ex;
            }
            finally
            {
                fs?.Close();
                ns?.Close();
            }
        }

        /// <summary>
        /// 合并文件
        /// </summary>
        private void MergeFile()
        {
            int readSize;
            string downFileNamePath = DestFileName;
            byte[] buffer = new byte[bufferSize];
            int length = 0;
            using (FileStream fs = new FileStream(downFileNamePath, FileMode.Create))
            {
                foreach (var item in threadinfos.OrderBy(o => o.ThreadId))
                {
                    if (!File.Exists(item.TmpFileName)) continue;
                    var tempFile = item.TmpFileName;
                    Debug.WriteLine($"当前合并文件:{tempFile}");
                    using (FileStream tempStream = new FileStream(tempFile, FileMode.Open))
                    {
                        while ((length = tempStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            fs.Write(buffer, 0, length);
                        }
                        tempStream.Flush();
                    }
                    try
                    {
                        File.Delete(item.TmpFileName);
                    }
                    catch
                    {
                    }
                }
            }

            if (OnGetFinalTime != null)
                OnGetFinalTime(DateTime.Now);
            if (OnSetControlStaus != null)
                OnSetControlStaus();
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            foreach (var item in threadinfos)
            {
                File.Delete(item.TmpFileName);
            }
        }
    }

    internal class ThreadInfo
    {
        public int ThreadId { get; set; }
        public bool ThreadStatus { get; set; }
        public long StartPosition { get; set; }
        public long FileSize { get; set; }
        public string Url { get; set; }
        public string TmpFileName { get; set; }
        public string FileName { get; set; }
        public int Times { get; set; }
    }
}
