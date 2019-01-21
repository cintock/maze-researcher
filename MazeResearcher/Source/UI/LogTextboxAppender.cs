using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net.Appender;
using log4net.Core;
using System.Threading;

namespace Maze.UI
{
    public class LogTextboxAppender : AppenderSkeleton
    {
        private static volatile TextBox loggingTextbox;

        public static TextBox LoggingTextbox
        { 
            set
            {
                loggingTextbox = value;
            }
        }

        private static SpinLock lockBuffer = new SpinLock();

        private static List<String> buffer = new List<string>();

        private System.Threading.Timer flushTimer = new System.Threading.Timer(Flush);

        protected override void Append(LoggingEvent loggingEvent)
        {
            TextBox textbox = loggingTextbox;
            if (textbox != null)
            {
                String mes = RenderLoggingEvent(loggingEvent) + Environment.NewLine;
                bool lockIsOk = false;
                try
                {
                    lockBuffer.Enter(ref lockIsOk);
                    buffer.Add(mes);
                }
                finally
                {
                    if (lockIsOk)
                    {
                        lockBuffer.Exit();
                    }
                }
                flushTimer.Change(100, System.Threading.Timeout.Infinite);
            }
        }

        private static void Flush(object state)
        {
            TextBox textbox = loggingTextbox;
            if (textbox != null)
            {
                bool lockIsOk = false;
                String cachedMessages;
                try
                {
                    lockBuffer.Enter(ref lockIsOk);
                    cachedMessages = String.Join("", buffer.ToArray());
                    buffer.Clear();
                }
                finally
                {
                    if (lockIsOk)
                    {
                        lockBuffer.Exit();
                    }
                }
                textbox.Invoke((Action)(() =>
                {
                    textbox.AppendText(cachedMessages);
                }));
            }
        }
    }
}
